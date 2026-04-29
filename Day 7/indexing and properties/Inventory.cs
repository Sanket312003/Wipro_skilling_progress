using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Indexers_Properties {
    public class Inventory {
        private List<Product> _products;

        // Constructor
        public Inventory() {
            _products = new List<Product>();
        }

        // Indexer by integer index (User Story 4 & 5)
        public Product this[int index] {
            get {
                if (index < 0 || index >= _products.Count)
                    throw new IndexOutOfRangeException($"Index {index} is out of range. Valid range: 0 to {_products.Count - 1}");
                return _products[index];
            }
            set {
                if (index < 0 || index >= _products.Count)
                    throw new IndexOutOfRangeException($"Index {index} is out of range. Valid range: 0 to {_products.Count - 1}");
                _products[index] = value;
            }
        }

        // Optional: Indexer by product name (bonus functionality)
        public Product this[string name] {
            get {
                var product = _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (product == null)
                    throw new KeyNotFoundException($"Product '{name}' not found");
                return product;
            }
        }

        // Method to add products to inventory
        public void AddProduct(Product product) {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _products.Add(product);
        }

        // Method to remove product
        public bool RemoveProduct(string name) {
            var product = _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null) {
                return _products.Remove(product);
            }
            return false;
        }

        // Property to get total number of products
        public int Count {
            get { return _products.Count; }
        }

        // Method to display all products
        public void DisplayAllProducts() {
            Console.WriteLine("\n=== Inventory List ===");
            for (int i = 0; i < _products.Count; i++) {
                Console.WriteLine($"[{i}] {_products[i]}");
            }
            Console.WriteLine("=====================\n");
        }
    }
}
