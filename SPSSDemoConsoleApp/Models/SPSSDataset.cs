using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPSS.BackendAPI;
using SPSS.BackendAPI.Controller.ErrorCode;

namespace SPSSDemoConsoleApp.Models {
    
        /// <summary>
        /// Class for abstracting out the properties of the entire dataset.
        /// Main responsibilities are wrapping collections of variables by their numeric index, and by name.
        /// The SPSS API does not provide the latter function by default, so that is important here.
        /// </summary>
        public class SPSSDataset {
            public int ID;
            public SortedDictionary<int, SPSSVariable> SPSSVariables { get; private set; }
            private SortedDictionary<string, int> SPSSVariableNameIndex { get; set; }

            public SPSSDataset() {
                SPSSVariables = new SortedDictionary<int, SPSSVariable>();
                SPSSVariableNameIndex = new SortedDictionary<string, int>();
            }

            /// <summary>
            /// Gets the ith variable, zero-based index.
            /// </summary>
            /// <param name="index">the order </param>
            /// <returns></returns>
            public SPSSVariable GetVariableAt(int index) {
                return SPSSVariables[index];
            }

            /// <summary>
            /// Convenience method that returns an SPSS variable by its variable name.
            /// </summary>
            /// <param name="varName">the variable name.</param>
            /// <returns></returns>
            public SPSSVariable GetVariableByName(string varName) {
                return SPSSVariables[SPSSVariableNameIndex[varName]];
            }
            
            /// <summary>
            /// Adds a new variable to the dataset.
            /// </summary>
            /// <param name="variable">The strongly-typed SPSS variable to add.</param>
            /// <returns>true if successful, false if the variable is already in the dataset </returns>
            public bool AddVariable(SPSSVariable variable) {
                try {
                    if (!SPSSVariableNameIndex.ContainsKey(variable.Name)) {
                        SPSSVariables.Add(variable.Index, variable);
                        SPSSVariableNameIndex.Add(variable.Name, variable.Index);
                        return true;
                    }
                    return false;
                    
                } catch (SpssException ex) {
                    Console.Write(ex.StackTrace);
                    return false;
                }
            }

            /// <summary>
            /// Checks whether the dataset contains the variable with the given name.
            /// </summary>
            /// <param name="variableName">Variable name for which to check.</param>
            /// <returns>true if found, false otherwise.</returns>
            public bool HasVariable(string variableName) {
                return SPSSVariableNameIndex.ContainsKey(variableName);
            }
        }
}