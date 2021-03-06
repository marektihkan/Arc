#region License
//
//   Copyright 2009 Marek Tihkan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License
//
#endregion

namespace Arc.Testing.Styles
{
    /// <summary>
    /// Behavior Driven Development style: Arrange Act Assert. 
    /// </summary>
    /// <typeparam name="TSystemUnderTest">The type of the system under test.</typeparam>
    public class ArrangeActAssert<TSystemUnderTest> : BaseStyle<TSystemUnderTest>
    {
        /// <summary>
        /// Sets up context.
        /// </summary>
        protected override void ContextSetUp()
        {
            Arrange();
            Act();
        }

        /// <summary>
        /// Setups context.
        /// </summary>
        public virtual void Arrange()
        {
        }

        /// <summary>
        /// Acts on context.
        /// </summary>
        public virtual void Act()
        {
        }
    }
}