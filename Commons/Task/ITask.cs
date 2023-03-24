namespace Commons.Task;

public interface ITask<TResult>
{
    public TResult Run(string[] args);
}