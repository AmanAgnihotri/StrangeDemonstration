using strange.extensions.command.impl;

namespace Demonstration.Persist
{
  public class DeleteCommand : Command
  {
    [Inject]
    public IPersistenceService PersistenceService { get; set; }

    public override void Execute ()
    {
      PersistenceService.Delete ();
    }
  }
}
