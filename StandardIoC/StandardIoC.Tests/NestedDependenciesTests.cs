namespace StandardIoC.Tests
{
    using NUnit.Framework;
    
    [TestFixture]
    public class NestedDependenciesTests
    {
        [Test]
        public void WhenCreatingAnInstanceThatRequiresOtherInstances_ShouldBuildWholeObjectGraph()
        {
            Container container = new Container();

            Test1 result = container.Resolve<Test1>();

            Assert.That(result, Is.Not.Null);
        }

        class Test1
        {
            public Test1(Test2 test2)
            {
            }
        }

        class Test2
        {
            public Test2(Test3 test3, Test4 test4)
            {
            }
        }

        class Test3
        {
        }

        class Test4
        {
        }
    }
}