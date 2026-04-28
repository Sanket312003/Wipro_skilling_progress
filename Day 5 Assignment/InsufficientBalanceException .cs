using System;
using System.Collections.Generic;
using System.Text;

namespace Day5_Assignment
{
    internal class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

}
