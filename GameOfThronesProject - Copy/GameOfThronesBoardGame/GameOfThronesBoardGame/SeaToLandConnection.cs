using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameOfThronesBoardGame
{
    public class SeaToLandConnection
    {
        Resources resource;
        public SeaToLandConnection(Resources resource)
        {
            this.resource = resource;
        }

        public List<string> allSeas(string textFile)
        {
            string line;
            List<string> allSeas = new List<string>();
            using (StreamReader sr = new StreamReader(textFile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(':');
                    allSeas.Add(splitLine[0]);
                }

            }

            return allSeas;
        }


        private List<string> makeConnections(string[] array)
        {
            List<string> list = new List<string>();
            foreach(string s in array)
            {
                    list.Add(s.Trim());
            }
            return list;
        }

        public void createSeaToLandConnections(string textFile)
        {
            using (StreamReader sr = new StreamReader(textFile))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(':');
                    string name = splitLine[0];
                    string[] connections = splitLine[1].Split(',');
                    switch (name)
                    {
                        //creates all the land territories
                        case "The_Shivering_Sea":
                            resource.The_Shivering_Sea.setLandConnections(makeConnections(connections));
                            break;
                        case "The_Narrow_Sea":
                            resource.The_Narrow_Sea.setLandConnections(makeConnections(connections));
                            break;
                        case "Shipbreaker_Bay":
                            resource.Shipbreaker_Bay.setLandConnections(makeConnections(connections));
                            break;
                        case "Blackwater_Bay":
                            resource.Blackwater_Bay.setLandConnections(makeConnections(connections));
                            break;
                        case "Sea_Of_Dorne":
                            resource.Sea_Of_Dorne.setLandConnections(makeConnections(connections));
                            break;
                        case "East_Summer_Sea":
                            resource.East_Summer_Sea.setLandConnections(makeConnections(connections));
                            break;
                        case "West_Summer_Sea":
                            resource.West_Summer_Sea.setLandConnections(makeConnections(connections));
                            break;
                        case "Redwyne_Straights":
                            resource.Redwyne_Straights.setLandConnections(makeConnections(connections));
                            break;
                        case "Sunset_Sea":
                            resource.Sunset_Sea.setLandConnections(makeConnections(connections));
                            break;
                        case "The_Golden_Sound":
                            resource.The_Golden_Sound.setLandConnections(makeConnections(connections));
                            break;
                        case "Ironmans_Bay":
                            resource.Ironmans_Bay.setLandConnections(makeConnections(connections));
                            break;
                        case "Bay_Of_Ice":
                            resource.Bay_Of_Ice.setLandConnections(makeConnections(connections));
                            break;
                        default:

                            break;

                    }
                }

            }
        }

    }
}
