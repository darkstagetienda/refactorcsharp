using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Active : IAccountState
    {
        private Action OnUnfreeze;

        public Active(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }
        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }


        public IAccountState Freeze() => new Frozen(this.OnUnfreeze);


        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }
        public IAccountState HolderVerified() => this;
    }
}
