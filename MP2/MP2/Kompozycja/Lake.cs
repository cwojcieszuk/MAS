namespace MP2.Kompozycja;

public class Lake
{
    public string Name { get; set; }
    public string Location { get; set; }
    public double Area { get; set; }

    private List<Fish> _fishes = new List<Fish>();

    public Lake(string name, string location, double area)
    {
        Name = name;
        Location = location;
        Area = area;
    }

    public Fish CreateFish(string name)
    {
        Fish newFish = new Fish(name);
        _fishes.Add(newFish);

        return newFish;
    }

    public override string ToString()
    {
        string fishes = _fishes.Count <= 0 ? "" : $"Fishes: {string.Join(", ", _fishes)}";
        return base.ToString() + $" Name: {Name} Location: {Location} Area: {Area} {fishes}";
    }

    public class Fish
    {
        public string Name { get; set; }

        public Fish(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return base.ToString() + $" Name: {Name}";
        }
    }
}