using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class SampleTest {
        [Test]
        public void TestGetTransform() {
            var p1 = new Vector3(10, 0, 0);
            var p2 = new Vector3(0, 0, 10);
            var testObject = new GameObject();
            var actual = RoomGenerator.GetWallTransform(p1, p2, 1.8f);

            Assert.AreEqual(new Vector3(5, 0.5f, 5), actual.position);
            Assert.LessOrEqual(actual.rotation.x - 0, 0.01);
            Assert.LessOrEqual(actual.rotation.y - 0.3826835, 0.01);
            Assert.LessOrEqual(actual.rotation.z - 0, 0.01);
            Assert.LessOrEqual(actual.rotation.w - 0.9238795, 0.01);
            Assert.LessOrEqual(actual.localScale.x - 14.1421356, 0.01);
        }
    }
}