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
using System.Globalization;

namespace Arc.Domain.Units
{
    /// <summary>
    /// Currency.
    /// </summary>
    public class Currency
    {
        private static readonly IDictionary<string, string> _culture = new Dictionary<string, string>
                                                                  {
                                                                      {string.Empty, string.Empty},
                                                                      {CurrencyConstants.AUD, "en-AU"},
                                                                      {CurrencyConstants.BGN, "bg-BG"},
                                                                      {CurrencyConstants.CAD, "en-CA"},
                                                                      {CurrencyConstants.CHF, "fr-CH"},
                                                                      {CurrencyConstants.CZK, "cs-CZ"},
                                                                      {CurrencyConstants.DKK, "da-DK"},
                                                                      {CurrencyConstants.EEK, "et-EE"},
                                                                      {CurrencyConstants.EUR, "de-DE"},
                                                                      {CurrencyConstants.GBP, "en-GB"},
                                                                      {CurrencyConstants.HRK, "hr-HR"},
                                                                      {CurrencyConstants.HUF, "hu-HU"},
                                                                      {CurrencyConstants.JPY, "ja-JP"},
                                                                      {CurrencyConstants.LTL, "lt-LT"},
                                                                      {CurrencyConstants.LVL, "lv-LV"},
                                                                      {CurrencyConstants.NOK, "nb-NO"},
                                                                      {CurrencyConstants.PLN, "pl-PL"},
                                                                      {CurrencyConstants.RON, "ro-RO"},
                                                                      {CurrencyConstants.RUB, "ru-RU"},
                                                                      {CurrencyConstants.SEK, "sv-SE"},
                                                                      {CurrencyConstants.TRY, "tr-TR"},
                                                                      {CurrencyConstants.USD, "en-US"}
                                                                  };


        private readonly string _abbreviation;


        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        protected Currency()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="abbreviation">The abbreviation.</param>
        public Currency(string abbreviation)
        {
            _abbreviation = abbreviation;
        }


        /// <summary>
        /// Formats the specified number in current currency.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public string Format(decimal number)
        {
            return number.ToString("C", GetCultureInfo());
        }

        private CultureInfo GetCultureInfo()
        {
            return (_culture.ContainsKey(Abbreviation)) ? new CultureInfo(_culture[Abbreviation]) : null;
        }


        /// <summary>
        /// Gets the abbreviation.
        /// </summary>
        /// <value>The abbreviation.</value>
        public string Abbreviation
        {
            get { return _abbreviation; }
        }

        /// <summary>
        /// Gets the null currency.
        /// </summary>
        /// <value>The null currency.</value>
        public static Currency None { get { return new Currency(string.Empty); } }

        /// <summary>
        /// Gets the AUD.
        /// </summary>
        /// <value>The AUD.</value>
        public static Currency AUD { get { return new Currency(CurrencyConstants.AUD); } }

        /// <summary>
        /// Gets the BGN.
        /// </summary>
        /// <value>The BGN.</value>
        public static Currency BGN { get { return new Currency(CurrencyConstants.BGN); } }

        /// <summary>
        /// Gets the CAD.
        /// </summary>
        /// <value>The CAD.</value>
        public static Currency CAD { get { return new Currency(CurrencyConstants.CAD); } }

        /// <summary>
        /// Gets the CHF.
        /// </summary>
        /// <value>The CHF.</value>
        public static Currency CHF { get { return new Currency(CurrencyConstants.CHF); } }

        /// <summary>
        /// Gets the CZK.
        /// </summary>
        /// <value>The CZK.</value>
        public static Currency CZK { get { return new Currency(CurrencyConstants.CZK); } }

        /// <summary>
        /// Gets the DKK.
        /// </summary>
        /// <value>The DKK.</value>
        public static Currency DKK { get { return new Currency(CurrencyConstants.DKK); } }

        /// <summary>
        /// Gets the EEK.
        /// </summary>
        /// <value>The EEK.</value>
        public static Currency EEK { get { return new Currency(CurrencyConstants.EEK); } }

        /// <summary>
        /// Gets the EUR.
        /// </summary>
        /// <value>The EUR.</value>
        public static Currency EUR { get { return new Currency(CurrencyConstants.EUR); } }

        /// <summary>
        /// Gets the GBP.
        /// </summary>
        /// <value>The GBP.</value>
        public static Currency GBP { get { return new Currency(CurrencyConstants.GBP); } }

        /// <summary>
        /// Gets the HRK.
        /// </summary>
        /// <value>The HRK.</value>
        public static Currency HRK { get { return new Currency(CurrencyConstants.HRK); } }

        /// <summary>
        /// Gets the HUF.
        /// </summary>
        /// <value>The HUF.</value>
        public static Currency HUF { get { return new Currency(CurrencyConstants.HUF); } }

        /// <summary>
        /// Gets the JPY.
        /// </summary>
        /// <value>The JPY.</value>
        public static Currency JPY { get { return new Currency(CurrencyConstants.JPY); } }

        /// <summary>
        /// Gets the LTL.
        /// </summary>
        /// <value>The LTL.</value>
        public static Currency LTL { get { return new Currency(CurrencyConstants.LTL); } }

        /// <summary>
        /// Gets the LVL.
        /// </summary>
        /// <value>The LVL.</value>
        public static Currency LVL { get { return new Currency(CurrencyConstants.LVL); } }

        /// <summary>
        /// Gets the NOK.
        /// </summary>
        /// <value>The NOK.</value>
        public static Currency NOK { get { return new Currency(CurrencyConstants.NOK); } }

        /// <summary>
        /// Gets the PLN.
        /// </summary>
        /// <value>The PLN.</value>
        public static Currency PLN { get { return new Currency(CurrencyConstants.PLN); } }

        /// <summary>
        /// Gets the RON.
        /// </summary>
        /// <value>The RON.</value>
        public static Currency RON { get { return new Currency(CurrencyConstants.RON); } }

        /// <summary>
        /// Gets the RUB.
        /// </summary>
        /// <value>The RUB.</value>
        public static Currency RUB { get { return new Currency(CurrencyConstants.RUB); } }

        /// <summary>
        /// Gets the SEK.
        /// </summary>
        /// <value>The SEK.</value>
        public static Currency SEK { get { return new Currency(CurrencyConstants.SEK); } }

        /// <summary>
        /// Gets the TRY.
        /// </summary>
        /// <value>The TRY.</value>
        public static Currency TRY { get { return new Currency(CurrencyConstants.TRY); } }

        /// <summary>
        /// Gets the USD.
        /// </summary>
        /// <value>The USD.</value>
        public static Currency USD { get { return new Currency(CurrencyConstants.USD); } }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Currency left, Currency right)
        {
            var isLeftSideNull = (object) left == null;
            var isRightSideNull = (object)right == null;
            if (isLeftSideNull && isRightSideNull)
                return true;
            if (isLeftSideNull)
                return false;

            return left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Currency left, Currency right)
        {
            return !(left == right);
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
            if (obj == null || !(obj is Currency))
                return false;
            
            var currency = obj as Currency;
            return Abbreviation == currency.Abbreviation;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Abbreviation.GetHashCode();
        }
    }
}