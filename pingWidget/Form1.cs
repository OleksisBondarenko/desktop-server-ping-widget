using pingWidget.src;
using pingWidget.src.ui;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pingWidget
{
    public partial class Form1 : Form
    {
        private Core core;
        private RoundButton buttonUpdate;
        private List<RowServerUI> serverPingRows; 

        public Form1()
        {
            core = new Core();
            buttonUpdate = new RoundButton();
            serverPingRows = new List<RowServerUI>();

            InitializeComponent();

            // Form properties
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            this.ShowInTaskbar = false;
            this.timerToPing.Enabled = true;
            this.Load += Form1_Load;

            // Initial setup for FlowLayoutPanel
            mainFlowPanel.FlowDirection = FlowDirection.TopDown;
            mainFlowPanel.WrapContents = false;

            // Initial setup for Button
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Text = "Оновити";
            buttonUpdate.ForeColor = Color.Black;
            buttonUpdate.BackColor = Color.White;
            buttonUpdate.AutoSize = true;
            buttonUpdate.Height = 50;
            buttonUpdate.Font = new Font(buttonUpdate.Font.FontFamily, 11, FontStyle.Bold);
            buttonUpdate.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            buttonUpdate.Click += ButtonUpdate_Click;

            // Initial setup for Timer
            timerToPing.Interval = Constants.TIMER_INTERVAL_PING;

            // Create UI for server rows
            var serverRows = CreateServerRows();
            serverPingRows = serverRows; // Store the server rows for later use
        }

        private async void MakeUI(List<RowServerUI> serverRows)
        {
            mainFlowPanel.Controls.Clear();

            foreach (var row in serverRows)
            {
                mainFlowPanel.Controls.Add(row);
            }

            mainFlowPanel.Controls.Add(buttonUpdate);

            // Adjust margins and heights
            foreach (Control item in mainFlowPanel.Controls)
            {
                UIHelper.AdjustControlMarginBottom(item);
            }

            UIHelper.AdjustHeightByInnerComponents(mainFlowPanel);
            UIHelper.AdjustHeightByInnerComponents(this);

            PositionFormAtBottomRight();

            await UpdateServerRowsAsync(serverRows);
        }

        private List<RowServerUI> CreateServerRows()
        {
            List<RowServerUI> serverRows = new List<RowServerUI>();
            List<ServerData> serverData = core.GetServerData();

            foreach (var dataFromServer in serverData)
            {
                var rowUi = new RowServerUI(core, dataFromServer);
                serverRows.Add(rowUi);
            }

            return serverRows;
        }

        private void PositionFormAtBottomRight(int marginX = Constants.MARGIN_FORM_X, int marginY = Constants.MARGIN_FORM_Y)
        {
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(screen.Width - this.Width - marginX, screen.Height - this.Height - marginY);
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            // Handle button click to refresh data
            RefreshServerRows();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MakeUI(serverPingRows); // Pass server rows to MakeUI
        }

        private async Task UpdateServerRowsAsync(List<RowServerUI> serverRows)
        {
            var tasks = serverRows.Select(async row =>
            {
                await row.UpdateStatusAsync(); // Update each row asynchronously
            });

            await Task.WhenAll(tasks); // Wait for all updates to complete
        }

        private async void RefreshServerRows()
        {
            // Refresh server data and update UI
            var serverData = await core.PingServerAsync(core.GetServerData());
            foreach (var row in serverPingRows)
            {
                var data = serverData.FirstOrDefault(d => d.Name == row.ServerData.Name);
                if (data != null)
                {
                    row.UpdateUI(data); // Update the row's UI with new data
                }
            }
        }

        private void TimerPing_Tick(object sender, EventArgs e)
        {
            RefreshServerRows();
        }
    }
}