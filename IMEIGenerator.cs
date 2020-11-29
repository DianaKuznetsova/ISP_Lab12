using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12
{
    class IMEIGenerator
    {
        private static IMEIGenerator instance = null;
        private int counter=0;
        private IMEIGenerator()
        {

        }

        public static IMEIGenerator getInstance()
        {
            if(instance == null)
            {
                instance = new IMEIGenerator();
            }
            return instance;
        }

        public string GenerateNewIMEI()
        {
            counter++;
            return counter.ToString();
        }
    }
}
