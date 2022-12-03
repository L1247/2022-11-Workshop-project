#region

using NUnit.Framework;
using UnityEngine;

#endregion

public class ChasingTests
{
#region Test Methods

    [Test]
    public void _01_MoveTowardsTarget()
    {
        var self = new GameObject("Self").transform;
        self.position = Vector3.zero;
        var target = new GameObject("Target").transform;
        target.position = new Vector3(1.42f , 1.42f , 0);
        Animator animator = null;
        var      chasing  = new Chasing(self , target , animator , 1);

        chasing.OnLogic();
        Should_Position_Equal(self.position , 0.71f , 0.71f);

        chasing.OnLogic();
        Should_Position_Equal(self.position , 1.42f , 1.42f);
    }

#endregion

#region Private Methods

    private static void Should_Position_Equal(Vector3 pos , float exceptedX , float exceptedY)
    {
        var posX = pos.x;
        var posY = pos.y;
        Assert.AreEqual(exceptedX , posX , 0.01f , "x is not equal.");
        Assert.AreEqual(exceptedY , posY , 0.01f , "y is not equal.");
    }

#endregion
}