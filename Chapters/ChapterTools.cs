using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Rickhter.Chapters
{
    static class ChapterTools
    {
        public static void PrintHeader(string header)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(header);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
