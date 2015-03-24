using Demonstration.Common;
using strange.extensions.context.impl;

namespace Demonstration.Log
{
  public class LogContext : SignalContext
  {
    public LogContext (ContextView contextView) : base (contextView)
    {
    }

    protected override void mapBindings ()
    {
      base.mapBindings ();

      commandBinder.Bind<LogSignal> ().To<LogCommand> ();
    }

    public override void Launch ()
    {
      injectionBinder.GetInstance<LogSignal> ().Dispatch ("Hello World!");
    }
  }
}
