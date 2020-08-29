using NUnit.Framework;
using NoteGraphr.Core.UniqueID;

namespace NoteGraphr.Tests.Core.UniqueID
{
    class TestBox { }
    class TestCircle { }

    [TestFixture]
    class UIDTests
    {
        [Test]
        public void AcceptsObject()
        {
            UID.AddAndGetID(new TestBox());
            Assert.That(true, Is.True);
        }

        [Test]
        public void TellIfContainsAnObject()
        {
            TestBox box = new TestBox();
            UID.AddAndGetID(box);

            Assert.That(UID.Contains(box), Is.True);
        }

        [Test]
        public void ReturnsAnID()
        {
            uint id = UID.AddAndGetID(new TestBox());
            Assert.That(id, Is.Not.Null);
        }

        [Test]
        public void ReturnsAnObjectGivenItsID()
        {
            TestBox box = new TestBox();
            uint id = UID.AddAndGetID(box);

            TestBox retBox = UID.TryToGet<TestBox>(id);

            Assert.That(box, Is.EqualTo(retBox));
        }

        [Test]
        public void StoresNObjects()
        {
            TestBox[] boxes = new TestBox[5];
            uint[] ids = new uint[5];

            for (int i = 0; i < 5; i++)
            {
                boxes[i] = new TestBox();
                ids[i] = UID.AddAndGetID(boxes[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                TestBox box = UID.TryToGet<TestBox>(ids[i]);
                Assert.That(box, Is.EqualTo(boxes[i]));
            }
        }

        [Test]
        public void ReturnsNullIfTypeMismatch()
        {
            uint id = UID.AddAndGetID(new TestBox());
            TestCircle circle = UID.TryToGet<TestCircle>(id);
            Assert.That(circle, Is.Null);
        }

        [Test]
        public void CanFreeIDs()
        {
            uint id = UID.AddAndGetID(new TestBox());
            UID.Remove(id);
            Assert.That(UID.TryToGet<TestBox>(id), Is.Null);
        }

        [Test]
        public void DoesNotErrorWhenRemovingNonExistantID()
        {
            UID.Remove(0);
            Assert.That(true, Is.True);
        }

        [Test]
        public void FreedIDIsUsedOnNextObject()
        {
            uint id1 = UID.AddAndGetID(new TestBox());
            UID.Remove(id1);
            uint id2 = UID.AddAndGetID(new TestBox());
            Assert.That(id1, Is.EqualTo(id2));
        }

        [Test]
        public void AssigningSameIDToNewObjectDoesNotForceIDOverlapOnNext()
        {
            uint id1 = UID.AddAndGetID(new TestBox());
            uint id2 = UID.AddAndGetID(new TestBox());
            UID.Remove(id1);
            uint id3 = UID.AddAndGetID(new TestBox());
            uint id4 = UID.AddAndGetID(new TestBox());
            Assert.That(id2, Is.Not.EqualTo(id4));
        }

        [Test]
        public void FreeingAnIDHigherThanNextAvailableIDDoesNotChangeNextID()
        {
            uint id1 = UID.AddAndGetID(new TestBox());
            uint id2 = UID.AddAndGetID(new TestBox());
            UID.Remove(id1);
            UID.Remove(id2);
            uint id3 = UID.AddAndGetID(new TestBox());
            Assert.That(id3, Is.EqualTo(id1));
        }
    }
}
