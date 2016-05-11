using AniWatcher.ViewModels;
using AniWatcher.Views;
using Autofac;
using Xamarin.Forms;

namespace AniWatcher.MvvmIntegration
{
    public class Bootstrapper: AutofacBootstrapper
    {
        private readonly App _application;

        public Bootstrapper(App application)
        {
            _application = application;
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<AutofacModule>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<EpisodesViewModel, EpisodesView>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            // set main page
            var viewFactory = container.Resolve<IViewFactory>();
            var mainPage = viewFactory.Resolve<EpisodesViewModel>();
            var navigationPage = new NavigationPage(mainPage);

            _application.MainPage = navigationPage;
        }
    }
}
