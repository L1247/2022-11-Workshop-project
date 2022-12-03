#region

using GameJam.Core;
using NUnit.Framework;
using UnityEngine;

#endregion

[TestFixture]
public class Monster1Tests
{
#region Test Methods

    [Test(Description = "不能設定怪物面向為None")]
    public void Monster_Cant_Facing_None()
    {
        var monster1 = Given_A_Monster1();
        monster1.SetFacing(Facing.Left);

        Assert.DoesNotThrow(() => monster1.SetFacing(Facing.None));

        Assert.AreEqual(Facing.Left , monster1.GetFacing());
    }

    [Test(Description = "怪物面向")]
    [TestCase(Facing.Right , 1)]
    [TestCase(Facing.Left ,  -1)]
    public void Monster_Facing(Facing facing , float expectedScaleX)
    {
        var monster1 = Given_A_Monster1();
        monster1.SetFacing(facing);
        Assert.AreEqual(expectedScaleX , monster1.transform.localScale.x);
    }

#endregion

#region Private Methods

    private static Monster1 Given_A_Monster1()
    {
        var monster1 = new GameObject("").AddComponent<Monster1>();
        return monster1;
    }

#endregion
}