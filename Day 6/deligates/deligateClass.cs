using System;
using System.Collections.Generic;
using System.Text;


namespace Delegates {

    // define a delegate type called "MathOperation" that takes two integers as parameter and returns an integer as output.
    // outside the main record of the class and before the main method of the class.
    public delegate int MathOperation(int x, int y);
    public class delegateClass {

        public class delegateOne {
            public static int Add(int x, int y) {
                return x + y;
            }
            public static int Subtract(int x, int y) {
                return x - y;
            }
            public static int Multiply(int x, int y) {
                return x * y;
            }
        }
    }
}





﻿
namespace Delegates {

    // define a delegate type called "MathOperation" that takes two integers as parameter and returns an integer as output.
    // outside the main record of the class and before the main method of the class.
    public delegate int MathOperation(int x, int y);
    public class delegateClass {

        public class delegateOne {
            public static int Add(int x, int y) {
                return x + y;
            }
            public static int Subtract(int x, int y) {
                return x - y;
            }
            public static int Multiply(int x, int y) {
                return x * y;
            }
        }
    }
}
