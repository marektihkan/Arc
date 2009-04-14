using System;
using System.Collections.Generic;
using Arc.Testing.Styles;
using Arc.Unit.Tests.Fakes.Entities;

namespace Arc.Unit.Tests.Fakes.TestingStyles
{
    internal class GivenWhenThenTester : GivenWhenThen<Person>
    {
        public IList<string> InvokedActions { get; set; }
 
        public GivenWhenThenTester()
        {
            InvokedActions = new List<string>();
        }

        public override void Given()
        {
            InvokedActions.Add("Given");
        }

        public override void When()
        {
            InvokedActions.Add("When");
        }
    }
}