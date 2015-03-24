using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;

namespace Demonstration.Common
{
  public class SignalContext : MVCSContext
  {
    public SignalContext (ContextView contextView) : base (contextView)
    {
    }

    protected override void addCoreComponents ()
    {
      base.addCoreComponents ();

      injectionBinder.Unbind<ICommandBinder> ();
      injectionBinder.Bind<ICommandBinder> ().To<SignalCommandBinder> ().ToSingleton ();
    }
  }
}
