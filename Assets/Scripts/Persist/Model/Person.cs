namespace Demonstration.Persist
{
  public class Person
  {
    public string Name { get; private set; }

    public int Age { get; private set; }

    public Person (string name = "", int age = 0)
    {
      Set (name, age);
    }

    public void Set (string name, int age)
    {
      Name = name;
      Age = age;
    }
  }
}
