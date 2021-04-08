public interface IStatus
{
    void Start();
    void Update();
    void ExitStatus();
}

public abstract class Status : IStatus
{
    public abstract void Start();
    public abstract void Update();
    public abstract void ExitStatus();
}
