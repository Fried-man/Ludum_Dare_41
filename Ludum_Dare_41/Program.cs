using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludum_Dare_41 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Welcome to 'Text Based Life Simulator'!");
            Console.WriteLine("Created by Andrew Friedman");
            Console.ReadKey();

            Born();
        }

        static void Born () {
            Console.Clear();
            Random rnd = new Random();
            int Age = 0;
            String Gender = "Nothing";
            if (rnd.Next(2) == 0) {
                Gender = "Female";
            }else {
                Gender = "Male";
            }

            Console.WriteLine("You are " + Gender);
            Console.WriteLine("You are " + Age + " years old.");
            Console.ReadKey();

            Year_Advance(Age);
        }

        static void Year_Advance (int Age) {
            Age++;

            if (Age < 100) {
                Year_Advance(Age);
            }else {
                Game_Over(Age);
            }
        }

        static void Game_Over (int Age) {
            Console.Clear();
            Console.WriteLine("You have died at the age of " + Age);
            Console.WriteLine("Score: ???");
            Console.WriteLine("Restart? (Y/N)");
            Console.WriteLine(" ");
            string Input = Console.ReadLine();
            if (Input == "Y") {
                Born();
            }else if (Input == "N") {
                System.Environment.Exit(1);
            }else {
                Game_Over(Age);
            }
            Console.ReadKey();
        }
    }
}
