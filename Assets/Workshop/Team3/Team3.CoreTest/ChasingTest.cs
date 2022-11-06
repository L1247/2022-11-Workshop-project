using NUnit.Framework;
using UnityEngine;
using Workshop.Team3;
using NSubstitute;

public class ChasingTest
{
    MonsterStateMachine stateMachine;
    Transform selfTrans;
    Transform targetTrans;
    [SetUp]
    public void SetUp()
    {
        selfTrans = new GameObject().transform;
        targetTrans = new GameObject().transform;
        stateMachine = selfTrans.gameObject.AddComponent<MonsterStateMachine>();
    }

    [Test]
    public void ChasingTarget()
    {
        selfTrans.position = new Vector3(100, 0, 0);
        targetTrans.position = new Vector3(0, 0, 0);
        var time = Substitute.For<ITime>();
        time.getDeltaTime().Returns(1);
        var chase = new Chase(stateMachine, time);
        chase.Move(targetTrans.position, time);
        Assert.Less(Vector3.Distance(selfTrans.position, targetTrans.position),100);
    }
}
