using System;
using Xunit;

namespace NetMicro.LoadBalancing.Tests
{
    public class RoundRobinTest
    {
        [Fact]
        public void RoundRobinOfReferenceType_ShouldReturnNull_WhenEmpty()
        {
            var sut = new RoundRobin<string>();
            var result = sut.Get();

            Assert.Null(result);
        }

        [Fact]
        public void RoundRobinOfValueType_ShouldReturnDefault_WhenEmpty()
        {
            var sut = new RoundRobin<int>();
            var result = sut.Get();

            Assert.Equal(0, result);
        }

        [Fact]
        public void RoundRobin_ShouldReturnTheOnlyEntry()
        {
            const string theOnlyOne = "theOnlyOne";

            var sut = new RoundRobin<string>();
            sut.Add(theOnlyOne);
            var result = sut.Get();

            Assert.Equal(theOnlyOne, result);
        }

        [Fact]
        public void RoundRobin_ShouldReturnTheOnlyEntryMultipleTimes()
        {
            const string theOnlyOne = "theOnlyOne";

            var sut = new RoundRobin<string>();
            sut.Add(theOnlyOne);

            Assert.Equal(theOnlyOne, sut.Get());
            Assert.Equal(theOnlyOne, sut.Get());
            Assert.Equal(theOnlyOne, sut.Get());
            Assert.Equal(theOnlyOne, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnEntriesInOrder()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            Assert.Equal(thirdEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnEntriesInCycles()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";

            var sut = new RoundRobin<string> {firstEntry, secondEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            Assert.Equal(firstEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnEntriesAddedAfterInitialisation()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            sut.Add(thirdEntry);
            Assert.Equal(thirdEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnOmitRemovedEntries()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            sut.Remove(thirdEntry);
            Assert.Equal(firstEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnNextEntryWhenAnyNextRemoved()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};

            Assert.Equal(firstEntry, sut.Get());
            sut.Remove(thirdEntry);
            Assert.Equal(secondEntry, sut.Get());
            Assert.Equal(firstEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnNextEntryWhenAnyPreviousRemoved()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            sut.Remove(firstEntry);
            Assert.Equal(thirdEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnNextEntryWhenLastReturnedRemoved()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            sut.Remove(secondEntry);
            Assert.Equal(thirdEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnEntriesWhenUpdateChangesNothing()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            sut.Update(new[] {
                firstEntry, secondEntry, thirdEntry
            });
            Assert.Equal(thirdEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnEntriesAddedByUpdateAfterInitialisation()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            sut.Update(new[] {
                firstEntry, secondEntry, thirdEntry
            });
            Assert.Equal(thirdEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnOmitEntriesRemovedByUpdate()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            sut.Update(new[] {firstEntry, secondEntry });
            Assert.Equal(firstEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnNextEntryWhenAnyNextRemovedByUpdate()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};

            Assert.Equal(firstEntry, sut.Get());
            sut.Update(new[] { firstEntry, secondEntry });
            Assert.Equal(secondEntry, sut.Get());
            Assert.Equal(firstEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnNextEntryWhenAnyPreviousRemovedByUpdate()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            sut.Update(new []{secondEntry, thirdEntry});
            Assert.Equal(thirdEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnNextEntryWhenLastReturnedRemovedByUpdate()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};

            Assert.Equal(firstEntry, sut.Get());
            Assert.Equal(secondEntry, sut.Get());
            sut.Update(new [] { firstEntry, thirdEntry });
            Assert.Equal(thirdEntry, sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnDefaultWhenAllEntriesRemoved()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};
            sut.Remove(firstEntry);
            sut.Remove(secondEntry);
            sut.Remove(thirdEntry);
            Assert.Null(sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnDefaultWhenCleared()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string thirdEntry = "entry3";

            var sut = new RoundRobin<string> {firstEntry, secondEntry, thirdEntry};
            sut.Clear();
            Assert.Null(sut.Get());
        }

        [Fact]
        public void RoundRobin_ShouldReturnNextWhenNotExistingEntryRemoved()
        {
            const string firstEntry = "entry1";
            const string secondEntry = "entry2";
            const string notExistingEntry = "fakeEntry";

            var sut = new RoundRobin<string> {firstEntry, secondEntry};
            sut.Remove(notExistingEntry);
            Assert.Equal(firstEntry, sut.Get());
        }
    }
}