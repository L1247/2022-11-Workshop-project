using System;
using FSM;
using NUnit.Framework;
using UnityEngine;
using Workshop.Team2;

public class ChasingTests
{
    [Test]
    public void ChasingTarget()
    {
        var self = new GameObject("Self", typeof(Character));
        var target = new GameObject("Target", typeof(Player));
        self.transform.position = new Vector3(1 , 0 , 0);
        var chasing = new Chase(self.GetComponent<Character>(), target.GetComponent<Character>());
        for (int i = 0 ; i < 10 ; i++)
        {
            chasing.MoveTo(target.transform , 0.1f);
            
        }
       
        Assert.AreEqual( 0 , Vector3.Distance(self.transform.position, target.transform.position));
    }

}