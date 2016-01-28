using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    public class PopulateLand
    {
        Resources resource;
        MainWindow main;
        Dictionary<string, LandTerritory> allLands = new Dictionary<string,LandTerritory>();
        public PopulateLand(Resources resource, MainWindow main)
        {
            this.resource = resource;
            this.main = main;
        }

        private LandTerritory parseGoodies(string line, Button button, StackPanel stackPanel)
        {
            List<string> placeHolderConnections = new List<string>();
            int numCrowns = 0;
            int numSupply = 0;
            bool hasCastle = false;
            bool hasStronghold = false;
            bool hasPort = false;
            bool isOccupied = false;
            string[] splitLine = line.Split(':');
            string name = splitLine[0];
            string[] goodies = splitLine[1].Split(',');
            LandTerritory land;
            foreach (string s in goodies)
            {
                if(s.Trim().Equals("CROWN")){
                    numCrowns++;
                }
                if(s.Trim().Equals("SUPPLY")){
                    numSupply++;
                }
                if(s.Trim().Equals("CASTLE")){
                    hasCastle = true;
                }
                if(s.Trim().Equals("STRONGHOLD")){
                    hasStronghold = true;
                }
                if(s.Trim().Equals("PORT")){
                    hasPort = true;
                }
            }
            
            land = new LandTerritory(name, numSupply, numCrowns, 0, 0, 0, hasCastle, hasStronghold, isOccupied, resource.Neutral, new PlaceHolderOrderToken(), placeHolderConnections);
            allLands.Add(name, land);
            return land;
        }

        public Dictionary<string,LandTerritory> populateLand(string textFile)
        {
            using (StreamReader sr = new StreamReader(textFile))
            {
                String line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(':');
                    string name = splitLine[0];
                    switch (name){
                        //Populates the territories
                        case "Castle_Black":
                            resource.Castle_Black = parseGoodies(line, main.CastleBlackButton, main.CastleBlackStackPanel);
                            break;

                        case "Karhold":
                            resource.Karhold = parseGoodies(line, main.KarholdButton, main.KarholdStackPannel);
                            break;
                        case "Winterfell":
                            resource.Winterfell = parseGoodies(line, main.WinterfellButton,  main.WinterFellStackPanel);
                            break;
                        case "The_Stony_Shore":
                            resource.The_Stony_Shore = parseGoodies(line, main.TheStoneyShoreButton, main.TheStoneyShoreStackPanel);
                            break;
                        case "White_Harbor":
                            resource.White_Harbor = parseGoodies(line, main.WhiteHarborButton, main.WhiteHarborStackPanel);
                            break;
                        case "Widows_Watch":
                            resource.Widows_Watch = parseGoodies(line, main.WidowsWatchButton, main.WidowsWatchStackPanel);
                            break;
                        case "Moat_Cailin":
                            resource.Moat_Cailin = parseGoodies(line, main.MoatCailinButton, main.MoatCailinStackPanel);
                            break;
                        case "Greywater_Watch":
                            resource.Greywater_Watch = parseGoodies(line, main.GreywaterWatchButton, main.GreywaterWatchStackPanel);
                            break;
                        case "Flints_Fingers":
                            resource.Flints_Fingers = parseGoodies(line, main.FlintsFingersButton, main.FlintsFingersStackPanel);
                            break;
                        case "Seagard":
                            resource.Seagard = parseGoodies(line, main.SeagardButton, main.SeagardStackPanel);
                            break;
                        case "Pyke":
                            resource.Pyke = parseGoodies(line, main.PykeButton, main.PykeStackPanel);
                            break;
                        case "The_Twins":
                            resource.The_Twins = parseGoodies(line, main.TheTwinsButton, main.TheTwinsStackPanel);
                            break;
                        case "The_Fingers":
                            resource.The_Fingers = parseGoodies(line, main.TheFingersButton, main.TheFingersStackPanel);
                            break;
                        case "The Mountains_Of_The_Moon":
                            resource.The_Mountains_Of_The_Moon = parseGoodies(line, main.TheMountainsOfTheMoonButton, main.TheMountainsOfTheMoonStackPanel);
                            break;
                        case "The_Eyrie":
                            resource.The_Eyrie = parseGoodies(line, main.TheEyrieButton, main.TheEyrieStackPanel);
                            break;
                        case "Riverrun":
                            resource.Riverrun = parseGoodies(line, main.RiverrunButton, main.RiverrunStackPanel);
                            break;
                        case "Lannisport":
                            resource.Lannisport = parseGoodies(line, main.LannisportButton, main.LannisportStackPanel);
                            break;
                        case "Stoney_Sept":
                            resource.Stoney_Sept = parseGoodies(line, main.StoneySeptButton, main.StoneySeptStackPanel);
                            break;
                        case "Harrenhal":
                            resource.Harrenhal = parseGoodies(line, main.HarrenhalButton, main.HarrenhalStackPanel);
                            break;
                        case "Crackclaw_Point":
                            resource.Crackclaw_Point = parseGoodies(line, main.CrackclawPointButton, main.CrackclawPointStackPanel);
                            break;
                        case "Searoad_Marches":
                            resource.Searoad_Marches = parseGoodies(line, main.SearoadMarchesButton, main.SearoadMarchesStackPanel);
                            break;
                        case "Blackwater":
                            resource.Blackwater = parseGoodies(line, main.BlackwaterButton, main.BlackwaterStackPanel);
                            break;
                        case "Kings_Landing":
                            resource.Kings_Landing = parseGoodies(line, main.KingsLandingButton, main.KingsLandingStackPanel);
                            break;
                        case "Dragonstone":
                            resource.Dragonstone = parseGoodies(line, main.DragonstoneButton, main.DragonstoneStackPanel);
                            break;
                        case "Highgarden":
                            resource.Highgarden = parseGoodies(line, main.HighgardenButton, main.HighgardenStackPanel);
                            break;
                        case "The_Reach":
                            resource.The_Reach = parseGoodies(line, main.TheReachButton, main.TheReachStackPanel);
                            break;
                        case "Kingswood":
                            resource.Kingswood = parseGoodies(line, main.KingsWoodButton, main.KingsLandingStackPanel);
                            break;
                        case "Storms_End":
                            resource.Storms_End = parseGoodies(line, main.StormsEndButton, main.StormsEndStackPanel);
                            break;
                        case "The_Boneway":
                            resource.The_Boneway = parseGoodies(line, main.TheBoneWayButton, main.TheBonewayStackPanel);
                            break;
                        case "Dornish_Marches":
                            resource.Dornish_Marches = parseGoodies(line, main.DornishMarchesButton, main.DornishMarchesStackPanel);
                            break;
                        case "Oldtown":
                            resource.Oldtown = parseGoodies(line, main.OldtownButton, main.OldtownStackPanel);
                            break;
                        case "Three_Towers":
                            resource.Three_Towers = parseGoodies(line, main.ThreeTowersButton, main.ThreeTowersStackPanel);
                            break;
                        case "Princes_Pass":
                            resource.Princes_Pass = parseGoodies(line, main.PrincesPassButton, main.PrincesPassStackPanel);
                            break;
                        case "Yronwood":
                            resource.Yronwood = parseGoodies(line, main.YronwoodButton, main.YronwoodStackPanel);
                            break;
                        case "Sunspear":
                            resource.Sunspear = parseGoodies(line, main.SunspearButton, main.SunspearStackPanel);
                            break;
                        case "Starfall":
                            resource.Starfall = parseGoodies(line, main.StarfallButton, main.StarfallStackPanel);
                            break;
                        case "Salt_Shore":
                            resource.Salt_Shore = parseGoodies(line, main.SaltShoreButton, main.SaltShoreStackPanel);
                            break;
                        case "The_Arbor":
                            resource.The_Arbor = parseGoodies(line, main.TheArborButton, main.TheArborStackPanel);
                            break;

                        default:

                            break;

                }
                }

            }
            return allLands;
        }

    }
}

