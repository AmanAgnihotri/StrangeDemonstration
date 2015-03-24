using strange.extensions.command.impl;

namespace Demonstration.Persist
{
  public class LoadCommand : Command
  {
    [Inject]
    public IPersistenceService PersistenceService { get; set; }

    public override void Execute ()
    {
      PersistenceService.Load ();
    }
  }
}
