using System.Collections.Generic;
using MusterAg.Monitoring.Client.Helper;
using NUnit.Framework;

namespace MusterAg.Monitoring.Client.Tests
{
    [TestFixture]
    public class RegexHelperTests
    {

        [Test]
        public void TestMatchUrl()
        {
            // Arrange
            List<bool> checkList = new List<bool>();
            List<string> urlList = new List<string>()
            {
                "www.google.com,", "http://www.google.com", "https://www.google.com", "google.com",
                "https://policies.google.com/", "https://policies.google.com/technologies/voice?hl=de&gl=ch"
            };
            // Act
            foreach (var url in urlList)
            {
                checkList.Add(RegexHelper.MatchUrl(url));
            }
            // Assert
            Assert.IsTrue(checkList[0]);
            Assert.IsTrue(checkList[1]);
            Assert.IsTrue(checkList[2]);
            Assert.IsTrue(checkList[3]);
            Assert.IsTrue(checkList[4]);
            Assert.IsTrue(checkList[5]);
        }
        
        [Test]
        public void TestMatchEmail()
        {
            // Arrange
            List<bool> checkList = new List<bool>();
            List<string> urlList = new List<string>()
            {
                "test.test@test.ch", "test@test.com", "test.test."
            };
            // Act
            foreach (var url in urlList)
            {
                checkList.Add(RegexHelper.MatchEmail(url));
            }
            // Assert
            Assert.IsTrue(checkList[0]);
            Assert.IsTrue(checkList[1]);
            Assert.IsFalse(checkList[2]);
        }
        
        [Test]
        public void TestMatchCustomerNr()
        {
            // Arrange
            List<bool> checkList = new List<bool>();
            List<string> urlList = new List<string>()
            {
                "CU00001", "CU99999", "CU000001"
            };
            // Act
            foreach (var url in urlList)
            {
                checkList.Add(RegexHelper.MatchCustomerNr(url));
            }
            // Assert
            Assert.IsTrue(checkList[0]);
            Assert.IsTrue(checkList[1]);
            Assert.IsFalse(checkList[2]);
        }
        
        [Test]
        public void TestMatchPassword()
        {
            // Arrange
            List<bool> checkList = new List<bool>();
            List<string> urlList = new List<string>()
            {
                "AaBb9900", "AaBb990", "AaBb99000"
            };
            // Act
            foreach (var url in urlList)
            {
                checkList.Add(RegexHelper.MatchPassword(url));
            }
            // Assert
            Assert.IsTrue(checkList[0]);
            Assert.IsTrue(checkList[1]);
            Assert.IsFalse(checkList[2]);
        }
        
    }
}