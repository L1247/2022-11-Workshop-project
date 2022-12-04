#region

using GameJam.Core;
using GameJam.Core.States;
using NSubstitute;
using NUnit.Framework;

#endregion

public class ChasingTests : GGJTests
{
#region Test Methods

    [Test(Description = "往目標方向移動")]
    [TestCase(-1.42f , -1.42f , -0.71f , -0.71f , Facing.Right ,
              Facing.Left , Description = "左")]
    [TestCase(1.42f , 1.42f , 0.71f , 0.71f , Facing.Left ,
              Facing.Right , Description = "右")]
    [Category("Moving")]
    public void _01_MoveTowardsTarget(float  targetPosX , float targetPosY , float frame1X , float frame1Y , Facing defaultFacing ,
                                      Facing expectedFacing)
    {
        var monster1 = Given_A_Monster1_With_Pos(Given_Pos(0 , 0));
        var target   = Given_A_Monster1_With_Pos(Given_Pos(targetPosX , targetPosY));
        monster1.SetTarget(target.transform);
        monster1.SetMoveSpeed(1);
        Given_A_Facing(monster1 , defaultFacing);
        var chasing = Given_A_Chasing_State(monster1);

        UpdateTheState(chasing);
        Should_Position_Equal(monster1.GetPos() , frame1X , frame1Y);

        UpdateTheState(chasing);
        Should_Position_Equal(monster1.GetPos() , targetPosX , targetPosY);

        Should_Facing_Is(monster1 , expectedFacing);
    }

    [Test(Description = "距離靠近，停止移動")]
    [TestCase(-1 , -1 , -0.95f , -0.95f , Facing.Left ,
              Description = "左")]
    [TestCase(1 , 1 , 0.95f , 0.95f , Facing.Right ,
              Description = "右")]
    [Category("Moving")]
    public void _02_StopMoving(float targetPosX , float targetPosY , float monster1PosX , float monster1PosY , Facing facing)
    {
        var monster1 = Given_A_Monster1_With_Pos(Given_Pos(monster1PosX , monster1PosY));
        Given_A_Facing(monster1 , facing);
        var chasing = Given_A_Chasing_State(monster1);

        UpdateTheState(chasing);
        Should_Position_Equal(monster1.GetPos() , monster1PosX , monster1PosY);
        Should_Facing_Is(monster1 , facing);
    }

    [Test(Description = "移動速度過快")]
    [TestCase(-1.42f , -1.42f , -1.42f , -1.42f , Facing.Right ,
              Facing.Left , Description = "左")]
    [TestCase(1.42f , 1.42f , 1.42f , 1.42f , Facing.Left ,
              Facing.Right , Description = "右")]
    [Category("Moving")]
    public void _03_MoveSpeed_Is_High(float  targetPosX ,    float  targetPosY , float frame1X , float frame1Y ,
                                      Facing defaultFacing , Facing expectedFacing)
    {
        var monster1 = Given_A_Monster1_With_Pos(Given_Pos(0 , 0));
        var target   = Given_A_Monster1_With_Pos(Given_Pos(targetPosX , targetPosY));
        monster1.SetTarget(target.transform);
        Given_A_Facing(monster1 , defaultFacing);
        monster1.SetMoveSpeed(9999);
        var chasing = Given_A_Chasing_State(monster1);

        UpdateTheState(chasing);
        Should_Position_Equal(monster1.GetPos() , frame1X , frame1Y);

        UpdateTheState(chasing);

        Should_Position_Equal(monster1.GetPos() , targetPosX , targetPosY);
        Should_Facing_Is(monster1 , expectedFacing);
    }

    [Test(Description = "追擊_無目標")]
    public void _04_Move_With_No_Target()
    {
        var monster1 = Given_A_Monster1_With_Pos(Given_Pos(0 , 0));
        Given_A_Facing(monster1 , Facing.Right);
        var chasing = Given_A_Chasing_State(monster1);

        UpdateTheState(chasing);
        Should_Position_Equal(monster1.GetPos() , 0 , 0);
    }

    [Test(Description = "進入Chasing，播放動畫")]
    [Category("Animation")]
    public void _05_Play_Animation_When_Enter_Chasing()
    {
        var monster1     = Give_A_Monster1();
        var chasingState = Given_A_Chasing_State(monster1);
        chasingState.OnEnter();

        monster1.UnityComponent.Received(1).PlayAnimation("Chasing");
    }

    [Test(Description = "當快靠近目標，不要順移過去")]
    [Category("Bug")]
    public void _101_Should_Not_Teleport_Position_When_Closing_Target()
    {
        var monster1 = Given_A_Monster1_With_Pos(Given_Pos(-0.30f , 2.39f));
        monster1.SetMoveSpeed(1);
        var target = Given_A_Monster1_With_Pos(Given_Pos(1.86f , 3.39f));
        monster1.SetTarget(target.transform);
        var chasing = Given_A_Chasing_State(monster1);
        UpdateTheState(chasing);
        var posX = monster1.GetPos().x;
        var posY = monster1.GetPos().y;

        Assert.AreNotEqual(1.86f , posX);
        Assert.AreNotEqual(3.39f , posY);
    }

#endregion

#region Private Methods

    private static Chasing Given_A_Chasing_State(Monster1 monster1)
    {
        // var chasing = new Chasing(monster1 , moveSpeed);
        var chasing = new Chasing(monster1);
        chasing.SetDeltaTime(1);
        return chasing;
    }

    private static void Given_A_Facing(Monster1 monster1 , Facing facing)
    {
        monster1.SetFacing(facing);
    }

    private static void Should_Facing_Is(Monster1 monster1 , Facing exceptedFacing)
    {
        Assert.AreEqual(exceptedFacing , monster1.GetFacing());
    }

    private static void UpdateTheState(Chasing chasing)
    {
        chasing.OnLogic();
    }

#endregion
}