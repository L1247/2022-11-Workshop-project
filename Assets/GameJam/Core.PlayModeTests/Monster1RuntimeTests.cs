using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class Monster1RuntimeTests
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ChasingTest()
    {
        var monsterPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameJam/Prefab/Monster1.prefab");
        var monster       = Object.Instantiate(monsterPrefab).GetComponent<Monster1>();
        monster.SetPos(new Vector3(5,5,0));
        var target       = Object.Instantiate(monsterPrefab).GetComponent<Monster1>();
        target.SetPos(Vector3.zero);
        monster.SetTarget(target.transform);
        Assert.IsNotNull(monster);
        yield return new WaitForSeconds(5);
        Assert.AreEqual(Vector3.zero , monster.GetPos());
    }
}