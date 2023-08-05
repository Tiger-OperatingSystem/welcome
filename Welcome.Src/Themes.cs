using System.Diagnostics;


namespace welcome
{
    public class Themes
    {
        public static void ApplyThemes(string theme, string themeName)
        {
            var argument = theme == "theme" ? "/Net/ThemeName" : "/Net/IconThemeName";

            var arguments = $"-c xsettings -p {argument} -s {themeName}";

            Process processBash = new();
            processBash.StartInfo.FileName = "xfconf-query";
            processBash.StartInfo.Arguments = arguments;
            processBash.StartInfo.UseShellExecute = false;
            processBash.Start();
            processBash.WaitForExit();
        }

        public static void ApplyXfm4(string modo)
        {
            var argumentS = modo == "light" ? "Flat-Remix-Light-XFWM" : "Flat-Remix-Dark-XFWM";
            var arguments = $"-c xfwm4 -p /general/theme -s {argumentS}";

            Process processBash = new();
            processBash.StartInfo.FileName = "xfconf-query";
            processBash.StartInfo.Arguments = arguments;
            processBash.StartInfo.UseShellExecute = false;
            processBash.Start();
            processBash.WaitForExit();
        }

        public static string CheckTheme(string typeTheme)
        {
            string argumentC;
            string argumentP;

            if (typeTheme == "xfm")
            {
                argumentC = "xfwm4";
                argumentP = "/general/theme";
            }
            else
            {
                argumentC = "xsettings";
                argumentP = typeTheme == "icon" ? "/Net/IconThemeName" : "/Net/ThemeName";
            }

            var arguments = $"-c {argumentC} -p {argumentP}";

            Process processBash = new();
            processBash.StartInfo.FileName = "xfconf-query";
            processBash.StartInfo.Arguments = arguments;
            processBash.StartInfo.RedirectStandardOutput = true;
            processBash.StartInfo.UseShellExecute = false;
            processBash.Start();
            var output = processBash.StandardOutput.ReadToEnd();
            processBash.WaitForExit();
            return output;
        }
    }
}