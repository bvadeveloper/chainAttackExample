using System;

namespace Shared.DomainExtensions
{
    public static class DomainExtensions
    {
        public static (string, string) SplitDomainName(this string name)
        {
            var readOnlySpan = name.AsSpan();
            var indexOf = readOnlySpan.IndexOf('.');

            if (indexOf == -1)
            {
                return (name, "");
            }

            var sld = readOnlySpan[..indexOf].ToString();
            var tld = readOnlySpan[indexOf..].TrimStart('.').ToString();

            return (sld, tld);
        }

        public static string Combine(this (string, string) tuple) => 
            $"{tuple.Item1}.{tuple.Item2}";
    }
}