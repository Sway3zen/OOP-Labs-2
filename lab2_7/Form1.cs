using CefSharp;
using CefSharp.WinForms;
using CefSharp.JavascriptBinding;

namespace lab2_7
{
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
      //settings.CefCommandLineArgs.Add("disable-features", "OutOfBlinkCors");
      //settings.CefCommandLineArgs.Add("disable-web-security", "true");
      Cef.Initialize(settings);

      string path = "http://localhost:5173/";
      //string path = "C:\\Users\\Swayze\\source\\repos\\Labs\\lab2_7\\cef\\build\\index.html";
      Form1.browser = new ChromiumWebBrowser(path);
  
      Form1.browser.Dock = DockStyle.Fill;
      Controls.Add(Form1.browser);

      Form1.browser.JavascriptObjectRepository.Register("boundAsync", new BoundObject(), BindingOptions.DefaultBinder);

      Form1.browser.LoadingStateChanged += (sender, args) =>
      {
        if (!Form1.browser.IsLoading)
        {
          Form1.browser.ShowDevTools();
          
        }
      };
    }
  }

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
}
