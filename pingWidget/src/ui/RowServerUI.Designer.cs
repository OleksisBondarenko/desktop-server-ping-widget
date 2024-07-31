using System.Drawing;
using System.Windows.Forms;

namespace pingWidget
{
    partial class RowServerUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelStatus = new Panel();
            labelName = new Label();
            panelLink = new Panel();
            labelDescription = new Label();
            SuspendLayout();
            // 
            // panelStatus
            // 
            panelStatus.BackColor = Color.FromArgb(242, 5, 5);
            panelStatus.Dock = DockStyle.Left;
            panelStatus.Location = new Point(0, 0);
            panelStatus.Margin = new Padding(0);
            panelStatus.Name = "panelStatus";
            panelStatus.Size = new Size(10, 65);
            panelStatus.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.BackColor = Color.Transparent;
            labelName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelName.Location = new Point(78, 2);
            labelName.Margin = new Padding(0);
            labelName.Name = "labelName";
            labelName.Size = new Size(157, 28);
            labelName.TabIndex = 3;
            labelName.Text = "Gart 10 Резерв";
            // 
            // panelLink
            // 
            panelLink.BackColor = Color.FromArgb(248, 248, 248);
            panelLink.BackgroundImage = Properties.Resources.link_active;
            panelLink.BackgroundImageLayout = ImageLayout.Center;
            panelLink.Location = new Point(10, 0);
            panelLink.Margin = new Padding(0);
            panelLink.Name = "panelLink";
            panelLink.Size = new Size(65, 65);
            panelLink.TabIndex = 1;
            panelLink.Click += panelLink_Click;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.BackColor = Color.Transparent;
            labelDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescription.ForeColor = SystemColors.ButtonShadow;
            labelDescription.Location = new Point(78, 30);
            labelDescription.Margin = new Padding(0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(117, 28);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Вимкнений";
            // 
            // ServerRow
            // 
            BackColor = Color.White;
            Controls.Add(labelDescription);
            Controls.Add(panelLink);
            Controls.Add(labelName);
            Controls.Add(panelStatus);
            Margin = new Padding(0);
            Name = "ServerRow";
            Size = new Size(320, 65);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelStatus;
        private Label labelName;
        private Panel panelLink;
        private Label labelDescription;
    }
}
