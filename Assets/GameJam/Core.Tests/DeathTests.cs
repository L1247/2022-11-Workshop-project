#region

using GameJam.Core.States;
using NUnit.Framework;

#endregion

[TestFixture]
public class DeathTests : GGJTests
{
#region Test Methods

    [Test(Description = "進入死亡，消失")]
    public void _01_Disappear_On_Enter()
    {
        var monsterA = Give_A_Monster1();
        new Death(monsterA).OnEnter();
        var targetB = Give_A_Monster1();
        Assert.IsNull(monsterA);
    }

#endregion
}