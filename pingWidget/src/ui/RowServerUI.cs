using pingWidget.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pingWidget
{
    public partial class RowServerUI : UserControl
    {
        private Core core;
        public ServerData ServerData { get; set; }

        public RowServerUI(Core core, ServerData serverData)
        {
            this.core = core;
            this.ServerData = serverData;

            InitializeComponent();
            // component style 
            this.BorderStyle = BorderStyle.None;
            Region = Region.FromHrgn(UIHelper.CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            
            //link
            panelLink.BackgroundImageLayout = ImageLayout.Center;
            UpdateUI(serverData);

            this.Click += ServerControl_Click;
            panelStatus.Click += ServerControl_Click;
            labelName.Click += ServerControl_Click;
        }

        public void UpdateUI(ServerData serverData)
        {
            labelName.Text = serverData.Name;
            panelStatus.BackColor = serverData.Status ? Constants.COLOR_ACTIVE : Constants.COLOR_NOT_ACTIVE;
            //panelLink.BackgroundImage = ServerData.Status ? Constants.IMAGE_LINK_ACTIVE : Constants.IMAGE_LINK_NOT_ACTIVE;
            panelLink.BackgroundImage = serverData.Status ? Properties.Resources.link_active : Properties.Resources.link_inactive;
            panelLink.Cursor = serverData.Status ? Cursors.Hand : Cursors.Default;
            labelDescription.Text = serverData.Status ? Constants.TEXT_AVALIABLE : Constants.TEXT_NOT_AVALIABLE;
       
        }

        public async Task UpdateStatusAsync()
        {
            ServerData.Status = await core.PingServerAsync(ServerData.AddressToPing);
            UpdateUI(ServerData);
        }

        private void ServerControl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ServerData.AddressToWeb) && ServerData.Status)
            {
                Process.Start(new ProcessStartInfo(ServerData.AddressToWeb) { UseShellExecute = true });
            } else
            {
                MessageBox.Show($"Сервер {ServerData.Name} вимкнено");
            }
        }

        private void panelLink_Click(object sender, EventArgs e)
        {
            ServerControl_Click(sender, e);
        }
    }
}

