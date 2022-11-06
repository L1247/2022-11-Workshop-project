#region

using NUnit.Framework;
using UnityEngine;

#endregion

public class ChaseTests
{
#region Test Methods

    [Test]
    public void ChaseTarget()
    {
        var self = new GameObject("Self");
        var player = new GameObject
        {
            tag       = "Player",
            transform = { position = new Vector3(1, 0, 0) }
        };

        var moster  = self.AddComponent<Monster>();
        var chasing = new Chase(moster);

        chasing.OnEnter();
        chasing.OnLogic();
        
        var distance = Vector3.Distance(self.transform.position, player.transform.position);
        Assert.IsTrue(distance < 1f);
    }

#endregion
}