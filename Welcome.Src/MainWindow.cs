using System;
using System.IO;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace welcome
{
  class MainWindow : Window
  {
    // [UI] private readonly Switch _slideStart = null;
    [UI] private readonly CheckButton _checkStart = null;

    // Elementos Guia de Início
    [UI] private readonly RadioButton _radioButtonLight = null;
    [UI] private readonly RadioButton _radioButtonMix = null;
    [UI] private readonly RadioButton _radioButtonDark = null;
    [UI] private readonly RadioButton _radioButtonGreen = null;
    [UI] private readonly RadioButton _radioButtonOrange = null;
    [UI] private readonly RadioButton _radioButtonYellow = null;
    [UI] private readonly RadioButton _radioButtonRed = null;
    [UI] private readonly RadioButton _radioButtonPink = null;
    [UI] private readonly RadioButton _radioButtonPurple = null;
    [UI] private readonly Button _buttonInstallDrivers = null;
    [UI] private readonly Button _buttonUpgradeSystem = null;
    [UI] private readonly Button _buttonInstallClamav = null;
    [UI] private readonly Button _buttonRemmina = null;
    [UI] private readonly Button _buttonCodecs = null;

    // Elementos Guia Office
    [UI] private readonly Button _buttonLibreOffice = null;
    [UI] private readonly Button _buttonWpsOffice = null;
    [UI] private readonly Button _buttonGdocs = null;
    [UI] private readonly Button _buttonOnlyOffice = null;
    [UI] private readonly Button _buttonOffice365 = null;

    // Elementos Guia Navegadores 

    [UI] private readonly Button _buttonGoogleChrome = null;
    [UI] private readonly Button _buttonEdge = null;
    [UI] private readonly Button _buttonBrave = null;
    [UI] private readonly Button _buttonOpera = null;
    [UI] private readonly Button _buttonFirefox = null;
    [UI] private readonly Button _buttonTor = null;

    // Elemtos Guia WebApps

    ////Acessorios
    [UI] private readonly Button _buttonWebAppGcontact = null;
    [UI] private readonly Button _buttonGoogleSchedule = null;
    [UI] private readonly Button _buttonGoogleKeep = null;
    [UI] private readonly Button _buttonCv2You = null;

    ////Desenvolvimento

    [UI] private readonly Button _buttonGithub = null;
    [UI] private readonly Button _buttonGist = null;
    [UI] private readonly Button _buttonGlitch = null;
    [UI] private readonly Button _buttonCodePen = null;
    [UI] private readonly Button _buttonDiagrams = null;

    ////Escritório
    [UI] private readonly Button _buttonGoogleForms = null;

    ////Gráficos
    [UI] private readonly Button _buttonAdobeSpark = null;
    [UI] private readonly Button _buttonCanva = null;
    [UI] private readonly Button _buttonLogoMaker = null;
    [UI] private readonly Button _buttonPhotopea = null;
    [UI] private readonly Button _buttonPhotoshopOnline = null;

    ////Internet

    [UI] private readonly Button _buttonGoogleMeet = null;
    [UI] private readonly Button _buttonMedium = null;

    // Elementos Guia Sobre

    [UI] private readonly Button _buttonContribute = null;
    [UI] private readonly Button _buttonSite = null;
    [UI] private readonly Button _buttonYoutube = null;
    [UI] private readonly Button _buttonInstagram = null;


    public string ColorName;
    public string ThemeMode;

    public Apps Apps = new();
    public CheckApps Check = new();
    public Themes Theme = new();
    public MainWindow() : this(new Builder("MainWindow.glade")) { }

    private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
    {
      builder.Autoconnect(this);
      DeleteEvent += Window_DeleteEvent;

      _checkStart.Clicked += _checkStartClicked;

      // Checks do Apps
      CheckAllButtons();
      CheckRadioButtons();
      CheckRadioButonsThemes();


      // Radio Buttons Modos 
      _radioButtonLight.Clicked += RadioButtonLightClicked;
      _radioButtonMix.Clicked += RadioButtonMixClicked;
      _radioButtonDark.Clicked += RadioButtonDarkClicked;

      // Radio Buttons Guia Inicial
      _radioButtonGreen.Clicked += RadioButtonGreenClicked;
      _radioButtonOrange.Clicked += RadioButtonOrangeClicked;
      _radioButtonYellow.Clicked += RadioButtonYellowClicked;
      _radioButtonRed.Clicked += RadioButtonRedClicked;
      _radioButtonPink.Clicked += RadioButtonPinkClicked;
      _radioButtonPurple.Clicked += RadioButtonPurpleClicked;

      // Buttons Guia Inicial
      _buttonInstallDrivers.Clicked += _buttonInstallDrivers_Clicked;
      _buttonUpgradeSystem.Clicked += _buttonUpgradeSystem_Clicked;
      _buttonInstallClamav.Clicked += _buttonInstallClamav_Clicked;
      _buttonRemmina.Clicked += _buttonRemmina_Clicked;
      _buttonCodecs.Clicked += _buttonCodecs_Clicked;

      // Buttons Guia Office 

      _buttonLibreOffice.Clicked += _buttonLibreOffice_Clicked;
      _buttonWpsOffice.Clicked += _buttonWpsOfficeClicked;
      _buttonGdocs.Clicked += _buttonGdocsClicked;
      _buttonOnlyOffice.Clicked += _buttonOnlyOfficeClicked;
      _buttonOffice365.Clicked += _buttonOffice365Clicked;

      // Buttons Guia Navegadores 

      _buttonGoogleChrome.Clicked += _buttonGoogleChromeClicked;
      _buttonEdge.Clicked += _buttonEdgeClicked;
      _buttonBrave.Clicked += _buttonBraveClicked;
      _buttonOpera.Clicked += _butttonOperaClicked;
      _buttonFirefox.Clicked += _buttonFirefoxClicked;
      _buttonTor.Clicked += _buttonTorClicked;

      // Buttons WebApps

      ////Acessórios
      _buttonWebAppGcontact.Clicked += _buttonWebAppGcontactClicked;
      _buttonGoogleSchedule.Clicked += _buttonGoogleScheduleClicked;
      _buttonGoogleKeep.Clicked += _buttonGoogleKeepClicked;
      _buttonCv2You.Clicked += _buttonCV2YouClicked;

      ////Desenvolvimemto
      _buttonGithub.Clicked += _buttonGithubClicked;
      _buttonGist.Clicked += _buttonGistClicked;
      _buttonGlitch.Clicked += _buttonGlitchClicked;
      _buttonCodePen.Clicked += _buttonCodePenClicked;
      _buttonDiagrams.Clicked += _buttonDiagramsClicked;

      ////Escritorio
      _buttonGoogleForms.Clicked += _buttonGoogleFormsClicked;

      ////Gráficos
      _buttonAdobeSpark.Clicked += _buttonAdobeSparkClicked;
      _buttonCanva.Clicked += _buttonCanvaClicked;
      _buttonLogoMaker.Clicked += _buttonLogoMakerClicked;
      _buttonPhotopea.Clicked += _buttonPhotopeaClicked;
      _buttonPhotoshopOnline.Clicked += _buttonPhotoshopOnlineClicked;

      ////Internet

      _buttonGoogleMeet.Clicked += _buttonGoogleMeetClicked;
      _buttonMedium.Clicked += _buttonMediumClicked;

      //Buttons Guia Sobre
      _buttonContribute.Clicked += _buttonContributeClicked;
      _buttonSite.Clicked += _buttonSiteClicked;
      _buttonYoutube.Clicked += _buttonYoutubeClicked;
      _buttonInstagram.Clicked += _buttonInstagramClicked;


    }

    private static void _checkStartClicked(object sender, EventArgs e)
    {
      // var userName = Environment.UserName;
      // var sourcePath = " /usr/share/applications/Tiger-Preview.desktop";
      // var destinationPath = $"/home/{userName}/.config/autostart/Tiger-Preview.desktop";
      // var check = _checkStar.Active;
      // if (check)

      System.Diagnostics.Process.Start("./autostart.sh");
    }


    private void RadioButtonDarkClicked(object sender, EventArgs e) => RadioButtonsMode("Dark");
    private void RadioButtonMixClicked(object sender, EventArgs e) => RadioButtonsMode("Mix");
    private void RadioButtonLightClicked(object sender, EventArgs e) => RadioButtonsMode("Light");

    public void RadioButtonsMode(string modeTheme)
    {
      CheckRadioButtons();
      string colorIcon;
      if (modeTheme.Contains("Light"))
      {
        colorIcon = $"{ColorName}-Light";
        Themes.ApplyXfm4("light");
      }
      else
      {
        colorIcon = $"{ColorName}-Dark";
        Themes.ApplyXfm4("dark");
      }
      var colorTheme = $"{ColorName}-{modeTheme}";
      Themes.ApplyThemes("icon", colorIcon);
      Themes.ApplyThemes("theme", colorTheme.ToLower());
    }
    private void ApplyThemesModesRadiosButtons(string modo)
    {
      var colorTheme = "";

      if (modo.Contains("Light"))
        colorTheme = $"{ColorName}-Light";
      else if (modo.Contains("Mix"))
        colorTheme = $"{ColorName}-Mix";
      else if (modo.Contains("Dark"))
        colorTheme = $"{ColorName}-Dark";

      Themes.ApplyThemes("theme", colorTheme.ToLower());

      colorTheme = modo.Contains("Light") ? $"{ColorName}-Light" : $"{ColorName}-Dark";

      Themes.ApplyThemes("icon", colorTheme);
      Themes.ApplyXfm4($"{modo.ToLower()}");
      CheckRadioButonsThemes();
    }
    private void ApplyThemesRadioButtons(string colorTheme)
    {
      ColorName = colorTheme;
      var modo = Themes.CheckTheme("theme").ToLower();
      if (modo.Contains("light"))
        ApplyThemesModesRadiosButtons("Light");
      else if (modo.Contains("mix"))
        ApplyThemesModesRadiosButtons("Mix");
      else if (modo.Contains("dark"))
        ApplyThemesModesRadiosButtons("Dark");
      CheckRadioButonsThemes();
    }
    private void RadioButtonGreenClicked(object sender, EventArgs e) => ApplyThemesRadioButtons("Green");
    private void RadioButtonOrangeClicked(object sender, EventArgs e) => ApplyThemesRadioButtons("Orange");
    private void RadioButtonYellowClicked(object sender, EventArgs e) => ApplyThemesRadioButtons("Yellow");
    private void RadioButtonRedClicked(object sender, EventArgs e) => ApplyThemesRadioButtons("Red");
    private void RadioButtonPinkClicked(object sender, EventArgs e) => ApplyThemesRadioButtons("Pink");
    private void RadioButtonPurpleClicked(object sender, EventArgs e) => ApplyThemesRadioButtons("Purple");
    private void CheckRadioButtons()
    {
      var color = Themes.CheckTheme("theme").ToLower();

      if (color.Contains("green"))
      {
        _radioButtonGreen.Active = true;
        ColorName = "Green";
      }
      else if (color.Contains("orange"))
      {
        _radioButtonOrange.Active = true;
        ColorName = "Orange";
      }
      else if (color.Contains("yellow"))
      {
        _radioButtonYellow.Active = true;
        ColorName = "Yellow";
      }
      else if (color.Contains("red"))
      {
        _radioButtonRed.Active = true;
        ColorName = "Red";
      }
      else if (color.Contains("pink"))
      {
        _radioButtonPink.Active = true;
        ColorName = "Pink";
      }
      else if (color.Contains("purple"))
      {
        _radioButtonPurple.Active = true;
        ColorName = "Purple";
      }
    }
    private void CheckRadioButonsThemes()
    {
      var color = Themes.CheckTheme("theme").ToLower();
      if (color.Contains("light"))
      {
        _radioButtonLight.Active = true;
        ThemeMode = "Light";
      }
      else if (color.Contains("mix"))
      {
        _radioButtonMix.Active = true;
        ThemeMode = "Mix";
      }
      else if (color.Contains("dark"))
      {
        _radioButtonDark.Active = true;
        ThemeMode = "Dark";
      }
    }
    private void _buttonCodecs_Clicked(object sender, EventArgs e) => Apps.InstallDebs("codecs");

    private void CheckStart()
    {

      var userName = Environment.UserName;
      var path = $"/home/{userName}/.config/autostart/Tiger-Preview.desktop";
      var exists = !File.Exists(path);
        if (exists)
          _checkStart.Active = false;
        else
          _checkStart.Active = true;
    }

    private void CheckAllButtons()
    {
      CheckButtonClamav();
      CheckButtonRemmina();
      CheckButtonCodecs();
      CheckButtonsOffice();
      CheckButtonsBrowsers();
      CheckWebApps();
      CheckStart();
    }
    private void CheckButtonClamav()
    {
      var appExist = CheckApps.ExistDeb("clamtk");
      _buttonInstallClamav.Label = appExist == "true" ? "Instalar Anti Vírus" : "Remover Anti Vírus";
    }
    private void CheckButtonRemmina()
    {
      var appExist = CheckApps.ExistDeb("remmina");
      _buttonRemmina.Label = appExist == "true" ? "Instalar Remmina" : "Remover Remmina";
    }
    private void CheckButtonCodecs()
    {
      var appExist = CheckApps.ExistDeb("rar");
      if (appExist == "true")
      {
        _buttonCodecs.Sensitive = true;
        _buttonCodecs.Label = "Instalar Codecs";
      }
      else
      {
        _buttonCodecs.Sensitive = false;
        _buttonCodecs.Label = "Codecs Instalados";
      }
    }
    private void _buttonInstallClamav_Clicked(object sender, EventArgs e)
    {
      var checkInstallClamav = _buttonInstallClamav.Label;

      if (checkInstallClamav == "Instalar Anti Vírus")
        Apps.InstallDebs("clamav");
      else
        Apps.RemoveDebs("clamav");

      CheckButtonClamav();
    }
    private void _buttonRemmina_Clicked(object sender, EventArgs e)
    {
      var checkInstallRemmina = _buttonRemmina.Label;

      if (checkInstallRemmina == "Instalar Remmina")
        Apps.InstallDebs("remmina");
      else
        Apps.RemoveDebs("remmina");

      CheckButtonRemmina();
    }
    private static void _buttonUpgradeSystem_Clicked(object sender, EventArgs e) => System.Diagnostics.Process.Start("io.elementary.appcenter", "--show-updates");
    private static void _buttonInstallDrivers_Clicked(object sender, EventArgs e) => System.Diagnostics.Process.Start("driver-manager");

    // Elementos Guia Office
    private void CheckButtonsOffice()
    {
      CheckButtonLibreoffice();
      CheckButtonWpsOffice();
      CheckButtonGdocs();
      CheckButtonOnlyOffice();
      CheckButtonOffice365();
    }
    private void CheckButtonOffice365()
    {
      var exist = CheckApps.ExistWebApp("msword.desktop");
      _buttonOffice365.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckButtonOnlyOffice()
    {
      var exist = CheckApps.ExistFlatPack("org.onlyoffice.desktopeditors.desktop");
      _buttonOnlyOffice.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckButtonGdocs()
    {
      var exist = CheckApps.ExistWebApp("gdocs.desktop");
      _buttonGdocs.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckButtonLibreoffice()
    {
      var appExist = CheckApps.ExistDeb("libreoffice");
      _buttonLibreOffice.Label = appExist == "true" ? "Instalar" : "Remover";
    }
    private void CheckButtonWpsOffice()
    {
      var appExist = CheckApps.ExistDeb("wps");
      _buttonWpsOffice.Label = appExist == "true" ? "Instalar" : "Remover";
    }
    private void _buttonLibreOffice_Clicked(object sender, EventArgs e)
    {
      var checkInstallLibreOffice = _buttonLibreOffice.Label;

      if (checkInstallLibreOffice == "Instalar")
        Apps.InstallDebs("libreoffice");
      else
        Apps.RemoveDebs("libreoffice");

      CheckButtonLibreoffice();
    }
    private void _buttonWpsOfficeClicked(object sender, EventArgs e)
    {
      var checkInstallWpsOffice = _buttonWpsOffice.Label;

      if (checkInstallWpsOffice == "Instalar")
        Apps.InstallDebs("wps");
      else
        Apps.RemoveDebs("wps");

      CheckButtonWpsOffice();
    }
    private void _buttonOffice365Clicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonOffice365.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("msoffice");
      else
        Apps.RemoveDebs("msoffice");

      CheckButtonOffice365();
    }
    private void _buttonOnlyOfficeClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonOnlyOffice.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("onlyoffice");
      else
        Apps.RemoveDebs("onlyoffice");

      CheckButtonOnlyOffice();
    }
    private void _buttonGdocsClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonGdocs.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("googledocs");
      else
        Apps.RemoveDebs("googledocs");

      CheckButtonGdocs();
    }
    private void CheckButtonsBrowsers()
    {
      CheckGoogleChrome();
      CheckEdge();
      CheckBrave();
      CheckOpera();
      CheckFirefox();
      CheckTor();
    }
    private void CheckGoogleChrome()
    {
      var appExist = CheckApps.ExistDeb("google-chrome");
      _buttonGoogleChrome.Label = appExist == "true" ? "Instalar" : "Remover";
    }
    private void CheckEdge()
    {
      var appExist = CheckApps.ExistFlatPack("com.microsoft.Edge.desktop");
      _buttonEdge.Label = !appExist ? "Instalar" : "Remover";
    }
    private void CheckBrave()
    {
      var appExist = CheckApps.ExistDeb("brave-browser");
      _buttonBrave.Label = appExist == "true" ? "Instalar" : "Remover";
    }
    private void CheckOpera()
    {
      var appExist = CheckApps.ExistDeb("opera");
      _buttonOpera.Label = appExist == "true" ? "Instalar" : "Remover";
    }
    private void CheckFirefox()
    {
      var appExist = CheckApps.ExistDeb("firefox");
      _buttonFirefox.Label = appExist == "true" ? "Instalar" : "Remover";
    }
    private void CheckTor()
    {
      var appExist = CheckApps.ExistFlatPack("com.github.micahflee.torbrowser-launcher.desktop");
      _buttonTor.Label = !appExist ? "Instalar" : "Remover";
    }
    private void _buttonGoogleChromeClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonGoogleChrome.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("chrome");
      else
        Apps.RemoveDebs("chrome");

      CheckGoogleChrome();
    }
    private void _buttonEdgeClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonEdge.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("edge");
      else
        Apps.RemoveDebs("edge");

      CheckEdge();
    }
    private void _buttonBraveClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonBrave.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("brave");
      else
        Apps.RemoveDebs("brave-browser");

      CheckBrave();
    }
    private void _butttonOperaClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonOpera.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("opera");
      else
        Apps.RemoveDebs("opera");

      CheckOpera();
    }
    private void _buttonFirefoxClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonFirefox.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("firefox");
      else
        Apps.RemoveDebs("firefox");
    }
    private void _buttonTorClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonTor.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("tor");
      else
        Apps.RemoveDebs("tor");

      CheckTor();
    }
    private void CheckWebApps()
    {
      CheckGoogleContact();
      CheckGoogleSchedule();
      CheckGoogleKeep();
      CheckCV2You();
      CheckGithub();
      CheckGist();
      CheckGlitch();
      CheckCodePen();
      CheckDiagrams();
      CheckGoogleForms();
      CheckAdobeSpark();
      CheckCanva();
      CheckLogoMaker();
      CheckPhotopea();
      CheckPhotoshop();
      CheckGoogleMeet();
      CheckMedium();
    }
    private void CheckGoogleContact()
    {
      var exist = CheckApps.ExistWebApp("gcontacts.desktop");
      _buttonWebAppGcontact.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckGoogleSchedule()
    {
      var exist = CheckApps.ExistWebApp("gcalendar.desktop");
      _buttonGoogleSchedule.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckGoogleKeep()
    {
      var exist = CheckApps.ExistWebApp("gkeep.desktop");
      _buttonGoogleKeep.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckCV2You()
    {
      var exist = CheckApps.ExistWebApp("cvyou.desktop");
      _buttonCv2You.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckGithub()
    {
      var exist = CheckApps.ExistWebApp("github.desktop");
      _buttonGithub.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckGist()
    {
      var exist = CheckApps.ExistWebApp("gist.desktop");
      _buttonGist.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckGlitch()
    {
      var exist = CheckApps.ExistWebApp("gist.desktop");
      _buttonGlitch.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckCodePen()
    {
      var exist = CheckApps.ExistWebApp("codepen.desktop");
      _buttonCodePen.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckDiagrams()
    {
      var exist = CheckApps.ExistWebApp("codepen.desktop");
      _buttonDiagrams.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckGoogleForms()
    {
      var exist = CheckApps.ExistWebApp("gforms.desktop");
      _buttonGoogleForms.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckAdobeSpark()
    {
      var exist = CheckApps.ExistWebApp("spark.desktop");
      _buttonAdobeSpark.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckCanva()
    {
      var exist = CheckApps.ExistWebApp("canva.desktop");
      _buttonCanva.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckLogoMaker()
    {
      var exist = CheckApps.ExistWebApp("logomaker.desktop");
      _buttonLogoMaker.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckPhotopea()
    {
      var exist = CheckApps.ExistWebApp("photopea.desktop");
      _buttonPhotopea.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckPhotoshop()
    {
      var exist = CheckApps.ExistWebApp("photoshop.desktop");
      _buttonPhotoshopOnline.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckGoogleMeet()
    {
      var exist = CheckApps.ExistWebApp("gmeet.desktop");
      _buttonGoogleMeet.Label = !exist ? "Instalar" : "Remover";
    }
    private void CheckMedium()
    {
      var exist = CheckApps.ExistWebApp("medium.desktop");
      _buttonMedium.Label = !exist ? "Instalar" : "Remover";
    }
    private void _buttonWebAppGcontactClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonWebAppGcontact.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("gcontacts");
      else
        Apps.RemoveDebs("gcontacts");

      CheckGoogleContact();
    }
    private void _buttonGoogleScheduleClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonGoogleSchedule.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("gcalendar");
      else
        Apps.RemoveDebs("gcalendar");
      CheckGoogleSchedule();
    }
    private void _buttonGoogleKeepClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonGoogleKeep.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("gkeep");
      else
        Apps.RemoveDebs("gkeep");
      CheckGoogleKeep();
    }
    private void _buttonCV2YouClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonCv2You.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("cvyou");
      else
        Apps.RemoveDebs("cvyou");
      CheckCV2You();
    }
    private void _buttonMediumClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonMedium.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("medium");
      else
        Apps.RemoveDebs("medium");
      CheckMedium();
    }
    private void _buttonGoogleMeetClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonMedium.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("gmeet");
      else
        Apps.RemoveDebs("gmeet");
      CheckGoogleMeet();
    }
    private void _buttonPhotoshopOnlineClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonPhotoshopOnline.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("photoshop");
      else
        Apps.RemoveDebs("photoshop");
      CheckPhotoshop();
    }
    private void _buttonPhotopeaClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonPhotopea.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("photopea");
      else
        Apps.RemoveDebs("photopea");
      CheckPhotopea();
    }
    private void _buttonLogoMakerClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonLogoMaker.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("logomaker");
      else
        Apps.RemoveDebs("logomaker");
      CheckLogoMaker();
    }
    private void _buttonCanvaClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonCanva.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("canva");
      else
        Apps.RemoveDebs("canva");
      CheckCanva();
    }

    private void _buttonAdobeSparkClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonAdobeSpark.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("spark");
      else
        Apps.RemoveDebs("spark");
      CheckAdobeSpark();
    }

    private void _buttonGoogleFormsClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonGoogleForms.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("gforms");
      else
        Apps.RemoveDebs("gforms");
      CheckGoogleForms();
    }

    private void _buttonDiagramsClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonDiagrams.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("diagrams");
      else
        Apps.RemoveDebs("diagrams");
      CheckDiagrams();
    }

    private void _buttonCodePenClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonCodePen.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("codepen");
      else
        Apps.RemoveDebs("codepen");
      CheckCodePen();
    }

    private void _buttonGlitchClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonGlitch.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("glitch");
      else
        Apps.RemoveDebs("glitch");
      CheckGlitch();
    }

    private void _buttonGistClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonGist.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("gist");
      else
        Apps.RemoveDebs("gist");
      CheckGist();
    }
    private void _buttonGithubClicked(object sender, EventArgs e)
    {
      var checkInstall = _buttonGithub.Label;

      if (checkInstall == "Instalar")
        Apps.InstallDebs("github");
      else
        Apps.RemoveDebs("github");
      CheckGithub();
    }
    private static void _buttonInstagramClicked(object sender, EventArgs e) => System.Diagnostics.Process.Start("xdg-open", "https://instagram.com/mestresemlinux");
    private static void _buttonYoutubeClicked(object sender, EventArgs e) => System.Diagnostics.Process.Start("xdg-open", "https://youtube.com/mestresemlinux");
    private static void _buttonSiteClicked(object sender, EventArgs e) => System.Diagnostics.Process.Start("xdg-open", "https://tigeros.com.br");
    private static void _buttonContributeClicked(object sender, EventArgs e) => System.Diagnostics.Process.Start("xdg-open", "https://www.padrim.com.br/mestresemlinux");
    private static void Window_DeleteEvent(object sender, DeleteEventArgs a) => Application.Quit();

  }
}