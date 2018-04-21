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
            Person User = new Ludum_Dare_41.Person();
            Random rnd = new Random();
            if (rnd.Next(2) == 0) {
                User.Gender = "Female";
            }else {
                User.Gender = "Male";
            }

            Console.WriteLine("You are " + User.Gender);
            Console.WriteLine("You are " + User.Age + " years old.");

            User.Name = Console.ReadLine();

            Console.ReadKey();

            Year_Advance(User);
        }

        static void Year_Advance (Person User) {
            User.Age++;

            if (User.Age < 100) {
                Year_Advance(User);
            }else {
                Game_Over(User);
            }
        }

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

    class Person {
        //Strategic values
        public int Age = 0;
        //Aesthetic Values
        public string Name = "Andrew Friedman";
        public string Gender = "Male";
        public string Ethnicity = "White";
        public int Family_Count = 3;
    }
}
