namespace SkeletonTests
{
    using Moq;
    using NUnit.Framework;

    public class HeroTests
    {
        private const int giveXP = 25;

        [Test]
        public void HeroShouldGainsXPWhenTheTargetDies()
        {
            Hero hero = new Hero("Pesho", new FakeAxe());
            ITarget target = new FakeTarget();

            hero.Attack(target);

            Assert.That(hero.Experience, Is.EqualTo(giveXP),"Hero doesn't receive XP.");
        }


        [Test]
        public void HeroShouldGainsXPWhenTheTargetDiesMocking()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(t => t.Health).Returns(0);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(giveXP);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Hero hero = new Hero("Pesho", fakeWeapon.Object);
            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(giveXP), "Hero doesn't receive XP.");
        }

        private class FakeTarget : ITarget
        {
            private const int targetHealth = 10;
           
            public FakeTarget()
            {
                this.Health = targetHealth;
            }

            public int Health { get; private set; }

            public int GiveExperience()
            {
                return giveXP;
            }

            public bool IsDead()
            {
                return this.Health <= 0;
            }

            public void TakeAttack(int attackPoints)
            {
                this.Health -= attackPoints;
            }
        }

        private class FakeAxe : IWeapon
        {
            private const int attackPoints = 15;

            public FakeAxe()
            {
                this.AttackPoints = attackPoints;
            }

            public int AttackPoints { get; private set; }

            public int DurabilityPoints { get; private set; }

            public void Attack(ITarget target)
            {
                target.TakeAttack(AttackPoints);
            }
        }
    }
}
