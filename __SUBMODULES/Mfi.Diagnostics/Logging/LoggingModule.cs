

using Autofac;

namespace Mfi.Diagnostics.Logging
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DefaultLogService>()
                   .AsImplementedInterfaces()
                   .SingleInstance();

            //builder.re
        }
    }
}