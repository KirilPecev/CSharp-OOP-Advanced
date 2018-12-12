namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Globalization;
    using System.Linq;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);

                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = performer.Instruments
                        .OrderByDescending(i => i.Wear);

                    result += ($"---{performer.Name}");

                    int counter = 1;
                    result += " (";
                    foreach (var instrument in instruments)
                    {
                        if (counter != 1)
                        {
                            result += ", ";
                        }

                        if (!instrument.IsBroken)
                        {
                            result += $"{instrument}";
                        }
                        else
                        {
                            result += $"{instrument}";
                        }

                        counter++;
                    }

                    result += ")" + Environment.NewLine;
                }

                if (!set.Songs.Any())
                {
                    result += ("--No songs played") + "\n";
                }
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({FormatTime(song.Duration)})") + "\n";
                    }
                }
            }

            return result.ToString().TrimEnd();
        }

        private string FormatTime(TimeSpan time)
        {
            int minutes = time.Days * 1440 + time.Hours * 60 + time.Minutes;
            int seconds = time.Seconds;

            return $"{minutes:d2}:{seconds:d2}";
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            var factory = typeof(StartUp).Assembly.GetTypes().FirstOrDefault(x => x.Name == "SetFactory");
            var instance = Activator.CreateInstance(factory);
            ISet currentSet = (ISet)factory.GetMethod("CreateSet").Invoke(instance, new object[] { name, type });

            this.stage.AddSet(currentSet);

            return $"Registered {type} set";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instruments = args.Skip(2).ToArray();

            var instrumentFactory = typeof(StartUp).Assembly.GetTypes().FirstOrDefault(x => x.Name == "InstrumentFactory");
            var instrumentInstance = Activator.CreateInstance(instrumentFactory);

            IInstrument[] currentInsturments = instruments
                .Select(i =>
                (IInstrument)instrumentFactory.GetMethod("CreateInstrument")
                .Invoke(instrumentInstance, new object[] { i }))
                .ToArray();

            var performerFactory = typeof(StartUp).Assembly.GetTypes().FirstOrDefault(x => x.Name == "PerformerFactory");
            var performerInstance = Activator.CreateInstance(performerFactory);

            var performer = (IPerformer)performerFactory.GetMethod("CreatePerformer").Invoke(performerInstance, new object[] { name, age });


            foreach (var instrument in currentInsturments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, CultureInfo.InvariantCulture);

            var factory = typeof(StartUp).Assembly.GetTypes().FirstOrDefault(x => x.Name == "SongFactory");
            var instance = Activator.CreateInstance(factory);

            var song = (ISong)factory.GetMethod("CreateSong").Invoke(instance, new object[] { name, duration });

            this.stage.AddSong(song);

            return $"Registered song {name} ({duration.ToString(TimeFormat)})";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration.ToString(TimeFormat)}) to {setName}";
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            ISet set = this.stage.GetSet(setName);
            IPerformer performer = this.stage.GetPerformer(performerName);

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
    }
}