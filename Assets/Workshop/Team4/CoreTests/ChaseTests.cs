#region

using System.Runtime.Remoting;
using NUnit.Framework;
using UnityEngine;

#endregion

public class ChaseTests
{
    #region Test Methods

    [Test]
    public void ChaseTarget() {
        var self = new GameObject("Self") {
            transform = { position = new Vector3(0, 0, 0) }
        };
        var player = new GameObject
        {
            tag       = "Player",
            transform = { position = new Vector3(1, 0, 0) }
        };

        var timer = new FakeTimer();
        timer.DeltTime = 1;
        
        var moster  = self.AddComponent<Monster>();
        var chasing = new Chase(moster, timer);

        chasing.OnEnter();
        chasing.OnLogic();

        Assert.AreEqual(self.transform.position.x, player.transform.position.x);
    }

    #endregion
}
