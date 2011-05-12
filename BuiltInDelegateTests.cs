using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesLambdasAndExpressions
{
    [TestClass]
    public class BuiltInDelegateTests
    {
        public class TestClass
        {
            public TestArg Arg { get; set; }
        }

        public class TestArg { }

        object testEventSender;
        EventArgs testEventArgs;

        void MyEventHandler(object sender, EventArgs eventArgs)
        {
            testEventSender = sender;
            testEventArgs = eventArgs;
        }

        [TestMethod]
        public void EventHandlerTest()
        {
            object sender = "My Sender";
            var eventArgs = new EventArgs();
            EventHandler eventHandler = MyEventHandler;
            eventHandler(sender, eventArgs);
            Assert.AreEqual(sender, testEventSender);
            Assert.AreEqual(eventArgs, testEventArgs);
        }

        bool StringIsNotNull(string value)
        {
            return value != null;
        }

        [TestMethod]
        public void PredicateTest()
        {
            Predicate<string> stringIsNotNullPredicate = StringIsNotNull;
            var result = stringIsNotNullPredicate("I'm not null");
            Assert.IsTrue(result);
        }

        int MyIntComparison(int x, int y)
        {
            return x.CompareTo(y);
        }

        [TestMethod]
        public void ComparisonTest()
        {
            var x = 3; var y = 7;
            Comparison<int> useCompareTo = MyIntComparison;
            var result = useCompareTo(x, y);
            Assert.AreEqual(x.CompareTo(y), result);
        }

        TestClass TestClassConverter(TestArg arg)
        {
            return new TestClass {Arg = arg};
        }

        [TestMethod]
        public void ConverterTest()
        {
            var genericTestArg = new TestArg();
            Converter<TestArg, TestClass> convertTestArgToTestClass = TestClassConverter;
            var result = convertTestArgToTestClass(genericTestArg);
            Assert.AreEqual(genericTestArg, result.Arg);
        }

        bool testActionExecuted;

        void MyAction()
        {
            testActionExecuted = true;
        }

        [TestMethod]
        public void ActionTest()
        {
            testActionExecuted = false;
            Action action = MyAction;
            action();
            Assert.IsTrue(testActionExecuted);
        }

        TestArg testGenericDelegateArg;

        void MyActionWithArg(TestArg arg)
        {
            testGenericDelegateArg = arg;
        }

        [TestMethod]
        public void ActionWithArgTest()
        {
            testGenericDelegateArg = null;
            var genericTestArg = new TestArg();
            Action<TestArg> actionWithTestArg = MyActionWithArg;
            actionWithTestArg(genericTestArg);
            Assert.AreEqual(genericTestArg, testGenericDelegateArg);
        }

        TestClass genericNoArgFunctionReturnValue;

        TestClass MyNoArgFunction()
        {
            return genericNoArgFunctionReturnValue;
        }

        [TestMethod]
        public void FunctionTest()
        {
            genericNoArgFunctionReturnValue = new TestClass();
            Func<TestClass> noArgFunction = MyNoArgFunction;
            var result = noArgFunction();
            Assert.AreEqual(genericNoArgFunctionReturnValue, result);
        }

        [TestMethod]
        public void FunctionWithArgTest()
        {
            var genericTestArg = new TestArg();
            Func<TestArg, TestClass> functionWithArg = TestClassConverter;
            var result = functionWithArg(genericTestArg);
            Assert.AreEqual(genericTestArg, result.Arg);
        }
    }
}
