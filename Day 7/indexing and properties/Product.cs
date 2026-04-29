using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Indexers_Properties {
    public class Product {
        // Private fields
        private string _name;
        private decimal _price;
        private int _quantity;

        // Constructor
        public Product(string name, decimal price, int quantity) {
            _name = name;
            Price = price;      // Using property setter for validation
            Quantity = quantity; // Using property setter for validation
        }

        // Property for Name
        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        // Property for Price with validation (User Story 3)
        public decimal Price {
            get { return _price; }
            set {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative");
                _price = value;
            }
        }

        // Property for Quantity with validation (User Story 3)
        public int Quantity {
            get { return _quantity; }
            set {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be negative");
                _quantity = value;
            }
        }

        // Override ToString for easy display
        public override string ToString() {
            return $"Product: {Name}, Price: ${Price:F2}, Quantity: {Quantity}";
        }
    }
}
