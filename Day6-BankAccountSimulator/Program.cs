using System;
using System.Collections.Generic;

class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();
    static int nextAccountNumber = 1001;

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nBank Account Simulator");
            Console.WriteLine("1. Create new account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check balance");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    PerformTransaction("depositi");
                    break;
                case "3":
                    PerformTransaction("withdraw");
                    break;
                case "4":
                    CheckBalance();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void CreateAccount()
    {
        Console.Write("Enter account holder name: ");
        string name = Console.ReadLine();

        Console.Write("Set a 4-digit PIN code: ");
        string pin = Console.ReadLine();

        BankAccount newAccount = new BankAccount(nextAccountNumber, name, pin);
        accounts.Add(newAccount);
        Console.WriteLine($"Account created! Your account number is {nextAccountNumber}");
        nextAccountNumber++;
    }

    static BankAccount FindAccount()
    {
        Console.Write("Enter account number: ");
        int accNum = Convert.ToInt32(Console.ReadLine());

        BankAccount account = accounts.Find(a => a.AccountNumber == accNum);
        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return null;
        }

        Console.Write("Enter PIN code: ");
        string enteredPin = Console.ReadLine();

        if (!account.VerifyPin(enteredPin))
        {
            Console.WriteLine("Incorrect PIN.");
            return null;
        }

        return account;
    }

    static void PerformTransaction(string type)
    {
        BankAccount account = FindAccount();
        if (account == null) return;

        Console.Write($"Enter amount to {type}: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        if (type == "deposit")
        {
            account.Deposit(amount);
        }
        else if (type == "withdraw")
        {
            account.Withdraw(amount);
        }
    }

    static void CheckBalance()
    {
        BankAccount account = FindAccount();
        if (account == null) return;

        Console.WriteLine($" Current balance: {account.Balance:F2} BGN");
    }
}
public class BankAccount
{
    public int AccountNumber { get; }
    public string HolderName { get; }
    private string Pin { get; }
    public double Balance { get; private set; }

    public BankAccount(int accountNumber, string holderName, string pin)
    {
        AccountNumber = accountNumber;
        HolderName = holderName;
        Pin = pin;
        Balance = 0;
    }

    public bool VerifyPin(string inputPin)
    {
        return Pin == inputPin;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount must be greater than 0.");
            return;
        }

        Balance += amount;
        Console.WriteLine($" Deposited {amount:F2} BGN. New balance: {Balance:F2} BGN.");
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount must be greater than 0.");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine(" Not enough funds.");
            return;
        }

        Balance -= amount;
        Console.WriteLine($" Withdrawn {amount:F2} BGN. New balance: {Balance:F2} BGN.");
    }
}
