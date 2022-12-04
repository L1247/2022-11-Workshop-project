#region

using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

#endregion

public class Monster1RuntimeTests
{
#region Public Methods

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ChasingTest()
    {
        var monsterPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameJam/Prefab/Monster1.prefab");
        var monster       = Object.Instantiate(monsterPrefab).GetComponent<Monster1>();
        monster.SetPos(new Vector3(1 , 1 , 0));
        var target = Object.Instantiate(monsterPrefab).GetComponent<Monster1>();
        target.SetPos(Vector3.zero);
        monster.SetTarget(target.transform);
        Assert.IsNotNull(monster);
        yield return new WaitForSeconds(1);
        Assert.AreEqual(new Vector3(0.05f , 0.05f , 0f) , monster.GetPos());
    }

    [UnityTest]
    public IEnumerator Monster_Initialization()
    {
        var monsterPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameJam/Prefab/Monster1.prefab");
        var monster       = Object.Instantiate(monsterPrefab).GetComponent<Monster1>();
        yield return null;
        Assert.AreEqual("Chasing" , monster.GetStateTypeName("Chasing"));
        Assert.AreEqual("Death" , monster.GetStateTypeName("Death"));
        Assert.AreEqual("Chasing" , monster.GetCurrentStateTypeName());
    }

    [UnityTest]
    public IEnumerator Transition_To_Death_When_Health_0()
    {
        var monsterPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameJam/Prefab/Monster1.prefab");
        var monster       = Object.Instantiate(monsterPrefab).GetComponent<Monster1>();

        monster.SetHealth(0);

        yield return null;

        Assert.AreEqual("Death" , monster.GetCurrentStateTypeName());
    }

#endregion
}