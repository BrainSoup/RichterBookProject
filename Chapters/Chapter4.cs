using Book_Rickhter.Chapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Rickhter
{
    static class Chapter4
    {
        class Base
        { }

        class Derived : Base
        { }

        public static void Execute()
        {
            ChapterTools.PrintHeader("Chapter4");
            TypeConversation();

            StackAndHeap(); //No output
        }

        private static void TypeConversation()
        {
            Console.WriteLine("Type Conversation");
            //causing exceptions
            try
            {
                object o = new Base();
                Base b = (Base)o;
                Derived d = (Derived)o;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            //no exceptions
            {
                object o1 = new Base();
                if (o1 is Base)
                    Console.WriteLine("o1 is Base");

                if (o1 is Derived)
                    Console.WriteLine("o1 is Derived");

                var b1 = o1 as Base;
                var d1 = o1 as Derived;

                Console.WriteLine("b1 is " + (b1 == null ? "null" : "not null"));
                Console.WriteLine("o1 is " + (d1 == null ? "null" : "not null"));
            }

        }

        private static void StackAndHeap()
        {
            int i = 1;
            StackExample(i);
            #region StackDump
            //Heap
            //--empty-- //No Objects
            //Thread Stack
            //...       //Starting inside StackAndHeap()
            //  i
            #endregion
            //CLR compiles executed method code and create all needed object types
            StackObjectsExample();
        }

        private static void StackExample(int param)
        {
            float x, y = param;
            param = 10;
            #region StackDump
            //Heap
            //--empty-- //No Objects
            //Thread Stack
            //...       //Starting inside StackAndHeap()
            //  i   
            //  param           //Executed method params
            //  return address  //For executed method ExampleMethod()
            //  x = 0           //CLR initialize all local vars with null or 0, but still can't use explicitly uninit vars
            //  y = 10          //Local var
            #endregion
        }

        private static void StackObjectsExample()
        {
            #region HeapStackDump
            //Thread Stack
            //...
            //Heap
            //ObjectType Base
            //-Pointer to ObjectType - - - -
            //-SyncBlockIndex               |
            //-Static Fields                |
            //-Methods                      |
            //ObjectType Derived            |
            //-Same as ObjectType Base - - -|
            //------------------            |
            //ObjectType (System.Type)  <---  Base type for all type objects
            #endregion
            Base b;
            #region HeapStackDump
            //Thread Stack
            //...
            //Base -> null
            //Heap not changed
            #endregion
            b = new Derived();
            #region HeapStackDump
            //Thread Stack
            //...
            //Base - - - - - - - - - - - 
            //Heap                      |
            //Object Derived        <--- 
            //-Pointer to ObjectType - - 
            //-SyncBlockIndex           |
            //-Instance fields          |
            //ObjectType Base           |
            //ObjectType Derived   <---- 
            #endregion
        }
    }
}
