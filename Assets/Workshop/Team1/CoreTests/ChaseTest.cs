using NUnit.Framework;
using UnityEngine;

namespace Workshop.Team1.CoreTests
{
    public class ChaseTest
    {

        [Test]
        public void ChaseTestSimplePasses()
        {
            // Use the Assert class to test conditions.
            GameObject target = new GameObject();
            GameObject self = new GameObject();

            target.transform.position = new Vector3(2, 2, 2);
            self.transform.position = new Vector3(1, 1, 1);

            Chase chase = new Chase(self.transform,target.transform);
            var oringaldistense = Vector3.Distance(target.transform.position, self.transform.position);
            chase.OnLogic();
            var endistense = Vector3.Distance(chase.Origin.transform.position,chase.Target.transform.position);
            
            Assert.AreNotEqual(oringaldistense,endistense,"distense is chage");
        }
    }
}