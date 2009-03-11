using System.Collections.Generic;
using Arc.Testing.Styles;
using Arc.Unit.Tests.Fakes.Entities;

namespace Arc.Unit.Tests.Fakes.TestingStyles
{
    internal class ArrangeActAssertTester : ArrangeActAssert<Person>
    {
        public IList<string> InvokedActions { get; set; }

        public ArrangeActAssertTester()
        {
            InvokedActions = new List<string>();
        }

        public override void Arrange()
        {
            InvokedActions.Add("Arrange");
        }

        public override void Act()
        {
            InvokedActions.Add("Act");
        }
    }
}