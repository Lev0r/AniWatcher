using System;
using System.ComponentModel;

namespace AniWatcher.MvvmIntegration
{
    public interface IViewModel: INotifyPropertyChanged
    {
        // Allows each view model to have a Title
        string Title { get; set; }

        // Allows us to provide an action that will set the state of the view model when called.
        // This allows us to reuse view models and set their state when navigating
        void SetState<T>(Action<T> action) where T : class, IViewModel;
    }
}
