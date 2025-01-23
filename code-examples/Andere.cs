using System.Net;

namespace code_examples;

using Calculator = (double Sum, int Count);

public class Andere {
    void Tuples() {
        
        (double, int) t1 = (4.5, 3);
        Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");
        
        var t = (Sum: 4.5, Count: 3);
        Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");

        (double Sum, int Count) d = (4.5, 3);
        Console.WriteLine($"Sum of {d.Count} elements is {d.Sum}.");
        
        var sum = 4.5;
        var count = 3;
        var t2 = (sum, count);
        Console.WriteLine($"Sum of {t2.count} elements is {t2.sum}.");
        
        var a = 1;
        var t3 = (a, b: 2, 3);
        Console.WriteLine($"The 1st element is {t3.Item1} (same as {t3.a}).");
        Console.WriteLine($"The 2nd element is {t3.Item2} (same as {t3.b}).");
        Console.WriteLine($"The 3rd element is {t3.Item3}.");
        
        (double Sum, int Count) t4 = d;
        Console.WriteLine($"Sum of {t4.Count} elements is {t4.Sum}.");

        Calculator calc = d;
        Console.WriteLine($"Sum of {calc.Count} elements is {calc.Sum}.");
        
    }
#pragma warning disable CS0219 // Variable is assigned but its value is never used
#pragma warning disable CS8603 // Possible null reference return.

    async Task Anonymous() {
        
        using HttpClient client = new();
        try
        {
            var response = await client.GetAsync("https://httpstat.us/404");
            response.EnsureSuccessStatusCode(); // Gooit een exception voor niet-successtatuscodes
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            Console.WriteLine("Error: Resource not found (404).");
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.InternalServerError)
        {
            Console.WriteLine("Error: Server encountered an issue (500).");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Unexpected HTTP error: {ex.StatusCode}. Message: {ex.Message}");
        }
        

        var numberOld = default(int);

        int numberNew = default; 

    }

    public T GetDefaultOld<T>()
    {
        return default(T);
    }
    
    public T GetDefaultNew<T>()
    {
        return default;
    }
    
    public interface ILogger
    {
        void Log(string message);
        void LogWarning(string message) => Console.WriteLine($"WARNING: {message}");
    }
    
    public class ConsoleLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine($"LOG: {message}");
    }

    void Temp() {

        ILogger logger = new ConsoleLogger();
        logger.Log("This is a log message.");    // Output: LOG: This is a log message.
        logger.LogWarning("This is a warning."); // Output: WARNING: This is a warning.
        
    }
    
    void ProcessFile()
    {
        using var reader = new StreamReader("example.txt");
        string line = reader.ReadLine() ?? string.Empty;
        Console.WriteLine(line);
    } // Reader is disposed here
}
