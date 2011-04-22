using System;

namespace DelegatesLambdasAndExpressions
{
	public class GenericDelegates
	{
		public delegate void VoidActionWithGenericArg<in T>(T value);

		public void ExecuteAction<T>(VoidActionWithGenericArg<T> voidAction, T arg)
		{
			throw new NotImplementedException();
		}

		public delegate T NoArgGenericFunction<out T>();

		public T ExecuteFunction<T>(NoArgGenericFunction<T> noArgFunction)
		{
			throw new NotImplementedException();
		}

		public delegate TOutput GenericFunctionWithGenericArg<out TOutput, in TInput>(TInput value);

		public TOutput ExecuteFunction<TOutput, TInput>(GenericFunctionWithGenericArg<TOutput, TInput> noArgFunction, TInput arg)
		{
			throw new NotImplementedException();
		}
	}
}