
// Question
//problem statement based on Indexers and Property:
//IN an ecommerce application, we have a class called 'Product' that represents a product in the inventory.
//Each product has a name, price, and quantity. We want to create a collection of products and allow users to
//access and modify the products using both properties and indexers.
//IN an ecommerce application, we have a class called 'Product' that represents a product in the inventory.
//Each product has a name, price, and quantity. We want to create a collection of products and allow users to
//access and modify the products using both properties and indexers.

//User story 1: As a user, I want to be able to access the name, price, and quantity of a product using properties so that I can easily retrieve and display this information.
//User story 2: As a user, I want to be able to access and modify products in the collection using indexers so that I can easily manage the inventory.
//User story 3: As a user, I want to ensure that the price of a product cannot be set to a negative value and the quantity cannot be set to a negative number using properties so that I can maintain data integrity.
//User story 4: As a user, I want to ensure that when I access a product using an indexer, it returns the correct product based on the index so that I can efficiently manage the inventory.
//User story 5: As a user, I want to ensure that when I modify a product using an indexer, it updates the correct product in the collection so that I can maintain accurate inventory records.

using _4_Indexers_Properties;

class Program {
    static void Main(string[] args) {
        // Create inventory
        Inventory inventory = new Inventory();

        // Add products (User Story 1)
        inventory.AddProduct(new Product("Laptop", 999.99m, 10));
        inventory.AddProduct(new Product("Mouse", 29.99m, 50));
        inventory.AddProduct(new Product("Keyboard", 79.99m, 30));
        inventory.AddProduct(new Product("Monitor", 299.99m, 15));

        // Display all products
        inventory.DisplayAllProducts();

        // User Story 1: Access product information using properties
        Console.WriteLine("=== Accessing Product Properties ===");
        Product firstProduct = inventory[0];
        Console.WriteLine($"Product Name: {firstProduct.Name}");
        Console.WriteLine($"Product Price: ${firstProduct.Price:F2}");
        Console.WriteLine($"Product Quantity: {firstProduct.Quantity}");
        Console.WriteLine();

        // User Story 4: Access products using indexer
        Console.WriteLine("=== Accessing Products via Indexer ===");
        for (int i = 0; i < inventory.Count; i++) {
            Console.WriteLine($"Index {i}: {inventory[i].Name} - ${inventory[i].Price:F2}");
        }
        Console.WriteLine();

        // User Story 5: Modify products using indexer
        Console.WriteLine("=== Modifying Products via Indexer ===");
        Console.WriteLine("Before modification:");
        Console.WriteLine(inventory[1]); // Mouse product

        // Modify the product at index 1
        inventory[1].Price = 24.99m;
        inventory[1].Quantity = 45;

        Console.WriteLine("After modification:");
        Console.WriteLine(inventory[1]);
        Console.WriteLine();

        // User Story 3: Test validation
        Console.WriteLine("=== Testing Validation ===");
        try {
            // This should throw an exception
            Product invalidProduct = new Product("Invalid", -10.00m, 5);
        }
        catch (ArgumentException ex) {
            Console.WriteLine($"Validation error (price): {ex.Message}");
        }

        try {
            // This should throw an exception
            Product invalidProduct = new Product("Invalid", 10.00m, -5);
        }
        catch (ArgumentException ex) {
            Console.WriteLine($"Validation error (quantity): {ex.Message}");
        }
        Console.WriteLine();

        // Demonstrate index out of range handling
        Console.WriteLine("=== Index Out of Range Handling ===");
        try {
            Product invalidAccess = inventory[100]; // This will throw exception
        }
        catch (IndexOutOfRangeException ex) {
            Console.WriteLine($"Index error: {ex.Message}");
        }
        Console.WriteLine();

        // Bonus: Using name indexer
        Console.WriteLine("=== Accessing by Name Indexer ===");
        try {
            Product laptop = inventory["Laptop"];
            Console.WriteLine($"Found: {laptop}");

            Product notFound = inventory["Tablet"]; // This will throw
        }
        catch (KeyNotFoundException ex) {
            Console.WriteLine($"Name indexer error: {ex.Message}");
        }
        Console.WriteLine();

        // Complete inventory management example
        Console.WriteLine("=== Complete Inventory Management ===");
        inventory.DisplayAllProducts();

        // Replace entire product at index 2 using indexer
        inventory[2] = new Product("Gaming Keyboard", 129.99m, 20);
        Console.WriteLine("After replacing product at index 2:");
        inventory.DisplayAllProducts();

        // Remove a product
        inventory.RemoveProduct("Mouse");
        Console.WriteLine("After removing Mouse:");
        inventory.DisplayAllProducts();

        Console.WriteLine($"Total products in inventory: {inventory.Count}");
    }
}
