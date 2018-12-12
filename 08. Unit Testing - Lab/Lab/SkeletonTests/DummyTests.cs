namespace SkeletonTests
{
    using NUnit.Framework;
    using System;

    public class DummyTests
    {
        [Test]
        public void DummyShouldLosesHealthIfAttacked()
        {
            int dummyHealth = 5;
            int dummyExperience = 10;
            int attackPoints = 2;
            int expectedValue = 3;

            Dummy dummy = GetDummy(dummyHealth, dummyExperience);
            dummy.TakeAttack(attackPoints);

            Assert.That(dummy.Health, Is.EqualTo(expectedValue), "Dummy doesn't lose health.");
        }

        [Test]
        public void DeadDummyShouldThrowAnExceptionIfAttacked()
        {
            int dummyHealth = 0;
            int dummyExperience = 10;
            int attackPoints = 2;

            Dummy dummy = GetDummy(dummyHealth, dummyExperience);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints),"Dummy doesn't throw an exception.");
        }

        [Test]
        public void DeadDummyShouldGiveExperience()
        {
            int dummyHealth = 0;
            int dummyExperience = 10;

            Dummy dummy = GetDummy(dummyHealth, dummyExperience);
            Assert.That(dummy.GiveExperience(), Is.EqualTo(dummyExperience), "Dummy cannot give experience.");
        }

        [Test]
        public void AliveDummyShouldNotGiveExperience()
        {
            int dummyHealth = 10;
            int dummyExperience = 10;

            Dummy dummy = GetDummy(dummyHealth, dummyExperience);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(),"Dummy give experience.");
        }

        private static Dummy GetDummy(int dummyHealth, int dummyExperience)
        {
            return new Dummy(dummyHealth, dummyExperience);
        }
    }
}
