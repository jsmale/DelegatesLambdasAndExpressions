using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesLambdasAndExpressions
{
	[TestClass]
	public class DelegateTests
	{
        public delegate void VoidAction();
        bool testVoidActionExecuted;

        void MyAction()
        {
            testVoidActionExecuted = true;
        }

		[TestMethod]
		public void VoidNoArgDelegate()
		{
		    testVoidActionExecuted = false;
		    VoidAction voidAction = MyAction;
            voidAction();
			Assert.IsTrue(testVoidActionExecuted);
		}

        public delegate void VoidActionWithArg(int value);
        int testDelegateArg;

        void MyActionWithArg(int value)
        {
            testDelegateArg = value;
        }

		[TestMethod]
		public void VoidWithArgDelegate()
		{
            testDelegateArg = 0;
            var argument = (new Random()).Next(10, int.MaxValue);
            VoidActionWithArg voidActionWithArg = MyActionWithArg; 
		    voidActionWithArg(argument);
			Assert.AreEqual(argument, testDelegateArg);
		}

        public delegate int NoArgFunction();
        int noArgFunctionReturnValue;

        int MyNoArgFunction()
        {
            return noArgFunctionReturnValue;
        }

		[TestMethod]
		public void FunctionNoArgDelegate()
		{
            noArgFunctionReturnValue = (new Random()).Next(10, int.MaxValue);
            NoArgFunction noArgFunction = MyNoArgFunction;
            var returnValue = noArgFunction();
			Assert.AreEqual(noArgFunctionReturnValue, returnValue);
		}

        public delegate int FunctionWithArg(int value);

        int MyFunctionWithArg(int value)
        {
            return value;
        }

		[TestMethod]
		public void FunctionWithArgDelegate()
        {
            var argument = (new Random()).Next(10, int.MaxValue);
            FunctionWithArg functionWithArg = MyFunctionWithArg;
			var returnValue = functionWithArg(argument);
			Assert.AreEqual(argument, returnValue);
		}
	}
}
