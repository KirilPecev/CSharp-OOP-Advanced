namespace SkeletonTests
{
    using NUnit.Framework;
    using System;

    public class AxeTests
    {
        [Test]
        public void AxeShoudLosesDurabilityAfterEachAttack()
        {
            int attackPoints = 10;
            int durabilityPoints = 10;
            int dummyHealth = 5;
            int dummyExperience = 10;
            int expectedValue = 9;

            Axe axe = GetAxe(attackPoints, durabilityPoints);
            Dummy dummy = GetDummy(dummyHealth, dummyExperience);
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedValue), "Axe Durability doesn't change after attack");
        }

        [Test]
        public void AxeShoudThrowInvalidOperationException()
        {
            int attackPoints = 10;
            int durabilityPoints = 0;
            int dummyHealth = 5;
            int dummyExperience = 10;

            Axe axe = GetAxe(attackPoints, durabilityPoints);
            Dummy dummy = GetDummy(dummyHealth, dummyExperience);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Durability points are more than 0");
        }

        private static Dummy GetDummy(int dummyHealth, int dummyExperience)
        {
            return new Dummy(dummyHealth, dummyExperience);
        }

        private static Axe GetAxe(int attackPoints, int durabilityPoints)
        {
            return new Axe(attackPoints, durabilityPoints);
        }
    }
}
