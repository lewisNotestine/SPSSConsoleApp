using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPSSDemoConsoleApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Welcome to the SPSS dataset program. Loading default Dataset.\n\n");

            //Initialize the default dataset and populate its variables.
            SPSSWrapper wrapper = new SPSSWrapper();
            wrapper.PopulateVariables();
            bool exit = false;

            while (!exit) {
                Console.WriteLine("\n\nEnter a command by number: \n");
                Console.Write("1: List variables\n2: Run Frequencies on a variable\n3: Exit\n");
                int parsed;
                if (int.TryParse(Console.In.ReadLine(), out parsed)) {
                    switch (parsed) {
                        case 1:
                            wrapper.ListVariables();
                            break;
                        case 2:
                            Console.WriteLine("Input a variable name to run: ");
                            string varName = Console.In.ReadLine();
                            wrapper.RunFrequencies(varName);
                            break;
                        case 3:
                            exit = true;
                            break;                    
                        default:
                            Console.WriteLine("Invalid Choice.");
                            break;
                    }
                } else {
                    Console.WriteLine("Invalid Input");
                }
                

            }

        }
    }
}
