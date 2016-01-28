using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    public class SeaConnections
    {
        Resources resource;
        MainWindow main;

        Dictionary<string, SeaTerritory> allSeas = new Dictionary<string, SeaTerritory>();
        public SeaConnections(Resources resource, MainWindow main)
        {
            this.resource = resource;
            this.main = main;
        }


        private SeaTerritory makeConnections(string line, Button button)
        {
            SeaTerritory sea;
            string[] splitLine = line.Split(':');
            string name = splitLine[0];
            string[] connections = splitLine[1].Split(',');
            List<string> list = new List<string>();
            List<string> placeHolderSeaToLand = new List<string>();
            foreach(string s in connections)
            {
                list.Add(s.Trim());
            }

            sea = new SeaTerritory(name, 0, resource.Neutral, false, new PlaceHolderOrderToken(), button, placeHolderSeaToLand, list);
            allSeas.Add(name, sea);
            return sea;


        }

        public Dictionary<string,SeaTerritory> createSeaConnections(string textFile)
        {
            using (StreamReader sr = new StreamReader(textFile))
            {
                String line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(':');
                    string name = splitLine[0];
                    switch (name)
                    {
                        //creates all the land territories
                        case "The_Shivering_Sea":
                            resource.The_Shivering_Sea = makeConnections(line, main.TheShiveringSeaButton);
                            break;
                        case "The_Narrow_Sea":
                            resource.The_Narrow_Sea = makeConnections(line, main.TheNarrowSeaButton);
                            break;
                        case "Shipbreaker_Bay":
                            resource.Shipbreaker_Bay = makeConnections(line, main.ShipbreakerBayButton);
                            break;
                        case "Blackwater_Bay":
                            resource.Blackwater_Bay = makeConnections(line, main.BlackwaterBayButton);
                            break;
                        case "Sea_Of_Dorne":
                            resource.Sea_Of_Dorne = makeConnections(line, main.SeaOfDorneButton);
                            break;
                        case "East_Summer_Sea":
                            resource.East_Summer_Sea = makeConnections(line, main.EastSummerSeaButton);
                            break;
                        case "West_Summer_Sea":
                            resource.West_Summer_Sea = makeConnections(line, main.WestSummerSeaButton);
                            break;
                        case "Redwyne_Straights":
                            resource.Redwyne_Straights = makeConnections(line, main.RedwyneStraightsButton);
                            break;
                        case "Sunset_Sea":
                            resource.Sunset_Sea = makeConnections(line, main.SunsetSeaButton);
                            break;
                        case "The_Golden_Sound":
                            resource.The_Golden_Sound = makeConnections(line, main.TheGoldenSoundButton);
                            break;
                        case "Ironmans_Bay":
                            resource.Ironmans_Bay = makeConnections(line, main.IronmansBayButton);
                            break;
                        case "Bay_Of_Ice":
                            resource.Bay_Of_Ice = makeConnections(line, main.BayOfIceButton);
                            break;
                        default:

                            break;

                    }       
                }

            }
            return allSeas;
        }

    }
}
