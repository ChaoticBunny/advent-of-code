using Commons.Task;

namespace Year2015.Day1.NotQuiteLisp;

public class Y2015D1Task1 : ITask<(int, int)>
{
    private const char FloorDown = ')';
    private const char FloodUp = '(';

    public int CurrentFloor { get; private set; }
    public int BasementEnteredOnStep { get; private set; }

    public (int, int) Run(string[] args)
    {
        if (args.Length < 1)
        {
            return (CurrentFloor, BasementEnteredOnStep);
        }

        var input = args[0];
        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case FloorDown:
                    CurrentFloor--;
                    break;
                case FloodUp:
                    CurrentFloor++;
                    break;
            }
            
            if (BasementEnteredOnStep == 0 && CurrentFloor < 0)
            {
                BasementEnteredOnStep = i + 1;
            }
        }

        return (CurrentFloor, BasementEnteredOnStep);
    }
}