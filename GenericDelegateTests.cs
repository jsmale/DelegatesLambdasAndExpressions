using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesLambdasAndExpressions
{
	[TestClass]
	public class GenericDelegateTests
    {
		public class TestClass
		{
			public TestArg Arg { get; set; }
		}

		public class TestArg { }

        public delegate void VoidActionWithGenericArg<in T>(T value);
        TestClass testGenericDelegateArg;

		[TestMethod]
		public void VoidWithGenericArgDelegate()
        {
            testGenericDelegateArg = null;
            var genericArgument = new TestClass();
		    VoidActionWithGenericArg<TestClass> voidActionWithGenericArg = null;
		    voidActionWithGenericArg(genericArgument);
			Assert.AreEqual(genericArgument, testGenericDelegateArg);
		}

        TestClass genericNoArgFunctionReturnValue;
        public delegate T NoArgGenericFunction<out T>();

		[TestMethod]
		public void GenericFunctionNoArgDelegate()
        {
            genericNoArgFunctionReturnValue = new TestClass();
		    NoArgGenericFunction<TestClass> noArgGenericFunction = null;
		    var returnValue = noArgGenericFunction();
			Assert.AreEqual(genericNoArgFunctionReturnValue, returnValue);
		}

        public delegate TOutput GenericFunctionWithGenericArg<out TOutput, in TInput>(TInput value);

		[TestMethod]
		public void GenericFunctionWithArgDelegate()
		{
            var genericTestArg = new TestArg();
		    GenericFunctionWithGenericArg<TestClass, TestArg> genericFunctionWithGenericArg = null;
			var returnValue = genericFunctionWithGenericArg(genericTestArg);
			Assert.AreEqual(genericTestArg, returnValue.Arg);
		}
	}
}
