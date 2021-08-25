using Book_Rickhter.Chapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Book_Rickhter
{
    static class Chapter5
    {
        class SomeRef
        { public Int32 x; }

        struct SomeVal
        { public Int32 x; }

        public static void Execute()
        {
            ChapterTools.PrintHeader("Chapter5");

            TypeConversation();

            CheckedUncheckedExample();

            ValueReferenceTypes();

            BoxingUnboxing();
        }

        private static void TypeConversation()
        {
            //In cases of loose precicion explicit conversation required, in other cases implicit conv is ok
            int i = 10;
            byte b = (byte)i;   //explicit conversation
            i = b;              //implicit conversation
        }

        private static void CheckedUncheckedExample()
        {
            Console.WriteLine("\n Checked/Unchecked:\n");
            //By default compiler don't check Overflow
            Byte b = 200;
            b += 100;
            Console.WriteLine("Byte b = 200;\nb += 100;\nresult: b = " + b + "\n");

            try
            {
                b = checked((byte)(200 + b));   //checked()
                checked                         //Same as above checked{}
                {
                    b += 200;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("b = checked((byte)(200 + b));\n" + e.Message);
            }
        }

        private static void ValueReferenceTypes()
        {
            Console.WriteLine("\n Value/Reference types:\n");

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

        private static void BoxingUnboxing()
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
