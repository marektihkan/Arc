#region License

// Copyright (c) 2008-2009 Marek Tihkan (marektihkan@gmail.com)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Marek Tihkan nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

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