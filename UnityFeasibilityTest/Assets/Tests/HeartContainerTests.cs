using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Collections.Generic;
using Assets.Tests.Infrastructure;

namespace Assets.Tests
{
    public class HeartContainerTests
    {
        public class TheReplenishMethod
        {

            protected Image Target;
            

            [SetUp]
            public void BeforeEveryTest()
            {
                Target = An.Image();
                
            }

            [Test]
            public void _0_Sets_Image_With_0_Fill_To_0_Fill()
            {

                Target.fillAmount = 0;
                var heart = new Heart(Target);
                var heartContainer = new HeartContainer(new List< Heart > { heart });

                heartContainer.Replenish(0);

                Assert.AreEqual(0, Target.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                Target.fillAmount = 0;
                var heart = new Heart(Target);
                var heartContainer = new HeartContainer(new List<Heart> { heart });

                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Empty_Hearts_Are_Replenished()
            {
                Target.fillAmount = 0;
                var image = new GameObject().AddComponent<Image>();
                image.fillAmount = 1;

                var heartContainer = new HeartContainer(
                    new List<Heart> { new Heart(image), new Heart(Target) }
                    );

                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Hearts_Are_Replenished_One_At_A_Time()
            {
                Target.fillAmount = 0;
                var image = new GameObject().AddComponent<Image>();
                image.fillAmount = 0;
                var heartContainer = new HeartContainer(
                    new List<Heart> { new Heart(Target), new Heart(image) }
                    );
                heartContainer.Replenish(1);
            }

            [Test]
            public void _Hearts_Are_Replenished_In_Order()
            {
                var image = An.Image();

                var heartContainer = new HeartContainer(
                    new List<Heart> { new Heart(image), new Heart(Target) }
                    );

                heartContainer.Replenish(1);

                Assert.AreEqual(0, Target.fillAmount);
            }
        }
    }

}
