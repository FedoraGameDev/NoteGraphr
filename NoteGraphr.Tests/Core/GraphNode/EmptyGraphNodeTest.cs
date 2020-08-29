using NoteGraphr.Core.GraphNode;
using NUnit.Framework;

namespace NoteGraphr.Tests.Core.GraphNode
{
    [TestFixture]
    class EmptyGraphNodeTest
    {
        [Test]
        public void EmptyGraphNodeCanBeInstantiated()
        {
            EmptyGraphNode emptyNode = new EmptyGraphNode();
            Assert.That(emptyNode, Is.Not.Null);
        }

        [Test]
        public void EmptyGraphNodeExtendsGraphNodeBase()
        {
            GraphNodeBase emptyNode = new EmptyGraphNode();
            Assert.That(emptyNode, Is.Not.Null);
        }
    }
}
