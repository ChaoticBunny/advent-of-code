using Commons.Task;

namespace Year2015.Day2.IWasToldThereWouldBeNoMath;

public class Y2015D2Task1 : ITask<(int, int)>
{
    public int WrappingPaperNeeded { get; private set; }
    public int RibbonNeeded { get; private set; }

    public (int, int) Run(string[] args)
    {
        foreach (var giftDimensions in args)
        {
            var (l, w, h) = ParseDimensions(giftDimensions);
            var (lw, wh, hl) = (l * w, w * h, h * l);

            WrappingPaperNeeded += CalculateSurfaceAreaOfBox(lw, wh, hl);
            WrappingPaperNeeded += Math.Min(lw, Math.Min(wh, hl));

            RibbonNeeded += CalculateRibbonWrap(l, w, h);
            RibbonNeeded += l * w * h;
        }

        return (WrappingPaperNeeded, RibbonNeeded);
    }

    private (int, int, int) ParseDimensions(string dimensions)
    {
        var parsed = dimensions.Split('x').Select(int.Parse).ToArray();
        return (parsed[0], parsed[1], parsed[2]);
    }

    private int CalculateSurfaceAreaOfBox(int lw, int wh, int hl)
    {
        return 2 * lw + 2 * wh + 2 * hl;
    }

    private int CalculateRibbonWrap(int l, int w, int h)
    {
        var sides = new[] { l, w, h };
        Array.Sort(sides);
        return 2 * sides[0] + 2 * sides[1];
    }
}