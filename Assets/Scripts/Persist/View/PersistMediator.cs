using strange.extensions.mediation.impl;

namespace Demonstration.Persist
{
  public class PersistMediator : Mediator
  {
    [Inject]
    public PersistView PersistView { get; set; }

    [Inject]
    public DeleteSignal DeleteSignal { get; set; }

    [Inject]
    public LoadSignal LoadSignal { get; set; }

    [Inject]
    public SaveSignal SaveSignal { get; set; }

    [Inject]
    public LoadedSignal LoadedSignal { get; set; }

    private Person Person { get; set; }

    public override void OnRegister ()
    {
      PersistView.Initialize ();

      Person = new Person ();

      PersistView.InputSignal.AddListener (ProcessInput);

      LoadedSignal.AddListener (Loaded);
    }

    public override void OnRemove ()
    {
      PersistView.InputSignal.RemoveListener (ProcessInput);

      LoadedSignal.RemoveListener (Loaded);
    }

    private void ProcessInput (InputType type)
    {
      switch (type)
      {
        case InputType.Clear:
          Clear ();
          break;
        case InputType.Delete:
          DeleteSignal.Dispatch ();
          break;
        case InputType.Load:
          LoadSignal.Dispatch ();
          break;
        case InputType.Save:
          Save ();
          break;
      }
    }

    private void Save ()
    {
      int age = 0;

      int.TryParse (PersistView.Age.text, out age);

      Person.Set (PersistView.Name.text, age);

      SaveSignal.Dispatch (Person);
    }

    private void Clear ()
    {
      Set (string.Empty, string.Empty);
    }

    private void Loaded (IPerson person)
    {
      Set (person.Name, person.Age.ToString ());
    }

    private void Set (string name, string age)
    {
      PersistView.Name.text = name;
      PersistView.Age.text = age;
    }
  }
}
