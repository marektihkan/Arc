using System;
using System.Collections.Generic;
using Arc.Testing.Styles;
using Arc.Unit.Tests.Fakes.Entities;

namespace Arc.Unit.Tests.Fakes.TestingStyles
{
    internal class BaseStyleTester : BaseStyle<Person>
    {
        public IList<string> InvokedActions { get; set; }
        public IDictionary<string, Action> Actions { get; set; }
        

        public BaseStyleTester()
        {
            InvokedActions = new List<string>();
            Actions = new Dictionary<string, Action>();
        }

        protected override void ContextSetUp()
        {
            ExecuteAction("ContextSetUp");
        }

        public override void CleanUp()
        {
            InvokedActions.Add("CleanUp");
        }

        protected void ExecuteAction(string name)
        {
            if (Actions.ContainsKey(name))
                Actions[name].Invoke();
        }
    }
}