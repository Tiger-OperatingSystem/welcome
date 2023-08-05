using System;
using System.Diagnostics;
using System.IO;

namespace welcome
{
    public class CheckApps
    {
        public static string ExistDeb(string nameApp)
        {
            Debug.Assert(nameApp != null, nameof(nameApp) + " != null");
            var psi = new ProcessStartInfo("which", nameApp)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            var proc = Process.Start(psi);

            Debug.Assert(proc != null, nameof(proc) + " != null");
            var output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            var exists = string.IsNullOrEmpty(output) ? "true" : "false";

            return exists;
        }
        public static bool ExistWebApp(string nameApp)
        {
            var userName = Environment.UserName;
            var path = $"/home/{userName}/.local/share/applications/{nameApp}";
            var exists = File.Exists(path);
            return exists;
        }
        public static bool ExistFlatPack(string nameApp)
        {
            var path = $"/var/lib/flatpak/exports/share/applications/{nameApp}";
            var exists = File.Exists(path);
            return exists;
        }
    }
}