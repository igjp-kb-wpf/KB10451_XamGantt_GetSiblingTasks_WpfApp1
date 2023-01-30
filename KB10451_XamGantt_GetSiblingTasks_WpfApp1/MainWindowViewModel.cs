using Infragistics.Controls.Schedules;
using KB10451_XamGantt_GetSiblingTasks_WpfApp1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB10451_XamGantt_GetSiblingTasks_WpfApp1;
internal class MainWindowViewModel : ObservableObject
{
    private Project _project;

    public Project Project
    {
        get { return _project; }
        set { _project = value; OnPropertyChanged(); }
    }

    public MainWindowViewModel()
    {
        _project = GenerateProjectData();
    }

    private Project GenerateProjectData()
    {
        DateTime startTime = DateTime.Today.ToUniversalTime();

        // プロジェクト インスタンス作成する
        Project project = new Project();

        for(int i = 0; i < 4; i++)
        {
            var rootTask = new ProjectTask()
            {
                TaskName = $"Task {i.ToString()}",
                IsManual = false,
            };
            project.RootTask.Tasks.Add(rootTask);
            for(int j = 0; j < 3; j++)
            {
                var task = new ProjectTask()
                {
                    TaskName = $"Task {i.ToString()}-{j.ToString()}",
                    IsManual = false,
                    Start = startTime,
                    Duration = TimeSpan.FromDays(1),
                };
                rootTask.Tasks.Add(task);
            }
        }

        return project;
    }
}
