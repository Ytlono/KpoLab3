using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Lab3
    {
        public static void Main(string[] args)
        {
            string fileIn = "text.txt";
            ParseII parse = new ParseII(fileIn);
            parse.Run();

            
        }
    }
}
