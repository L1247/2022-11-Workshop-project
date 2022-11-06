#region

using NUnit.Framework;
using UnityEngine;

#endregion

public class ChasingTests
{
#region Test Methods

    [Test]
    public void ChasingTarget()
    {
        var self   = new GameObject("Self").transform;
        var target = new GameObject("Targe").transform;

        var chasing = new Chasing(self , target , null , 1);
        chasing.OnLogic();
        Assert.AreEqual(0.5f , 1);
    }

#endregion
}