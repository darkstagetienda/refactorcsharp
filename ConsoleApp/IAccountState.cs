using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState Withdraw(Action subtractFromBalance);
        IAccountState Freeze() => this;
        IAccountState HolderVerified() => this;
        IAccountState Close() => this;

    }
}
