using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesLambdasAndExpressions
{
    [TestClass]
    public class BuiltInDelegateTests
    {
        BuiltInDelegates delegates;
        object testEventSender;
        EventArgs testEventArgs;
        TestClass testGenericDelegateArg;
        TestClass genericArgument;
        TestClass genericNoArgFunctionReturnValue;
        TestArg genericTestArg;

        public void TestEventHandler(object sender, EventArgs eventArgs)
        {
            testEventSender = sender;
            testEventArgs = eventArgs;
        }

        public class TestClass
        {
            public TestArg Arg { get; set; }
        }

        public class TestArg { }

        public void TestVoidActionWithGenericArg(TestClass testClass)
        {
            testGenericDelegateArg = testClass;
        }

        public TestClass TestGenericNoArgFunction()
        {
            return genericNoArgFunctionReturnValue;
        }

        public TestClass TestGenericWithArgFunction(TestArg testArg)
        {
            return new TestClass { Arg = testArg };
        }

        [TestInitialize]
        public void Init()
        {
            delegates = new BuiltInDelegates();
            testEventSender = null;
            testEventArgs = null;
            testGenericDelegateArg = null;
            genericArgument = new TestClass();
            genericNoArgFunctionReturnValue = new TestClass();
            genericTestArg = new TestArg();
        }

        [TestMethod]
        public void EventHandlerTest()
        {
            object sender = "My Sender";
            var eventArgs = new EventArgs();            
            delegates.HandleEvent(TestEventHandler, sender, eventArgs);
            Assert.AreEqual(sender, testEventSender);
            Assert.AreEqual(eventArgs, testEventArgs);
        }
    }
}
