using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Rickhter.Chapters
{
    class Chapter7
    {
        class SomeClass { }

        // Only priminive types can be declared as const
        //const fields are part of Type not instance (like static members)
        const int c_int= 5; //const field variable (actually const is not a field)

        //readonly work not only with primitive types
        readonly SomeClass c = new SomeClass();
        //readonly fields are part of instance
        //readonly fields can be initialised only in constructor
        static readonly string str_ro = "Readonly string"; //readonly field variable

        static void RefExample(ref string p) { }

        public static void Execute()
        {
            ChapterTools.PrintHeader("Chapter7");

            const string str = "Only priminive types can be declared as const"; //local variable
            const SomeClass c = null;   // And objects initialised by null

            //readonly string str1 = "somthing";    //readonly can't be applied to local variable

            //RefExample(ref str1);   //Error: constants can't be ref params
            //RefExample(ref str_ro); //Error: readonly can't be ref params, except constructors
        }
    }
}
