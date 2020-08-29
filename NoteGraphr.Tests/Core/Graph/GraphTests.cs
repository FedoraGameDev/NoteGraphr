using FedoraDev.NoteGraphr.Core.Graph;
using NUnit.Framework;
using Moq;

namespace FedoraDev.NoteGraphr.Tests.Core.Graph
{
    [TestFixture]
    class GraphTests
    {
        GraphSheet graph;

        [SetUp]
        public void SetUp()
        {
            graph = new GraphSheet();
        }

        [Test]
        public void CanStoreGraphables()
        {
            Mock<IGraphable> mGraphable = new Mock<IGraphable>(MockBehavior.Strict);
            IGraphable graphable = mGraphable.Object;

            graph.Add(graphable);

            Assert.That(graph.Contains(graphable), Is.True);
        }

        [Test]
        public void ShowsFalseWhenGraphableIsNotAdded()
        {
            Mock<IGraphable> mGraphable = new Mock<IGraphable>(MockBehavior.Strict);
            IGraphable graphable = mGraphable.Object;

            Assert.That(graph.Contains(graphable), Is.False);
        }

        [Test]
        public void HoldsManyGraphables()
        {
            IGraphable[] graphables = new IGraphable[10];

            for (int i = 0; i < graphables.Length; i++)
            {
                Mock<IGraphable> mGraphable = new Mock<IGraphable>(MockBehavior.Strict);
                graphables[i] = mGraphable.Object;

                graph.Add(graphables[i]);
            }

            for (int i = 0; i < graphables.Length; i++)
            {
                Assert.That(graph.Contains(graphables[i]), Is.True);
            }
        }

        [Test]
        public void CanRemoveGraphable()
        {
            Mock<IGraphable> mGraphable = new Mock<IGraphable>(MockBehavior.Strict);
            IGraphable graphable = mGraphable.Object;

            graph.Add(graphable);
            graph.Remove(graphable);

            Assert.That(graph.Contains(graphable), Is.False);
        }
    }
}
