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
        }
    }
}
