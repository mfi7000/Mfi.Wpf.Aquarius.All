using DevExpress.Xpf.Core;
using Mfi.Wpf.Aquarius.StyletMods.Bootstrappers;
using Mfi.Wpf.Aquarius.TestApplication.ViewModels;

namespace Mfi.Wpf.Aquarius.TestApplication.Startup
{
    public class AppBootstrapper : AutofacBootstrapper<MainWindowViewModel>
    {
        protected override void OnStart()
        {
            base.OnStart();
            ApplicationThemeHelper.ApplicationThemeName = Theme.VS2019DarkName;
        }
    }
}