

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac.Core.Resolving.Pipeline;

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

            //builder.Register<DefaultLogSource>((c, p) =>
            //                                   {
            //                                       return new DefaultLogSource(c.Resolve<ILogService>(), "");
            //                                   })
            //       .AsImplementedInterfaces()
            //       .InstancePerDependency()

            builder.RegisterType<DefaultLogSource>()
                   .AsImplementedInterfaces()
                   .ConfigurePipeline(p => p.Use(PipelinePhase.ParameterSelection, (context, action) =>
                                                                                    {
                                                                                       Debug.WriteLine("Before ParameterSelection - Requesting {0}", context.Service);
                                                                                       Debug.WriteLine($" ==> {context.Operation.InitiatingRequest.Registration.Target.Activator.LimitType.Name}");

                                                                                       context.ChangeParameters( new List<Parameter>()
                                                                                                                 {
                                                                                                                     new PositionalParameter(0, context.Resolve<ILogService>()),
                                                                                                                     new PositionalParameter(1, context.Operation.InitiatingRequest.Registration.Target.Activator.LimitType.Name)
                                                                                                                 });

                                                                                       // Call the next middleware in the pipeline.
                                                                                       action(context);

                                                                                       Debug.WriteLine("After ParameterSelection - Instantiated {0}", context.Instance);
                                                                                    }))
                   .ConfigurePipeline(p => p.Use(PipelinePhase.Activation, (context, action) =>
                                                                                   {
                                                                                       Debug.WriteLine("Before Activation - Requesting {0}", context.Service);
                                                                                       Debug.WriteLine($" ==> {context.Operation.InitiatingRequest.Registration.Target}");

                                                                                       // Call the next middleware in the pipeline.
                                                                                       action(context);

                                                                                       Debug.WriteLine("After Activation - Instantiated {0}", context.Instance);
                                                                                   }))
                   .InstancePerDependency();


        }
    }
}