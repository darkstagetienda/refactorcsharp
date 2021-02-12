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
        private Action ManageUnfreezing { get; set; }
        public Account (Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
            this.ManageUnfreezing = () =>
            {
                if (this.IsFrozen)
                {
                    this.Unfreeze();
                }
                else
                {
                    this.StayUnfrozen();
                }
            };
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
            this.ManageUnfreezing();
            //deposit money
            this.Balance += amount;
        }

        //#3: Deposit 10, withdraw 1, Balance =10
        //#4:  Deposit 10, Verify, Close, Withdraw 1, Balance = 10
        //#5 Deposit 10, Verify, Withdraw 1, Balance = 9
        //#9: Deposit 10, Verify, Freeze, Withdraw 1, IsFrozen = false
        //#10: Deposit 10, Verify, Freeze, Withdraw 1, IsFrozen = false
        //#11: Deposit 10, Verify, Withdraw 1, OnUnfreeze was not called
        //sure that OnUnfreeze callback was not invoke on an account wich was not frozen before
        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return; //or do something
            if (this.IsClosed)
                return;
            ManageUnfreezing();
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

        private void Unfreeze()
        {
            this.IsFrozen = false;
            this.OnUnfreeze();
        }
        private void StayUnfrozen()
        {

        }
    }
}
