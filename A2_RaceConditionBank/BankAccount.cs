using System;
using System.Threading;

namespace A2_RaceConditionBank;

public class BankAccount
{
    private int balance;
    private readonly object _lock = new object();
    
    public BankAccount(int initial) 
    { 
        balance = initial; 
    }
    
    public void Deposit(int amount) 
    { 
        lock (_lock)
        {
            int oldBalance = balance;
            balance += amount;
            Console.WriteLine($"Einzahlung +{amount,3} | Saldo: {oldBalance,4} → {balance,4} | Thread: {Thread.CurrentThread.ManagedThreadId}");
        }
        Thread.Sleep(500);
    }
    
    public void Withdraw(int amount) 
    {
        lock (_lock)
        {
            int oldBalance = balance;
            balance -= amount;
            Console.WriteLine($"Abhebung  -{amount,3} | Saldo: {oldBalance,4} → {balance,4} | Thread: {Thread.CurrentThread.ManagedThreadId}");
        }
        Thread.Sleep(500);
    }

    public int GetBalance() 
    {
        lock (_lock)
        {
            return balance;
        }
    }
}
