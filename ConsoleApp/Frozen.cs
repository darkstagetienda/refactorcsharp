using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Frozen : IAccountState
    {
        private Action _OnUnfreeze { get; }
        public Frozen(Action onUnfreeze)
        {
            this._OnUnfreeze = onUnfreeze;
        }
        public IAccountState Deposit(Action addToBalance)
        {
            this._OnUnfreeze();
            addToBalance();
            return new Active(this._OnUnfreeze);
        }

        public IAccountState Freeze() => this;


        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this._OnUnfreeze();
            subtractFromBalance();
            return new Active(this._OnUnfreeze);
        }
    }
}
