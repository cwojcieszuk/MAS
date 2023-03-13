namespace MP4.Atrybut;

public class Video
{
    private const int MaxVideoLength = 3;
    public string Name { get; set; }
    private double _length;

    public double Length
    {
        get => _length;
        set
        {
            if (value > MaxVideoLength)
            {
                throw new Exception("Video max length is 3 minutes");
            }

            _length = value;
        }
    }

    public Video(int length, string name)
    {
        Length = length;
        Name = name;
    }

    public override string ToString()
    {
        return base.ToString() + $" Name: {Name} Length: {Length}";
    }
}