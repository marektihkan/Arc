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
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Arc.Domain.Security
{
    /// <summary>
    /// Service for password generation and computing hashes.
    /// <remarks>
    /// Service uses MD5 for hashing and generates password from safe letters.
    /// </remarks>
    /// </summary>
    public class PasswordGenerator : IPasswordGenerator
    {
        private static readonly char[] AllCharacters = "abcdefghjkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789".ToCharArray();
        private static readonly char[] LowercaseCharacters = "abcdefghjklmnpqrstuvwxyz".ToCharArray();
        private static readonly char[] UppercaseCharacters = "ABCDEFGHJKLMNPQRSTUVWXYZ".ToCharArray();
        private static readonly char[] Numbers = "23456789".ToCharArray();
        private static readonly Random _random = new Random(GetSeed());
        private static object _lock = new object();

        /// <summary>
        /// Creates the password.
        /// </summary>
        /// <remarks>
        /// It generates password from safe letters.
        /// </remarks>
        /// <param name="length">The length.</param>
        /// <returns>Generated password.</returns>
        public string Create(int length)
        {
            var characters = CreateCharacterList(length);
            ShuffleList(characters);
            return new string(characters.ToArray());
        }

        /// <summary>
        /// Computes the password hash.
        /// </summary>
        /// <remarks>
        /// It uses MD5 for hashing. 
        /// </remarks>
        /// <param name="password">The password.</param>
        /// <returns>Password hash.</returns>
        public string ComputeHash(string password)
        {
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashBytes = new MD5CryptoServiceProvider().ComputeHash(passwordBytes);
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }


        //TODO: Extract Rendom object

        /// <summary>
        /// Creates random character list.
        /// </summary>
        /// <param name="length">The length of list.</param>
        /// <returns></returns>
        private static List<char> CreateCharacterList(int length)
        {
            var result = new List<char>();

            var allCharacters = length % 3;
            var charactersPerType = (length - allCharacters) / 3;

            result.AddRange(GetRandomCharacters(charactersPerType, LowercaseCharacters));
            result.AddRange(GetRandomCharacters(charactersPerType, UppercaseCharacters));
            result.AddRange(GetRandomCharacters(charactersPerType, Numbers));

            if (allCharacters > 0)
                result.AddRange(GetRandomCharacters(allCharacters, AllCharacters));

            return result;
        }

        /// <summary>
        /// Shuffles the list.
        /// </summary>
        /// <param name="list">The list.</param>
        private static void ShuffleList(IList<char> list)
        {
            var length = list.Count;
            var minValue = 0;
            var maxValue = length - 1;

            for (var current = 0; current < length; current++)
            {
                var newPosition = GetRandomNumber(minValue, maxValue);
                var swapingCharacter = list[current];
                list[current] = list[newPosition];
                list[newPosition] = swapingCharacter;
            }
        }

        /// <summary>
        /// Gets the list of random characters.
        /// </summary>
        /// <param name="count">The list count.</param>
        /// <param name="characters">The characters list.</param>
        /// <returns></returns>
        private static char[] GetRandomCharacters(int count, char[] characters)
        {
            var minValue = 0;
            var maxValue = characters.Length - 1;

            if (maxValue < 1 || count < 1)
                return null;

            var result = new char[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = characters[GetRandomNumber(minValue, maxValue)];
            }
            return result;
        }

        /// <summary>
        /// Creates the random.
        /// </summary>
        /// <returns></returns>
        private static int GetRandomNumber(int min, int max)
        {
            lock (_lock)
            {
                return _random.Next(min, max);
            }
        }

        /// <summary>
        /// Gets the seed.
        /// </summary>
        /// <returns></returns>
        private static int GetSeed()
        {
            return (int)DateTime.Now.Ticks;
        }        
    }
}