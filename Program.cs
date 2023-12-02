public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class Calculator
{
    private ILogger _logger;

    public Calculator(ILogger logger)
    {
        _logger = logger;
    }

    public double Add(double a, double b)
    {
        double result = a + b;
        _logger.Log($"{a} + {b} = {result}");
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        _logger.Log($"{a} * {b} = {result}");
        return result;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            _logger.Log($"Нельзя делить {a} на ноль");
            throw new DivideByZeroException();
        }

        double result = a / b;
        _logger.Log($"{a} / {b} = {result}");
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ILogger logger = new ConsoleLogger();
        Calculator calculator = new Calculator(logger);

        double a = 10;
        double b = 2;

        double sum = calculator.Add(a, b);
        double product = calculator.Multiply(a, b);
        double quotient = calculator.Divide(a, b);

        Console.WriteLine($"Результат суммы: {sum}");
        Console.WriteLine($"Результат умножения: {product}");
        Console.WriteLine($"Результат деление: {quotient}");
    }
}