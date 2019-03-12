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
            var testObject = new GameObject();
            var actual = new RoomGenerator().GetTransform(p1, p2, testObject);
            Debug.Log(actual.position);
            Debug.Log(actual.rotation);
            Debug.Log(actual.localScale);

            Assert.AreEqual(new Vector3(5, 0.5f, 5), actual.position);
//            Assert.LessOrEqual(new Quaternion(0, 0.4f, 0, 0.9f).x - actual.rotation.x, 0.01);
//            Assert.LessOrEqual(new Quaternion(0, 0.4f, 0, 0.9f).y - actual.rotation.y, 0.01);
//            Assert.LessOrEqual(new Quaternion(0, 0.4f, 0, 0.9f).z - actual.rotation.z, 0.01);
//            Assert.LessOrEqual(new Quaternion(0, 0.4f, 0, 0.9f).w - actual.rotation.w, 0.01);
            Assert.AreEqual(new Vector3(14.1f, 1.0f, 1.0f), actual.localScale);
        }
    }
}