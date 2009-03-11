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