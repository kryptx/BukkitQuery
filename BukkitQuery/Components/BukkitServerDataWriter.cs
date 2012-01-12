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

        private static readonly XmlSerializer xml = new XmlSerializer(
            typeof(List<BukkitServer>),
            new[] { typeof(BukkitServer) });

        public static void SaveServers(ICollection objects) {

            using (var writer = new XmlTextWriter("servers.xml", Encoding.UTF8)) {
                xml.Serialize(writer, objects.Cast<BukkitServer>().ToList());
            }

        }

    }

}
