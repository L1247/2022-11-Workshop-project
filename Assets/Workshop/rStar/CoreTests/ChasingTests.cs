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
        var self = new GameObject("Self").transform;
        self.position = new Vector3(1 , 1 , 1);
        var target = new GameObject("Targe").transform;
        target.position = new Vector3(2.73f , 2.73f , 2.73f);

        var moveSpeed = 1f;
        var chasing   = new Chasing(self , target , null , moveSpeed);

        chasing.OnLogic();

        var nearThreshold      = 0.01f;
        var frame1Value        = 1.58f;
        var movedDistance      = (new Vector3(frame1Value , frame1Value , frame1Value) - self.position).magnitude;
        var reachFramePosition = movedDistance <= nearThreshold;
        Assert.AreEqual(true , reachFramePosition);

        chasing.OnLogic();
        var frame2Value = 2.15f;
        movedDistance      = (new Vector3(frame2Value , frame2Value , frame2Value) - self.position).magnitude;
        reachFramePosition = movedDistance <= nearThreshold;
        Assert.AreEqual(true , reachFramePosition);

        chasing.OnLogic();
        var frame3Value = 2.73f;
        movedDistance      = (new Vector3(frame3Value , frame3Value , frame3Value) - self.position).magnitude;
        reachFramePosition = movedDistance <= nearThreshold;
        Assert.AreEqual(true , reachFramePosition);

        var samePosition = (target.position - self.position).magnitude <= nearThreshold;
        Assert.AreEqual(true , samePosition);
    }

#endregion
}