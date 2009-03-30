using Arc.Learning.Tests.Fakes.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using StructureMap;
using StructureMap.Attributes;

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
    }
}