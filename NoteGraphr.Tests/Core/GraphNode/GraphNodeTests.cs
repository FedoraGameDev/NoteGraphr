using NUnit.Framework;
using FedoraDev.NoteGraphr.Core.GraphNode;
using Moq;

namespace FedoraDev.NoteGraphr.Tests.Core.GraphNode
{
    [TestFixture]
    class GraphNodeTests
    {
        [Test]
        public void IGraphNodeHasContent()
        {
            Mock<IGraphNode> node = new Mock<IGraphNode>(MockBehavior.Strict);
            node.Setup(mNode => mNode.Content).Returns("Hello World");

            IGraphNode graphNode = node.Object;

            Assert.That(graphNode.Content, Is.Not.Null.And.EqualTo("Hello World"));
        }

        [Test]
        public void IGraphNodeHasPosition()
        {
            Mock<IGraphNode> node = new Mock<IGraphNode>(MockBehavior.Strict);
            node.Setup(mNode => mNode.X).Returns(0);
            node.Setup(mNode => mNode.Y).Returns(0);

            IGraphNode graphNode = node.Object;

            Assert.That(graphNode.X, Is.Not.Null.And.EqualTo(0));
            Assert.That(graphNode.Y, Is.Not.Null.And.EqualTo(0));
        }

        [Test]
        public void IGraphNodeHasSize()
        {
            Mock<IGraphNode> node = new Mock<IGraphNode>(MockBehavior.Strict);
            node.Setup(mNode => mNode.Width).Returns(0);
            node.Setup(mNode => mNode.Height).Returns(0);

            IGraphNode graphNode = node.Object;

            Assert.That(graphNode.Width, Is.Not.Null.And.EqualTo(0));
            Assert.That(graphNode.Height, Is.Not.Null.And.EqualTo(0));
        }
    }
}
