using System;
using System.Windows;
using Prism;
using Prism.Ioc;

namespace VpnWpfCore.Domain.Extensions
{
    public static class PrismApplicationExtensions
    {
        public static IContainerExtension GetContainer(this Application @this)
        {
            return ((@this as PrismApplicationBase).Container as IContainerExtension) ?? throw new ArgumentNullException("@this");
        }
    }
}
