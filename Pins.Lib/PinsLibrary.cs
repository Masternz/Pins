using System;
using System.Collections.Generic;

namespace Pins.Lib
{
    
    public interface IPinsLibrary
    {
        HashSet<string> GenerateBatch(int width, int batchSize);
    }

    public interface IPinsValidation
    {
       bool ValidateInputParameters(int batchSize, int pinLenght);
        int GetRandomInputSizeBasedOnPinLength(int pinLength);
    }

    public class PinsLibrary:IPinsLibrary,IPinsValidation
    {
        public PinsLibrary()
        {
        }

        // a comment

        public HashSet<string> GenerateBatch(int batchSize, int width)
        {
            var coll = new HashSet<string>();
            Random rdm = new Random();


            // Could be a problem here if the width is not large enough for the
            // batchSize.
            // hardcoded for now
            var max = GetRandomInputSizeBasedOnPinLength(width);

            int index = 1;
            int failureCount = 0;
            // Need more exit criteria to eliminate chance of an infinite loop
            // default we cannot have a failurecount more than the batch size.
            // Could add something more suffisticated around failure count.
            // especially if we add more validation criteria.
            while(index <= batchSize && failureCount <= batchSize)
            {
                int pin = rdm.Next(1, max);

                string strPin = pin.ToString("D" + width);

                // validation - elimination

                if(coll.Add(strPin))
                {
                    ++index;
                }
                //else
                //{
                //    ++failureCount;
                //}

            }

            // if batch size is incorrect throw an exception.
            
            return coll;

        }

        /// Returns true if all imput parameter combinations are valid
        public bool ValidateInputParameters(int batchSize, int pinLenght)
        {
            return true;
        }

        public int GetRandomInputSizeBasedOnPinLength(int pinLength)
        {
            int pinMax = System.Convert.ToInt32(new String('9', pinLength));   
        
            return pinMax;
        }
    }
}
