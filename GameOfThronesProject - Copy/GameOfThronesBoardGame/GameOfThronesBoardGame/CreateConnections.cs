using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public class CreateConnections
    {
        Resources resource;
        public CreateConnections(Resources resource)
        {
            this.resource = resource;
        }

        private List<string> makeConnections(string[] array)
        {
            List<string> list = new List<string>();
            foreach (string s in array)
            {
                if (!s.Equals("NA"))
                {
                    list.Add(s);
                }
            }
            return list;
        }

        public List<string> allLands(string textFile)
        {
            string line;
            List<string> allLands = new List<string>();
            using (StreamReader sr = new StreamReader(textFile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(':');
                    allLands.Add(splitLine[0]);
                }

            }

            return allLands;
        }

        public void createLandConnections(string textFile)
        {
            using (StreamReader sr = new StreamReader(textFile))
            {
                String line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(':');
                    string name = splitLine[0];
                    string[] connections;
                    Console.WriteLine(name);
                    Console.ReadLine();
                    if (!splitLine[1].Equals("NA"))
                    {
                        connections = splitLine[1].Split(',');
                    }
                    else
                    {
                        connections = new string[1] { "NA" };
                    }
                    switch (name){
                        //creates all the land territories
                        case "Castle_Black":
                            resource.Castle_Black.setConnections(makeConnections(connections));
                            break;

                        case "Karhold":
                            resource.Karhold.setConnections(makeConnections(connections));
                            break;
                        case "Winterfell":
                            resource.Winterfell.setConnections(makeConnections(connections));
                            break;
                        case "The_Stony_Shore":
                            resource.The_Stony_Shore.setConnections(makeConnections(connections));
                            break;
                        case "White_Harbor":
                            resource.White_Harbor.setConnections(makeConnections(connections));
                            break;
                        case "Widows_Watch":
                            resource.Widows_Watch.setConnections(makeConnections(connections));
                            break;
                        case "Moat_Cailin":
                            resource.Moat_Cailin.setConnections(makeConnections(connections));
                            break;
                        case "Greywater_Watch":
                            resource.Greywater_Watch.setConnections(makeConnections(connections));
                            break;
                        case "Flints_Fingers":
                            resource.Flints_Fingers.setConnections(makeConnections(connections));
                            break;
                        case "Seagard":
                            resource.Seagard.setConnections(makeConnections(connections));
                            break;
                        case "Pyke":
                            resource.Pyke.setConnections(makeConnections(connections));
                            break;
                        case "The_Twins":
                            resource.The_Twins.setConnections(makeConnections(connections));
                            break;
                        case "The_Fingers":
                            resource.The_Fingers.setConnections(makeConnections(connections));
                            break;
                        case "The Mountains_Of_The_Moon":
                            resource.The_Mountains_Of_The_Moon.setConnections(makeConnections(connections));
                            break;
                        case "The_Eyrie":
                            resource.The_Eyrie.setConnections(makeConnections(connections));
                            break;
                        case "Riverrun":
                            resource.Riverrun.setConnections(makeConnections(connections));
                            break;
                        case "Lannisport":
                            resource.Lannisport.setConnections(makeConnections(connections));
                            break;
                        case "Stoney_Sept":
                            resource.Stoney_Sept.setConnections(makeConnections(connections));
                            break;
                        case "Harrenhal":
                            resource.Harrenhal.setConnections(makeConnections(connections));
                            break;
                        case "Crackclaw_Point":
                            resource.Crackclaw_Point.setConnections(makeConnections(connections));
                            break;
                        case "Searoad_Marches":
                            resource.Searoad_Marches.setConnections(makeConnections(connections));
                            break;
                        case "Blackwater":
                            resource.Blackwater.setConnections(makeConnections(connections));
                            break;
                        case "Kings_Landing":
                            resource.Kings_Landing.setConnections(makeConnections(connections));
                            break;
                        case "Dragonstone":
                            resource.Dragonstone.setConnections(makeConnections(connections));
                            break;
                        case "Highgarden":
                            resource.Highgarden.setConnections(makeConnections(connections));
                            break;
                        case "The_Reach":
                            resource.The_Reach.setConnections(makeConnections(connections));
                            break;
                        case "Kingswood":
                            resource.Kingswood.setConnections(makeConnections(connections));
                            break;
                        case "Storms_End":
                            resource.Storms_End.setConnections(makeConnections(connections));
                            break;
                        case "The_Boneway":
                            resource.The_Boneway.setConnections(makeConnections(connections));
                            break;
                        case "Dornish_Marches":
                            resource.Dornish_Marches.setConnections(makeConnections(connections));
                            break;
                        case "Oldtown":
                            resource.Oldtown.setConnections(makeConnections(connections));
                            break;
                        case "Three_Towers":
                            resource.Three_Towers.setConnections(makeConnections(connections));
                            break;
                        case "Princes_Pass":
                            resource.Princes_Pass.setConnections(makeConnections(connections));
                            break;
                        case "Yronwood":
                            resource.Yronwood.setConnections(makeConnections(connections));
                            break;
                        case "Sunspear":
                            resource.Sunspear.setConnections(makeConnections(connections));
                            break;
                        case "Starfall":
                            resource.Starfall.setConnections(makeConnections(connections));
                            break;
                        case "Salt_Shore":
                            resource.Salt_Shore.setConnections(makeConnections(connections));
                            break;
                        case "The_Arbor":
                            resource.The_Arbor.setConnections(makeConnections(connections));
                            break;

                        default:

                            break;

                }
                }

            }
        }

    }
}
