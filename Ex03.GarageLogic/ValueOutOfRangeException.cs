using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private const string k_ExceptionMsg = "Given Value is out of range and should be between {0}-{1}";

        private readonly float r_MinValue;
        private readonly float r_MaxValue;
        
        public float MinValue
        {
            get { return r_MinValue; }
        }

        public float MaxValue
        {
            get { return r_MaxValue; }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : base(string.Format(k_ExceptionMsg, i_MinValue, i_MaxValue))
        {
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
        }
    }
}
