namespace code_examples;

public class StringExamples {
    public void StringInterpolation() {
        var activeUser = "Jules";
        var action = "login";
        var logRecord = $"Action {action} performed by user: {activeUser} at {DateTime.Now::yyyy-MM-dd HH:mm:ss}";
        Console.Write(logRecord);
    }

    public void RawStringLiterals() {
        var customer = """
           {
             "customer": "Jules H",
             "address": "Rue de la Loi 16, 1000 Brussels"
           }
           """;

        var customerName = "Wouter V";
        var interpolCustomer = $$"""
           {
             "customer": "{{customerName}}",
             "address": "Rue de la Loi 16, 1000 Brussels"
           }
           """;
    }
}
