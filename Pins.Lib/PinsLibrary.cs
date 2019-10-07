using System;
using System.Collections.Generic;

namespace Pins.Lib
{
    
    public interface IPinsLibrary
    {
        HashSet<string> GenerateBatch(int width, int batchSize);
    }


    public class PinsLibrary:IPinsLibrary
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
            var max = 9999;

            int index = 1;
            while(index <= batchSize)
            {
                int pin = rdm.Next(1, max);

                string strPin = pin.ToString("D" + width);

                if(coll.Add(strPin))
                {
                    ++index;
                }
            }
            
            return coll;

        }
    }
}
