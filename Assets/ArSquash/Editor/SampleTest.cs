using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class SampleTest {
        [Test]
        public void AnyTest() {
            int a = 5, b = 4;
            int ans = a * b;
            Assert.AreEqual(ans, 20);
            // Use the Assert class to test conditions
        }
    }
}