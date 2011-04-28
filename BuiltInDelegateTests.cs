﻿using System;
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

        [TestMethod]
        public void EventHandlerTest()
        {
            object sender = "My Sender";
            var eventArgs = new EventArgs();
            EventHandler eventHandler = null;
            eventHandler(sender, eventArgs);
            Assert.AreEqual(sender, testEventSender);
            Assert.AreEqual(eventArgs, testEventArgs);
        }

        [TestMethod]
        public void PredicateTest()
        {
            Predicate<string> stringIsNotNullPredicate = null;
            var result = stringIsNotNullPredicate("I'm not null");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ComparisonTest()
        {
            var x = 3; var y = 7;
            Comparison<int> useCompareTo = null;
            var result = useCompareTo(x, y);
            Assert.AreEqual(x.CompareTo(y), result);
        }

        [TestMethod]
        public void ConverterTest()
        {
            var genericTestArg = new TestArg();
            Converter<TestArg, TestClass> convertTestArgToTestClass = null;
            var result = convertTestArgToTestClass(genericTestArg);
            Assert.AreEqual(genericTestArg, result.Arg);
        }

        bool testActionExecuted;

        [TestMethod]
        public void ActionTest()
        {
            testActionExecuted = false;
            Action action = null;
            action();
            Assert.IsTrue(testActionExecuted);
        }

        TestArg testGenericDelegateArg;

        [TestMethod]
        public void ActionWithArgTest()
        {
            testGenericDelegateArg = null;
            var genericTestArg = new TestArg();
            Action<TestArg> actionWithTestArg = null;
            actionWithTestArg(genericTestArg);
            Assert.AreEqual(genericTestArg, testGenericDelegateArg);
        }

        TestClass genericNoArgFunctionReturnValue;

        [TestMethod]
        public void FunctionTest()
        {
            genericNoArgFunctionReturnValue = new TestClass();
            Func<TestClass> noArgFunction = null;
            var result = noArgFunction();
            Assert.AreEqual(genericNoArgFunctionReturnValue, result);
        }

        [TestMethod]
        public void FunctionWithArgTest()
        {
            var genericTestArg = new TestArg();
            Func<TestArg, TestClass> functionWithArg = null;
            var result = functionWithArg(genericTestArg);
            Assert.AreEqual(genericTestArg, result.Arg);
        }
    }
}
