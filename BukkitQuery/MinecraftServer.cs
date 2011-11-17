using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BukkitQuery {

    [XmlInclude(typeof(MinecraftServer))]
    public class MinecraftServer {

        public enum ServerStatus { Online, Unreachable, Unknown, Full };

        public string ServerName { get; set; }
        public string ServerAddress { get; set; }
        public int QueryPort { get; set; }

        [XmlIgnore]
        public ServerStatus Status { get; set; }
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


        public MinecraftServer(string serverName, string serverAddress, int queryPort) {
            ServerName = serverName;
            ServerAddress = serverAddress;
            QueryPort = queryPort;
            Status = ServerStatus.Unknown;
            PlayerCount = MaxPlayers = ServerPort = 0;
            PlayerList = new List<string>();
        }


        public MinecraftServer() : this("", "", 0) { }


    }
}
