using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BukkitQuery.Components {

    static class BukkitServerDataWriter {

        public static void SaveServers(ICollection objects) {

            using (XmlTextWriter writer = new XmlTextWriter("servers.xml", Encoding.UTF8)) {
                XmlSerializer xml = new XmlSerializer(
                    typeof(List<BukkitServer>), 
                    new Type[] { typeof(BukkitServer) });

                List<BukkitServer> servers = MakeBukkitServerList(objects);
                xml.Serialize(writer, servers);
            }

        }


        private static List<BukkitServer> MakeBukkitServerList(ICollection collection) {

            List<BukkitServer> servers = new List<BukkitServer>();
            foreach (object obj in collection) {
                servers.Add((BukkitServer)obj);
            }

            return servers;
        }

    }

}
