using System;
using System.Collections;
using NUnit.Framework;

namespace Open_Lab_02._08
{
    [TestFixture]
    public class Tests
    {

        private Checker checker;

        private const int RandSeed = 207207207;
        private const int RandWordMaxSize = 10;
        private const int RandTestCasesCount = 96;

        [OneTimeSetUp]
        public void Init() => checker = new Checker();

        [TestCase("", true)]
        [TestCase(" ", false)]
        [TestCase("a", false)]
        [TestCase("text", false)]
        [TestCaseSource(nameof(GetRandom))]
        public void IsEmptyTest(string input, bool expectedOutput) =>
            Assert.That(checker.IsEmpty(input), Is.EqualTo(expectedOutput));

        private static IEnumerable GetRandom()
        {
            var random = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var arr = new char[random.Next(RandWordMaxSize)];

                for (var j = 0; j < arr.Length; j++)
                    arr[j] = (char) random.Next(48, 123);

                yield return new TestCaseData(new string(arr), arr.Length == 0);
            }
        }

    }
}
