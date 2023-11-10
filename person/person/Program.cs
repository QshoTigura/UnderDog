using System;

class Person
{
    private string firstName;
    private string lastName;
    private string birthplace;
    private int age;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string Birthplace
    {
        get { return birthplace; }
        set { birthplace = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Person()
    {
    }

    public Person(string firstName, string lastName, string birthplace, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthplace = birthplace;
        this.age = age;
    }

    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public void Introduce()
    {
        Console.WriteLine($"Аз съм {firstName} {lastName}, на {age} години, от {birthplace}.");
    }
}

class Program
{
    static void Main()
    {
        Person person1 = new Person("Иван", "Иванов", "София", 30);

        Console.Write("Въведете вашето име: ");
        string firstName = Console.ReadLine();
        Console.Write("Въведете вашата фамилия: ");
        string lastName = Console.ReadLine();
        Person person2 = new Person(firstName, lastName);

        person1.Introduce();
        person2.Introduce();
    }
}

