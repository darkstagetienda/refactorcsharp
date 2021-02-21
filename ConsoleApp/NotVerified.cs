using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class NotVerified : IAccountState
    {
        private Action OnUnfreeze { get; }
        public IAccountState Close() => new Closed();

        public NotVerified(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(this.OnUnfreeze);

        public IAccountState Withdraw(Action subtractFromBalance) => this; 
    }
}
