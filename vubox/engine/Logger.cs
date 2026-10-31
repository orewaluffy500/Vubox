namespace vubox.engine;

public static class Logger
{
    public static void Log(ConsoleColor color, string label, string message)
    {
        Console.ForegroundColor = color;
        Console.Write(label.ToUpper());
        Console.ResetColor();
        Console.WriteLine($": {message}");
    }

    public static void Info(string msg) => Log(ConsoleColor.Green, "info", msg);
    public static void Error(string msg) => Log(ConsoleColor.Red, "error", msg);
    public static void Warn(string msg) => Log(ConsoleColor.Yellow, "warn", msg);
}