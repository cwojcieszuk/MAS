using MP4.Ordered;

namespace MP4.Utils;

public class GameComparer : IComparer<Game>
{
    public int Compare(Game x, Game y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
}