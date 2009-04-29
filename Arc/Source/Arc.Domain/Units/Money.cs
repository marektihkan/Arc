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

using System;

namespace Arc.Domain.Units
{
    /// <summary>
    /// Class for money.
    /// </summary>
    public class Money : IComparable<Money>
    {
        private decimal _amount;
        private Currency _currency;


        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        protected Money()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currency">The currency.</param>
        public Money(decimal amount, Currency currency)
        {
            _amount = amount;
            _currency = currency;
        }


        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public virtual decimal Amount
        {
            get { return _amount; }
            protected set { _amount = value; }
        }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        public virtual Currency Currency
        {
            get { return _currency; }
            protected set { _currency = value; }
        }

        /// <summary>
        /// Adds the specified addend to money.
        /// </summary>
        /// <param name="addend">The addend.</param>
        /// <returns></returns>
        public Money Add(Money addend)
        {
            return this + addend;
        }

        /// <summary>
        /// Subtracts the specified subtrahend from money.
        /// </summary>
        /// <param name="subtrahend">The subtrahend.</param>
        /// <returns></returns>
        public Money Subtract(Money subtrahend)
        {
            return this - subtrahend;
        }

        /// <summary>
        /// Multiplies the money.
        /// </summary>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        public Money Multiply(int multiplier)
        {
            return this * multiplier;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <param name="addend">The addend.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator +(Money augend, Money addend)
        {
            CheckCurrency(augend, addend);
            return new Money(augend.Amount + addend.Amount, augend.Currency);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="minuend">The minuend.</param>
        /// <param name="subtrahend">The subtrahend.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator -(Money minuend, Money subtrahend)
        {
            CheckCurrency(minuend, subtrahend);
            return new Money(minuend.Amount - subtrahend.Amount, minuend.Currency);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator *(Money multiplicand, int multiplier)
        {
            return new Money(multiplicand.Amount * multiplier, multiplicand.Currency);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="multiplier">The multiplier.</param>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator *(int multiplier, Money multiplicand)
        {
            return multiplicand * multiplier;
        }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(Money left, Money right)
        {
            return left.CompareTo(right) == 1;
        }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(Money left, Money right)
        {
            return left.CompareTo(right) == -1;
        }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(Money left, Money right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(Money left, Money right)
        {
            return left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Money left, Money right)
        {
            var isLeftSideNull = (object) left == null;
            var isRightSideNull = (object) right == null;
            
            if (isLeftSideNull && isRightSideNull)
                return true;
            
            return !isLeftSideNull && left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Money left, Money right)
        {
            return !(left == right);
        }

        private static void CheckCurrency(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Cannot add/subtract money in different currencies");
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This object is less than the <paramref name="other"/> parameter.
        /// Zero
        /// This object is equal to <paramref name="other"/>.
        /// Greater than zero
        /// This object is greater than <paramref name="other"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><c>other</c> is null.</exception>
        public virtual int CompareTo(Money other)
        {
            if (other == null)
                throw new ArgumentNullException("other", "Money should not be null.");

            CheckCurrency(this, other);
            return Amount.CompareTo(other.Amount);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Money))
                return false;

            var money = obj as Money;
            return money.Amount == Amount && money.Currency == Currency;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Amount.GetHashCode() ^ Currency.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return Currency.Format(Amount);
        }
    }
}