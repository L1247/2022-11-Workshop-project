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

            target.transform.position = new Vector3(5, 0, 0);
            self.transform.position = new Vector3(0, 0, 0);

            Chase chase = new Chase(self.transform, target.transform, 1);
            var oringaldistense = Vector3.Distance(chase.Origin.transform.position, chase.Target.transform.position);
            chase.ChasingTarget(1);
            var endistense = Vector3.Distance(chase.Origin.transform.position, chase.Target.transform.position);

            Assert.Less(oringaldistense,endistense , "distense is chage");
        }
    }
}