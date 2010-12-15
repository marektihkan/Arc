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

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arc.Domain.Units
{
    /// <summary>
    /// Bag of money.
    /// </summary>
    public class Moneybag
    {
        private readonly IDictionary<Currency, Money> _moneyBag = new Dictionary<Currency, Money>();

        /// <summary>
        /// Gets the bag.
        /// </summary>
        /// <value>The bag.</value>
        protected IDictionary<Currency, Money> Bag
        {
            get { return _moneyBag; }
        }

        /// <summary>
        /// Adds the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        public void Add(Money money)
        {
            if (money == null) return;

            var currency = money.Currency;
            if (Bag.ContainsKey(currency))
            {
                Bag[currency] += money;
            }
            else
            {
                Bag.Add(currency, money);
            }
        }

        /// <summary>
        /// Gets the <see cref="Arc.Domain.Units.Money"/> with the specified currency.
        /// </summary>
        /// <value></value>
        public Money this[Currency currency]
        {
            get
            {
                return Bag.ContainsKey(currency) ? Bag[currency] : null;
            }
        }

        /// <summary>
        /// Gets the all money in bag.
        /// </summary>
        /// <value>The money.</value>
        public Money[] Money
        {
            get { return Bag.Values.ToArray(); }
        }

        /// <summary>
        /// Removes the specified currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        public void Remove(Currency currency)
        {
            Bag.Remove(currency);
        }

        /// <summary>
        /// Determines whether the specified currency is in bag.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>
        /// 	<c>true</c> if the specified currency is in bag; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Currency currency)
        {
            return Bag.ContainsKey(currency);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var money in Bag.Values)
            {
                result.Append(money);
                result.Append("; ");
            }
            result.Remove(result.Length - 2, 2);

            return result.ToString();
        }
    }
}