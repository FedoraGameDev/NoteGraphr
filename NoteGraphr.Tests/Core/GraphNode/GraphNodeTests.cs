using NUnit.Framework;
using NoteGraphr.Core.GraphNode;
using Moq;
using NoteGraphr.Core.Graph;

namespace NoteGraphr.Tests.Core.GraphNode
{
    [TestFixture]
    class GraphNodeTests
    {
        GraphNodeBase _graphNode;

        [SetUp]
        public void SetUp()
        {
            _graphNode = new Mock<GraphNodeBase>(MockBehavior.Strict).Object;
        }

        [Test]
        public void GraphNodeBaseHasID()
        {
            Assert.That(_graphNode.ID, Is.Not.Null);
        }

        [Test]
        public void GraphNodeBaseIDIsUnique()
        {
            GraphNodeBase graphNode2 = new Mock<GraphNodeBase>(MockBehavior.Strict).Object;

            Assert.That(_graphNode.ID, Is.Not.EqualTo(graphNode2.ID));
        }

        [Test]
        public void GraphNodeBaseHasPosition()
        {
            Assert.That(_graphNode.X, Is.Not.Null.And.EqualTo(0));
            Assert.That(_graphNode.Y, Is.Not.Null.And.EqualTo(0));
        }

        [Test]
        public void GraphNodeBaseHasSize()
        {
            Assert.That(_graphNode.Width, Is.Not.Null);
            Assert.That(_graphNode.Height, Is.Not.Null);
        }

        [Test]
        public void GraphNodeBaseSizeDefaultsAwayFromZero()
        {
            Assert.That(_graphNode.Width, Is.Not.EqualTo(0));
            Assert.That(_graphNode.Height, Is.Not.EqualTo(0));
        }

        [Test]
        public void GraphNodeBaseSizeCanBeSet()
        {
            _graphNode.SetSize(100, 100);

            Assert.That(_graphNode.Width, Is.EqualTo(100));
            Assert.That(_graphNode.Height, Is.EqualTo(100));
        }

        [Test]
        public void GraphNodeBaseSizeSetToN()
        {
            for (int i = 0; i < 10; i++)
            {
                _graphNode.SetSize(i, i);

                Assert.That(_graphNode.Width, Is.EqualTo(i));
                Assert.That(_graphNode.Height, Is.EqualTo(i));
            }
        }

        [Test]
        public void GraphNodeBaseSizeCanGrow()
        {
            _graphNode.SetSize(1, 1);
            _graphNode.Grow(2, 5);

            Assert.That(_graphNode.Width, Is.EqualTo(3));
            Assert.That(_graphNode.Height, Is.EqualTo(6));
        }

        [Test]
        public void GraphNodeBaseSizeGrowsByN()
        {
            for (int i = -10; i < 10; i++)
            {
                _graphNode.SetSize(15, 15);
                _graphNode.Grow(i, i);

                Assert.That(_graphNode.Width, Is.EqualTo(15 + i));
                Assert.That(_graphNode.Height, Is.EqualTo(15 + i));
            }
        }

        [Test]
        public void GraphNodeBaseSizeDoesNotBecomeLessThanOne()
        {
            _graphNode.SetSize(1, 1);
            _graphNode.Grow(-1, -1);

            Assert.That(_graphNode.Width, Is.EqualTo(1));
            Assert.That(_graphNode.Height, Is.EqualTo(1));

            _graphNode.Grow(-100, -100);

            Assert.That(_graphNode.Width, Is.EqualTo(1));
            Assert.That(_graphNode.Height, Is.EqualTo(1));
        }

        [Test]
        public void GraphNodeBasePositionDefaultsToZero()
        {
            Assert.That(_graphNode.X, Is.Not.Null.And.EqualTo(0));
            Assert.That(_graphNode.Y, Is.Not.Null.And.EqualTo(0));
        }

        [Test]
        public void GraphNodeBasePositionCanBeSet()
        {
            _graphNode.SetPosition(100, 100);

            Assert.That(_graphNode.X, Is.EqualTo(100));
            Assert.That(_graphNode.Y, Is.EqualTo(100));
        }

        [Test]
        public void GraphNodeBasePositionSetToN()
        {
            for (int i = 0; i < 10; i++)
            {
                _graphNode.SetPosition(i, i);

                Assert.That(_graphNode.X, Is.EqualTo(i));
                Assert.That(_graphNode.Y, Is.EqualTo(i));
            }
        }

        [Test]
        public void GraphNodeBaseCanBeMoved()
        {
            _graphNode.SetPosition(50, 50);
            _graphNode.Move(5, 5);

            Assert.That(_graphNode.X, Is.EqualTo(55));
            Assert.That(_graphNode.Y, Is.EqualTo(55));
        }

        [Test]
        public void GraphNodeBaseCanBeMoveNAmount()
        {
            for (int i = -10; i < 10; i++)
            {
                _graphNode.SetPosition(50, 50);
                _graphNode.Move(i, i);

                Assert.That(_graphNode.X, Is.EqualTo(50 + i));
                Assert.That(_graphNode.Y, Is.EqualTo(50 + i));
            }
        }

        [Test]
        public void GraphNodeCanBeAddedToGraphSheet()
        {
            GraphSheet graph = new GraphSheet();
            graph.Add(_graphNode);

            Assert.That(graph.Contains(_graphNode), Is.True);
        }
    }
}
