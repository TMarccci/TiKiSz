// Import Libraries
using Rise_of_Derma.scenarios;

// Initial Windows Setup (Pragma for ignore alert)
#pragma warning disable CA1416
Console.SetWindowSize(82, 24);
Console.Title = "Rise of Derma";
#pragma warning restore CA1416

// Demo
Scenario currentScenario = new DemoScenario();

// Main game loop + Controls
ConsoleKeyInfo cki = new ConsoleKeyInfo();

do
{
    while (Console.KeyAvailable == false)
        Thread.Sleep(250);
    cki = Console.ReadKey(true);

    currentScenario.ProcessInput(cki);

} while (cki.Key != ConsoleKey.X);
