using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPSSDemoConsoleApp.Models {
    
        public class SPSSDataset {
            public int ID;
            public HashSet<string> DataFileAttributeNames { get; private set; }
            public Dictionary<string, HashSet<string>> DataFileAttributes { get; private set; }
            public SortedDictionary<int, SPSSVariable> SPSSVariables { get; private set; }
            
            private Dictionary<string, int> SPSSVariableNameIndex { get; set; }

            public SPSSVariable GetVariableAt(int index) {
                return SPSSVariables[index];
            }

            public SPSSVariable GetVariableByName(string varName) {
                return SPSSVariables[SPSSVariableNameIndex[varName]];
            }
        }
}