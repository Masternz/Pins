using System;

namespace Pins.Lib
{

    public class ValidateConsecutive : IValidator
    {
        public bool Validate(string pin)
        {
            bool result = true;

            if(pin.Length == 0)
                return false;

            char previous = pin[0];
            for (int i = 1; i < pin.Length; ++i)
            {
                if(previous == pin[i])
                    return false;
                else
                    previous = pin[i];
            }
            
            return result;
        }
    }
}
