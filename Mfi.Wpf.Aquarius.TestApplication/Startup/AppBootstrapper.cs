using System;
using Autofac;
using DevExpress.Xpf.Core;
using Mfi.Diagnostics.Logging;
using Mfi.Wpf.Aquarius.Modules.Interaction;
using Mfi.Wpf.Aquarius.Modules.MainWindow;
using Mfi.Wpf.Aquarius.Modules.MainWindow.ViewModels;
using Mfi.Wpf.Aquarius.Modules.Resources;
using Mfi.Wpf.Aquarius.Modules.Shell;
using Mfi.Wpf.Aquarius.Modules.Shell.ViewModels;
using Mfi.Wpf.Aquarius.StyletMods.Bootstrappers;
using Microsoft.VisualBasic;

namespace Mfi.Wpf.Aquarius.TestApplication.Startup
{
    public class AppBootstrapper : AutofacBootstrapper<MainWindowViewModel>
    {
        protected override void DefaultConfigureIoC(ContainerBuilder builder)
        {
            base.DefaultConfigureIoC(builder);

            builder.RegisterModule<LoggingModule>();
            builder.RegisterModule<ResourcesModule>();
            builder.RegisterModule<InteractionModule>();
            builder.RegisterModule<MainWindowModule>();
            builder.RegisterModule<ResourcesModule>();
            builder.RegisterModule<ShellModule>();
        }

        protected override void Configure()
        {
            base.Configure();

            (GetInstance(typeof(IGlobalResourceManager)) as IGlobalResourceManager)?.Init();
        }

        protected override void OnStart()
        {
            base.OnStart();
            ApplicationThemeHelper.ApplicationThemeName = Theme.VS2019DarkName;
        }
    }
}