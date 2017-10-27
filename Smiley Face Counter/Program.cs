using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smiley_Face_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test1 = new string[] { ":D", ":~)", ";~D", ":)" };        //expect 4
            string[] test2 = new string[] { ":)", ":(", ":D", ":O", ":;" } ;   //expect 2
            string[] test3 = new string[] { ";]", ":[", ";*", ":$", ";-D" };   //expect 1
            string[] test4 = new string[] { ";", ")", ";*", ":$", "8-D" };     //expect 0
            Console.WriteLine(CountSmileys(test1));
            Console.WriteLine(CountSmileys(test2));
            Console.WriteLine(CountSmileys(test3));
            Console.WriteLine(CountSmileys(test4));
            Console.ReadLine();
        }

        public static int CountSmileys(string[] smileys)
        {
            int smileyCount = 0;
            for (int i = 0; i < smileys.Length; i++)
            {
                int eyeLocation = -1;
                string currentString = smileys[i];
                if (currentString.IndexOf(':') != -1)
                {
                    eyeLocation = currentString.IndexOf(':');
                }

                if (currentString.IndexOf(';') != -1)
                {
                    eyeLocation = currentString.IndexOf(';');
                }

                if (eyeLocation != -1  && (eyeLocation < (currentString.Length)-1))    // have to make sure there is no index error if eyeLocation is at the end of current string
                {
                    if (currentString[eyeLocation + 1 ] == 'D' || currentString[eyeLocation + 1] == ')')
                    {
                        smileyCount += 1;
                    }
                    if (currentString[eyeLocation + 1] == '-' || currentString[eyeLocation + 1] == '~')
                    {
                        if (currentString[eyeLocation + 2] == 'D' || currentString[eyeLocation + 2] == ')')
                        {
                            smileyCount += 1;
                        }
                    }
                }
            }
            return smileyCount;
        }
    }
}
