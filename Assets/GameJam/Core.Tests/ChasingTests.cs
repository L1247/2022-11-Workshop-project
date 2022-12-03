#region

using NUnit.Framework;
using UnityEngine;

#endregion

public class ChasingTests
{
#region Test Methods

    [Test]
    [TestCase(1.42f ,  1.42f ,  0.71f ,  0.71f)]
    [TestCase(-1.42f , -1.42f , -0.71f , -0.71f)]
    public void _01_MoveTowardsTarget(float targetPosX , float targetPosY , float frame1X , float frame1Y)
    {
        var self = new GameObject("Self").transform;
        self.position = Vector3.zero;
        var target         = new GameObject("Target").transform;
        var targetPosition = Given_Pos(targetPosX , targetPosY);
        target.position = targetPosition;
        Animator animator = null;
        var      chasing  = new Chasing(self , target , animator , 1);

        chasing.OnLogic();
        Should_Position_Equal(self.position , frame1X , frame1Y);

        chasing.OnLogic();
        Should_Position_Equal(self.position , targetPosX , targetPosY);
    }

#endregion

#region Private Methods

    private static Vector3 Given_Pos(float x , float y)
    {
        var targetPosition = new Vector3(x , y , 0);
        return targetPosition;
    }

    private static void Should_Position_Equal(Vector3 pos , float exceptedX , float exceptedY)
    {
        var posX = pos.x;
        var posY = pos.y;
        Assert.AreEqual(exceptedX , posX , 0.01f , "x is not equal.");
        Assert.AreEqual(exceptedY , posY , 0.01f , "y is not equal.");
    }

#endregion
}