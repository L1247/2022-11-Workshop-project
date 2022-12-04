#region

using GameJam.Core;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

#endregion

public class GGJTests
{
#region Protected Methods

    protected static Monster1 Give_A_Monster1()
    {
        var unityComponent = Substitute.For<IUnityComponent>();
        var monster1       = new GameObject("monster1").AddComponent<Monster1>();
        monster1.SetUnityComponent(unityComponent);
        return monster1;
    }

    protected static Monster1 Given_A_Monster1_With_Pos(Vector3 pos)
    {
        var monster1 = Give_A_Monster1();
        monster1.SetPos(pos);
        return monster1;
    }

    protected static Vector3 Given_Pos(float x , float y)
    {
        var targetPosition = new Vector3(x , y , 0);
        return targetPosition;
    }

    protected static void Should_Position_Equal(Vector3 pos , float exceptedX , float exceptedY)
    {
        var posX = pos.x;
        var posY = pos.y;
        Assert.AreEqual(exceptedX , posX , 0.01f , "x is not equal.");
        Assert.AreEqual(exceptedY , posY , 0.01f , "y is not equal.");
    }

#endregion
}