using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;


namespace Tests
{
    public class NetworkTestPlaymode
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NetworkTestPlaymodeSimplePasses()
        {
            var CUDLRserver = GameObject.Find("CUDLRServer");
            Debug.Log(CUDLRserver);

            var lists = GameObject.FindObjectsOfType<Text>();
            Debug.Log(lists);
            Debug.Log(lists.Length);
            Debug.Log(lists[0].text);

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NetworkTestPlaymodeWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
