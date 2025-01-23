namespace code_examples;

public class Null {
    void Example() {
        string? firstName = null;
        string? lastName = null;
        // var fullName = $"{firstName ?? "Jan"} {lastName ?? "Klaas"}";

        var person = new NullPerson { FirstName = "Jan" };
        Console.Write(person.Address?.Street ?? "Unknown");
        
        string? fullName = null;
        fullName ??= "Jan Klaas";
        
        string? nullableName = null; // Allowed 
        string nonNullableName = null; // Compile-time error
        
        
        
        
        string? name = null;
        if (!string.IsNullOrEmpty(name))
        {
            Console.WriteLine(name.Length);
        }
        
        Console.Write(fullName);
        Console.Write(nullableName);
        Console.Write(nonNullableName);
    }
}

public class NullPerson {
    public string FirstName { get; init; }
    public Address? Address { get; set; }
}

public class Address {
    public string? Street { get; set; }
}

