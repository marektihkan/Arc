using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;

namespace Arc.Unit.Tests.Infrastructure.Data.NHibernate
{
    public class AssertCriteria
    {
        public static void AreEqual(DetachedCriteria actual, DetachedCriteria expected)
        {
            new AssertCriteriaImpl().AreEqual(expected, actual);
        }

        public static void AreEqual(ICriteria actual, ICriteria expected)
        {
            new AssertCriteriaImpl().AreEqual(expected, actual);
        }

        private class AssertCriteriaImpl
        {
            private readonly Hashtable _visitedObjects = new Hashtable();
            private readonly Stack<string> _fieldPath = new Stack<string>();

            private void AssertDictionariesAreEqual(IDictionary expected, IDictionary actual)
            {
                Assert.AreEqual(expected.Keys.Count, actual.Keys.Count, _fieldPath.Peek() + ".Count");
                foreach (object key in expected.Keys)
                {
                    if (!actual.Contains(key))
                        Assert.AreEqual(key, null, _fieldPath.Peek() + "[" + key + "]");

                    AssertObjectsAreEqual(expected[key], actual[key], "[" + key + "]");
                }
            }

            private void AssertListsAreEqual(IList expected, IList actual)
            {
                Assert.AreEqual(expected.Count, actual.Count, _fieldPath.Peek() + ".Count");
                for (var i = 0; i < expected.Count; i++)
                {
                    AssertObjectsAreEqual(expected[i], actual[i], "[" + i + "]");
                }
            }

            private void PushName(string name)
            {
                if (_fieldPath.Count == 0)
                {
                    _fieldPath.Push(name);
                }
                else
                {
                    _fieldPath.Push(_fieldPath.Peek() + name);
                }
            }

            private void AssertObjectsAreEqual(object expected, object actual, string name)
            {
                PushName(name);
                string fieldPath = _fieldPath.Peek();

                if (expected == null)
                {
                    Assert.AreEqual(expected, actual, fieldPath);
                    _fieldPath.Pop();
                    return;
                }

                System.Type expectedType = expected.GetType();
                Assert.AreEqual(expectedType, actual.GetType(), fieldPath);

                if ((expectedType.IsValueType)
                    || (expected is Type)
                    || (expected is string))
                {
                    Assert.AreEqual(expected, actual, fieldPath);
                    _fieldPath.Pop();
                    return;
                }

                if (_visitedObjects.Contains(expected))
                {
                    _fieldPath.Pop();
                    return;
                }

                _visitedObjects.Add(expected, null);

                if (expected is IDictionary)
                {
                    AssertDictionariesAreEqual((IDictionary)expected, (IDictionary)actual);
                    _fieldPath.Pop();
                    return;
                }

                if (expected is IList)
                {
                    AssertListsAreEqual((IList)expected, (IList)actual);
                    _fieldPath.Pop();
                    return;
                }

                while (expectedType != null)
                {
                    foreach (FieldInfo fieldInfo in expectedType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                    {
                        AssertObjectsAreEqual(fieldInfo.GetValue(expected), fieldInfo.GetValue(actual), "." + fieldInfo.Name);
                    }
                    expectedType = expectedType.BaseType;
                }

                _fieldPath.Pop();
            }

            private void AssertObjectsAreEqual(object expected, object actual)
            {
                _visitedObjects.Clear();
                _fieldPath.Clear();
                AssertObjectsAreEqual(expected, actual, expected.GetType().Name);
            }

            public void AreEqual(ICriteria expected, ICriteria actual)
            {
                AssertObjectsAreEqual(expected, actual);
            }

            public void AreEqual(DetachedCriteria expected, DetachedCriteria actual)
            {
                AssertObjectsAreEqual(expected, actual);
            }
        }
    }
}