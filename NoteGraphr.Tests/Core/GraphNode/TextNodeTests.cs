using FedoraDev.NoteGraphr.Core.GraphNode;
using NUnit.Framework;

namespace FedoraDev.NoteGraphr.Tests.Core.GraphNode
{
    [TestFixture]
    class TextNodeTests
    {
        [Test]
        public void TextNodeImplementsIGraphNode()
        {
            IGraphNode textNode = new TextNode();
            Assert.That(textNode, Is.Not.Null);
        }

        [Test]
        public void TextNodeContentDefaultsToEmptyString()
        {
            IGraphNode textNode = new TextNode();
            Assert.That(textNode.Content, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TextNodePositionDefaultsToZero()
        {
            IGraphNode textNode = new TextNode();
            Assert.That(textNode.X, Is.Not.Null.And.EqualTo(0));
        }

        [Test]
        public void TextNodeContentCanBeSet()
        {
            IGraphNode textNode = new TextNode();

            textNode.SetContent("Hello World");

            Assert.That(textNode.Content, Is.Not.Null.And.EqualTo("Hello World"));
        }

        [Test]
        public void TextNodeSizeCanBeSet()
        {
            IGraphNode textNode = new TextNode();

            textNode.SetSize(100, 100);

            Assert.That(textNode.Width, Is.EqualTo(100));
            Assert.That(textNode.Height, Is.EqualTo(100));
        }

        [Test]
        public void TextNodeSizeSetToN()
        {
            IGraphNode textNode = new TextNode();

            for (int i = 0; i < 10; i++)
            {
                textNode.SetSize(i, i);

                Assert.That(textNode.Width, Is.EqualTo(i));
                Assert.That(textNode.Height, Is.EqualTo(i));
            }
        }

        [Test]
        public void TextNodePositionCanBeSet()
        {
            IGraphNode textNode = new TextNode();

            textNode.SetPosition(100, 100);

            Assert.That(textNode.X, Is.EqualTo(100));
            Assert.That(textNode.Y, Is.EqualTo(100));
        }

        [Test]
        public void TextNodePositionSetToN()
        {
            IGraphNode textNode = new TextNode();

            for (int i = 0; i < 10; i++)
            {
                textNode.SetPosition(i, i);

                Assert.That(textNode.X, Is.EqualTo(i));
                Assert.That(textNode.Y, Is.EqualTo(i));
            }
        }
    }
}
