/*using CefSharp;
using CefSharp.WinForms;
using Microsoft.Win32;
using System.Diagnostics;

namespace lab2_7
{
  public partial class Form1 : Form
  {
    static ChromiumWebBrowser ChromiumWebBrowser;
    private CallbackObjectForJs _callBackObjectForJs;
    public Form1()
    {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {

      CefSettings settings = new CefSettings();

      Cef.Initialize(settings);

      string path = "C:\\Users\\Swayze\\source\\repos\\Labs\\lab2_7\\cef\\public\\index.html";
      Form1.ChromiumWebBrowser = new ChromiumWebBrowser(path);

      Form1.ChromiumWebBrowser.JavascriptObjectRepository.Register("callbackObj", new CallbackObjectForJs(), options: null);

      Form1.ChromiumWebBrowser.Dock = DockStyle.Fill;

      this.Controls.Add(Form1.ChromiumWebBrowser);


      Form1.ChromiumWebBrowser.LoadingStateChanged += (sender, args) =>
      {
        if (!args.IsLoading)
        {
          Form1.ChromiumWebBrowser.ShowDevTools();

          Form1.ChromiumWebBrowser.ExecuteScriptAsync("window.alertMessage('Loaded 1221')");

        }
      };
    }
  }

  public class CallbackObjectForJs
  {
    public void showMessage(string msg)
    {
      MessageBox.Show(msg);
    }
  }
}
*/

using CefSharp;
using CefSharp.WinForms;
using CefSharp.JavascriptBinding;

namespace lab2_7
{
  public class BoundObject
  {
    public void showMessage(string msg)
    {
      try
      {
        MessageBox.Show(msg);

        if (Form1.browser != null)
        {
          Form1.browser.ExecuteScriptAsync("console.log('Loaded 1221')");
        }
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }
  }

  public partial class Form1 : Form
  {
    public static ChromiumWebBrowser browser;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      CefSettings settings = new CefSettings();
      //settings.CefCommandLineArgs.Add("disable-features", "BlockInsecurePrivateNetworkRequests");
      settings.CefCommandLineArgs.Add("disable-features", "OutOfBlinkCors");
      settings.CefCommandLineArgs.Add("disable-web-security", "true");
      Cef.Initialize(settings);

      string path = "http://localhost:5173/";
      //string path = "C:\\Users\\Swayze\\source\\repos\\Labs\\lab2_7\\cef\\build\\index.html";
      Form1.browser = new ChromiumWebBrowser(path);
  
      Form1.browser.Dock = DockStyle.Fill;
      Controls.Add(Form1.browser);

      Form1.browser.LoadingStateChanged += (sender, args) =>
      {
        if (!Form1.browser.IsLoading)
        {
          Form1.browser.ShowDevTools();
          //Form1.browser.JavascriptObjectRepository.Register("boundAsync", new BoundObject(), BindingOptions.DefaultBinder);
        }
      };
    }
  }
}
