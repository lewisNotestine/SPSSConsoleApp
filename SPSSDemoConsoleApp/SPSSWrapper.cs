using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPSS.BackendAPI;
using SPSS.BackendAPI.Controller;
using SPSS.BackendAPI.Controller.AssistType;
using System.IO;
using SPSSDemoConsoleApp.Models;


namespace SPSSDemoConsoleApp {

    /// <summary>
    /// Class that wraps the SPSS backend controller for data analysis operations within our program.
    /// Also handles File IO for datasets, for convenience.
    /// </summary>
    public class SPSSWrapper {

        /// <summary>
        /// Reference to an SPSS Processor object, this does the heavy lifting.
        /// </summary>
        private Processor Processor {get; set;}

        ///These constants are for convenience, for constructing a few simple SPSS syntax commands.  You can make this more abstracted and robust if you like.
        private const string COMMAND_GET_FILE = "GET FILE=";
        private const string COMMAND_FREQUENCIES = "FREQUENCIES VARIABLES=";
        private const string TERMINATOR = ".";
               
        private const string PATH_SEPARATOR = "/";
        private static string DATA_DIRECTORY = string.Concat(AppDomain.CurrentDomain.BaseDirectory, PATH_SEPARATOR, "App_Data/");
        private const string DEFAULT_DATA_FILE = "socialData2012.SAV";

        private SPSSDataset Dataset { get; set; }

        public SPSSWrapper() {
            Processor = new Processor();
            Processor.StartSPSS();
            LoadDefaultDataSet();
        }

        /// <summary>
        /// Creates a collection of SPSSVariable objects to be used by the program.
        /// </summary>
        public void PopulateVariables() {

            for (int i = 0; i < Processor.GetVariableCount(); i++) {
                SPSSVariableBuilder builder = new SPSSVariableBuilder();
                builder.WithIndex(i)
                    .WithName(Processor.GetVariableName(i))
                    .WithLabel(Processor.GetVariableLabel(i))
                    .WithMeasurementScale(Processor.GetVariableMeasurementLevel(i))
                    .WithVariableType(Processor.GetVariableType(i));
                    
                foreach (ValueLabelPair<double, string> pair in Processor.GetVariableNValueLabel(i)) {
                    builder.AddValueLabel(pair.Value, pair.Label);
                }

                SPSSVariable variable = builder.Build();
                Console.WriteLine(string.Concat("Added variable: ", variable.Name)); 

                Dataset.AddVariable(variable);
            }
        }

        /// <summary>
        /// Loads the default dataset, supplied with the application.
        /// </summary>
        public void LoadDefaultDataSet() {
            string fullPath = string.Concat(COMMAND_GET_FILE, "'", DATA_DIRECTORY,  DEFAULT_DATA_FILE, "'");
            //The SPSS processor uses forward-slashes.
            fullPath = string.Concat(fullPath.Replace("\\", PATH_SEPARATOR));
            
            Processor.Submit(fullPath);
            Dataset = new SPSSDataset();
        }


        /// <summary>
        /// Public api, to run the frequencies by a variable name.
        /// </summary>
        /// <param name="variableName">Variable name to run</param>
        /// <returns>Success of operation, true if the variable exists and frequencies are run, false otherwise.</returns>
        public bool RunFrequencies(string variableName) {
            if (Dataset.HasVariable(variableName)) {
                RunFrequencies(Dataset.GetVariableByName(variableName));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Runs a univariate frequencies command on the variable.
        /// </summary>
        /// <param name="variable"></param>
        private void RunFrequencies(SPSSVariable variable) { 
            string commandString = string.Concat(COMMAND_FREQUENCIES, variable.Name, TERMINATOR);
            Processor.Submit(commandString);
        }


        /// <summary>
        /// List the names of the variables in the dataset.
        /// </summary>
        public void ListVariables() {
            foreach (SPSSVariable variable in Dataset.SPSSVariables.Values) {
                Console.WriteLine(variable.Name);
            }
        }
    }
}