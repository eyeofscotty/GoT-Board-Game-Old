using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    public class Resources
    {

        public LandTerritory Castle_Black;
        public LandTerritory The_Stony_Shore;
        public LandTerritory Karhold;
        public LandTerritory Widows_Watch;
        public LandTerritory White_Harbor;
        public LandTerritory Winterfell;
        public LandTerritory Moat_Cailin;
        public LandTerritory Greywater_Watch;
        public LandTerritory Flints_Fingers;
        public LandTerritory Seagard;
        public LandTerritory Pyke;
        public LandTerritory The_Twins;
        public LandTerritory The_Fingers;
        public LandTerritory The_Mountains_Of_The_Moon;
        public LandTerritory The_Eyrie;
        public LandTerritory Riverrun;
        public LandTerritory Lannisport;
        public LandTerritory Stoney_Sept;
        public LandTerritory Harrenhal;
        public LandTerritory Crackclaw_Point;
        public LandTerritory Searoad_Marches;
        public LandTerritory Blackwater;
        public LandTerritory Kings_Landing;
        public LandTerritory Dragonstone;
        public LandTerritory Highgarden;
        public LandTerritory The_Reach;
        public LandTerritory Kingswood;
        public LandTerritory Storms_End;
        public LandTerritory The_Boneway;
        public LandTerritory Dornish_Marches;
        public LandTerritory Oldtown;
        public LandTerritory Three_Towers;
        public LandTerritory Princes_Pass;
        public LandTerritory Yronwood;
        public LandTerritory Sunspear;
        public LandTerritory Starfall;
        public LandTerritory Salt_Shore;
        public LandTerritory The_Arbor;

        public SeaTerritory The_Shivering_Sea;
        public SeaTerritory The_Narrow_Sea;
        public SeaTerritory Shipbreaker_Bay;
        public SeaTerritory Blackwater_Bay;
        public SeaTerritory Sea_Of_Dorne;
        public SeaTerritory East_Summer_Sea;
        public SeaTerritory West_Summer_Sea;
        public SeaTerritory Redwyne_Straights;
        public SeaTerritory Sunset_Sea;
        public SeaTerritory The_Golden_Sound;
        public SeaTerritory Ironmans_Bay;
        public SeaTerritory Bay_Of_Ice;

        public HouseStark Stark;
        public HouseBaratheon Baratheon;
        public HouseGreyjoy Greyjoy;
        public HouseLannister Lannister;
        public HouseTyrell Tyrell;
        public HouseMartell Martell;
        public HouseNeutral Neutral = new HouseNeutral();

        public List<House> allHouses = new List<House>();
        public List<OrderToken> allOrderTokens = new List<OrderToken>();

        public List<string> allLandTerritoryNames;
        public List<string> allSeaTerritoryNames;

        public Dictionary<string, LandTerritory> allLandConnections;
        public Dictionary<string, SeaTerritory> allSeaConnections;
        public Dictionary<Button, OrderToken> buttonOrderTokenDict;
        public Dictionary<OrderToken, Button> orderTokenButtonDict;

        MainWindow main;


        //public Territory STORMS_END = new Territory(6, 7, 2, "Martell");
        //public Territory THE_KINGS_WOOD = new Territory(5, 4, 3, "Baratheon");
        //public Territory THE_BONEWAY = new Territory(3, 3, 3, "Martell");


        public Resources(MainWindow main)
        {
            this.main = main;
            
        }

        public void initialize()
        {

            Stark = new HouseStark();
            Baratheon = new HouseBaratheon();
            Greyjoy = new HouseGreyjoy();
            Lannister = new HouseLannister();
            Tyrell = new HouseTyrell();
            Martell = new HouseMartell();

            assignOrderTokenLists(Stark, createOrderTokens());
            assignOrderTokenLists(Martell, createOrderTokens());
            assignOrderTokenLists(Greyjoy, createOrderTokens());
            assignOrderTokenLists(Baratheon, createOrderTokens());
            assignOrderTokenLists(Lannister, createOrderTokens());
            assignOrderTokenLists(Tyrell, createOrderTokens());
            
            setOrderTokenButtonDictionary();
            FillMaxOrderTokens();

            PopulateLand populate = new PopulateLand(this, main);
            allLandConnections = populate.populateLand("C:\\Users\\User\\Desktop\\GameOfThronesProject\\LandTerritory.txt"); 
            CreateConnections createConnectins = new CreateConnections(this);
            createConnectins.createLandConnections("C:\\Users\\User\\Desktop\\GameOfThronesProject\\LandToLand.txt");

            SeaConnections seaConnection = new SeaConnections(this, main);
            allSeaConnections = seaConnection.createSeaConnections("C:\\Users\\User\\Desktop\\GameOfThronesProject\\SeaToSea.txt");
            SeaToLandConnection seaToLand = new SeaToLandConnection(this);
            seaToLand.createSeaToLandConnections("C:\\Users\\User\\Desktop\\GameOfThronesProject\\SeaToLand.txt");

            allLandTerritoryNames = createConnectins.allLands("C:\\Users\\User\\Desktop\\GameOfThronesProject\\LandTerritory.txt");
            allSeaTerritoryNames = seaToLand.allSeas("C:\\Users\\User\\Desktop\\GameOfThronesProject\\SeaToLand.txt");

            setHouseStartingLand(Stark, Winterfell,2, 2, 0);
            setHouseStartingLand(Martell, White_Harbor, 1, 0, 0);
            setHouseStartingSea(Stark, The_Shivering_Sea, 1);

            setHouseStartingLand(Greyjoy, Pyke, 1, 1, 0);
            setHouseStartingLand(Greyjoy, Greywater_Watch, 1, 0, 0);
            setHouseStartingSea(Greyjoy, Ironmans_Bay, 1);
            //Do The ports

            setHouseStartingLand(Lannister, Lannisport, 1, 1, 0);
            setHouseStartingLand(Lannister, Stoney_Sept, 1, 0, 0);
            setHouseStartingSea(Lannister, The_Golden_Sound, 1);

            setHouseStartingLand(Baratheon, Dragonstone,1 ,1, 0);
            setHouseStartingLand(Baratheon, Kingswood, 1, 0, 0);
            setHouseStartingSea(Baratheon, Shipbreaker_Bay, 2);

            setHouseStartingLand(Tyrell, Highgarden, 1, 1, 0);
            setHouseStartingLand(Tyrell, Dornish_Marches, 1, 0, 0);
            setHouseStartingSea(Tyrell, Redwyne_Straights, 1);

            setHouseStartingLand(Martell, Sunspear, 1, 1, 0);
            setHouseStartingLand(Martell, Salt_Shore, 1, 0, 0);
            setHouseStartingSea(Martell, Sea_Of_Dorne, 1);

            listAllHouses();
        }

        public void copyAllOrderTokensToAvailable()
        {
            Stark.setAvailableOrderTokens(Stark.getAllOrderTokens());
            Tyrell.setAvailableOrderTokens(Tyrell.getAllOrderTokens());
            Martell.setAvailableOrderTokens(Martell.getAllOrderTokens());
            Baratheon.setAvailableOrderTokens(Baratheon.getAllOrderTokens());
            Lannister.setAvailableOrderTokens(Lannister.getAllOrderTokens());
            Greyjoy.setAvailableOrderTokens(Greyjoy.getAllOrderTokens());
            FillMaxOrderTokens();
        }

        public void FillMaxOrderTokens()
        {
            Stark.setAllOrderTokens(createOrderTokens());
            Tyrell.setAllOrderTokens(createOrderTokens());
            Baratheon.setAllOrderTokens(createOrderTokens());
            Greyjoy.setAllOrderTokens(createOrderTokens());
            Martell.setAllOrderTokens(createOrderTokens());
            Lannister.setAllOrderTokens(createOrderTokens());
        }

        public void assignOrderTokenLists(House house, List<OrderToken> orderTokenList)
        {
            house.setAvailableOrderTokens(orderTokenList);
        }

        public List<OrderToken> createOrderTokens()
        {
            List<OrderToken> list = new List<OrderToken>();

            list.Add(new MarchOrder(true, false, false, true));
            list.Add(new MarchOrder(false, true, false, true));
            list.Add(new MarchOrder(false, false, true, true));

            list.Add(new DefenseOrder(true, true));
            list.Add(new DefenseOrder(false, true));
            list.Add(new DefenseOrder(false, true));

            list.Add(new SupportOrder(true, true));
            list.Add(new SupportOrder(false, true));
            list.Add(new SupportOrder(false, true));

            list.Add(new RaidOrder(true, true));
            list.Add(new RaidOrder(false, true));
            list.Add(new RaidOrder(false, true));

            list.Add(new ConsolidatePower(true, true));
            list.Add(new ConsolidatePower(false, true));
            list.Add(new ConsolidatePower(false, true));

            return list;
        }

        private void setOrderTokenButtonDictionary()
        {
            buttonOrderTokenDict = new Dictionary<Button, OrderToken>();
            orderTokenButtonDict = new Dictionary<OrderToken, Button>();

            MarchOrder marchStar = (new MarchOrder(true, false, false, true));
            MarchOrder marchZero = (new MarchOrder(false, true, false, true));
            MarchOrder marchNeg = (new MarchOrder(false, false, true, true));

            DefenseOrder defenseStar = (new DefenseOrder(true, true));
            DefenseOrder defense1 = (new DefenseOrder(false, true));
            DefenseOrder defense2 = (new DefenseOrder(false, true));

            SupportOrder supportStar = (new SupportOrder(true, true));
            SupportOrder support1 = (new SupportOrder(false, true));
            SupportOrder support2 = (new SupportOrder(false, true));

            RaidOrder raidStar = (new RaidOrder(true, true));
            RaidOrder raid1 = (new RaidOrder(false, true));
            RaidOrder raid2 = (new RaidOrder(false, true));

            ConsolidatePower consolidatePowerStar = (new ConsolidatePower(true, true));
            ConsolidatePower consolidatePower1 = (new ConsolidatePower(false, true));
            ConsolidatePower consolidatePower2 = (new ConsolidatePower(false, true));

            allOrderTokens.Add(marchStar);
            allOrderTokens.Add(marchZero);
            allOrderTokens.Add(marchNeg);
            allOrderTokens.Add(defenseStar);
            allOrderTokens.Add(defense1);
            allOrderTokens.Add(defense2);
            allOrderTokens.Add(supportStar);
            allOrderTokens.Add(support1);
            allOrderTokens.Add(support2);
            allOrderTokens.Add(raidStar);
            allOrderTokens.Add(raid1);
            allOrderTokens.Add(raid2);
            allOrderTokens.Add(consolidatePowerStar);
            allOrderTokens.Add(consolidatePower1);
            allOrderTokens.Add(consolidatePower2);


            buttonOrderTokenDict.Add(main.MarchStar, marchStar);
            buttonOrderTokenDict.Add(main.MarchZero, marchZero);
            buttonOrderTokenDict.Add(main.MarchMinusOne, marchNeg);
            buttonOrderTokenDict.Add(main.DefenseStar, defenseStar);
            buttonOrderTokenDict.Add(main.Defense1, defense1);
            buttonOrderTokenDict.Add(main.Defense2, defense2);
            buttonOrderTokenDict.Add(main.SupportStar, supportStar);
            buttonOrderTokenDict.Add(main.Support1, support1);
            buttonOrderTokenDict.Add(main.Support2, support2);
            buttonOrderTokenDict.Add(main.RaidStar, raidStar);
            buttonOrderTokenDict.Add(main.Raid1, raid1);
            buttonOrderTokenDict.Add(main.Raid2, raid2);
            buttonOrderTokenDict.Add(main.ConsolidatePowerStar, consolidatePowerStar);
            buttonOrderTokenDict.Add(main.ConsolidatePower1, consolidatePower1);
            buttonOrderTokenDict.Add(main.ConsolidatePower2, consolidatePower2);

            orderTokenButtonDict.Add(marchStar, main.MarchStar);
            orderTokenButtonDict.Add(marchZero, main.MarchZero);
            orderTokenButtonDict.Add(marchNeg, main.MarchMinusOne);
            orderTokenButtonDict.Add(defenseStar, main.DefenseStar);
            orderTokenButtonDict.Add(defense1, main.Defense1);
            orderTokenButtonDict.Add(defense2, main.Defense2);
            orderTokenButtonDict.Add(supportStar, main.SupportStar);
            orderTokenButtonDict.Add(support1, main.Support1);
            orderTokenButtonDict.Add(support2, main.Support2);
            orderTokenButtonDict.Add(raidStar, main.RaidStar);
            orderTokenButtonDict.Add(raid1, main.Raid1);
            orderTokenButtonDict.Add(raid2, main.Raid2);
            orderTokenButtonDict.Add(consolidatePowerStar, main.ConsolidatePowerStar);
            orderTokenButtonDict.Add(consolidatePower1, main.ConsolidatePower1);
            orderTokenButtonDict.Add(consolidatePower2, main.ConsolidatePower2);
        }


       

        public void setHouseStartingLand(House house, LandTerritory land, int numInfantry, int numKnights, int numSiegeEngine)
        {
            List<Infantry> infantry = new List<Infantry>();
            List<Knight> knight = new List<Knight>();
            land.setHouseOccupied(house);
            land.setNumInfantry(numInfantry);
            for (int i = 0; i < numInfantry; i++)
            {
                infantry.Add(new Infantry());
            }
            land.setInfantry(infantry);
            land.setNumKnight(numKnights);
            for (int i = 0; i < numKnights; i++)
            {
                knight.Add(new Knight());
            }
            land.setKnights(knight);

            main.drawUnits.DrawIt(land);
        }

        public void listAllHouses()
        {
            allHouses.Add(Stark);
            allHouses.Add(Tyrell);
            allHouses.Add(Martell);
            allHouses.Add(Greyjoy);
            allHouses.Add(Baratheon);
            allHouses.Add(Lannister);
        }

        public void setHouseStartingSea(House house, SeaTerritory sea, int numShips)
        {
            sea.setHouseOccupied(house);
            sea.setNumShips(numShips);
        }


        

    }


    /*List<OrderToken> list = new List<OrderToken>();
            MarchOrder marchStar = new MarchOrder(true, false, false, main.MarchStar);
            MarchOrder marchZero = new MarchOrder(false, true, false, main.MarchZero);
            MarchOrder marchNeg = new MarchOrder(false, false, true, main.MarchMinusOne);

            DefenseOrder defenseStar = new DefenseOrder(true, main.DefenseStar);
            DefenseOrder defenseNorm1 = new DefenseOrder(false, main.Defense1);
            DefenseOrder defenseNorm2 = new DefenseOrder(false, main.Defense2);

            SupportOrder supportStar = new SupportOrder(true, main.SupportStar);
            SupportOrder supportNorm1 = new SupportOrder(false, main.Support1);
            SupportOrder supportNorm2 = new SupportOrder(false, main.Support2);

            RaidOrder raidStar = new RaidOrder(true, main.RaidStar);
            RaidOrder raidStar1 = new RaidOrder(false, main.Raid1);
            RaidOrder raidStar2 = new RaidOrder(false, main.Raid2);

            ConsolidatePower consolidatePowerStar = new ConsolidatePower(true, main.ConsolidatePowerStar);
            ConsolidatePower consolidatePower1 = new ConsolidatePower(false, main.ConsolidatePower1);
            ConsolidatePower consolidatePower2 = new ConsolidatePower(false, main.ConsolidatePower2);
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * orderTokenButtonDict = new Dictionary<Button, OrderToken>();

            MarchOrder marchStar = (new MarchOrder(true, false, false, true));
            MarchOrder marchZero = (new MarchOrder(false, true, false, true));
            MarchOrder marchNeg = (new MarchOrder(false, false, true, true));

            DefenseOrder defenseStar = (new DefenseOrder(true, true));
            DefenseOrder defense1 = (new DefenseOrder(false, true));
            DefenseOrder defense2 = (new DefenseOrder(false, true));

            SupportOrder supportStar = (new SupportOrder(true, true));
            SupportOrder support1 = (new SupportOrder(false, true));
            SupportOrder support2 = (new SupportOrder(false, true));

            RaidOrder raidStar = (new RaidOrder(true, true));
            RaidOrder raid1 = (new RaidOrder(false, true));
            RaidOrder raid2 = (new RaidOrder(false, true));

            ConsolidatePower consolidatePowerStar = (new ConsolidatePower(true, true));
            ConsolidatePower consolidatePower1 = (new ConsolidatePower(false, true));
            ConsolidatePower consolidatePower2 = (new ConsolidatePower(false, true));

            orderTokenButtonDict.Add(main.MarchStar, marchStar);
            orderTokenButtonDict.Add(main.MarchZero, marchZero);
            orderTokenButtonDict.Add(main.MarchMinusOne, marchNeg);
            orderTokenButtonDict.Add(main.DefenseStar, defenseStar);
            orderTokenButtonDict.Add(main.Defense1, defense1);
            orderTokenButtonDict.Add(main.Defense2, defense2);
            orderTokenButtonDict.Add(main.SupportStar, supportStar);
            orderTokenButtonDict.Add(main.Support1, support1);
            orderTokenButtonDict.Add(main.Support2, support2);
            orderTokenButtonDict.Add(main.RaidStar, raidStar);
            orderTokenButtonDict.Add(main.Raid1, raid1);
            orderTokenButtonDict.Add(main.Raid2, raid2);
            orderTokenButtonDict.Add(main.ConsolidatePowerStar, consolidatePowerStar);
            orderTokenButtonDict.Add(main.ConsolidatePower1, consolidatePower1);
            orderTokenButtonDict.Add(main.ConsolidatePower2, consolidatePower2);
     * */
}
