using System;

namespace Pins.Lib
{

    public class ValidateSequential : IValidator
    {
        public bool Validate(string pin)
        {
            bool result = true;

            if(pin.Length < 3)
                return true;

            for (int i = 0; i < pin.Length - 2; ++i)
            {
                if(pin[i]+1 == pin[i+1] && pin[i]+2 == pin[i+2])
                    return false;
            }
            
            return result;
        }
    }
}
