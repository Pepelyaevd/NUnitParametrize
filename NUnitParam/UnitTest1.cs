using System;
using NUnit.Framework;
using System.Collections;

namespace NUnitParam
{
    [TestFixture]
    public class MyTests
    {
        [TestCaseSource(typeof(MyDataClass), "DatasetDetails")]
        [TestCaseSource(typeof(MyDataClass), "GetData")]
        public int ApiTest(int n, int d)
        {
            return n / d;
        }
    }

    public class MyDataClass
    {
        public static IEnumerable DatasetDetails
        {
            get
            {
                yield return new TestCaseData().Returns(4).SetName("DatasetDetailsNumberOne");
                yield return new TestCaseData(12, 2).Returns(6).SetName("DatasetDetailsNumberTwo");
                yield return new TestCaseData(12, 4).Returns(3);
            }
        }

        public static IEnumerable GetData
        {
            get
            {
                yield return new TestCaseData(1, 1).Returns(1).SetName("GetDataNumberOne");
                yield return new TestCaseData(2, 0).Returns(3).SetName("GetDataNumber2");
            }
        }
    }
}
