using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Active : IFreezable
    {
        public IFreezable Deposit()
        {
            throw new NotImplementedException();
        }

        public IFreezable Freeze()
        {
            throw new NotImplementedException();
        }

        public IFreezable Withdraw()
        {
            throw new NotImplementedException();
        }
    }
}
