using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaskinia
{
    static class TextBuffer
    {
        private static string outputBuffer;
        
        public static void Add(string text)
        {
            outputBuffer += text + "\n";
        }

        public static void Display()
        {
            //Console.Clear();

            Console.Write(TextUtils.WordWrap(outputBuffer, Console.WindowWidth));
            Console.WriteLine("Co chcesz zrobic?");
            Console.Write(">>");

            outputBuffer = "";
        }

        internal static void Add(object inventoryWeight)
        {
            throw new NotImplementedException();
        }
    }
}
