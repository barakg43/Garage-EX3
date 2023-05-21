using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ParameterWrapper
    {
        public ParameterWrapper(Type i_Type, string i_Name)
        {
            Type = i_Type;
            Name = i_Name;
        }

        public Type Type
        {
            get;
        }

        public string Name
        {
            get;
        }

        public object Value
        {
            get; set;
        }
    }

}
