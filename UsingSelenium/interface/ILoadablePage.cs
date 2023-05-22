using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingSelenium.Interface
{
    public interface ILoadablePage
    {
        void WaitUntilPageIsLoaded();
    }
}
