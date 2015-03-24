using strange.extensions.command.impl;

namespace Demonstration.Persist
{
  public class SaveCommand : Command
  {
    [Inject]
    public IPerson Person { get; set; }

    [Inject]
    public IPersistenceService PersistenceService { get; set; }

    public override void Execute ()
    {
      PersistenceService.Save (Person);
    }
  }
}
