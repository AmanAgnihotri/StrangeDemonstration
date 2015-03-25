using Demonstration.Common;
using strange.extensions.context.impl;

namespace Demonstration.Echo
{
  public class EchoContext : SignalContext
  {
    public EchoContext (ContextView contextView) : base (contextView)
    {
    }

    protected override void mapBindings ()
    {
      base.mapBindings ();

      injectionBinder.Bind<LogSignal> ().ToSingleton ();

      injectionBinder.Bind<IWebSocketService> ().To<EchoService> ().ToSingleton ();
      injectionBinder.Bind<IRoutineRunner> ().To<RoutineRunner> ().ToSingleton ();

      commandBinder.Bind<ConnectSignal> ().To<ConnectCommand> ();
      commandBinder.Bind<DisconnectSignal> ().To<DisconnectCommand> ();
      commandBinder.Bind<SendMessageSignal> ().To<SendMessageCommand> ().Pooled ();

      mediationBinder.Bind<EchoView> ().To<EchoMediator> ();
    }
  }
}
