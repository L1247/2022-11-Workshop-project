using System;
using FSM;
using NUnit.Framework;
using UnityEngine;
using Workshop.Team2;

public class ChasingTests
{
    [Test]
    public void ChasingToTarget()
    {
        var timeSec = 1;
        var fps = 60;
        var frame = timeSec * fps;
        
        var self = new GameObject("Self", typeof(Character));
        var target = new GameObject("Target");
        
        self.transform.position = new Vector3(3 , 2 , 0);
        float originDistance = (target.transform.position - self.transform.position).magnitude;
        
        var chasing = new Chase(self.GetComponent<Character>(), target);
        for (int i = 0 ; i < frame ; i++)
        {
            var tick = 1 / (double)fps;
            chasing.MoveTo(target.transform , (float)tick);
        }
        
        float distanceAfterMove = (target.transform.position - self.transform.position).magnitude;
        Debug.Log($"Origin Dis: {originDistance} | AfterMove Dis: {distanceAfterMove}");
        Assert.Greater(originDistance , 0); // 原始距離 > 0
        Assert.Less(distanceAfterMove , originDistance); // 1秒後 移動後距離 < 原始距離
    }

}