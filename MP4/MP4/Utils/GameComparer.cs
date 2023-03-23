using MP4.Ordered;

namespace MP4.Utils;

public class GamePlayerComparer : IComparer<GamePlayer>
{
    public int Compare(GamePlayer x, GamePlayer y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
}