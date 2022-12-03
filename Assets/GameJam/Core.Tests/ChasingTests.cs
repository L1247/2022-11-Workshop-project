#region

using NUnit.Framework;
using UnityEngine;

#endregion

public class ChasingTests
{
    #region Test Methods

    [Test]
    [TestCase(1.42f, 1.42f, 0.71f, 0.71f,1f)]
    [TestCase(-1.42f, -1.42f, -0.71f, -0.71f,-1f)]
    public void _01_MoveTowardsTarget(float targetPosX, float targetPosY, float frame1X, float frame1Y, float scaleX)
    {
        var self = Given_A_Transform_With_Pos(Given_Pos(0, 0));
        var target = Given_A_Transform_With_Pos(Given_Pos(targetPosX, targetPosY));
        var chasing = new Chasing(self, target, null, 1);

        UpdateTheState(chasing);
        Should_Position_Equal(self.position, frame1X, frame1Y);

        UpdateTheState(chasing);
        Should_Position_Equal(self.position, targetPosX, targetPosY);
        Assert.AreEqual(scaleX, self.localScale.x);
    }

    #endregion

    #region Private Methods

    private static Transform Given_A_Transform_With_Pos(Vector3 pos)
    {
        var self = new GameObject("Self").transform;
        self.position = pos;
        return self;
    }

    private static Vector3 Given_Pos(float x, float y)
    {
        var targetPosition = new Vector3(x, y, 0);
        return targetPosition;
    }

    private static void Should_Position_Equal(Vector3 pos, float exceptedX, float exceptedY)
    {
        var posX = pos.x;
        var posY = pos.y;
        Assert.AreEqual(exceptedX, posX, 0.01f, "x is not equal.");
        Assert.AreEqual(exceptedY, posY, 0.01f, "y is not equal.");
    }

    private static void UpdateTheState(Chasing chasing)
    {
        chasing.OnLogic();
    }

    #endregion
}