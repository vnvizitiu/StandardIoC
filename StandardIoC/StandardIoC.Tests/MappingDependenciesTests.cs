namespace StandardIoC.Tests
{
    using NUnit.Framework;
    
    [TestFixture]
    public class MappingDependenciesTests
    {
        [Test]
        public void MappingTest()
        {
            Container container = new Container();

            container.Register<Test1>();
            container.Register<TestBase, Test2>();
            container.Register<ITest3, Test3>();
            
            Test1 result = container.Resolve<Test1>();

            Assert.That(result, Is.Not.Null);
        }

        class Test1
        {
            public Test1(TestBase testBase, ITest3 test3)
            {
            }
        }

        abstract class TestBase
        {
        }

        class Test2 : TestBase
        {
        }

        interface ITest3
        {
        }

        class Test3 : ITest3
        {
        }
    }
}