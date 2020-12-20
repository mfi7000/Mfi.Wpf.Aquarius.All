using System;
using Autofac.Core.Resolving.Pipeline;

namespace Mfi.Diagnostics.Logging
{
    public class LogResolveMiddleware : IResolveMiddleware
    {
        public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
        {
            Console.WriteLine("Before Activation - Requesting {0}", context.Service);

            // Call the next middleware in the pipeline.
            next(context);

            Console.WriteLine("After Activation - Instantiated {0}", context.Instance);
        }

        public PipelinePhase Phase { get; }
    }
}