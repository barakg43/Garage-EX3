using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ParameterWrapper
    {
        public ParameterWrapper(Type i_ParameterType, string i_ParameterName)
        {
            ParameterType = i_ParameterType;
            ParameterName = i_ParameterName;
        }

        public Type ParameterType
        {
            get;
        }

        public string ParameterName
        {
            get;
        }

        public object Value
        {
            get; set;
        }
    }

}
