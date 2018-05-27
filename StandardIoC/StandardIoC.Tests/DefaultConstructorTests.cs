namespace StandardIoC.Tests
{
    using NUnit.Framework;
    
    using StandardIoC;
    
    [TestFixture]
    public class DefaultConstructorTests
    {
        [Test]
        public void WhenRequestingATypeWithDefaultConstructor_ShouldReturnInstance()
        {
            Container container = new Container();

            TestClass result = container.Resolve<TestClass>();

            Assert.That(result, Is.Not.Null);
        }

        public class TestClass
        {

        }
    }
}