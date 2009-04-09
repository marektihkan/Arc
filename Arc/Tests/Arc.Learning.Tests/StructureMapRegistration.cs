using Arc.Learning.Tests.Fakes.Model;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using StructureMap;
using StructureMap.Attributes;
using StructureMap.Pipeline;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class StructureMapRegistration
    {
        [Test]
        public void Should_register_to_factory_method()
        {
            var container = new Container();

            container.Configure(x =>
                x.ForRequestedType<IObjectFactory>()
                    .AddConcreteType<ObjectFactoryImpl>()
                    .CacheBy(InstanceScope.Singleton));

            container.Configure(x =>
                x.BuildInstancesOf<ICreatedObject>()
                    .AddInstances(y => y.ConstructedBy(context => context.GetInstance<IObjectFactory>().Create()))
                    .CacheBy(InstanceScope.PerRequest));


            var firstCreatedObject = container.GetInstance<ICreatedObject>();
            var secondCreatedObject = container.GetInstance<ICreatedObject>();

            Assert.That(firstCreatedObject, Is.Not.SameAs(secondCreatedObject));
        }

        [Test]
        public void Should_register_to_factory_method_without_generics()
        {
            var wasFactoryMethodCalled = false;
            var container = new Container();

            container.Configure(x =>
                x.ForRequestedType<IObjectFactory>()
                    .AddConcreteType<ObjectFactoryImpl>()
                    .CacheBy(InstanceScope.Singleton));

            var instance = new ConstructorInstance<object>(context =>
            {
                wasFactoryMethodCalled = true;
                return context.GetInstance<IObjectFactory>().Create();
            });

            container.SetDefault(typeof(ICreatedObject), instance);

            var actual = container.GetInstance<ICreatedObject>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(wasFactoryMethodCalled, Is.True);
        }

        [Test]
        public void Should_register_to_factory_method_without_generics_with_scope()
        {
            var wasFactoryMethodCalledCount = 0;
            var container = new Container();

            container.Configure(x =>
                x.ForRequestedType<IObjectFactory>()
                    .AddConcreteType<ObjectFactoryImpl>()
                    .CacheBy(InstanceScope.Singleton));

            container.Configure(x => x.ForRequestedType(typeof(ICreatedObject)).CacheBy(InstanceScope.Singleton));

            var instance = new ConstructorInstance<object>(context =>
            {
                wasFactoryMethodCalledCount++;
                return context.GetInstance<IObjectFactory>().Create();
            });

            container.SetDefault(typeof(ICreatedObject), instance);

            var first = container.GetInstance<ICreatedObject>();
            var second = container.GetInstance<ICreatedObject>();

            Assert.That(first, Is.Not.Null);
            Assert.That(first, Is.SameAs(second));
            Assert.That(wasFactoryMethodCalledCount, Is.EqualTo(1));
        }

        [Test]
        [ExpectedException(typeof (StructureMapException))]
        public void Cannot_build_nhibernate_configuration()
        {
            var container = new Container();

            container.Configure(x => 
                x.BuildInstancesOf<Configuration>()
                    .AddInstances(y => y.ConstructedBy(context => new Configuration().Configure()))
                    .CacheBy(InstanceScope.Singleton));

            container.Configure(x =>
                x.BuildInstancesOf<ISessionFactory>()
                    .AddInstances(y => y.ConstructedBy(context => context.GetInstance<Configuration>().BuildSessionFactory()))
                    .CacheBy(InstanceScope.Singleton));

         
            var actual = container.GetInstance<ISessionFactory>();

            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void Should_register_service_for_conrete_type()
        {
            var container = new Container();

            container.Configure(x =>
                x.ForRequestedType<ICreatedObject>()
                    .AddConcreteType<CreatedObjectImpl>());

            container.Configure(x =>
                x.ForRequestedType<IHostObject>()
                    .AddConcreteType<HostObjectImpl>());

        }
    }
}