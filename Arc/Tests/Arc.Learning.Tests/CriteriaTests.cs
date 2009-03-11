using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Arc.Domain.Identity;
using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Data.NHibernate;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Registry;
using NHibernate;
using NHibernate.Criterion;
using Ninject.Core;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class CriteriaTests
    {

        [Test]
        public void TEST_NAME()
        {
            var actual = Restrictions.Eq("PROP", "VAL");

            Assert.That(actual.PropertyName, Is.EqualTo("PROP"));
            Assert.That(actual.Value, Is.EqualTo("VAL"));
        }

        [Test]
        [Ignore("Test")]
        public void Should_create_citeria()
        {
            Bootstrapper.Configure();
            ServiceLocator.Load(typeof(DataTestConfiguration).FullName + ", Arc.Learning.Tests");

            var repository = ServiceLocator.Resolve<IRepository<Dummy>>();

            var criteria = repository.CreateCriteria().Add(Restrictions.Eq("Name", "mY"));

            //var i = ForProperty<Dummy>(x => x.Name.Contains("My"));

            repository.CreateCriteria().Add(ForProperty<Dummy>(x => x.Name == "My"));
        }

        public ICriterion ForProperty<T>(Expression<Func<T, bool>> expression)
        {
            var memberExpression = GetMemberExpression(expression);
            var propertyInfo = memberExpression.Key.Member as PropertyInfo;
            //var func = expression.Compile();

            //var entity = (T) Activator.CreateInstance(typeof(T));
            //var value = func(entity);


            var result = Restrictions.Eq(propertyInfo.Name, memberExpression.Value);
            return result;
            
            return null;
        }


        public void Map<T>(T entity, Expression<Func<T, object>> expression)
        {
//            var memberExpression = GetMemberExpression(expression);
//            var propertyInfo = memberExpression.Member as PropertyInfo;
//            var func = expression.Compile();
//            var value = func(entity);
//            writer.WriteLine("<node name=\"{0}\">{1}</node>", propertyInfo.Name, value);
        }



        private KeyValuePair<MemberExpression, object>GetMemberExpression<T>(Expression<Func<T, bool>> expression)
        {
            MemberExpression memberExpression = null;
            object memberValue = null;
            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                var body = (UnaryExpression)expression.Body;
                memberExpression = body.Operand as MemberExpression;
            }
            else if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = expression.Body as MemberExpression;
            }
            else if (expression.Body.NodeType == ExpressionType.Equal)
            {
                var body = (BinaryExpression) expression.Body;
                memberExpression = body.Left as MemberExpression;
                memberValue = body.Right as object;
                if (memberExpression == null)
                {
                    memberExpression = body.Right as MemberExpression;
                    memberValue = body.Left as object;
                }
            }
            if (memberExpression == null)
            {
                throw new ArgumentException("Not a member access", "member");
            }
            return new KeyValuePair<MemberExpression, object>(memberExpression, memberValue);
        }

    }

    public class Dummy : IntegerIdentityEntity
    {
        public virtual string Name { get; set; }
    }

    public class DataTestConfiguration : StandardModule
    {
        public static string FullName
        {
            get
            {
                var type = typeof(DataTestConfiguration);
                return type.FullName + ", " + type.Assembly.FullName;
            }
        }

        public override void Load()
        {
            Bind<IRegistry>().To<LocalRegistry>().ForMembersOf<UnitOfWorkFactory>();
        }
    }
}