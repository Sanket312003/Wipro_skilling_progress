using System;
using System.Collections.Generic;
using System.Text;

namespace Day5_Assignment
{
    internal class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message) { }
    }
}
