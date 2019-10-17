using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityEngine;

namespace TestsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var image = new GameObject().AddComponent<Image>();
            var heart = new Heart(image);
            heart.Replenish(0);
            Assert.AreEqual(0, image.fillAmount);
        }
    }
}
