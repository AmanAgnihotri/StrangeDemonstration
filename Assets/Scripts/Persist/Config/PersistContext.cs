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

      injectionBinder.Bind<LoadedSignal<Person>> ().ToSingleton ();
      injectionBinder.Bind<IPersistenceService<Person>> ().To<DiskPersistenceService<Person>> ().ToSingleton ();

      commandBinder.Bind<DeleteSignal<Person>> ().To<DeleteCommand<Person>> ().Pooled ();
      commandBinder.Bind<LoadSignal<Person>> ().To<LoadCommand<Person>> ().Pooled ();
      commandBinder.Bind<SaveSignal<Person>> ().To<SaveCommand<Person>> ().Pooled ();

      mediationBinder.Bind<PersistView> ().To<PersistMediator> ();
    }
  }
}
