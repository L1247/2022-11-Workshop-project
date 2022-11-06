using NUnit.Framework;
using UnityEngine;
using Workshop.Team3;
using NSubstitute;

public class ChasingTest
{
    MonsterStateMachine stateMachine;
    Transform selfTrans;
    Transform targetTrans;
    ITime itime;
    [SetUp]
    public void SetUp()
    {
        selfTrans = new GameObject().transform;
        targetTrans = new GameObject().transform;
        stateMachine = selfTrans.gameObject.AddComponent<MonsterStateMachine>();
        itime = new TestTime();
    }

    [Test]
    public void ChasingTarget()
    {
        selfTrans.position = new Vector3(100, 0, 0);
        targetTrans.position = new Vector3(0, 0, 0);
        var chase = new Chase(stateMachine, itime);
        itime.getDeltaTime().Returns<float>(1);
        chase.Move(targetTrans.position, itime);
        Assert.Less(Vector3.Distance(selfTrans.position, targetTrans.position),100);
    }
}
