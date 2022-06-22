namespace ScrutorConsoleApp;

public class Settings
{
    public string Username { get; set; }

    public string Password { get; set; }

    public static readonly TimeSpan Delay = TimeSpan.FromMilliseconds(100);
}