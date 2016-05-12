using AniWatcher.Helpers;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace AniWatcher.MvvmIntegration
{
    public abstract class ViewModelBase : IViewModel
    {
        public string Title { get; set;  }

        public event PropertyChangedEventHandler PropertyChanged;

        void IViewModel.SetState<T>(Action<T> action)
        {
            action(this as T);
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertyHelper.GetPropertyNameFromExpression(propertyExpression);
            OnPropertyChanged(propertyName);
        }
    }
}
