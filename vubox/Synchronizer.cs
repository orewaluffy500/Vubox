namespace vubox;


public class Syncer
{
    public static T Sync<T>(Task<T> task)
    {
        return task.GetAwaiter().GetResult();
    }

    public static void Sync(Task task)
    {
        task.GetAwaiter().GetResult();
    }

    public static T Sync<T>(ValueTask<T> task)
    {
        return task.GetAwaiter().GetResult();
    }

    public static void Sync(ValueTask task)
    {
        task.GetAwaiter().GetResult();
    }
}