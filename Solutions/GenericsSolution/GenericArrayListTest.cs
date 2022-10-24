

using GenericsLab;

namespace GTests
{
    public class GenericArrayListTest
    {
        private GenericArrayList<string> sut;
        private string s1 = "Hello";
        private string s2 = "World";
        private string s3 = "test";

        public GenericArrayListTest()
        {
            sut = new();
        }

        [Fact]
        public void TestNewObjectArrayList()
        {
            Assert.Equal(0, sut.Size);
        }

        [Fact]
        public void TestAdd()
        {
            sut.Add(s1).Add(s2).Add(s3);
            Assert.Equal(3, sut.Size);
        }
        [Fact]
        public void TestAddRemove()
        {
            sut.Add(s1).Add(s2).Add(s3).Add(s1).Add(s2).Add(s3);
            sut.Remove(3);
            Assert.Equal(5, sut.Size);
        }
        [Fact]
        public void TestAddRemoveSequenceIndexer()
        {
            sut.Add(s1).Add(s2).Add(s3).Add(s1).Add(s2).Add(s3);
            sut.Remove(3);
            Assert.Multiple(
                () => Assert.Equal(s1, sut[0]),
                () => Assert.Equal(s2, sut[1]),
                () => Assert.Equal(s3, sut[2]),
                () => Assert.Equal(s2, sut[3]),
                () => Assert.Equal(s3, sut[4]));
        }

        [Fact]
        public void TestGrowArray()
        {
            for (int i = 0; i < 30; i++)
                sut.Add(s1 + i);
            Assert.Equal(30, sut.Size);
        }

        [Fact]
        public void TestIndexOutOfBoundsSetter()
        {
            sut.Add(s1).Add(s2).Add(s3);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut[3]);
        }
    }
}