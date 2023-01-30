using Infragistics.Controls.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KB10451_XamGantt_GetSiblingTasks_WpfApp1;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
        textBlock1.Text = "";

        // 選択されているセルもしくは行のタスクをProjectTaskとして取り出す。
        ProjectTask? selectedTask = (
            xamGantt1.SelectedCells.Count > 0 ?
                xamGantt1.SelectedCells[0].Row.Task :
                xamGantt1.SelectedRows.Count > 0 ?
                    xamGantt1.SelectedRows[0].Task :
                    null
            ) as ProjectTask;
        // ProjectTaskとして取り出せなかったら何もしない。
        if (selectedTask == null) return;

        // 親のTasks（兄弟タスク）をProjectTaskのListとして取り出す。
        List<ProjectTask> siblingTasks = selectedTask.Parent.Tasks.ToList();
        // 各兄弟ProjectTaskに関して
        foreach(var siblingTask in siblingTasks)
        {
            // 情報を出力する。
            textBlock1.Text += $"Task Name: {siblingTask.TaskName}" + Environment.NewLine;
        }
    }
}
