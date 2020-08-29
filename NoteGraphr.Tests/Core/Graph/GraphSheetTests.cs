using FedoraDev.NoteGraphr.Core.Graph;
using NUnit.Framework;
using Moq;
using FedoraDev.NoteGraphr.Core.UniqueID;

namespace FedoraDev.NoteGraphr.Tests.Core.Graph
{
    [TestFixture]
    class GraphSheetTests
    {
        GraphSheet _graph;

        [SetUp]
        public void SetUp()
        {
            _graph = new GraphSheet();
        }

        [Test]
        public void CanStoreGraphables()
        {
            Mock<IGraphable> mGraphable = new Mock<IGraphable>(MockBehavior.Strict);
            IGraphable graphable = mGraphable.Object;

            _graph.Add(graphable);

            Assert.That(_graph.Contains(graphable), Is.True);
        }

        [Test]
        public void ShowsFalseWhenGraphableIsNotAdded()
        {
            Mock<IGraphable> mGraphable = new Mock<IGraphable>(MockBehavior.Strict);
            IGraphable graphable = mGraphable.Object;

            Assert.That(_graph.Contains(graphable), Is.False);
        }

        [Test]
        public void HoldsManyGraphables()
        {
            IGraphable[] graphables = new IGraphable[10];

            for (int i = 0; i < graphables.Length; i++)
            {
                Mock<IGraphable> mGraphable = new Mock<IGraphable>(MockBehavior.Strict);
                graphables[i] = mGraphable.Object;

                _graph.Add(graphables[i]);
            }

            for (int i = 0; i < graphables.Length; i++)
            {
                Assert.That(_graph.Contains(graphables[i]), Is.True);
            }
        }

        [Test]
        public void CanRemoveGraphable()
        {
            Mock<IGraphable> mGraphable = new Mock<IGraphable>(MockBehavior.Strict);
            IGraphable graphable = mGraphable.Object;

            _graph.Add(graphable);
            _graph.Remove(graphable);

            Assert.That(_graph.Contains(graphable), Is.False);
        }

        [Test]
        public void AddedToUID()
        {
            Assert.That(UID.Contains(_graph), Is.True);
        }

        [Test]
        public void ContainsID()
        {
            Assert.That(_graph.ID, Is.Not.Null);
        }
    }
}
