using System.Diagnostics;

namespace welcome
{
    public class Apps
    {
        public static void InstallDebs(string nameApp)
        {
            Process p = new();
            var arguments = $"./install.sh {nameApp}";
            p.StartInfo.FileName = "bash";
            p.StartInfo.Arguments = arguments;
            p.StartInfo.UseShellExecute = true;
            p.Start();
            p.WaitForExit();
        }

        public static void RemoveDebs(string nameApp)
        {
            Process p = new();
            var arguments = $"./remove.sh {nameApp}";
            p.StartInfo.FileName = "bash";
            p.StartInfo.Arguments = arguments;
            p.StartInfo.UseShellExecute = true;
            p.Start();
            p.WaitForExit();
        }
    }
}