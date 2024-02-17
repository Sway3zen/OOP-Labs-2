using System.Windows.Forms;

namespace Lab1
{
  class FileManager
  {
    public string OpenFileInfo(OpenFileDialog ofd)
    {
      ofd.ShowDialog();
      ofd.Title = "Browse JSON files";

      if (ofd.ShowDialog() == DialogResult.OK) return ofd.FileName;

      return "";
    }

    public string SaveFile(string json, SaveFileDialog sfd) 
    {
      sfd.ShowDialog();
      if (sfd.FileName == "") return "";

      File.WriteAllText(sfd.FileName, json);

      return sfd.FileName;
    }
  }
}
