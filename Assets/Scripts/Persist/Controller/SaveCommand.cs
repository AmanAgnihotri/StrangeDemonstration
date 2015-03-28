using strange.extensions.command.impl;

namespace Demonstration.Persist
{
  public class SaveCommand<T> : Command
  {
    [Inject]
    public T Object { get; set; }

    [Inject]
    public IPersistenceService<T> PersistenceService { get; set; }

    public override void Execute ()
    {
      PersistenceService.Save (Object);
    }
  }
}
