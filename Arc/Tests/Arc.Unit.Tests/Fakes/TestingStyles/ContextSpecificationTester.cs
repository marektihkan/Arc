using System.Collections.Generic;
using Arc.Testing.Styles;
using Arc.Unit.Tests.Fakes.Entities;

namespace Arc.Unit.Tests.Fakes.TestingStyles
{
    internal class ContextSpecificationTester : ContextSpecification<Person>
    {
        public IList<string> InvokedActions { get; set; }

        public ContextSpecificationTester()
        {
            InvokedActions = new List<string>();
        }

        public override void Context()
        {
            InvokedActions.Add("Context");
        }

        public override void Because()
        {
            InvokedActions.Add("Because");
        }
    }
}