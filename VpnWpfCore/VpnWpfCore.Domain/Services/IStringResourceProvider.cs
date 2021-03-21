namespace VpnWpfCore.Domain.Services
{
    public interface IStringResourceProvider
    {
        string GetResStringFromAssembly(string assemblyName, string resourceName);
    }
}
