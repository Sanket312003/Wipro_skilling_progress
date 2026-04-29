using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace _1_SearchingAlgorithm {
    internal class LinearSearch {

        // Steps for implementing Linear Search and BinarySearch via methods are like below:
        // Step 1 : Create a method for linear search and binary search
        // Step 2 : Take input from user for array and element to be searched    
        // Step 3 : Call the method for linear search and binary search and pass the array and element to be searched as parameters
        // Steo 4 : Display the result of linear search and binary search
        // Step 5: We can show time complexity of linear search and binary search in milliseconds.

        // Linear Search Methods

        //Linear Search Method
        public static int LinearSearch(int[] arr, int element) {
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == element) {
                    return i; // Return the index of the found element
                }
            }
            return -1; // Return -1 if the element is not found
        }

        Console.WriteLine("Enter the size of the array:");
        int size = int.Parse(Console.ReadLine()); // taking input for size of array
                int[] arr = new int[size]; // creating an array of given size
                Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i<size; i++) {
            arr[i] = int.Parse(Console.ReadLine()); // taking input for elements of array
            }
            Console.WriteLine("Enter the element to be searched:");
        int element = int.Parse(Console.ReadLine()); // taking input for element to be searched
            Console.WriteLine("Linear Search Result:");

        int linearSearchResult = LinearSearch(arr, element);
        // calling the linear search method and storing the result in a variable
        if (linearSearchResult != -1)// this condition is used to check if the element is found in the array or not.
                                        // If the element is found, it will return the index of the element in the array,
                                        // otherwise it will return -1.
        {
            Console.WriteLine($"Element found at index: {linearSearchResult}");
        }
        else {
            Console.WriteLine("Element not found in the array.");
        }
    }
}