using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesLambdasAndExpressions
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void TestExpressionCompilation()
        {
            var valueToBeReturned = 42;
            Expression<Func<int>> expression = () => valueToBeReturned;
            Func<int> compiledFunc = expression.Compile();
            var result = compiledFunc();
            Assert.AreEqual(valueToBeReturned, result);
        }

        public class Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        TOutput ExtractPropertyValue<T, TOutput>(T target, Expression<Func<T, TOutput>> property)
        {
            var propertyMethod = property.Compile();
            return propertyMethod(target);
        }

        [TestMethod]
        public void TestExtractPropertyValue()
        {
            var name = new Name {FirstName = "John", LastName = "Doe"};
            var firstName = ExtractPropertyValue(name, x => x.FirstName);
            Assert.AreEqual(name.FirstName, firstName);
            var lastName = ExtractPropertyValue(name, x => x.LastName);
            Assert.AreEqual(name.LastName, lastName);
        }

        string ExtractPropertyName<T>(Expression<Func<T, object>> property)
        {
            return ((MemberExpression) property.Body).Member.Name;
        }

        [TestMethod]
        public void TestExtractPropertyName()
        {
            var propertyName = ExtractPropertyName<Name>(x => x.FirstName);
            Assert.AreEqual("FirstName", propertyName);
            propertyName = ExtractPropertyName<Name>(x => x.LastName);
            Assert.AreEqual("LastName", propertyName);
        }
    }
}
