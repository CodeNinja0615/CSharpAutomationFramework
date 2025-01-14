using CSharpSeleniumFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.tests
{
    [Parallelizable(ParallelScope.All)]
    public class Tests2: Base
    {
        [Test, Category("Regression")]
        public void Test4()
        {
            TestContext.Progress.WriteLine("Test4 ");
        }
    }
}
