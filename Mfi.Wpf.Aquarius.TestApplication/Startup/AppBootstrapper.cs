using Autofac;
using DevExpress.Xpf.Core;
using Mfi.Diagnostics.Logging;
using Mfi.Wpf.Aquarius.Modules.MainWindow.ViewModels;
using Mfi.Wpf.Aquarius.Modules.Shell.ViewModels;
using Mfi.Wpf.Aquarius.StyletMods.Bootstrappers;

namespace Mfi.Wpf.Aquarius.TestApplication.Startup
{
    public class AppBootstrapper : AutofacBootstrapper<MainWindowViewModel>
    {
        protected override void DefaultConfigureIoC(ContainerBuilder builder)
        {
            base.DefaultConfigureIoC(builder);

            builder.RegisterModule<LoggingModule>();
        }

        protected override void OnStart()
        {
            base.OnStart();
            ApplicationThemeHelper.ApplicationThemeName = Theme.VS2019DarkName;
        }
    }
}