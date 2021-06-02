using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using System.Media;

namespace ReadingAndWriting
{
    class EndlessOnline
    {
        // private string endlessOnline = "EndlessOnline.txt";
        private string TitleArt = @"
 _____          _ _                 _____       _ _            
|  ___|        | | |               |  _  |     | (_)           
| |__ _ __   __| | | ___  ___ ___  | | | |_ __ | |_ _ __   ___ 
|  __| '_ \ / _` | |/ _ \/ __/ __| | | | | '_ \| | | '_ \ / _ \
| |__| | | | (_| | |  __/\__ \__ \ \ \_/ / | | | | | | | |  __/
\____/_| |_|\__,_|_|\___||___/___/  \___/|_| |_|_|_|_| |_|\___|
                                                               
                                                               ";
        private string endlessOnline = "Endless Online.txt";
        //Kicks off the application. 
        public void Run()
        {
            Title = "Endless Online";
            DisplayIntro();
            CreatesEOFile();
            RunMenu();
            DisplayOutro();
        }

        // present options and let the user choose what to do. repeat until they want to exit.
        public void RunMenu()
        {

            string choice;

            do
            {
                choice = GetChoice();
                
                switch (choice)
                {
                    case "1":
                        DisplayCharacters();
                        break;
                    case "2":
                        ClearFile();
                        break;
                    case "3":
                        AddEntry();
                        break;
                    default:
                        break;
                }
            } while (choice != "4");
        }

        private string GetChoice()
        {
            bool isChoiceValid = false;
            string choice = "";
            do
            {
                Clear();
                
                ForegroundColor = ConsoleColor.DarkGray;
                WriteLine(TitleArt);
                ForegroundColor = ConsoleColor.Black;
                WriteLine("\nWhat would you like to do?");
                WriteLine("> 1 - Display Endless Online Dev progress");
                WriteLine("> 2 - Clear the dev diary");
                WriteLine("> 3 - Add to the dev diary");
                WriteLine("> 4 - Quit");

                ForegroundColor = ConsoleColor.DarkBlue;
                choice = ReadLine().Trim();
                ForegroundColor = ConsoleColor.Black;

                if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                {
                    isChoiceValid = true;
                   
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"\" {choice} \" is not a valid option. Please choose 1 - 4.");
                    WaitforKey();
                }
            } while (!isChoiceValid);

            return choice;
        }
        
        // Check if the file exists and if it doesn't creates it. 
        private void CreatesEOFile()
        {
            // This is relative to our exe. 
            WriteLine($"Testing System.IO - {File.Exists(endlessOnline)}");
            if (!File.Exists(endlessOnline))
            {
                File.CreateText(endlessOnline);
            }
        }
        
        private void DisplayIntro()
        {
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
            Clear();
            WriteLine(TitleArt);
            WriteLine("\nWelcome to my Endless Online development diary");
            Write("Do you want to play sound? (yes/no) :");
            string response = ReadLine().Trim().ToLower();
            if (response == "yes")
            {
                Music();
            }
            WaitforKey();
        }

        private void DisplayOutro()
        {
            ForegroundColor = ConsoleColor.Black;
            WriteLine("\nASCII text from: https://patorjk.com.");
            WriteLine("Music: Harvest Village by the endless online team : remix by Lugh R.");
            WaitforKey();
        }
        
        private void WaitforKey()
        {
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("\nPress any key...");
            ReadKey(true);
        }
        public void DisplayCharacters()
        {
            ForegroundColor = ConsoleColor.Magenta;
            string Characters = File.ReadAllText(endlessOnline);
            WriteLine("=== Diary ===");
            WriteLine(Characters);
            WriteLine("===================================");
            WaitforKey();
        }
        private void Music()
        {
            SoundPlayer HarvestEO = new SoundPlayer("Endless Online - Harvest VillageAeven Town Arrangement 2.wav");
            HarvestEO.Load();
            HarvestEO.PlayLooping();
          
        }

        private void ClearFile()
        {
            ForegroundColor = ConsoleColor.Black;
            File.WriteAllText(endlessOnline, "");
            WriteLine("Thoughts cleared ...");
            WaitforKey();

        }

        private void AddEntry()
        {
            // grabs the current date.
            DateTime dateTime = DateTime.Now;
            ForegroundColor = ConsoleColor.Black;
            WriteLine("\nWhat notes would you like to add (Type exit and press enter to stop) ");
            ForegroundColor = ConsoleColor.DarkMagenta;
            string newEntry = "";
            bool shouldContinue = true;
            while (shouldContinue)
            {
                string line = ReadLine();
                if(line.ToLower().Trim() == "exit")
                {
                    shouldContinue = false;
                }
                else
                {
                   newEntry += line + "\n";
                }
            }
            File.AppendAllText(endlessOnline, $"\n{dateTime}:\n{newEntry}");
            WriteLine("Notes have been modified!");
            WaitforKey();
        }

    }
}
