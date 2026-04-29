using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Indexing {
    //With the help of indexing we can access the elements of an array or a collection using their index.
    //Steps for implemting indexing in C#:
    //Step 1: Define a class that will represent the collection you want to index.
    //Step 2: Implement the indexer in the class. An indexer is defined using the 'this' keyword followed by square brackets [].
    //Step 3: Inside the indexer, you can define the logic to get or set the value based on the index provided.
    //Step 4: Create an instance of the class and use the indexer to access or modify the elements of the collection.

    // Properties and Indexers are very in that they are used to access and modify
    // the elements of a collection.
    // 
    internal class Program {
        static void Main(string[] args) {
        }
    }
    class MyCollection// This class represents a collection of integers and implements an indexer to access its elements.
    {
        private int[] data = new int[10]; // This array will hold the integers in the collection.
                                          // Implementing the indexer
        public int this[int index] // This is the indexer definition. It allows us to access elements of the collection using an index.
        {
            get// The 'get' accessor is used to retrieve the value at the specified index.
            {
                if (index < 0 || index >= data.Length) // OR condition to check if the index is within the bounds of the array.
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return data[index];
            }
        }
        set // The 'set' accessor is used to assign a value to the specified index.
        {
            if (index< 0 || index >= data.Length) {
            throw new IndexOutOfRangeException("Index out of range");
        }
        data[index] = value;
                    }
    }
}