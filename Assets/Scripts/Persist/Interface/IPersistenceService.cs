using strange.extensions.signal.impl;

namespace Demonstration.Persist
{
  public interface IPersistenceService
  {
    void Delete ();

    void Load ();

    void Save (IPerson person);
  }
}
