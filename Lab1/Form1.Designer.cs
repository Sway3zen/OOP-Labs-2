namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      menuStrip1 = new MenuStrip();
      newFileToolStripMenuItem = new ToolStripMenuItem();
      loadFileToolStripMenuItem = new ToolStripMenuItem();
      richTextBox1 = new RichTextBox();
      richTextBox2 = new RichTextBox();
      label1 = new Label();
      button1 = new Button();
      label2 = new Label();
      openFileDialog1 = new OpenFileDialog();
      openFileDialog2 = new OpenFileDialog();
      menuStrip1.SuspendLayout();
      SuspendLayout();
      // 
      // menuStrip1
      // 
      menuStrip1.Items.AddRange(new ToolStripItem[] { newFileToolStripMenuItem });
      menuStrip1.Location = new Point(0, 0);
      menuStrip1.Name = "menuStrip1";
      menuStrip1.Padding = new Padding(8, 3, 0, 3);
      menuStrip1.Size = new Size(728, 25);
      menuStrip1.TabIndex = 0;
      menuStrip1.Text = "menuStrip1";
      // 
      // newFileToolStripMenuItem
      // 
      newFileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadFileToolStripMenuItem });
      newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
      newFileToolStripMenuItem.Size = new Size(37, 19);
      newFileToolStripMenuItem.Text = "File";
      // 
      // loadFileToolStripMenuItem
      // 
      loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
      loadFileToolStripMenuItem.Size = new Size(119, 22);
      loadFileToolStripMenuItem.Text = "Load file";
      loadFileToolStripMenuItem.Click += loadFileToolStripMenuItem_Click;
      // 
      // richTextBox1
      // 
      richTextBox1.AcceptsTab = true;
      richTextBox1.AutoWordSelection = true;
      richTextBox1.Location = new Point(15, 64);
      richTextBox1.Margin = new Padding(4);
      richTextBox1.Name = "richTextBox1";
      richTextBox1.Size = new Size(349, 334);
      richTextBox1.TabIndex = 1;
      richTextBox1.Text = "";
      // 
      // richTextBox2
      // 
      richTextBox2.Location = new Point(412, 64);
      richTextBox2.Margin = new Padding(4);
      richTextBox2.Name = "richTextBox2";
      richTextBox2.Size = new Size(303, 334);
      richTextBox2.TabIndex = 2;
      richTextBox2.Text = "";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
      label1.Location = new Point(15, 39);
      label1.Margin = new Padding(4, 0, 4, 0);
      label1.Name = "label1";
      label1.Size = new Size(88, 21);
      label1.TabIndex = 3;
      label1.Text = "Імя файлу: ";
      // 
      // button1
      // 
      button1.BackColor = Color.White;
      button1.FlatStyle = FlatStyle.Flat;
      button1.Location = new Point(268, 406);
      button1.Margin = new Padding(4);
      button1.Name = "button1";
      button1.Size = new Size(96, 32);
      button1.TabIndex = 4;
      button1.Text = "Зберегти";
      button1.UseVisualStyleBackColor = false;
      button1.Click += button1_Click;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
      label2.Location = new Point(412, 39);
      label2.Margin = new Padding(4, 0, 4, 0);
      label2.Name = "label2";
      label2.Size = new Size(182, 21);
      label2.TabIndex = 5;
      label2.Text = "Час в дорозі < 10 годин";
      // 
      // openFileDialog1
      // 
      openFileDialog1.FileName = "openFileDialog1";
      // 
      // openFileDialog2
      // 
      openFileDialog2.FileName = "openFileDialog2";
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(9F, 21F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.PapayaWhip;
      ClientSize = new Size(728, 451);
      Controls.Add(label2);
      Controls.Add(button1);
      Controls.Add(label1);
      Controls.Add(richTextBox2);
      Controls.Add(richTextBox1);
      Controls.Add(menuStrip1);
      Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
      MainMenuStrip = menuStrip1;
      Margin = new Padding(4);
      Name = "Form1";
      Text = "Form1";
      Load += Form1_Load;
      menuStrip1.ResumeLayout(false);
      menuStrip1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem newFileToolStripMenuItem;
    private ToolStripMenuItem loadFileToolStripMenuItem;
    private RichTextBox richTextBox1;
    private RichTextBox richTextBox2;
    private Label label1;
    private Button button1;
    private Label label2;
    private OpenFileDialog openFileDialog1;
    private OpenFileDialog openFileDialog2;
  }
}
