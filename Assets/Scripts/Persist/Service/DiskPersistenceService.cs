using UnityEngine;
using Newtonsoft.Json;

namespace Demonstration.Persist
{
  public class DiskPersistenceService<T> : IPersistenceService<T>
  {
    private string Key { get; set; }

    [Inject]
    public LoadedSignal<T> LoadedSignal { get; set; }

    public DiskPersistenceService ()
    {
      Key = "Demonstration.Persist." + typeof (T).Name;
    }

    public void Delete ()
    {
      PlayerPrefs.DeleteKey (Key);
    }

    public void Load ()
    {
      var data = PlayerPrefs.GetString (Key, string.Empty);

      if (!string.IsNullOrEmpty (data))
      {
        var dataObject = JsonConvert.DeserializeObject<T> (data);

        LoadedSignal.Dispatch (dataObject);
      }
    }

    public void Save (T type)
    {
      var data = JsonConvert.SerializeObject (type);

      try
      {
        PlayerPrefs.SetString (Key, data);
        PlayerPrefs.Save ();
      }
      catch (PlayerPrefsException exception)
      {
        Debug.LogError (exception);
      }
    }
  }
}
