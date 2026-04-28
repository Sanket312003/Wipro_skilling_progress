using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Day4_Assignment
{
    class TransactionService
    {
        private List<Transaction> history = new List<Transaction>();
        private Dictionary<string, double> balances = new Dictionary<string, double>();
        private Queue<Transaction> pending = new Queue<Transaction>();
        private Stack<Transaction> processedStack = new Stack<Transaction>();
        private HashSet<string> transactionIds = new HashSet<string>();

        // Create account
        public void AddAccount(string accountId, double initialBalance)
        {
            if (balances.ContainsKey(accountId))
            {
                Console.WriteLine("Account already exists.");
                return;
            }

            balances[accountId] = initialBalance;
            Console.WriteLine("Account created.");
        }

        // Add transaction (goes to queue)
        public void AddTransaction()
        {
            Console.Write("Transaction ID: ");
            string id = Console.ReadLine();

            if (!transactionIds.Add(id))
            {
                Console.WriteLine("Duplicate Transaction ID!");
                return;
            }

            Console.Write("Account ID: ");
            string accId = Console.ReadLine();

            if (!balances.ContainsKey(accId))
            {
                Console.WriteLine("Account not found!");
                return;
            }

            Console.Write("Amount (+deposit / -withdraw): ");
            double amt = double.Parse(Console.ReadLine());

            Transaction t = new Transaction
            {
                TransactionId = id,
                AccountId = accId,
                Amount = amt
            };

            pending.Enqueue(t); // Queue
            Console.WriteLine("Transaction added to queue.");
        }

        // Process next transaction (FIFO)
        public void ProcessTransaction()
        {
            if (pending.Count == 0)
            {
                Console.WriteLine("No pending transactions.");
                return;
            }

            Transaction t = pending.Dequeue();

            double currentBalance = balances[t.AccountId];

            // Simple validation: no overdraft
            if (currentBalance + t.Amount < 0)
            {
                Console.WriteLine("Transaction failed (insufficient funds).");
                return;
            }

            balances[t.AccountId] += t.Amount;

            history.Add(t);              // List
            processedStack.Push(t);      // Stack (for rollback)

            Console.WriteLine("Transaction processed.");
        }

        // Rollback last transaction
        public void Rollback()
        {
            if (processedStack.Count == 0)
            {
                Console.WriteLine("Nothing to rollback.");
                return;
            }

            Transaction last = processedStack.Pop();

            // Reverse the transaction
            balances[last.AccountId] -= last.Amount;

            history.Remove(last);

            Console.WriteLine("Last transaction rolled back.");
        }

        // View balances
        public void ViewBalances()
        {
            Console.WriteLine("Account Balances:");
            foreach (var acc in balances)
            {
                Console.WriteLine($"{acc.Key} → {acc.Value}");
            }
        }

        // View history
        public void ViewHistory()
        {
            Console.WriteLine("Transaction History:");
            foreach (var t in history)
            {
                Console.WriteLine($"{t.TransactionId} | {t.AccountId} | {t.Amount}");
            }
        }
    }

}
