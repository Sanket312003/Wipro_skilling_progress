using Day4_Assignment;

class Program
{
    static void Main()
    {
        TransactionService service = new TransactionService();

        while (true)
        {
            Console.WriteLine("\n1. Add Account");
            Console.WriteLine("2. Add Transaction");
            Console.WriteLine("3. Process Transaction");
            Console.WriteLine("4. Rollback Last");
            Console.WriteLine("5. View Balances");
            Console.WriteLine("6. View History");
            Console.WriteLine("7. Exit");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Account ID: ");
                    string acc = Console.ReadLine();
                    Console.Write("Initial Balance: ");
                    double bal = double.Parse(Console.ReadLine());
                    service.AddAccount(acc, bal);
                    break;

                case 2:
                    service.AddTransaction();
                    break;

                case 3:
                    service.ProcessTransaction();
                    break;

                case 4:
                    service.Rollback();
                    break;

                case 5:
                    service.ViewBalances();
                    break;

                case 6:
                    service.ViewHistory();
                    break;

                case 7:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}