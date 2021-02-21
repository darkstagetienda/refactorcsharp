using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Frozen : IFreezable
    {
        private Action _OnUnfreeze { get; }
        public Frozen(Action onUnfreeze)
        {
            this._OnUnfreeze = onUnfreeze;
        }
        public IFreezable Deposit()
        {
            this._OnUnfreeze();
            return new Active();
        }

        public IFreezable Freeze() => this;


        public IFreezable Withdraw()
        {
            this._OnUnfreeze();
            return new Active();
        }
    }
}
