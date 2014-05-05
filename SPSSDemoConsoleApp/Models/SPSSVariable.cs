using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPSSDemoConsoleApp.Models {
    
    public class SPSSVariable {

        public enum Scale { 
            NOMINAL,
            ORDINAL,
            SCALE,
            UNKNOWN
        }

        public enum VarType { 
            NUMERIC,
            STRING
        }

        public int ID { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public Scale MeasurementScale { get; set; }
        public Dictionary<int, string> NumValues { get; set; }
        public HashSet<int> MissingValues { get; set; }
        public string VariableFormat { get; set; }
            
    }
}