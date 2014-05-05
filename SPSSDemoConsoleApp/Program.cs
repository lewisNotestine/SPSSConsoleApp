using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPSSDemoConsoleApp {

    /// <summary>
    /// SPSS Demo Console App.
    /// 
    /// This is a demo application for showing how the SPSS API for .NET works. It is a convenient wrapper for programmatically wrapping SPSS functionality in a CLR environment.
    /// This just loads a prepackaged default dataset, but can be configured to run whatever you want.
    /// See API Doc at: ftp://public.dhe.ibm.com/software/analytics/spss/documentation/statistics/20.0/en/netplugin/Manuals/Microsoft_NET_User_Guide_for_IBM_SPSS_Statistics.pdf
    /// </summary>
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
