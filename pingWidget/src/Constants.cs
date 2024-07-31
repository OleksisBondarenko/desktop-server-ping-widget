using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pingWidget.src
{
    public class Constants
    {
        public const string TEXT_AVALIABLE = "Увімкнений";
        public const string TEXT_NOT_AVALIABLE = "Вимкнений";
        public const int MARGIN_BOTTOM_DEFAULT = 10;
        public const int MARGIN_FORM_X = 10;
        public const int MARGIN_FORM_Y = 10;
        public const int CONFIG_COUNT_PART = 3;
        public const int TIMER_INTERVAL_PING = 60_000;
        public const int TIMER_INTERVAL_DEBOUNCE = 1_000;
        public static Color COLOR_NOT_ACTIVE = Color.FromArgb(255, 242, 5, 5);
        public static Color COLOR_ACTIVE = Color.FromArgb(255, 5, 242, 100);
        public static Bitmap IMAGE_LINK_ACTIVE = Properties.Resources.link_active;
        public static Bitmap IMAGE_LINK_NOT_ACTIVE = Properties.Resources.link_inactive;
        public static string CONFIG_NAME = "config.txt";
        public static string PATH_CURRENT_FOLDER = AppDomain.CurrentDomain.BaseDirectory;
        public static string PATH_CONFIG = Path.Combine(PATH_CURRENT_FOLDER, CONFIG_NAME);

        public static List<ServerData> DATA_SERVER_DEFAULT = new List<ServerData>
            {
                new ServerData { Name = "Google", Status = false, AddressToPing = "8.8.8.8",AddressToWeb = "http://8.8.8.8/" },
                new ServerData { Name = "WARP", Status = true, AddressToPing = "1.1.1.1",AddressToWeb = "http://1.1.1.1/" },
           };
    }
}
