using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    interface IFreezable
    {
        IFreezable Deposit();
        IFreezable Withdraw();
        IFreezable Freeze();

    }
}
