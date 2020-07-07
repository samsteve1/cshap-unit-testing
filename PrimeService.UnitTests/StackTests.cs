using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace PrimeService.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;
        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }
        [Test]
        public void Push_ArgIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }
        [Test]
        public void Push_ArgIsValid_PushArgToList()
        {
            _stack.Push("a");
            Assert.That(_stack.Count, Is.EqualTo(1));
        }
        [Test]
        public void Pop_ListIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]

        public void Pop_ListIsNotEmpty_RemoveTheLastItemFromList()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(1));
        }
        [Test]
        public void Pop_ListIsNotEmpty_ReturnTheLastItemInList()
        {
            _stack.Push("a");
            _stack.Push("b");

            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        public void Peek_ListIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void Peek_ListIsNotEmpty_ReturnPeekItemInList()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
        }
    }
}