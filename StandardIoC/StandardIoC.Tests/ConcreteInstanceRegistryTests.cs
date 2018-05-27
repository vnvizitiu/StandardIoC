namespace StandardIoC.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ConcreteInstanceRegistryTests
    {
        [Test]
        public void WhenProvidedAnInstanceOfAConcreteType_ShouldReturnThatInstance()
        {
            Container container = new Container();

            Test1 exisitingInstance = new Test1();
            container.Register<Test1>(exisitingInstance);

            Test1 resolvedInstance = container.Resolve<Test1>();

            Assert.That(resolvedInstance, Is.SameAs(exisitingInstance));
        }

        public class Test1
        {
        }

        [Test]
        public void WhenProvidedWithABaseType_ShouldReturnThatInstance()
        {
            Container container = new Container();

            Test2 exisitingInstance = new Test2();
            container.Register<TestBase>(exisitingInstance);

            TestBase resolvedInstance = container.Resolve<TestBase>();

            Assert.That(resolvedInstance, Is.SameAs(exisitingInstance));
        }

        abstract class TestBase
        {
        }

        class Test2 : TestBase
        {
        }
    }
}