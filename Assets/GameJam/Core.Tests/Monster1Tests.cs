#region

using GameJam.Core;
using NUnit.Framework;
using UnityEngine;

#endregion

[TestFixture]
public class Monster1Tests
{
#region Test Methods

    [Test]
    [TestCase(Facing.Right , 1)]
    [TestCase(Facing.Left ,  -1)]
    public void Monster_Facing(Facing facing , float expectedScaleX)
    {
        var monster1 = new GameObject("").AddComponent<Monster1>();
        monster1.SetFacing(facing);
        Assert.AreEqual(expectedScaleX , monster1.transform.localScale.x);
    }

    [Test]
    public void Monster_Facing_None()
    {
        var monster1 = new GameObject("").AddComponent<Monster1>();
        monster1.SetFacing(Facing.Left);

        Assert.DoesNotThrow(() => monster1.SetFacing(Facing.None));

        Assert.AreEqual(Facing.Left , monster1.GetFacing());
    }

#endregion
}