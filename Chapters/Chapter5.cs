using Book_Rickhter.Chapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Book_Rickhter
{
    class Chapter5
    {
        class SomeRef
        { public Int32 x; }

        struct SomeVal
        { public Int32 x; }

        public static void Execute()
        {
            ChapterTools.PrintHeader("Chapter5");
            ValueReferenceTypes();

            BoxingUnboxing();
        }

        public static void ValueReferenceTypes()
        {
            var rt = new SomeRef(); //Allocated in heap
            var vt = new SomeVal(); //Allocated in stack
            Console.WriteLine("class is " + (rt is ValueType ? "" : "not") + " ValueType");
            Console.WriteLine("struct is " + (vt is ValueType ? "" : "not") + " ValueType");

            rt.x = 1;
            vt.x = 1;

            var rt1 = rt; // only reference copied
            var vt1 = vt; // new struct added to stack and copied all fields

            rt1.x = 2; // changes rt and rt1
            vt1.x = 2; // changes only vt1

            Console.WriteLine("rt = " + rt.x + ", rt1 = " + rt1.x);
            Console.WriteLine("vt = " + vt.x + ", vt1 = " + vt1.x);
        }

        public static void BoxingUnboxing()
        {
            //Boxing
            //Allocate heap mem for struct + 2 fields: typeRef and SyncBlock
            ArrayList list = new ArrayList();
            list.Add(new SomeVal()); //boxing
            SomeVal vt = (SomeVal)list[0]; //unboxing

            Object o = vt; //boxing to o
            var vt1 = (SomeVal)o; // unboxing
        }
    }
}
