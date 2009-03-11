using System.Collections.Generic;
using Arc.Testing.Styles;
using Arc.Unit.Tests.Fakes.Entities;

namespace Arc.Unit.Tests.Fakes.TestingStyles
{
    internal class BaseStyleTester : BaseStyle<Person>
    {
        public IList<string> InvokedActions { get; set; }

        public BaseStyleTester()
        {
            InvokedActions = new List<string>();
        }

        protected override void ContextSetUp()
        {
        }

        public override void CleanUp()
        {
            InvokedActions.Add("CleanUp");
        }
    }
}