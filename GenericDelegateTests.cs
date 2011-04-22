using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesLambdasAndExpressions
{
	[TestClass]
	public class GenericDelegateTests
	{
		GenericDelegates delegates;
		TestClass testGenericDelegateArg;
		TestClass genericArgument;
		TestClass genericNoArgFunctionReturnValue;
		TestArg genericTestArg;

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
			delegates = new GenericDelegates();
			testGenericDelegateArg = null;
			genericArgument = new TestClass();
			genericNoArgFunctionReturnValue = new TestClass();
			genericTestArg = new TestArg();
		}

		[TestMethod]
		public void VoidWithGenericArgDelegate()
		{
			delegates.ExecuteAction(TestVoidActionWithGenericArg, genericArgument);
			Assert.AreEqual(genericArgument, testGenericDelegateArg);
		}

		[TestMethod]
		public void GenericFunctionNoArgDelegate()
		{
			var returnValue = delegates.ExecuteFunction(TestGenericNoArgFunction);
			Assert.AreEqual(genericNoArgFunctionReturnValue, returnValue);
		}

		[TestMethod]
		public void GenericFunctionWithArgDelegate()
		{
			var returnValue = delegates.ExecuteFunction(TestGenericWithArgFunction, genericTestArg);
			Assert.AreEqual(genericTestArg, returnValue.Arg);
		}
	}
}
