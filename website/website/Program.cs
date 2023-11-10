using System;

class WebSite
{
    private string name;
    private int countVisitors;
    private double money;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int CountVisitors
    {
        get { return countVisitors; }
        set { countVisitors = value; }
    }

    public double Money
    {
        get { return money; }
        set { money = value; }
    }

    public WebSite(string name, int countVisitors, double money)
    {
        this.name = name;
        this.countVisitors = countVisitors;
        this.money = money;
    }

    public void IntroduceWebSite()
    {
        Console.WriteLine($"Our website {name} has {countVisitors} visitors and we earn {money} lv. per month.");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter website name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the number of visitors: ");
        int countVisitors = int.Parse(Console.ReadLine());

        Console.Write("Enter monthly earnings (in lv.): ");
        double money = double.Parse(Console.ReadLine());

        WebSite website = new WebSite(name, countVisitors, money);
        website.IntroduceWebSite();
    }
}