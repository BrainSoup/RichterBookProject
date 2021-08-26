using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Rickhter.Chapters
{
    class Chapter6
    {
        #region StaticClass

        class SomeClass { }

        interface SomeInterface { }

        static class StaticClass
        //    : SomeClass   //Error: static class can derive only System.Object
        //    : SomeInterface   //Error: static classes can't implement interfaces
        {
            //int i = 0;  //Error: static class can't have non static members
        }

        //static struct StaticStruct { }    //Error: struct can't be defined as static

        //static void SomeMethod(StaticClass sc) { }    //Error: static class can't be used as instance or parameter
        #endregion

        public static void Execute()
        {
            ChapterTools.PrintHeader("Chapter6");
        }

    }
}
