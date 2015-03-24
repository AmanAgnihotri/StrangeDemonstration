using Demonstration.Common;
using strange.extensions.context.impl;

namespace Demonstration.Persist
{
  public class PersistContext : SignalContext
  {
    public PersistContext (ContextView contextView) : base (contextView)
    {
    }

    protected override void mapBindings ()
    {
      base.mapBindings ();

      injectionBinder.Bind<LoadedSignal> ().ToSingleton ();
      injectionBinder.Bind<IPersistenceService> ().To<DiskPersistenceService> ().ToSingleton ();

      commandBinder.Bind<DeleteSignal> ().To<DeleteCommand> ().Pooled ();
      commandBinder.Bind<LoadSignal> ().To<LoadCommand> ().Pooled ();
      commandBinder.Bind<SaveSignal> ().To<SaveCommand> ().Pooled ();

      mediationBinder.Bind<PersistView> ().To<PersistMediator> ();
    }
  }
}
