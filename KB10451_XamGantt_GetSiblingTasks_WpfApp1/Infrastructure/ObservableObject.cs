using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KB10451_XamGantt_GetSiblingTasks_WpfApp1.Infrastructure;
public abstract class ObservableObject : INotifyPropertyChanged
{
    protected ObservableObject()
    {

    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] String? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
