using System.Text.Json;
using Newtonsoft.Json;
using Lab1.Models;

namespace Lab1
{
  public partial class Form1 : Form
  {
    FileManager fileManager = new FileManager();
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      SaveFileDialog sfd = new();
      string fileName = fileManager.SaveFile(richTextBox1.Text, sfd);

      if (fileName == "")
      {
        MessageBox.Show("File not saved, try again");
        return;
      }

      this.loadTrainInfo(fileName);
    }

    private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new();

      string fileName = fileManager.OpenFileInfo(ofd);

      if (fileName == "")
      {
        MessageBox.Show("Please select a JSON file");
        return;
      }

      richTextBox1.Text = File.ReadAllText(fileName);
      this.loadTrainInfo(fileName);
    }

    private void loadTrainInfo(string fileName)
    {
      string json = File.ReadAllText(fileName);

      List<TrainVm> trains = JsonConvert.DeserializeObject<List<TrainVm>>(json);

      if (trains == null || trains.Count == 0) return;

      richTextBox2.Clear();

      foreach (TrainVm train in trains)
      {
        DateTime arrivalTime = DateTime.Parse(train.ArrivalTime);
        DateTime departureTime = DateTime.Parse(train.DepartureTime);

        var difference = departureTime - arrivalTime;

        if (difference.TotalHours <= 10)
        {
          richTextBox2.AppendText("\n" + "Name: " + train.Name + " destinationStation: " + train.DestinationStation + " number: " + train.TrainNumber + " arrivalTime: " + train.ArrivalTime
            + " departureTime: " + train.DepartureTime + "\n");
        }
      }
    }
  }
}
