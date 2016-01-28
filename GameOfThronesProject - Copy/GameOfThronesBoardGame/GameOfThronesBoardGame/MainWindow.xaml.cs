using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace GameOfThronesBoardGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock attackerText;
        TextBlock defenderText;

        PlaceHolderOrderToken placeHolder = new PlaceHolderOrderToken();

        public Territory currentTerritory;
        List<Button> MartellButtons = new List<Button>();

        public TakeTurn takeTurn;
        public Resources resources;
        public ResolveMarch resolveMarch;
        public DrawUnits drawUnits;

        public enum TurnPhase { PlaceTokens, Raid, March, ConsolidatePower, Westeros };

        TurnPhase turnPhase = TurnPhase.PlaceTokens;

        int turnNum = 1;        

        public MainWindow()
        {
            InitializeComponent();
            

            //Territory STORMS_END = new Territory();
            initializeWindow();
            Play();
            

        }

        private void OrderTokenChanged(Button pastButton, Button newButton, EventArgs e)
        {
            pastButton.IsEnabled = false;
            newButton.IsEnabled = true;
        }


        public void Play()
        {
            for (int i = 0; i < 10; i++)
            {
                turnNum++;
            }

            takeTurn.DeclareWinner();

        }


        public void ResolveMarchOrders()
        {
           
        }

        

        public void initializeWindow()
        {
            
            resources = new Resources(this);
            takeTurn = new TakeTurn(resources, this);
            resolveMarch = new ResolveMarch(this);
            drawUnits = new DrawUnits(this);
            resources.initialize();
            takeTurn.currentPlayer = resources.Stark;
            takeTurn.SetInfluenceTracks();
            takeTurn.disableButtons(resources.Stark);
           // MarchOrder march = new MarchOrder(false, true, false);
           /// resources.Sunspear.setOrderToken(march);
            takeTurn.March += new MarchEventHandler(OrderTokenChanged);
        }

        public void performButtonFunction(SeaTerritory passedTerritory, TextBlock passedText)
        {
            switch (turnPhase)
            {
                case TurnPhase.PlaceTokens:
                   // takeTurn.updateDisableButtons();
                    currentTerritory = passedTerritory;
                    ChooseOrderTokenPopup.IsOpen = false;
                    ChooseOrderTokenPopup.IsOpen = true;
                    
                    //passedTerritory.setOrderToken(new MarchOrder(false, true, false));
                    //passedText.Text = takeTurn.territoryPrintOut(passedTerritory);

                    break;
                case TurnPhase.Westeros:

                    break;
                case TurnPhase.Raid:

                    break;
                case TurnPhase.March:

                    resolveMarch.doMarchOrder(passedTerritory, passedText);

                    break;
                case TurnPhase.ConsolidatePower:


                    turnNum++;
                    break;
            }


        }

        public void performButtonFunction(LandTerritory passedTerritory)
        {
            switch (turnPhase)
            {
                case TurnPhase.PlaceTokens:
                    //takeTurn.updateDisableButtons();
                    currentTerritory = passedTerritory;
                    ChooseOrderTokenPopup.IsOpen = false;
                    ChooseOrderTokenPopup.IsOpen = true; 
                   //passedTerritory.setOrderToken(new MarchOrder(false, true, false));
                    //passedText.Text = takeTurn.territoryPrintOut(passedTerritory);
                    break;
                case TurnPhase.Westeros:

                    break;
                case TurnPhase.Raid:

                    break;
                case TurnPhase.March:
                     resolveMarch.doMarchOrder((LandTerritory)passedTerritory);

                    break;
                case TurnPhase.ConsolidatePower:


                    turnNum++;
                    break;
               }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
        }

        public void ConfirmAttack_Click()
        {
        
           /*if (!attacker.Equals(defender) && attack == false)
            {
                winner = attacker.attack(defender);
                if (winner.Equals(attacker))
                {
                    
                    defenderText.Text = attacker.DisplayHouse + " I: " + attacker.getInfantry;
                    attackerText.Text = attacker.DisplayHouse + " I: " + attacker.getInfantry;
                }
                else
                {
                    PopupVictoryLabel.Content = "House " + winner.DisplayHouse + " Defended " + defender.getDefensePower() + "-" + attacker.getAttackPower();
                    defenderText.Text = defender.DisplayHouse + " I: " + defender.getInfantry;
                    attackerText.Text = attacker.DisplayHouse + " I: " + defender.getInfantry + " R";
                }
            }


           */ Popup1.IsOpen = false;
            //PopupVictoryLabel.Content = "House " + attacker.getHouseOccupied().getName() + " won ";
            PopupVictory.IsOpen = true;


        }

        private void ClosePopupVictory_Click(object sender, RoutedEventArgs e)
        {
            //attacker = new Territory();
            //defender = new Territory();
            defenderText = new TextBlock();
            attackerText = new TextBlock();
            PopupVictory.IsOpen = false;
        }

        private void Button_Click_Proceed(object sender, RoutedEventArgs e)
        {
            switch (turnPhase)
            {
                case TurnPhase.PlaceTokens:
                    //remember to set availablePowerTokens == to allPowerTokens


                    turnPhase = TurnPhase.March;
                    resources.copyAllOrderTokensToAvailable();

                    break;
                case TurnPhase.Westeros:

                    break;
                case TurnPhase.Raid:

                    break;
                case TurnPhase.March:
                    //Take attacker and defender and fire an event for an attack
                    resolveMarch.performCombat();
                    break;
                case TurnPhase.ConsolidatePower:

                    break;
            }
        }



        public void Button_Click_STORMS_ENDS(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Storms_End);
        }

        public void Button_Click_THE_KINGS_WOOD(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Kingswood);

        }

        private void Button_Click_THE_BONEWAY(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Boneway);
        }

        private void Button_Click_Sunspear(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Sunspear);
        }

        private void Button_Click_SALT_SHORE(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Salt_Shore);
        }

        private void Button_Click_DRAGONSTONE(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Dragonstone);
        }

        private void Button_Click_CRACKCLAW_POINT(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Crackclaw_Point);
        }

        private void Button_Click_HARRENHAL(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Salt_Shore);
        }

        private void Button_Click_RIVERRUN(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Riverrun);
        }

        private void Button_Click_Lannisport(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Lannisport);
        }

        private void Button_Click_STONEY_SEPT(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Stoney_Sept);
        }

        private void Button_Click_SEAROAD_MARCHES(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Searoad_Marches);
        }

        private void Button_Click_BLACKWATER(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Blackwater);
        }

        private void Button_Click_KINGS_LANDING(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Kings_Landing);
        }

        private void Button_Click_HIGHGARDEN(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Highgarden);
        }

        private void Button_Click_THE_REACH(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Reach);
        }

        private void Button_Click_DORNISH_MARCHES(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Dornish_Marches);
        }

        private void Button_Click_OLD_TOWN(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Oldtown);
        }

        private void Button_Click_PRINCES_PASS(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Princes_Pass);
        }

        private void Button_Click_THREE_TOWERS(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Three_Towers);
        }

        private void Button_Click_THE_ARBOR(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Arbor);
        }

        private void Button_Click_STARFALL(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Starfall);
        }

        private void Button_Click_YRONWOOD(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Yronwood);
        }

        private void Button_Click_PYKE(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Pyke);
        }

        private void Button_Click_SEAGARD(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Seagard);
        }

        private void Button_Click_THE_TWINS(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Twins);
        }

        private void Button_Click_THE_FINGERS(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Fingers);
        }

        private void Button_Click_THE_EYRIE(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Eyrie);
        }

        private void Button_Click_THE_MOUNTAINS_OF_THE_MOON(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Mountains_Of_The_Moon);
        }

        private void Button_Click_MOAT_CAILIN(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Moat_Cailin);
        }

        private void Button_Click_FLINTS_FINGERS(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Flints_Fingers);
        }

        private void Button_Click_GREYWATER_WATCH(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Greywater_Watch);
        }

        private void Button_Click_WIDOWS_WATCH(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Widows_Watch);
        }

        private void Button_Click_WHITE_HARBOR(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.White_Harbor);
        }

        private void Button_Click_WINTERFELL(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Winterfell);
        }

        private void Button_Click_THE_STONEY_SHORE(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Stony_Shore);
        }

        private void Button_Click_KARHOLD(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Karhold);
        }

        private void Button_Click_CASTLE_BLACK(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Castle_Black);
        }

        private void Button_Click_THE_NARROW_SEA(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Narrow_Sea, TheNarrowSeaText);
        }

        private void Button_Click_THE_SHIVERING_SEA(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Shivering_Sea, TheShiveringSeaText);
        }

        private void Button_Click_BAY_OF_ICE(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Bay_Of_Ice, BayOfIceText);
        }

        private void Button_Click_SUNSET_SEA(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Sunset_Sea, SunsetSeaText);
        }

        private void Button_Click_SHIPBREAKER_BAY(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Shipbreaker_Bay, ShipbreakerBayText);
        }

        private void Button_Click_THE_GOLDEN_SOUND(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.The_Golden_Sound, TheGoldenSoundText);
        }

        private void Button_Click_IRON_MANS_BAY(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Ironmans_Bay, IronmansBayText);
        }

        private void Button_Click_BLACKWATER_BAY(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Blackwater_Bay, BlackwaterBayText);
        }

        private void Button_Click_EAST_SUMMER_SEA(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.East_Summer_Sea, EastSummerSeaText);
        }

        private void Button_Click_SEA_OF_DORNE(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Sea_Of_Dorne, SeaOfDorneText);
        }

        private void Button_Click_WEST_SUMMER_SEA(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.West_Summer_Sea, WestSummerSeaText);
        }

        private void Button_REDWYNE_STRAIGHTS(object sender, RoutedEventArgs e)
        {
            performButtonFunction(resources.Redwyne_Straights, RedwyneStraightsText);
        }

        private void Click_ORDER(object sender, RoutedEventArgs e)
        {
            ChooseOrderTokenPopup.IsOpen = false;
            string fileString = "C:\\Users\\User\\Desktop\\GameOfThronesProject\\GameOfThronesOrderTokens\\" + (sender as Control).Name +".jpg";
            System.Windows.Controls.Image image1 = new System.Windows.Controls.Image();
            image1.Source = new BitmapImage(new Uri(fileString, UriKind.RelativeOrAbsolute));
            currentTerritory.getStackPanel().Children.Add(image1);
            takeTurn.intermediateTerritoryPrintOut(currentTerritory, (sender as Button));
        }

        
    }

    


    /* public void performButtonFunction(LandTerritory passedTerritory, TextBlock passedText)
        {
            if (attack)
            {
                attacker = passedTerritory;
                attackerText = passedText;
                attack = false;
            }
            else
            {
                LandTerritory tempDefender = defender;
                defender = passedTerritory;
                if (!attacker.Equals(defender))
                {

                    defenderText = passedText;
                    PopupLable1.Content = "A: " + attacker.getHouseOccupied().getName() + " I: " + attacker.getNumInfantry() + " " + attacker.getAttackPower();
                    PopupLable2.Content = "D: " + defender.DisplayHouse + " I: " + defender.getInfantry + " " + defender.getDefensePower();
                    Popup1.IsOpen = true;
                }
                else
                {
                    defender = tempDefender;
                }
            }
        }*/
}
