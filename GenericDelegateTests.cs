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

        void MyActionWithGenericArg(TestClass value)
        {
            testGenericDelegateArg = value;
        }

		[TestMethod]
		public void VoidWithGenericArgDelegate()
        {
            testGenericDelegateArg = null;
            var genericArgument = new TestClass();
            VoidActionWithGenericArg<TestClass> voidActionWithGenericArg = MyActionWithGenericArg;
		    voidActionWithGenericArg(genericArgument);
			Assert.AreEqual(genericArgument, testGenericDelegateArg);
		}

        TestClass genericNoArgFunctionReturnValue;
        public delegate T NoArgGenericFunction<out T>();

        TestClass MyNoArgGenericFunction()
        {
            return genericNoArgFunctionReturnValue;
        }

		[TestMethod]
		public void GenericFunctionNoArgDelegate()
        {
            genericNoArgFunctionReturnValue = new TestClass();
            NoArgGenericFunction<TestClass> noArgGenericFunction = MyNoArgGenericFunction;
		    var returnValue = noArgGenericFunction();
			Assert.AreEqual(genericNoArgFunctionReturnValue, returnValue);
		}

        public delegate TOutput GenericFunctionWithGenericArg<out TOutput, in TInput>(TInput value);

        TestClass MyGenericFunctionWithGenericArg(TestArg value)
        {
            return new TestClass {Arg = value};
        }

		[TestMethod]
		public void GenericFunctionWithArgDelegate()
		{
            var genericTestArg = new TestArg();
            GenericFunctionWithGenericArg<TestClass, TestArg> genericFunctionWithGenericArg = MyGenericFunctionWithGenericArg;
			var returnValue = genericFunctionWithGenericArg(genericTestArg);
			Assert.AreEqual(genericTestArg, returnValue.Arg);
		}
	}
}
