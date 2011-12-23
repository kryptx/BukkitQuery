using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BukkitQuery.Components {
    class BukkitServerDataReader {

        public static List<BukkitServer> ReadServers() {

            try {
                using (XmlTextReader reader = new XmlTextReader("servers.xml")) {

                    XmlSerializer xml = new XmlSerializer(
                        typeof(List<BukkitServer>),
                        new Type[] { typeof(BukkitServer) }
                    );

                    return (List<BukkitServer>)xml.Deserialize(reader);

                }

            } catch (InvalidOperationException e) {
                if (e.InnerException is FileNotFoundException) {
                    return new List<BukkitServer>();
                } else throw;
            }

        }
    }
}
