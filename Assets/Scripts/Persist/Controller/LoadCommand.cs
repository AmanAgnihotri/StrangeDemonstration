using strange.extensions.command.impl;

namespace Demonstration.Persist
{
  public class LoadCommand<T> : Command
  {
    [Inject]
    public IPersistenceService<T> PersistenceService { get; set; }

    public override void Execute ()
    {
      PersistenceService.Load ();
    }
  }
}
