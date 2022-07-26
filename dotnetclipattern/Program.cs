using CommandLine;
using CommandLine.Text;
using dotnetclipattern.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnetclipattern;

public class Program
{
    public class Options
    {
        [Option('n',"number", HelpText="The number to test")]
        public int Number { get; set; }
        [Option('l',"palindrome", HelpText="Test if number is a palindrome.")]
        public bool Palindrome { get; set; }
        [Option('e',"even", HelpText="Test if number is even.")]
        public bool Even { get; set; }
        [Option('p',"prime", HelpText="Test if number is prime.")]
        public bool Prime { get; set; }
    }

    static void Main(string[] args)
    {
        // Parse arg result
        var parser = new CommandLine.Parser(with => with.HelpWriter = null);
        var parserResult = parser.ParseArguments<Options>(args);

        // Prepare the DI
        var service = new ServiceCollection();
        ConfigureService(service, parserResult.Value);
        var serviceProvider = service.BuildServiceProvider();
        var app = serviceProvider.GetRequiredService<MainApp>();

        parserResult
            .WithParsed<Options>(Options => app.Run(parserResult.Value))
            .WithNotParsed<Options>(Options => DisplayHelp(parserResult));
    }

    private static void ConfigureService(IServiceCollection services, Options option)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if(environment == null)
        {
            environment = "Development";
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{environment}.json", true, true)
            .AddEnvironmentVariables()
            .Build();

        services.AddTransient<IMiscNumberValidation, MiscNumberValidation>();
        services.AddSingleton<MainApp, MainApp>();
    }

    static void DisplayHelp<T>(ParserResult<T> result)
    {
        var helpText = HelpText.AutoBuild(result, h =>
        {
            h.AdditionalNewLineAfterOption = false;
            h.Heading = "dotnetclipattern v1.0.0";
            h.Copyright = $"Copyright (c) {DateTime.Now.Year} Gujaru";
            return HelpText.DefaultParsingErrorsHandler(result, h);
        }, e => e);
        Console.WriteLine(helpText); 
    }
}
