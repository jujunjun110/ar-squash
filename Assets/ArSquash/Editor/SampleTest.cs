using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class SampleTest {
        [Test]
        public void AnyTest() {
            var p1 = new Vector3(10, 0, 0);
            var p2 = new Vector3(0, 0, 10);
            var actual = new RoomGenerator().GetTransform(p1, p2);
            Debug.Log(actual.position);
            Debug.Log(actual.rotation);
            Debug.Log(actual.localScale);

            Assert.AreEqual(actual.position, new Vector3(5, 0, 5));
        }
    }
}