using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerTest
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
            ConfigTest();
        }
        protected abstract void ConfigTest();
    }
}
