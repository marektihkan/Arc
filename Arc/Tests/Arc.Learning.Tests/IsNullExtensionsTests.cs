using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class IsNullExtensionsTests
    {

        [Test]
        public void Testing_null_equality_with_operator()
        {
            Assert.That(new Test<int>().IsNullEq(1), Is.False);
            Assert.That(new Test<int>().IsNullEq(default(int)), Is.False);
            Assert.That(new Test<object>().IsNullEq(null), Is.True);
            Assert.That(new Test<int?>().IsNullEq(null), Is.True);
        }

        [Test]
        public void Testing_null_equality_with_extensions()
        {
            Assert.That(new Test<int>().IsNull(1), Is.False);
            Assert.That(new Test<int>().IsNull(default(int)), Is.False);
            Assert.That(new Test<object>().IsNull(null), Is.True);
            Assert.That(new Test<int?>().IsNull(null), Is.True);
        }

    }

    public static class Ex
    {
        public static bool IsNull(this object @object)
        {
            return @object == null;
        }

        public static bool IsNull<T>(this T? @object) where T : struct
        {
            return @object.HasValue;
        }
    }

    public class Test<T>
    {
        public bool IsNull(T element)
        {
            return element.IsNull();
        }

        public bool IsNullEq(T element)
        {
            return element == null;
        }
    }
}