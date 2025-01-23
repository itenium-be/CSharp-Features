using System.Diagnostics.CodeAnalysis;

namespace code_examples;

public class Person {
    public string FirstName { get; init; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

public class ExpressionPerson {
    public string FirstName => "Jules";
}


public class InitPerson {
    public string FirstName { get; init; }
}

public class RequiredPerson {
    public required string FirstName { get; init; }
    
    [SetsRequiredMembers] 
    public RequiredPerson(string firstName) {
        FirstName = firstName;
    }
}

public class PrimaryPerson(string firstName) {
    public string FirstName { get; set; } = firstName;
}

public class Car {
    public decimal Passengers { get; set; }
};

public class Truck {
    public decimal Weight { get; set; }
};

public class Construction {
    void ObjectInitialization() {
        var person = new Person {
            FirstName = "Jules",
            LastName = "H",
            Age = 30
        };

        object obj = "Hello, World!";
        if (obj is string s)
        {
            Console.WriteLine($"String length: {s.Length}");
        }

        decimal CalculateTax(object vehicle) => vehicle switch
        {
            Car c => c.Passengers * 2.0m,
            Truck t => t.Weight * 5.0m,
            _ => 0m
        };
        
        int[] numbers = { 1, 2, 3, 4, 5 };
        bool startsWithOneTwo = numbers is [1, 2, ..];

        
        var result = obj switch 
        {
            int i when i > 0 => "Positive integer", 
            int i when i < 0 => "Negative integer",
            _ => "Not an integer" 
        };
        
        Console.Write(CalculateTax(new Truck() { Weight = 1000m }));
    }
    
    class Product {
        public decimal Price { get; set; }
    }
    
    string DescribePerson(Person person) => person switch
    {
        { Age: < 18 } => "Minor",
        { Age: >= 18 } => "Adult",
        _ => "Unknown"
    };



    
    bool IsAdult(Person person) => person is { Age: >= 18 };
    
    string DescribePoint((int x, int y) point) => point switch
    {
        (0, 0) => "Origin",
        (var x, 0) => $"On the x-axis at {x}",
        (0, var y) => $"On the y-axis at {y}",
        _ => "Elsewhere"
    };
    
    bool IsWeekday(DayOfWeek day) => 
        day is >= DayOfWeek.Monday and <= DayOfWeek.Friday;

    string DescribeTemperature(int tempInCelsius) => tempInCelsius switch
    {
        < 0 => "Freezing",
        >= 0 and < 10 => "Cold",
        >= 10 and < 20 => "Mild",
        >= 20 and < 30 => "Warm",
        >= 30 => "Hot"
    };


    
    void Print(params IEnumerable<int> numbers)
    {
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }

    void ExecutePrint() {
        Print([1, 2, 3]);
    }
    
    void AnonymousTypes() {
        var person = new {
            FirstName = "Jules",
            LastName = "H",
            Age = 30
        };
        
        // var numbers = new List<int> { 1, 2, 3, 4, 5 };
        //
        // var dictionary = new Dictionary<string, int>
        // {
        //     { "One", 1 },
        //     { "Two", 2 }
        // };
        //
        // var dictionary2 = new Dictionary<int, string>
        // {
        //     [1] = "One",
        //     [2] = "Two"
        // };
        
        // var numbers = new int[] { 1, 2, 3, 4, 5, 6 };
        // var slice = numbers[1..4]; 
        //
        // Console.WriteLine(string.Join(", ", slice)); // 2, 3, 4
        
        // var numbers = new int[] { 10, 20, 30, 40, 50 };
        // var last = numbers[^1];
        // Console.WriteLine(last); // 50
        //
        // // Combinatie van range en index
        // var sliceFromEnd = numbers[^3..^1];
        // Console.WriteLine(string.Join(", ", sliceFromEnd)); // 30, 40
        
        int[] numbers = [1, 2, 3, 4, 5];
        string[] strings = ["one", "two", "three"];
        List<int> list = [..numbers];
        int[] row0 = [1, 2, 3];
        int[] row1 = [4, 5, 6];
        int[] single = [.. row0, .. row1];

    }

    void InitOnly() {

        var person = new InitPerson {
            FirstName = "Jules",
        };
        // person.FirstName = "Wouter"; // Error

        var mars = new Planet(1, "Mars", ["Phobos", "Deimos"]);
        var jupiter = mars with {
            Name = "Jupiter",
            Moons = ["Io", "Europa", "Ganymede", "Callisto"]
        };
    }

    
}

public readonly record struct Point(int X, int Y);
// Positional record
public record Planet(int Id, string? Name, IEnumerable<string>? Moons);