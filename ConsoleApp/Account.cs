using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Account
    {
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;
            //deposit money
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return; //or do something
            //withdraw mone
        }

        public void HoldVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }
    }
}
