using System;

namespace DelegatesLambdasAndExpressions
{
    public class BuiltInDelegates
    {
        public void HandleEvent(EventHandler eventHandler, object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        public bool ExecutePredicate<T>(Predicate<T> predicate, T instance)
        {
            throw new NotImplementedException();
        }

        public int ExecuteComparison<T>(Comparison<T> comparison, T instanceA, T instanceB)
        {
            throw new NotImplementedException();
        }

        public TOutput ExecuteConverter<TInput, TOutput>(Converter<TInput,TOutput> converter, TInput input)
        {
            throw new NotImplementedException();
        }

        public void ExecuteAction(Action action)
        {
            throw new NotImplementedException();
        }

        public void ExecuteAction<T>(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public T ExecuteFunction<T>(Func<T> func)
        {
            throw new NotImplementedException();
        }

        public TOutput ExecuteFunction<TOutput, TInput>(Func<TInput, TOutput> func, TInput input)
        {
            throw new NotImplementedException();
        } 
    }
}