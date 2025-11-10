using System;
using System.Threading;

namespace A2_RaceConditionBank;

public class BankAccount
{
    private int balance;
    BankAccount account = new BankAccount(1000);
    
    public BankAccount(int initial) 
    { 
        balance = initial; 
    }
    
    public void Deposit(int amount) 
    { 
        int count = 150;
        int result = amount - count;
        Console.WriteLine("" + result);
        Thread.Sleep(500);
    }
    
    public void Withdraw(int amount) 
    { 
        int count = 100;
        int result = amount + count;
        Console.WriteLine("" + result);
        Thread.Sleep(500);
    }

    public int GetBalance() 
    {
        return balance;
    }
}
