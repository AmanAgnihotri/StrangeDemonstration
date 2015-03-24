using UnityEngine;
using Newtonsoft.Json;

namespace Demonstration.Persist
{
  public class DiskPersistenceService : IPersistenceService
  {
    public const string SERVICE_KEY = "Demonstration.Persist.Person";

    [Inject]
    public LoadedSignal LoadedSignal { get; set; }

    public void Delete ()
    {
      PlayerPrefs.DeleteKey (SERVICE_KEY);
    }

    public void Load ()
    {
      var data = PlayerPrefs.GetString (SERVICE_KEY, string.Empty);

      if (!string.IsNullOrEmpty (data))
      {
        var person = JsonConvert.DeserializeObject<Person> (data);

        LoadedSignal.Dispatch (person);
      }
    }

    public void Save (IPerson person)
    {
      var data = JsonConvert.SerializeObject (person);

      try
      {
        PlayerPrefs.SetString (SERVICE_KEY, data);
        PlayerPrefs.Save ();
      }
      catch (PlayerPrefsException exception)
      {
        Debug.LogError (exception);
      }
    }
  }
}
