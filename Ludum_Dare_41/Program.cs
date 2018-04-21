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
            Console.Clear();
            User.Age++;
            Console.WriteLine("Date: ");

            if (User.Age < 100) {
                Year_Advance(User);
            }else {
                Game_Over(User);
            }
        }

        public static Person Create_Person_Stats (Person Target) {
            Random rnd = new Random();
            if (rnd.Next(2) == 0) {
                Target.Gender = "Female";
            }else {
                Target.Gender = "Male";
            }
            return Target;
        }

        //End game screen
        static void Game_Over (Person User) {
            Console.Clear();
            Console.WriteLine(User.Name + " has died at the age of " + User.Age);
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
            Console.ReadKey();
        }
    }

    //Every person has these stats
    class Person {
        //Strategic values
        public int Age = 0;
        //Aesthetic Values
        public string Name = "Andrew Friedman";
        public string Birthday = "6/11";
        public string Gender = "Male";
        public string Ethnicity = "White";
        public int Family_Count = 3;
    }
}
