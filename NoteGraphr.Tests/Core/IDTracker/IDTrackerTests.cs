using NUnit.Framework;
using FedoraDev.NoteGraphr.Core.IDTrackers;

namespace FedoraDev.NoteGraphr.Tests.Core.IDTrackers
{
    class TestBox { }
    class TestCircle { }

    [TestFixture]
    class IDTrackerTests
    {
        [Test]
        public void IDTrackerAcceptsObject()
        {
            IDTracker.Add(new TestBox());
            Assert.That(true, Is.True);
        }

        [Test]
        public void IDTrackerReturnsAnID()
        {
            uint id = IDTracker.Add(new TestBox());
            Assert.That(id, Is.Not.Null);
        }

        [Test]
        public void IDTrackerReturnsAnObjectGivenItsID()
        {
            TestBox box = new TestBox();
            uint id = IDTracker.Add(box);

            TestBox retBox = IDTracker.TryToGet<TestBox>(id);

            Assert.That(box, Is.EqualTo(retBox));
        }

        [Test]
        public void IDTrackerStoresNObjects()
        {
            TestBox[] boxes = new TestBox[5];
            uint[] ids = new uint[5];

            for (int i = 0; i < 5; i++)
            {
                boxes[i] = new TestBox();
                ids[i] = IDTracker.Add(boxes[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                TestBox box = IDTracker.TryToGet<TestBox>(ids[i]);
                Assert.That(box, Is.EqualTo(boxes[i]));
            }
        }

        [Test]
        public void IDTrackerReturnsNullIfTypeMismatch()
        {
            uint id = IDTracker.Add(new TestBox());
            TestCircle circle = IDTracker.TryToGet<TestCircle>(id);
            Assert.That(circle, Is.Null);
        }
    }
}
