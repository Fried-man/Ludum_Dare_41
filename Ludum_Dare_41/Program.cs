using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ludum_Dare_41 {
    class Program {
        //Title screen
        static void Main(string[] args) {
            Thread.Sleep(1000);
            Console.WriteLine("Welcome to 'Text Based Life Simulator'!");
            Thread.Sleep(1000);
            Console.WriteLine("Created by Andrew Friedman");
            Thread.Sleep(1000);
            Console.WriteLine("\nPress any key to start...");
            Console.ReadKey();

            Born();
        }

        //Start game
        static void Born () {
            Person User = new Ludum_Dare_41.Person();
            Console.Clear();
            Console.WriteLine("What is your name?");
            User.Name = Console.ReadLine();

            int Delay = 1000;
            while (1 > 0) {
                Console.Clear();
                Console.WriteLine("Hello " + User.Name + "!");
                Thread.Sleep(Delay);
                Console.WriteLine("\nHere is some info about you...");
                Thread.Sleep(Delay);
                Console.WriteLine("Gender: " + User.Gender);
                Thread.Sleep(Delay);
                Console.WriteLine("Age: " + User.Age + " years old.");
                Thread.Sleep(Delay);
                Console.WriteLine("\nAre you fine with these stats? (Y/N)");

                string Input = Console.ReadLine();
                if (Input == "Y") {
                    Thread.Sleep(Delay);
                    Console.WriteLine("\nGreat!");
                    Thread.Sleep(Delay);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                }else if (Input == "N") {
                    Thread.Sleep(Delay);
                    Console.WriteLine("\nYou dont get to choose how you are in life");
                    Thread.Sleep(Delay);
                    Console.WriteLine("Sucks to suck");
                    Thread.Sleep(Delay);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                }else {
                    Delay = 0;
                }
            }

            Year_Advance(User);
        }

        //Each year is a turn
        static void Year_Advance (Person User) {
            //Console.Clear();
            User.Age++;
            Console.WriteLine("Date: " + User.Birthday_Month + "/" + User.Birthday_Day + "/" + (2001 + User.Age));
            Console.WriteLine("Type continue to advance through life...");

            while (1 > 0) {
                string Input = Console.ReadLine();
                if (Input == "continue") {
                    break;
                }else {
                    Actions(Input);
                }
            }

            if (User.Age < 100) {
                int Month = User.Birthday_Month;
                int Day = User.Birthday_Day;
                int Year = User.Age + 2001;
                for (int i = 1; i < 364; i++) {
                    if (Day == 28) {
                        if (Month == 12) {
                            Year++;
                            Month = 1;
                        }else {
                            Month++;
                        }
                        Day = 1;
                    }else {
                        Day++;
                    }
                    Day_Advance(User, Month, Day, Year);
                }
                Year_Advance(User);
            }else {
                Game_Over(User);
            }
        }

        //Random event section
        static void Day_Advance (Person User, int Month, int Day, int Year) {
            //Console.Clear();
            Random rnd = new Random();
            Console.WriteLine("Date: " + Month + "/" + Day + "/" + Year);
            if (rnd.Next(1, 100001) == 100000) { //350400001 is actual rate
                Console.WriteLine("Date: " + Month + "/" + Day + "/" + Year);
                Thread.Sleep(1000);
                Console.WriteLine("YOU GOT STRUCK BY LIGHTNING!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Thread.Sleep(1000);
                if (rnd.Next(11) == 0) {
                    User.Death_Cause = "lightning";
                    Game_Over(User);
                }else {
                    Console.WriteLine("YOU SURVIVED!");
                    Thread.Sleep(1000);
                    int change = rnd.Next(-5, 6);
                    User.Happiness += change;
                    Console.WriteLine("Hapiness changed by " + change + " points");
                    Thread.Sleep(1000);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        //Creates random stats for person var
        public static Person Create_Person_Stats (Person Target) {
            Random rnd = new Random();

            if (rnd.Next(2) == 0) {
                Target.Gender = "Female";
            }else {
                Target.Gender = "Male";
            }
            Target.Birthday_Month = rnd.Next(1, 13);
            Target.Birthday_Day = rnd.Next(1,28);
            return Target;
        }

        static void Actions (string Action) {
            if (Action == "help") {
                Console.WriteLine("For more information on a specific action, type 'help' command-name");
                Console.WriteLine("help" + "          " + "Provides info about actions");
                Console.WriteLine("get" + "           " + "Provides info");
                Console.WriteLine("kill" + "          " + "Kills someone");
                Console.WriteLine("change" + "        " + "Changes something");
                Console.WriteLine("buy" + "           " + "Buys something");
                Console.WriteLine("go to" + "         " + "Go somewhere");
                Console.WriteLine("cls" + "           " + "Clears screen");
            }else if (Action == "cls") {
                Console.Clear();
            }else {
                Console.WriteLine("Action not found");
            }
        }
        //End game screen
        static void Game_Over (Person User) {
            Console.Clear();
            Console.WriteLine(User.Name + " has died at the age of " + User.Age);
            Console.WriteLine(User.Name + " has died from " + User.Death_Cause);
            Console.WriteLine("Score: ???");
            Console.WriteLine("Restart? (Y/N)");
            Console.WriteLine(" ");
            string Input = Console.ReadLine();
            if (Input == "Y") {
                Born();
            }else if (Input == "N") {
                System.Environment.Exit(1);
            }else {
                Game_Over(User);
            }
        }
    }

    //Every person has these stats
    class Person {
        //Strategic values
        public int Age = 0;
        public int Happiness = 100;
        public int Sanity = 100;
        //Aesthetic Values
        public string Name = "Andrew Friedman";
        public int Birthday_Month = 6;
        public int Birthday_Day = 11;
        public string Gender = "Male";
        public string Ethnicity = "White";
        public string Religion = "Agnostic";
        public int Family_Count = 3;
        public string Death_Cause = "none";
    }
}
