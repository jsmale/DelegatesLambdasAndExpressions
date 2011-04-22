using System;

namespace DelegatesLambdasAndExpressions
{
	public class Delegates
	{
		public delegate void VoidAction();

		public void ExecuteAction(VoidAction voidAction)
		{
			throw new NotImplementedException();
		}

		public delegate void VoidActionWithArg(int value);

		public void ExecuteAction(VoidActionWithArg voidAction, int arg)
		{
			throw new NotImplementedException();
		}

		public delegate int NoArgFunction();

		public int ExecuteFunction(NoArgFunction noArgFunction)
		{
			throw new NotImplementedException();
		}

		public delegate int FunctionWithArg(int value);

		public int ExecuteFunction(FunctionWithArg functionWithArg, int arg)
		{
			throw new NotImplementedException();
		}
	}
}