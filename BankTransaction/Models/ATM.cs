using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BankTransaction.Models
{
    public class ATM
    {
        public Dictionary<int, Account> Load_Accounts = new Dictionary<int, Account>();

        public ATM()
        {
            Load_AccountData();
        }

        public bool Is_Account_Valid(int accNo)
        {
            bool Is_acount_Valid = false;
            if (Load_Accounts.ContainsKey(accNo))
            {
                Account account = Load_Accounts[accNo];
                Is_acount_Valid = true;
            }
            return Is_acount_Valid;
        }

        public bool Is_Pin_valid(int accNo, int pin)
        {
            bool Is_Pin_valid = false;
            if(Load_Accounts.ContainsKey(accNo))
            {
                Account account = Load_Accounts[accNo];
                if (account.Pin == pin)
                {
                    Is_Pin_valid = true;
                }
            }
            return Is_Pin_valid;
        }

        public void Modify_PIN(int pin)
        {
            Account account = new Account();
            account.Change_PIN(pin);
        }

        public void DepositAmt(int accNo, double withdrawAmt)
        {
            //if(Is_Account_Valid(accNo))
            //{
                Account account = Load_Accounts[accNo];
                account.DepositAmount(withdrawAmt);
                //Verify_Balance(account);
            //}
        }

        public void WithdrawAmt(int accNo, int pin, double withdrawAmt)
        {
            //if(Is_Account_Valid(accNo))
            //{
            //    if(Is_Pin_valid(accNo, pin))
            //    {
                    Account account = Load_Accounts[accNo];
                    account.WithdrawAmount(withdrawAmt);
                    Verify_Balance(account);
            //    }
            //}
        }

        public void Verify_Balance(Account account)
        {
            Console.WriteLine($"Available Balance is: {account.Balance}");
        }

        private void Load_AccountData()
        {
            Load_Accounts.Add(9876541, new Account(9876541, "Arunkumar", 10000, 4321));
            Load_Accounts.Add(9876542, new Account(9876542, "Martin", 11000, 4321));
            Load_Accounts.Add(9876543, new Account(9876543, "Joe", 20315, 4321));
            Load_Accounts.Add(9876544, new Account(9876544, "Jai", 31350, 4321));
            Load_Accounts.Add(9876545, new Account(9876545, "Deepak", 33110, 4321));
            Load_Accounts.Add(9876546, new Account(9876546, "Kumar", 5121, 4321));
        }              
    }
}
