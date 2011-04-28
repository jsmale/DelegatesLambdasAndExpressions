using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesLambdasAndExpressions
{
    [TestClass]
    public class AnonymousDelegateTests
    {
        public class TestClass
        {
            public TestArg Arg { get; set; }
        }

        public class TestArg { }

        [TestMethod]
        public void EventHandlerTest()
        {
            object sender = "My Sender";
            var eventArgs = new EventArgs();            

            object testEventSender = null;
            EventArgs testEventArgs = null;
            var eventHandled = false;

            EventHandler eventHandler = null;
            eventHandler(sender, eventArgs);

            Assert.AreEqual(sender, testEventSender);
            Assert.AreEqual(eventArgs, testEventArgs);
            Assert.IsTrue(eventHandled);
        }

        [TestMethod]
        public void PredicateTest()
        {
            var predicateExecuted = false;
            Predicate<string> stringIsNotNullPredicate = null;
            var result = stringIsNotNullPredicate("I'm not null");
            Assert.IsTrue(result);
            Assert.IsTrue(predicateExecuted);
        }

        [TestMethod]
        public void ComparisonTest()
        {
            var comparisonExecuted = false;
            var x = 3; var y = 7;
            Comparison<int> useCompareTo = null;
            var result = useCompareTo(x, y);
            Assert.AreEqual(x.CompareTo(y), result);
            Assert.IsTrue(comparisonExecuted);
        }

        [TestMethod]
        public void ConverterTest()
        {
            var converterExecuted = false;
            var genericTestArg = new TestArg();
            Converter<TestArg, TestClass> convertTestArgToTestClass = null;
            var result = convertTestArgToTestClass(genericTestArg);
            Assert.AreEqual(genericTestArg, result.Arg);
            Assert.IsTrue(converterExecuted);
        }

        [TestMethod]
        public void ActionTest()
        {
            var testActionExecuted = false;
            Action action = null;
            action();
            Assert.IsTrue(testActionExecuted);
        }

        [TestMethod]
        public void ActionWithArgTest()
        {
            TestArg testGenericDelegateArg = null;
            var genericTestArg = new TestArg();
            Action<TestArg> actionWithTestArg = null;
            actionWithTestArg(genericTestArg);
            Assert.AreEqual(genericTestArg, testGenericDelegateArg);
        }

        [TestMethod]
        public void FunctionTest()
        {
            var genericNoArgFunctionReturnValue = new TestClass();
            Func<TestClass> noArgFunction = null;
            var result = noArgFunction();
            Assert.AreEqual(genericNoArgFunctionReturnValue, result);
        }

        [TestMethod]
        public void FunctionWithArgTest()
        {
            var functionExecuted = false;
            var genericTestArg = new TestArg();
            Func<TestArg, TestClass> functionWithArg = null;
            var result = functionWithArg(genericTestArg);
            Assert.AreEqual(genericTestArg, result.Arg);
            Assert.IsTrue(functionExecuted);
        }
    }
}
