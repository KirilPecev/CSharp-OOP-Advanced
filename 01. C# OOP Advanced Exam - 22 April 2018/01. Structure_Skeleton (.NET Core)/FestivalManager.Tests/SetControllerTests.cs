namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SetControllerTests
    {
        private const string GetThisType = "SetController";
        private const string GetThisField = "stage";
        private const string ConstructorParameter = "IStage";
        private const string MethodName = "PerformSets";
    

        [Test]
        public void ValidatePerformSetsMethodDidNotPerform()
        {
            IStage stage = new Stage();

            ISet shortSet = new Short("Short");
            ISet mediumSet = new Medium("Medium");
            ISet longSet = new Long("Long");

            longSet.AddSong(new Song("Kilo dole kilo gore", new TimeSpan(0, 3, 45)));
            mediumSet.AddSong(new Song("Sampanjac", new TimeSpan(0, 3, 32)));
            shortSet.AddSong(new Song("Milioni kamioni", new TimeSpan(0, 3, 0)));

            mediumSet.AddPerformer(new Performer("Mile Kitic", 32));

            stage.AddSet(shortSet);
            stage.AddSet(longSet);
            stage.AddSet(mediumSet);

            ISetController setController = new SetController(stage);

            string actualResult = setController.PerformSets();
            string expectedResult =
                "1. Long:\r\n-- Did not perform\r\n2. Medium:\r\n-- Did not perform\r\n3. Short:\r\n-- Did not perform";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ValidatePerformSetsInstrumentWearsDown()
        {
            IStage stage = new Stage();

            ISet set = new Long("Long");

            set.AddSong(new Song("Sampanjac", new TimeSpan(0, 3, 32)));

            IPerformer performer = new Performer("Mile Kitic", 32);

            IInstrument instrument = new Microphone();

            performer.AddInstrument(instrument);

            set.AddPerformer(performer);

            stage.AddSet(set);

            ISetController setController = new SetController(stage);

            setController.PerformSets();

            double actualResult = instrument.Wear;
            double expectedResult = 20;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ValidatePerformSetsCanPerform()
        {
            IStage stage = new Stage();

            ISet longSet = new Long("Long");
            ISet mediumSet = new Medium("Medium");
            ISet shortSet = new Short("Short");

            longSet.AddSong(new Song("Kilo dole kilo gore", new TimeSpan(0, 3, 45)));
            mediumSet.AddSong(new Song("Sampanjac", new TimeSpan(0, 3, 32)));
            shortSet.AddSong(new Song("Milioni kamioni", new TimeSpan(0, 3, 0)));

            IPerformer firstPerformer = new Performer("Mile Kitic", 32);
            firstPerformer.AddInstrument(new Microphone());

            IPerformer secondPerformer = new Performer("Kiro", 21);
            secondPerformer.AddInstrument(new Microphone());
            secondPerformer.AddInstrument(new Guitar());

            IPerformer thirdPerformer = new Performer("Pesho", 28);
            thirdPerformer.AddInstrument(new Microphone());

            IPerformer fourthPerformer = new Performer("Gosho", 34);
            fourthPerformer.AddInstrument(new Drums());

            mediumSet.AddPerformer(firstPerformer);
            mediumSet.AddPerformer(secondPerformer);
            shortSet.AddPerformer(thirdPerformer);
            longSet.AddPerformer(fourthPerformer);

            stage.AddSet(shortSet);
            stage.AddSet(longSet);
            stage.AddSet(mediumSet);

            ISetController setController = new SetController(stage);

            string actualResult = setController.PerformSets();
            string expectedResult =
                "1. Long:\r\n-- 1. Kilo dole kilo gore (03:45)\r\n-- Set Successful\r\n2. Medium:\r\n-- 1. Sampanjac (03:32)\r\n-- Set Successful\r\n3. Short:\r\n-- 1. Milioni kamioni (03:00)\r\n-- Set Successful";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}