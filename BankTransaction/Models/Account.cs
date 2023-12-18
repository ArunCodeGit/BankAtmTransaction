using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransaction.Models
{
    public class Account
    {
        int _accountNumber;
        string _accountName;
        double _balance;
        int _pin;

        public int AccountNumber 
        { 
            get => _accountNumber; 
        }
        public double Balance
        {
            get => _balance;
        }
        public int Pin 
        {
            get { return _pin; }
        }
        public string AccountName 
        { 
            get => _accountName;  
        }

        public Account(int accountNumber, int pin)
        {
            this._accountNumber = accountNumber;
        }

        public Account(int accountNumber, string accName, double balance, int pin)
        {
            this._accountNumber = accountNumber;
            this._accountName = accName;
            this._balance = balance;
            this._pin = pin;
        }

        public Account()
        {
            
        }
        
        private bool Is_Sufficient_Amt(double amt)
        {
            bool Is_Sufficient = false;
            if (_balance>amt)
            {
                Is_Sufficient = true;
            }
            else { Console.WriteLine("Insufficient balance"); }
            return Is_Sufficient;
        }

        public void WithdrawAmount(double amt)
        {
            if(Is_Sufficient_Amt(amt))
            {
                _balance -= Math.Abs(amt);
                Console.WriteLine($"Holder Name: {_accountName}");
                Console.WriteLine($"Withdrawn Amount: {amt}");
            }
        }

        public void DepositAmount(double amt)
        {
            _balance += Math.Abs(amt);
            Console.WriteLine($"Holder Name: {_accountName}");
            Console.WriteLine($"Amount Deposited: {amt}");
        }

        public void Change_PIN(int Pin)
        {
            _pin = Pin;

        }
    }
}

enum Transactiontype
{
    Debit,
    Credit
}