namespace FestivalManager.Entities
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Stage : IStage
    {
        private List<ISet> sets;
        private List<ISong> songs;
        private List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            return this.Performers.FirstOrDefault(p => p.Name == name);
        }

        public ISet GetSet(string name)
        {
            return this.Sets.FirstOrDefault(p => p.Name == name);
        }

        public ISong GetSong(string name)
        {
            return this.Songs.FirstOrDefault(p => p.Name == name);
        }

        public bool HasPerformer(string name)
        {
            return this.Performers.Any(p => p.Name == name);
        }

        public bool HasSet(string name)
        {
            return this.Sets.Any(p => p.Name == name);
        }

        public bool HasSong(string name)
        {
            return this.Songs.Any(p => p.Name == name);
        }
    }
}
