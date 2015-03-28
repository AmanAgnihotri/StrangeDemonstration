using strange.extensions.signal.impl;

namespace Demonstration.Persist
{
  public interface IPersistenceService<T>
  {
    void Delete ();

    void Load ();

    void Save (T type);
  }
}
