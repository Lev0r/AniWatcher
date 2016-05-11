using AniWatcher.MvvmIntegration;
using System;

using Xamarin.Forms;

namespace AniWatcher
{
    public class App : Application
    {        
        public App()
        {            
            var bootstrapper = new Bootstrapper(this);
            bootstrapper.Run();
        }

        protected override void OnStart(){ }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}

