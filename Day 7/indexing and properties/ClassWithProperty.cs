using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Indexing {
    /using above propoerty with objects of the class:

    // In the Main method, we can create instances of the Person and Employee classes and use their properties to set and get values.
    // Object of Person class
    // Person person = new Person();
    // person.Age = 25; // Setting the age using the property
    // Console.WriteLine($"Person's Age: {person.Age}"); // Getting the age using the property

    // Object of Employee class
    // Employee employee = new Employee();
    // employee.Salary = 25000; // Setting the salary using the property
    // Console.WriteLine($"Employee's Salary: {employee.Salary}"); // Getting the salary using the property

    // Major diff between property and fucntion is that property is used to represent the attributes of an object,
    // while function is used to represent the behavior of an object.
    // Property is accessed like a field, while a function is called like a method.
    // Properties are typically used to encapsulate data and provide controlled access to it,
    // while functions are used to perform actions or calculations based on the data.

    class Employee {
        private decimal _salary; // This is a private field that will hold the salary of the employee.
        public decimal Salary {
            get { return _salary; } // The 'get' accessor allows us to retrieve the value of '_salary'.
            set // The 'set' accessor allows us to set the value of '_salary' while ensuring that it cannot be less than the minimum wage.
            {
                if (value < 18000) // Assuming 15000 is the minimum wage.
                {
                    throw new ArgumentException("Salary cannot be less than the minimum wage.");
                }
                _salary = value;
            }
        }
    }

    class Person {
        private int _age;// This is a private field that will hold the age of the person.
        public int Age {
            get { return _age; } // The 'get' accessor allows us to retrieve the value of '_age'.
            set // The 'set' accessor allows us to set the value of '_age' while ensuring that it cannot be negative.
            {
                if (value < 0) {
                    throw new ArgumentException("Age cannot be negative.");
                }
                _age = value;
            }
        }
    }
    internal class ClassWithProperty {
    }
}

// INdexers v/s property in C#
// 1. Purpose: Properties are used to represent the attributes of an object,
// while indexers are used to represent a collection of objects that can be accessed using an index.
// 2. Syntax: Properties are defined using the 'get' and 'set' accessors,
// while indexers are defined using the 'this' keyword followed by square brackets [].
// 3. Access: Properties are accessed like fields, while indexers are accessed using an index.
// 4. Use Cases: Properties are typically used to encapsulate data and provide controlled access to it,
// while indexers are used to create custom collections that can be accessed using an index, similar to arrays or lists.

//limitation of indexers is that they can only have one parameter,
//which is the index, while properties can have multiple parameters (in the case of indexer properties).