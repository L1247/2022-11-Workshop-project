#region

using GameJam.Core;
using NUnit.Framework;
using UnityEngine;

#endregion

public class ChasingTests
{
#region Test Methods

    [Test]
    [TestCase(                              -1.42f , -1.42f , -0.71f , -0.71f , Facing.Right ,
                             Facing.Left ,  Description = "左")]
    [TestCase(                              1.42f , 1.42f , 0.71f , 0.71f , Facing.Left ,
                             Facing.Right , Description = "右")]
    [Category("Moving")]
    public void _01_MoveTowardsTarget(float  targetPosX , float targetPosY , float frame1X , float frame1Y , Facing defaultFacing ,
                                      Facing expectedFacing)
    {
        var self = Given_A_Monster1_With_Pos(Given_Pos(0 , 0));
        Given_A_Facing(self , defaultFacing);
        var target  = Given_A_Monster1_With_Pos(Given_Pos(targetPosX , targetPosY));
        var chasing = Given_A_Chasing_State(self , target);

        UpdateTheState(chasing);
        Should_Position_Equal(self.GetPos() , frame1X , frame1Y);

        UpdateTheState(chasing);
        Should_Position_Equal(self.GetPos() , targetPosX , targetPosY);

        Should_Facing_Is(self , expectedFacing);
    }


    [Test]
    [TestCase(-1 , -1 , -0.99f , -0.99f , Facing.Left ,
              Description = "左")]
    [TestCase(1 , 1 , 0.99f , 0.99f , Facing.Right ,
              Description = "右")]
    [Category("Moving")]
    public void _02_StopMoving(float targetPosX , float targetPosY , float selfPosX , float selfPosY , Facing facing)
    {
        var self = Given_A_Monster1_With_Pos(Given_Pos(selfPosX , selfPosY));
        Given_A_Facing(self , facing);
        var target  = Given_A_Monster1_With_Pos(Given_Pos(targetPosY , targetPosY));
        var chasing = Given_A_Chasing_State(self , target);

        UpdateTheState(chasing);
        Should_Position_Equal(self.GetPos() , selfPosX , selfPosY);
        Should_Facing_Is(self , facing);
    }

    [Test]
    [TestCase(                              -1.42f , -1.42f , -1.42f , -1.42f , Facing.Right ,
                             Facing.Left ,  Description = "左")]
    [TestCase(                              1.42f , 1.42f , 1.42f , 1.42f , Facing.Left ,
                             Facing.Right , Description = "右")]
    [Category("Moving")]
    public void _03_MoveSpeed_Is_High(float  targetPosX , float targetPosY , float frame1X , float frame1Y , Facing defaultFacing ,
                                      Facing expectedFacing)
    {
        var self = Given_A_Monster1_With_Pos(Given_Pos(0 , 0));
        Given_A_Facing(self , defaultFacing);
        var target  = Given_A_Monster1_With_Pos(Given_Pos(targetPosX , targetPosY));
        var chasing = Given_A_Chasing_State(self , target , 9999);

        UpdateTheState(chasing);
        Should_Position_Equal(self.GetPos() , frame1X , frame1Y);

        UpdateTheState(chasing);
        Should_Position_Equal(self.GetPos() , targetPosX , targetPosY);

        Should_Facing_Is(self , expectedFacing);
    }

#endregion

#region Private Methods

    private static Chasing Given_A_Chasing_State(Monster1 self , Monster1 target , float moveSpeed = 1)
    {
        var chasing = new Chasing(self , target.transform , null , moveSpeed);
        chasing.SetDeltaTime(1);
        return chasing;
    }

    private static void Given_A_Facing(Monster1 self , Facing facing)
    {
        self.SetFacing(facing);
    }

    private static Monster1 Given_A_Monster1_With_Pos(Vector3 pos)
    {
        var monster1 = new GameObject("Self").AddComponent<Monster1>();
        monster1.SetPos(pos);
        return monster1;
    }

    private static Vector3 Given_Pos(float x , float y)
    {
        var targetPosition = new Vector3(x , y , 0);
        return targetPosition;
    }

    private static void Should_Facing_Is(Monster1 monster1 , Facing exceptedFacing)
    {
        Assert.AreEqual(exceptedFacing , monster1.GetFacing());
    }

    private static void Should_Position_Equal(Vector3 pos , float exceptedX , float exceptedY)
    {
        var posX = pos.x;
        var posY = pos.y;
        Assert.AreEqual(exceptedX , posX , 0.01f , "x is not equal.");
        Assert.AreEqual(exceptedY , posY , 0.01f , "y is not equal.");
    }

    private static void UpdateTheState(Chasing chasing)
    {
        chasing.OnLogic();
    }

#endregion
}