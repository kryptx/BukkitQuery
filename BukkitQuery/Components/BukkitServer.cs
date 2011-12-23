using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;

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
        public List<string> PlayerList { get; set; }

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
