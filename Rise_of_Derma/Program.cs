// Import Libraries
using Rise_of_Derma.scenarios;
using Rise_of_Derma.providers;

// Initial Windows Setup (Pragma for ignore alert)
#pragma warning disable CA1416
Console.SetWindowSize(82, 25);
Console.Title = "Rise of Derma";
#pragma warning restore CA1416

// Initialise configs (Necessary because if no config file program will crash)
Config config = new Config();

// Print the intro for the user
Intro intro = new Intro();
intro.InitIntro();

// Get users name if the config doesnt include it
Name name = new Name();
name.Set();

// Refresh Config because changes may occure
config.refreshConfig();

// Run Game thru Main Menu
MainMenu mainMenu = new MainMenu();
mainMenu.InitMainMenu();