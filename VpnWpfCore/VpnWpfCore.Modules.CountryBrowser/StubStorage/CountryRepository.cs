using System.Collections.Generic;
using System.Windows.Media;
using VpnWpfCore.Domain.Models;
using VpnWpfCore.Domain.Services;

namespace VpnWpfCore.Modules.CountryBrowser.StubStorage
{
    public sealed class CountryRepository : IRepository<CountryModel>
    {
        private const int Size = 15;

        private readonly IStringResourceProvider _stringResourceProvider;

        public CountryRepository(IStringResourceProvider stringResourceProvider)
        {
            _stringResourceProvider = stringResourceProvider;
        }

        public IEnumerable<CountryModel> GetEntries()
        {
            var helper = new (string Path, string Name)[Size]
            {
                ("Assets\\f_spain.png",       "Spain"),
                ("Assets\\f_australia.png",   "Australia"),
                ("Assets\\f_egypt.png",       "Egypt"),
                ("Assets\\f_greece.png",      "Greece"),
                ("Assets\\f_india.png",       "India"),
                ("Assets\\f_liberia.png",     "Liberia"),
                ("Assets\\f_south_korea.png", "South Korea"),
                ("Assets\\f_taiwan.png",      "Taiwan"),
                ("Assets\\f_algeria.png",     "Algeria"),
                ("Assets\\f_belgium.png",     "Belgium"),
                ("Assets\\f_mexico.png",      "Mexico"),
                ("Assets\\f_nicaragua.png",   "Nicaragua"),
                ("Assets\\f_norway.png",      "Norway"),
                ("Assets\\f_tanzania.png",    "Tanzania"),
                ("Assets\\f_philippines.png", "Philippines")
            };

            foreach (var (Path, Name) in helper)
            {
                yield return new CountryModel(_stringResourceProvider.GetResStringFromAssembly("VpnWpfCore.Modules.CountryBrowser", Path), PixelFormats.Prgba64)
                {
                    Name = Name
                };
            }
        }
    }
}
