using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using System.Net.Sockets;

namespace BukkitQuery.Components {

    [XmlInclude(typeof(BukkitServer))]
    public class BukkitServer {

        public enum ServerStatus { Online, Unreachable, Unknown, Full };

        public string ServerName { get; set; }
        public string ServerAddress { get; set; }
        public int QueryPort { get; set; }

        private ServerStatus status;

        [XmlIgnore]
        public ServerStatus Status {
            get {
                return status;
            }
            set {
                ServerStatus oldStatus = status;
                status = value;
                if((status != oldStatus) && (StatusChanged != null))
                    StatusChanged.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler<EventArgs> StatusChanged;

        [XmlIgnore]
        public int ServerPort { get; set; }

        [XmlIgnore]
        public int PlayerCount { get; set; }

        [XmlIgnore]
        public int MaxPlayers { get; set; }

        [XmlIgnore]
        public IEnumerable<string> PlayerList { get; set; }

        [XmlIgnore]
        public BackgroundWorker AttachedWorker { get; set; }

        [XmlIgnore]
        public Brush ServerBrush {

            get {
                switch (Status) {

                    case BukkitServer.ServerStatus.Online:
                        return Brushes.DarkGreen;

                    case BukkitServer.ServerStatus.Unknown:
                        return Brushes.DarkBlue;

                    case BukkitServer.ServerStatus.Full:
                        return Brushes.DarkOrange;

                    case BukkitServer.ServerStatus.Unreachable:
                        return Brushes.DarkRed;

                    default:
                        throw new InvalidOperationException("Color for current server status is not defined.");

                }
            }
        }


        public string BuildPlayersString() {

            if ((Status == BukkitServer.ServerStatus.Full) || (Status == BukkitServer.ServerStatus.Online)) {
                return String.Format("{0} / {1}", PlayerCount.ToString(), MaxPlayers.ToString());
            } else return "";

        }


        public bool IsOnline() {
            return ((Status == BukkitServer.ServerStatus.Online) || (Status == BukkitServer.ServerStatus.Full));
        }


        public void Refresh() {

            Status = BukkitServer.ServerStatus.Unknown;
            AttachedWorker = new BackgroundWorker();
            AttachedWorker.DoWork += Refresh_DoWork;
            AttachedWorker.RunWorkerAsync();

        }


        private void Refresh_DoWork(object sender, DoWorkEventArgs e) {
            
            try {

                string responseString = GetDataFromServer();
                Dictionary<string,string> serverData = SplitResponse(responseString);
                UpdateServer(serverData);

            } catch {
                Status = BukkitServer.ServerStatus.Unreachable;
            }

        }


        private void UpdateServer(Dictionary<string, string> serverData) {

            ServerPort = Int32.Parse(serverData["SERVERPORT"]);
            PlayerCount = Int32.Parse(serverData["PLAYERCOUNT"]);
            MaxPlayers = Int32.Parse(serverData["MAXPLAYERS"]);
            PlayerList = CreatePlayerList(serverData["PLAYERLIST"]);
            
            if (PlayerCount >= MaxPlayers) {
                Status = BukkitServer.ServerStatus.Full;
            } else Status = BukkitServer.ServerStatus.Online;

        }


        private IEnumerable<string> CreatePlayerList(string playersString) {

            string[] players = playersString.TrimEnd(']').TrimStart('[').Split(',');
            foreach (string thisPlayer in players) {
                yield return thisPlayer.Trim();
            }

        }


        private Dictionary<string,string> SplitResponse(string responseString) {

            Dictionary<string, string> serverData = new Dictionary<string, string>();
            string[] responseLines = responseString.Trim().Split('\n');

            foreach (string thisLine in responseLines) {

                string property = thisLine.Substring(0, thisLine.IndexOf(' '));
                string value = thisLine.Substring(thisLine.IndexOf(' ') + 1);
                serverData[property] = value;

            }

            return serverData;

        }



        private string GetDataFromServer() {

            // prepare local variables
            byte[] data = Encoding.ASCII.GetBytes("QUERY\n");
            byte[] receiveBuffer = new byte[256];
            string responseString = "";

            // send the request, and receive the response
            using (TcpClient client = new TcpClient(ServerAddress, QueryPort)) {

                using (NetworkStream stream = client.GetStream()) {

                    stream.Write(data, 0, data.Length);
                    do {
                        int bytes = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                        responseString += Encoding.ASCII.GetString(receiveBuffer, 0, bytes);
                        Array.Clear(receiveBuffer, 0, bytes);
                    } while (!responseString.EndsWith("]\n"));

                }

            }

            return responseString;

        }


        public BukkitServer(string serverName, string serverAddress, int queryPort) {
            ServerName = serverName;
            ServerAddress = serverAddress;
            QueryPort = queryPort;
            Status = ServerStatus.Unknown;
            PlayerCount = MaxPlayers = ServerPort = 0;
            PlayerList = new List<string>();
        }


        public BukkitServer() : this("", "", 0) { }


    }

}
