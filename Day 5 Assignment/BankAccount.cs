using System;
using System.Collections.Generic;
using System.Text;

namespace Day5_Assignment
{
    internal class BankAccount
    {
        public string AccountHolderName { get; set; }
        public double Balance { get; set; }

        private const double MIN_BALANCE = 1000;

        public BankAccount(string name, double initialBalance)
        {
            if (initialBalance < MIN_BALANCE)
                throw new ArgumentException("Initial balance must be at least ₹1000");

            AccountHolderName = name;
            Balance = initialBalance;
        }

        // Deposit Method
        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Deposit amount must be greater than 0");

            Balance += amount;
            Console.WriteLine($"₹{amount} deposited successfully.");
        }

        // Withdraw Method
        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Withdrawal amount must be greater than 0");

            if (amount > Balance)
                throw new InsufficientBalanceException("Cannot withdraw more than balance");

            if (Balance - amount < MIN_BALANCE)
                throw new InsufficientBalanceException("Minimum balance ₹1000 must be maintained");

            Balance -= amount;
            Console.WriteLine($"₹{amount} withdrawn successfully.");
        }

        // Check Balance
        public void CheckBalance()
        {
            Console.WriteLine($"Current Balance: ₹{Balance}");
        }
    }
}
