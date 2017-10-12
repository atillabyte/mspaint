using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MSPaint
{
    internal static class Program
    {
        internal static List<(string[] aliases, OSVersion version)> VersionMap = new List<(string[] aliasaes, OSVersion version)> {
            (new [] { "95", "WIN95", "Windows 95" }, OSVersion.Win95),
            (new [] { "98", "WIN98", "Windows 98" }, OSVersion.Win98),
            (new [] { "xp", "Windows XP"          }, OSVersion.WinXP),
            (new [] { "vista", "Windows Vista"    }, OSVersion.Vista),
            (new [] { "7", "WIN7", "Windows 7"    }, OSVersion.Win7),
            (new [] { "8", "WIN8", "Windows 8"    }, OSVersion.Win8),
            (new [] { "10", "WIN10", "Windows 10" }, OSVersion.Win10)
        };

        internal static void RunMSPaint(OSVersion version, string path = "") =>
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) + $@"\binaries\{VersionMap.First(entity => entity.version == version).aliases[0]}\mspaint.exe", path);

        internal static OSVersion FindVersion(string input) => VersionMap.First(entity =>
            entity.aliases.Any(alias => string.Equals(alias.Replace(" ", ""), input.Replace(" ", ""), StringComparison.OrdinalIgnoreCase))).version;

        private static void Main(string[] args)
        {
            if (args.Length == 0) {
                RunMSPaint((OSVersion)Properties.Settings.Default.Version);
            }
            else if (args.Length == 1) {
                var path = Path.GetFullPath(args[0]);

                if (!File.Exists(path)) {
                    try {
                        var version = FindVersion(args[0]);

                        if (version != OSVersion.UNKNOWN) {
                            Properties.Settings.Default.Version = (int)version;
                            Properties.Settings.Default.Save();
                        }

                        RunMSPaint((OSVersion)Properties.Settings.Default.Version);
                    }
                    catch {
                        RunMSPaint((OSVersion)Properties.Settings.Default.Version);
                    }
                }
            }
            else if (args.Length == 2) {
                var version = FindVersion(args[0]);

                if (version == OSVersion.UNKNOWN) {
                    version = (OSVersion)Properties.Settings.Default.Version;
                }

                RunMSPaint(version, Path.GetFullPath(args[1]));
            }
        }
    }

    internal enum OSVersion
    {
        UNKNOWN = 0,
        Win95,
        Win98,
        WinXP,
        Vista,
        Win7,
        Win8,
        Win10
    }
}