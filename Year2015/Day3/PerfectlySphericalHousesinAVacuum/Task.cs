using Commons.Task;

namespace Year2015.Day3.PerfectlySphericalHousesinAVacuum;

public class Y2015D3Task1 : ITask<int>
{
    private Position _santaPosition;
    private Position _robotPosition;
    private HashSet<Position> _visited = new();

    public int Run(string[] args)
    {
        if (args.Length < 1)
        {
            return _visited.Count;
        }

        _visited.Add(_santaPosition); // both start at the same location
        var odd = true;
        foreach (var c in args[0])
        {
            if (odd)
            {
                _santaPosition = ParseMoveInstruction(c, _santaPosition);
                _visited.Add(_santaPosition);
            }
            else
            {
                _robotPosition = ParseMoveInstruction(c, _robotPosition);
                _visited.Add(_robotPosition);
            }

            odd = !odd;
        }

        return _visited.Count;
    }

    private Position ParseMoveInstruction(char instruction, Position currentPosition)
    {
        switch (instruction)
        {
            case '<':
                return currentPosition + new Position(-1, 0);
            case '>':
                return currentPosition + new Position(1, 0);
            case '^':
                return currentPosition + new Position(0, 1);
            case 'v':
                return currentPosition + new Position(0, -1);
        }

        return new Position();
    }

    private readonly struct Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Position operator +(Position a, Position b) => new(a.X + b.X, a.Y + b.Y);
        public static Position operator -(Position a, Position b) => new(a.X - b.X, a.Y - b.Y);

        public override string ToString()
        {
            return $"[{X}; {Y}]";
        }
    }
}