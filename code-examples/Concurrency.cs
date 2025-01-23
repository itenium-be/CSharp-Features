namespace code_examples;

public class Program
{
    private static readonly Lock _lockObject = new();
    private static int _counter = 0;

    private static async Task IncrementCounterAsync()
    {
        using (_lockObject.EnterScope())
        {
            _counter++;
            Console.WriteLine($"Counter: {_counter}");
        }
        await Task.Delay(100);
    }
    
    private static async Task IncrementCounterAsyncOld()
    {
        lock (_lockObject)
        {
            _counter++;
            Console.WriteLine($"Counter: {_counter}");
        }
        await Task.Delay(100);
    }
    
    public static async Task Main()
    {
        Task task1 = IncrementCounterAsync();
        Task task2 = IncrementCounterAsync();

        await Task.WhenAll(task1, task2);
    }
}



