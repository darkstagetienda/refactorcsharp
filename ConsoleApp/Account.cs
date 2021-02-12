using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Account //testing the account state is explicit

        ///how many ways there are to execute the deposit method?
        ///-drop line 17
        ///- another way is to pause the test and actually increase the balance. line 21
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }

        private Action OnUnfreeze { get; }
        public Account (Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }
        // #1 negative case:  Deposit 10, Close, Deposit 1, Balance = 10
        // #2 positive case:  Deposit 10, Deposit 1, Balance = 11
        //#6 Deposit 10, Freeze, Deposit 1 ,  OnUnfreeze was called
        //#7 Depost 10, Freeze, Deposit 1, IsFrozen = false 
        //#8 Depost 10, Deposit 1, OnUnFreeze was not called 
        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;
            if(this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreeze();
            }
            //deposit money
            this.Balance += amount;
        }

        //#3: Deposit 10, withdraw 1, Balance =10
        //#4:  Deposit 10, Verify, Close, Withdraw 1, Balance = 10
        //#5 Deposit 10, Verify, Withdraw 1, Balance = 9
      

        //#9: Deposit 10, Verify, Freeze, Withdraw 1, IsFrozen = false
        //#10: Deposit 10, Verify, Freeze, Withdraw 1, IsFrozen = false
        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return; //or do something
            if (this.IsClosed)
                return;
            if (this.IsFrozen) //repetido y requiere su own brand-new test  #10
            {
                this.IsFrozen = false;
                this.OnUnfreeze();
            }
            //withdraw mone
            this.Balance -= amount;
        }

        public void HoldVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }
        public void Freeze()
        {
            if (this.IsClosed)
                return;
            if (!this.IsVerified)
                return;
            this.IsFrozen = true;
        }
    }
}
