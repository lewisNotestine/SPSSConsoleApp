using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPSSDemoConsoleApp.Models {

    /// <summary>
    /// Class for building the SPSS variable. Implements the Builder pattern to guard against the Telescoping Constructor anti-pattern.
    /// </summary>
    class SPSSVariableBuilder {

        public int Index { get; set; }
        public string Name { get; private set; }
        public string Label { get; private set; }
        public string MeasurementScale { get; set; }
        public int VariableType { get; set; }
        public Dictionary<double, string> NumValues { get; set; }
        public string VariableFormat { get; set; }

        public SPSSVariableBuilder() {
            NumValues = new Dictionary<double, string>();
        }


        /// <summary>
        /// Creational method for the variable builder.
        /// </summary>
        /// <returns>Instance of SPSS variable with appropriate state set.</returns>
        public SPSSVariable Build() {
            if (HasValidParams()) {
                SPSSVariable variable = new SPSSVariable(Index, Name, Label, MeasurementScale, VariableType, VariableFormat);
                variable.NumValues = NumValues;
                
                return variable;
            }

            throw new InvalidOperationException("Call to SPSSVariableBuilder.Build() without setting valid parameters");
        }
       
        #region BuilderSpecificationMethods
        public SPSSVariableBuilder WithIndex(int index) {
            Index = index;
            return this;
        }

        public SPSSVariableBuilder WithName(string name) {
            Name = name;
            return this;
        }

        public SPSSVariableBuilder WithLabel(string label) {
            Label = label;
            return this;
        }

        public SPSSVariableBuilder WithMeasurementScale(string scale) {
            MeasurementScale = scale;
            return this;
        }

        public SPSSVariableBuilder WithVariableType(int type) {            
            VariableType = type;
            return this;
        }

        public SPSSVariableBuilder WithFormat(string format) {
            VariableFormat = format;
            return this;
        }

        public SPSSVariableBuilder AddValueLabel(double value, string label) {
            NumValues[value] = label;
            return this;
        }

        #endregion


        /// <summary>
        /// Validates the SPSS variable, call before building. 
        /// </summary>
        /// <returns>True if valid, false otherwise</returns>
        private bool HasValidParams() {
            return (Name != null);
        }
    }
}
