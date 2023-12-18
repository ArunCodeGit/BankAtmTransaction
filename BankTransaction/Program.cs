using BankTransaction.Models;
using System;
using System.Diagnostics;
using System.Threading.Channels;

namespace Bankapps
{
    public class BankApps
    {
        
        static void Main(string[] args)
        {
            ATM atmMachine = new ATM();
            bool flag = true;
            while(flag)
            {
                Console.Write("Account Number: ");
                int AccNo = Convert.ToInt32(Console.ReadLine());
                if(atmMachine.Is_Account_Valid(AccNo))
                {
                    Console.Write("PIN: ");
                    int PIN = Convert.ToInt32(Console.ReadLine());
                    if (atmMachine.Is_Pin_valid(AccNo, PIN))
                    {
                        Console.WriteLine("1: Withdraw");
                        Console.WriteLine("2: Deposit");
                        Console.WriteLine("3. Balance Enquiry");
                        Console.WriteLine("4. Change PIN");
                        Console.Write("Choose the option: ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Withdraw Amount: ");
                                double amt = Convert.ToDouble(Console.ReadLine());
                                atmMachine.WithdrawAmt(AccNo, PIN, amt);
                                break;

                            case 2:
                                Console.Write("Deposit Amount: ");
                                amt = Convert.ToDouble(Console.ReadLine());
                                atmMachine.DepositAmt(AccNo, amt);
                                break;
                            case 3:
                                double Balance = atmMachine.Load_Accounts[AccNo].Balance;
                                Console.WriteLine(Balance);
                                break;
                            case 4:
                                Console.Write("Enter Your current PIN: ");
                                PIN = Convert.ToInt32(Console.ReadLine());
                                if(atmMachine.Is_Pin_valid(atmMachine.Load_Accounts[AccNo].AccountNumber,PIN))
                                {
                                    Console.Write("Enter a New PIN: ");
                                    PIN = Convert.ToInt32(Console.ReadLine());
                                    atmMachine.Modify_PIN(PIN);
                                }
                                break;
                            default:
                                flag = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}