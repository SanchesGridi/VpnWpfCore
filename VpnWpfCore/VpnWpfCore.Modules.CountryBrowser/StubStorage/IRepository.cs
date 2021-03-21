using System.Collections.Generic;

namespace VpnWpfCore.Modules.CountryBrowser.StubStorage
{
    public interface IRepository<TEntry> where TEntry : class
    {
        IEnumerable<TEntry> GetEntries();
    }
}
