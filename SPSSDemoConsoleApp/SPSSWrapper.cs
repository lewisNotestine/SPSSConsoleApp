using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPSS.BackendAPI;
using SPSS.BackendAPI.Controller;
using System.IO;


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

        private const string GET_FILE = "GET FILE=";        
        private const char PATH_SEPARATOR = '/';
        private static string DATA_DIRECTORY = string.Concat(AppDomain.CurrentDomain.BaseDirectory, PATH_SEPARATOR, "App_Data/");
        private const string DATA_FILE = "socialData2012.SAV";

        public SPSSWrapper() {
            Processor = new Processor();
            Processor.StartSPSS();
            LoadDefaultDataSet();
        }

        public String[] GetAttributeNames() {
            return Processor.GetDataFileAttributeNames();
        }


        public void PopulateVariables() {
            for (int i = 0; i < Processor.GetVariableCount(); i++) { 
                
            }
        }

        public void LoadDefaultDataSet() {
            string fullPath = string.Concat(GET_FILE, "'", DATA_DIRECTORY,  DATA_FILE, "'");
            fullPath = string.Concat(fullPath.Replace("\\", "/"));
            
            Processor.Submit(fullPath);
        }
    }
}