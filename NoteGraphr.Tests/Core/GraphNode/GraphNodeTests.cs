using NUnit.Framework;
using FedoraDev.NoteGraphr.Core.GraphNode;
using Moq;

namespace FedoraDev.NoteGraphr.Tests.Core.GraphNode
{
    [TestFixture]
    class GraphNodeTests
    {
        GraphNodeBase graphNode;

        [SetUp]
        public void SetUp()
        {
            graphNode = new Mock<GraphNodeBase>(MockBehavior.Strict).Object;
        }

        [Test]
        public void GraphNodeBaseHasID()
        {
            Assert.That(graphNode.ID, Is.Not.Null);
        }

        [Test]
        public void GraphNodeBaseIDIsUnique()
        {
            GraphNodeBase graphNode2 = new Mock<GraphNodeBase>(MockBehavior.Strict).Object;

            Assert.That(graphNode.ID, Is.Not.EqualTo(graphNode2.ID));
        }

        [Test]
        public void GraphNodeBaseHasPosition()
        {
            Assert.That(graphNode.X, Is.Not.Null.And.EqualTo(0));
            Assert.That(graphNode.Y, Is.Not.Null.And.EqualTo(0));
        }

        [Test]
        public void GraphNodeBaseHasSize()
        {
            Assert.That(graphNode.Width, Is.Not.Null);
            Assert.That(graphNode.Height, Is.Not.Null);
        }

        [Test]
        public void GraphNodeBaseSizeDefaultsAwayFromZero()
        {
            Assert.That(graphNode.Width, Is.Not.EqualTo(0));
            Assert.That(graphNode.Height, Is.Not.EqualTo(0));
        }

        [Test]
        public void GraphNodeBaseSizeCanBeSet()
        {
            graphNode.SetSize(100, 100);

            Assert.That(graphNode.Width, Is.EqualTo(100));
            Assert.That(graphNode.Height, Is.EqualTo(100));
        }

        [Test]
        public void GraphNodeBaseSizeSetToN()
        {
            for (int i = 0; i < 10; i++)
            {
                graphNode.SetSize(i, i);

                Assert.That(graphNode.Width, Is.EqualTo(i));
                Assert.That(graphNode.Height, Is.EqualTo(i));
            }
        }

        [Test]
        public void GraphNodeBaseSizeCanGrow()
        {
            graphNode.SetSize(1, 1);
            graphNode.Grow(2, 5);

            Assert.That(graphNode.Width, Is.EqualTo(3));
            Assert.That(graphNode.Height, Is.EqualTo(6));
        }

        [Test]
        public void GraphNodeBaseSizeGrowsByN()
        {
            for (int i = -10; i < 10; i++)
            {
                graphNode.SetSize(15, 15);
                graphNode.Grow(i, i);

                Assert.That(graphNode.Width, Is.EqualTo(15 + i));
                Assert.That(graphNode.Height, Is.EqualTo(15 + i));
            }
        }

        [Test]
        public void GraphNodeBaseSizeDoesNotBecomeLessThanOne()
        {
            graphNode.SetSize(1, 1);
            graphNode.Grow(-1, -1);

            Assert.That(graphNode.Width, Is.EqualTo(1));
            Assert.That(graphNode.Height, Is.EqualTo(1));

            graphNode.Grow(-100, -100);

            Assert.That(graphNode.Width, Is.EqualTo(1));
            Assert.That(graphNode.Height, Is.EqualTo(1));
        }

        [Test]
        public void GraphNodeBasePositionDefaultsToZero()
        {
            Assert.That(graphNode.X, Is.Not.Null.And.EqualTo(0));
            Assert.That(graphNode.Y, Is.Not.Null.And.EqualTo(0));
        }

        [Test]
        public void GraphNodeBasePositionCanBeSet()
        {
            graphNode.SetPosition(100, 100);

            Assert.That(graphNode.X, Is.EqualTo(100));
            Assert.That(graphNode.Y, Is.EqualTo(100));
        }

        [Test]
        public void GraphNodeBasePositionSetToN()
        {
            for (int i = 0; i < 10; i++)
            {
                graphNode.SetPosition(i, i);

                Assert.That(graphNode.X, Is.EqualTo(i));
                Assert.That(graphNode.Y, Is.EqualTo(i));
            }
        }

        [Test]
        public void GraphNodeBaseCanBeMoved()
        {
            graphNode.SetPosition(50, 50);
            graphNode.Move(5, 5);

            Assert.That(graphNode.X, Is.EqualTo(55));
            Assert.That(graphNode.Y, Is.EqualTo(55));
        }

        [Test]
        public void GraphNodeBaseCanBeMoveNAmount()
        {
            for (int i = -10; i < 10; i++)
            {
                graphNode.SetPosition(50, 50);
                graphNode.Move(i, i);

                Assert.That(graphNode.X, Is.EqualTo(50 + i));
                Assert.That(graphNode.Y, Is.EqualTo(50 + i));
            }
        }
    }
}
