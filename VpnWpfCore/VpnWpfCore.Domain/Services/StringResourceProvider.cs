namespace VpnWpfCore.Domain.Services
{
    public sealed class StringResourceProvider : IStringResourceProvider
    {
        public string GetResStringFromAssembly(string assemblyName, string resourceName)
        {
            return $"pack://application:,,,/{assemblyName};Component/{resourceName}";
        }
    }
}
