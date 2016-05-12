using AniWatcher.ViewModels;
using AniWatcher.Views;
using Autofac;
using Xamarin.Forms;

namespace AniWatcher.MvvmIntegration
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // service registration
            builder.RegisterType<ViewFactory>()
                .As<IViewFactory>()
                .SingleInstance();

            builder.RegisterType<Navigator>()
                .As<INavigator>()
                .SingleInstance();

            // navigation registration
            builder.Register<INavigation>(context =>
                Application.Current.MainPage.Navigation
            ).SingleInstance();

            RegisterViewModels(builder);
        }

        private void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<EpisodesViewModel>()
                .SingleInstance();

            builder.RegisterType<EpisodesView>()
                .SingleInstance();
        }
    }
}
