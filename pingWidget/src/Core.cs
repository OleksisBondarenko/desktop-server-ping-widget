using pingWidget.src;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pingWidget
{
    public class Core
    {

        public List<ServerData> GetServerData()
        {
            List<ServerData> dataToPing = GetServerData(Constants.PATH_CONFIG);

            if (!dataToPing.Any())
            {
                dataToPing = Constants.DATA_SERVER_DEFAULT;
            }

          return dataToPing;
        }

        public List<ServerData> GetServerData(string configFilePath)
        {
            var serverDataList = new List<ServerData>();

            try
            {
                var lines = File.ReadAllLines(configFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == Constants.CONFIG_COUNT_PART)
                    {
                        serverDataList.Add(new ServerData
                        {
                            Name = parts[0],
                            AddressToPing = parts[1],
                            AddressToWeb = parts[2],
                            Status = false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return serverDataList;
                //MessageBox.Show($"Файл конфігурації не знайдено: {ex.Message}");
            }

            return serverDataList;
        }

        public async Task<List<ServerData>> PingServerAsync(List<ServerData> dataToPing)
        {
            var pingTasks = dataToPing.Select(async data =>
            {
                data.Status = await PingServerAsync(data.AddressToPing);
                return data;
            });

            var results = await Task.WhenAll(pingTasks);
            return results.ToList();
        }

        public async Task<bool> PingServerAsync(string ipAddress)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync(ipAddress);
                    return reply != null && reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
