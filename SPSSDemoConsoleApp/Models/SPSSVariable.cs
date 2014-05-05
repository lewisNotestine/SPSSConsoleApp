using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPSSDemoConsoleApp.Models {
    
    public class SPSSVariable {

        public int ID { get; private set; }
        public int Index { get; set; }
        public string Name { get; private set; }
        public string Label { get; private set; }
        public string Scale { get; set; }
        public int VarType { get; set; }
        public Dictionary<double, string> NumValues { get; set; }
        public string VariableFormat { get; set; }
            
        private SPSSVariable() {
            NumValues = new Dictionary<double, string>();
        }

        public SPSSVariable(int index, string name, string label, string scale, int type, string format) : this() {
            Index = index;
            Name = name;
            Label = label;
            Scale = scale;
            VarType = type;
            VariableFormat = format;
        }
    }
}