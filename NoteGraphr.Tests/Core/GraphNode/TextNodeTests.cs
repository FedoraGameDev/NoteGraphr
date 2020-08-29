using NoteGraphr.Core.GraphNode;
using NUnit.Framework;

namespace NoteGraphr.Tests.Core.GraphNode
{
    [TestFixture]
    class TextNodeTests
    {
        [Test]
        public void TextNodeIDIsUnique()
        {
            TextNode textNode = new TextNode();
            TextNode textNode2 = new TextNode();

            Assert.That(textNode.ID, Is.Not.EqualTo(textNode2.ID));
        }

        [Test]
        public void TextNodeImplementsIGraphNode()
        {
            TextNode textNode = new TextNode();
            Assert.That(textNode, Is.Not.Null);
        }

        [Test]
        public void TextNodeContentDefaultsToEmptyString()
        {
            TextNode textNode = new TextNode();
            Assert.That(textNode.Content, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TextNodeContentCanBeConstructed()
        {
            TextNode textNode = new TextNode("Hey There!");
            Assert.That(textNode.Content, Is.Not.Null.And.EqualTo("Hey There!"));
        }

        [Test]
        public void TextNodeContentConstructedToN()
        {
            for (int i = 0; i < 10; i++)
            {
                TextNode textNode = new TextNode($"Test: {i}");
                Assert.That(textNode.Content, Is.Not.Null.And.EqualTo($"Test: {i}"));
            }
        }

        [Test]
        public void TextNodeContentCanBeSet()
        {
            TextNode textNode = new TextNode();

            textNode.SetContent("Hello World");

            Assert.That(textNode.Content, Is.Not.Null.And.EqualTo("Hello World"));
        }

        [Test]
        public void TextNodeContentSetsToN()
        {
            TextNode textNode = new TextNode();

            for (int i = 0; i < 10; i++)
            {
                textNode.SetContent($"Test: {i}");

                Assert.That(textNode.Content, Is.Not.Null.And.EqualTo($"Test: {i}"));
            }
        }
    }
}
