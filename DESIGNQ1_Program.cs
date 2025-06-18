
// Logger class with Singleton pattern
public class Logger
{
    private static Logger? _instance;
    private static readonly object _lock = new object();
    
    private Logger()
    {
        Console.WriteLine("Logger instance created!");
    }
    
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
            }
        }
        return _instance;
    }
    
    public void Log(string message)
    {
        Console.WriteLine($"[LOG {DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {message}");
    }
    
    public string GetInstanceInfo()
    {
        return $"Logger Instance Hash Code: {this.GetHashCode()}";
    }
}

// Main Program class
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Singleton Pattern Test ===\n");
        
        Console.WriteLine("Test 1: Getting Logger instances...");
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();
        Logger logger3 = Logger.GetInstance();
        
        Console.WriteLine("\nTest 2: Checking instance equality...");
        Console.WriteLine($"logger1 == logger2: {ReferenceEquals(logger1, logger2)}");
        Console.WriteLine($"logger2 == logger3: {ReferenceEquals(logger2, logger3)}");
        
        Console.WriteLine("\nTest 3: Instance information...");
        Console.WriteLine(logger1.GetInstanceInfo());
        Console.WriteLine(logger2.GetInstanceInfo());
        
        Console.WriteLine("\nTest 4: Testing logging functionality...");
        logger1.Log("Application started");
        logger2.Log("User logged in");
        logger3.Log("Data processing completed");
        
        Console.WriteLine("\n=== All tests completed ===");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}