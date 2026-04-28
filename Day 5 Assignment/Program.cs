using Day5_Assignment;

using System;
using System.Collections.Generic;



class Program
{
    static void Main()
    {
        try
        {
            BankAccount account = new BankAccount("Sanket", 2000);

            while (true)
            {
                Console.WriteLine("\n1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter deposit amount: ");
                        double dAmt = double.Parse(Console.ReadLine());
                        account.Deposit(dAmt);
                        break;

                    case 2:
                        Console.Write("Enter withdrawal amount: ");
                        double wAmt = double.Parse(Console.ReadLine());
                        account.Withdraw(wAmt);
                        break;

                    case 3:
                        account.CheckBalance();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input format.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Thank you for using the banking system.");
        }
    }
}