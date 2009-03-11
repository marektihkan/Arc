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
using System.Collections;
using System.Web;
using System.Web.SessionState;

namespace Arc.Infrastructure.Registry
{
    /// <summary>
    /// Adapter for <see cref="HttpSessionState"/>.
    /// </summary>
    public class HttpSessionStateAdapter : IDictionary
    {
        private readonly HttpSessionState _sessionState;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpSessionStateAdapter"/> class.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="HttpContext"/> is not currently available.</exception>
        public HttpSessionStateAdapter() : this(HttpContext.Current.Session)
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("HttpContext is not currently available.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpSessionStateAdapter"/> class.
        /// </summary>
        /// <param name="sessionState">State of the session.</param>
        public HttpSessionStateAdapter(HttpSessionState sessionState)
        {
            _sessionState = sessionState;
        }


        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.IDictionary"/> object contains an element with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="T:System.Collections.IDictionary"/> object.</param>
        /// <returns>
        /// true if the <see cref="T:System.Collections.IDictionary"/> contains an element with the key; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="key"/> is null.
        /// </exception>
        public bool Contains(object key)
        {
            return _sessionState[key.ToString()] != null;
        }

        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="T:System.Collections.IDictionary"/> object.
        /// </summary>
        /// <param name="key">The <see cref="T:System.Object"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to use as the value of the element to add.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// An element with the same key already exists in the <see cref="T:System.Collections.IDictionary"/> object.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.IDictionary"/> is read-only.
        /// -or-
        /// The <see cref="T:System.Collections.IDictionary"/> has a fixed size.
        /// </exception>
        public void Add(object key, object value)
        {
            _sessionState.Add(key.ToString(), value);
        }

        /// <summary>
        /// Removes all elements from the <see cref="T:System.Collections.IDictionary"/> object.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.IDictionary"/> object is read-only.
        /// </exception>
        public void Clear()
        {
            _sessionState.RemoveAll();
        }

        /// <summary>
        /// Not supported operation.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="NotSupportedException">This is not supported.</exception>
        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotSupportedException("This is not supported.");
        }

        /// <summary>
        /// Removes the element with the specified key from the <see cref="T:System.Collections.IDictionary"/> object.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.IDictionary"/> object is read-only.
        /// -or-
        /// The <see cref="T:System.Collections.IDictionary"/> has a fixed size.
        /// </exception>
        public void Remove(object key)
        {
            _sessionState.Remove(key.ToString());
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified key.
        /// </summary>
        /// <value></value>
        public object this[object key]
        {
            get { return _sessionState[key.ToString()]; }
            set { _sessionState[key.ToString()] = value; }
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.ICollection"/> object containing the keys of the <see cref="T:System.Collections.IDictionary"/> object.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// An <see cref="T:System.Collections.ICollection"/> object containing the keys of the <see cref="T:System.Collections.IDictionary"/> object.
        /// </returns>
        public ICollection Keys
        {
            get { return _sessionState.Keys; }
        }

        /// <summary>
        /// Not supported operation.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// </returns>
        public ICollection Values
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IDictionary"/> object is read-only.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IDictionary"/> object is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly
        {
            get { return _sessionState.IsReadOnly; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IDictionary"/> object has a fixed size.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IDictionary"/> object has a fixed size; otherwise, false.
        /// </returns>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _sessionState.GetEnumerator();
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.ICollection"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="array"/> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> is less than zero.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="array"/> is multidimensional.
        /// -or-
        /// <paramref name="index"/> is equal to or greater than the length of <paramref name="array"/>.
        /// -or-
        /// The number of elements in the source <see cref="T:System.Collections.ICollection"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/>.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The type of the source <see cref="T:System.Collections.ICollection"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.
        /// </exception>
        public void CopyTo(Array array, int index)
        {
            _sessionState.CopyTo(array, index);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        public int Count
        {
            get { return _sessionState.Count; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        public object SyncRoot
        {
            get { return _sessionState.SyncRoot; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
        /// </summary>
        /// <value></value>
        /// <returns>true if access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe); otherwise, false.
        /// </returns>
        public bool IsSynchronized
        {
            get { return _sessionState.IsSynchronized; }
        }
    }
}