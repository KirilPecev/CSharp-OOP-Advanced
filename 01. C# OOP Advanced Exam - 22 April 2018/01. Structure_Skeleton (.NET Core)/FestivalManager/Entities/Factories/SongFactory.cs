namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SongFactory : ISongFactory
    {
        private const string DefaultType = "Song";

        public ISong CreateSong(string name, TimeSpan duration)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type currentType = assembly.GetTypes().FirstOrDefault(t => t.Name == DefaultType);
            return (ISong)Activator.CreateInstance(currentType, new object[] { name, duration });
        }
    }
}