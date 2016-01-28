using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{

    public delegate void MarchEventHandler(Button pastButton, Button newButton, EventArgs e);

    public class TakeTurn
    {
        Resources resources;
        MainWindow main;

        public event MarchEventHandler March;
        public House currentPlayer;

        public House[] IronThroneTrack = new House[6];
        public House[] FiefdomThroneTrack = new House[6];
        public House[] KingsCourtThroneTrack = new House[6];


        public TakeTurn(Resources resources, MainWindow main)
        {
            //marchEvent.March += new MarchEventHandler(performBattle);
            this.resources = resources;
            this.main = main;
        }

        public void editDisabledOrders(Territory passedTerritory, Button button)
        {
            button.IsEnabled = false;
            OrderToken newOrder = resources.buttonOrderTokenDict[button];
            foreach (OrderToken o in passedTerritory.getHouseOccupied().getAvailableOrderTokens())
            {
                if (o.Equals(newOrder))
                { 
                    newOrder = o;
                    break;
                }
            }
            newOrder.setIsAvailable(false);
            passedTerritory.getHouseOccupied().getAvailableOrderTokens().Remove(newOrder);

            if (!(passedTerritory.getOrderToken() is PlaceHolderOrderToken))
            {
                passedTerritory.getOrderToken().setIsAvailable(true);
                passedTerritory.getHouseOccupied().getAvailableOrderTokens().Add(passedTerritory.getOrderToken());  
                foreach (OrderToken o1 in resources.allOrderTokens)
                {
                    if (o1.Equals(passedTerritory.getOrderToken()) && !(resources.orderTokenButtonDict[o1].IsEnabled))
                    {
                        resources.orderTokenButtonDict[o1].IsEnabled = true;
                        break;
                    }
                }
            }
            passedTerritory.setOrderToken(newOrder);
        }

        public void intermediateTerritoryPrintOut(Territory passedTerritory, Button button)
        {
            editDisabledOrders(passedTerritory, button);

          /*  if (passedTerritory is LandTerritory)
            {
                return territoryPrintOut((LandTerritory)passedTerritory);
            }
            else
            {
                return territoryPrintOut((SeaTerritory)passedTerritory);
            }*/
        }

        public string territoryPrintOut(LandTerritory passedTerritory)
        {
            string str = (territoryTextToString(passedTerritory.getHouseOccupied().getName(), passedTerritory.getNumInfantry(), passedTerritory.getNumKnight(),
                          passedTerritory.getNumSiegeEngine(), passedTerritory.getOrderToken(), passedTerritory));
            return str;
        }

        public string territoryPrintOut(SeaTerritory passedTerritory)
        {
            string str = territoryTextToString(passedTerritory.getHouseOccupied().getName(), passedTerritory.getNumShips(), passedTerritory.getOrderToken(), passedTerritory);
            return str;
        }

        public string territoryTextToString(string name, int numShips, OrderToken order, SeaTerritory sea)
        {
            string returnString = name + "- ";
            if (numShips > 0)
            {
                returnString += " S: " + numShips;
            }

            returnString += order.toString();

            return returnString;
        }

        public string territoryTextToString(string name, int infantry, int knights, int siegeEngine, OrderToken order, LandTerritory land)
        {
            string returnString = name + "- ";
            if (infantry > 0)
            {
                returnString += " F: " + infantry;
            }
            if (knights > 0)
            {
                returnString += " K: " + knights;
            }
            if (siegeEngine > 0)
            {
                returnString += " SE: " + siegeEngine;
            }


            returnString += order.toString();

            return returnString;
        }

        public void DisableAllTerritoryButtons()
        {
            foreach (string s in resources.allLandTerritoryNames)
            {
                resources.allLandConnections[s.Trim()].getButton().IsEnabled = false;
            }
        }

        public void disableButtons(House house)
        {
            foreach (string s in resources.allLandTerritoryNames)
            {
                if (!resources.allLandConnections[s].getHouseOccupied().Equals(house) || resources.allLandConnections[s].getHouseOccupied() is HouseNeutral)
                {
                    resources.allLandConnections[s].getButton().IsEnabled = false;
                }
            }

            foreach (string s in resources.allSeaTerritoryNames)
            {
                if (!resources.allSeaConnections[s].getHouseOccupied().Equals(house))
                {
                    resources.allSeaConnections[s].getButton().IsEnabled = false;
                }
            }
                
            
        }

        public void doIT(object sender1, object sender2)
        {
            Button b1 = (sender1 as Button);
            Button b2 = (sender2 as Button);
            //OnOrderTokenChange(b1, b2, EventArgs.Empty);
        }

        // Invoke the Changed event; called whenever list changes
        protected virtual void OnOrderTokenChange(Button pastButton, Button newButton, EventArgs e)
        {
            if (March != null)
                March(pastButton, newButton, e);
        }
        

        public void TakeATurn()
        {
            House houseTurn;
            for (int i = 0; i < 6; i++)
            {
                houseTurn = IronThroneTrack[i];

            }
        }

        public void SetInfluenceTracks()
        {
            foreach (House h in resources.allHouses)
            {
                IronThroneTrack[h.getIronThroneTrack() - 1] = h;
                FiefdomThroneTrack[h.getSwordTrack() - 1] = h;
                KingsCourtThroneTrack[h.getRavenTrack() - 1] = h;
            }
        }

        public void CheckCastlesForVictory()
        {
            if (resources.Stark.totalCastlesAndStrongholds() >= 7 || resources.Tyrell.totalCastlesAndStrongholds() >= 7 || resources.Greyjoy.totalCastlesAndStrongholds() >= 7 ||
                   resources.Martell.totalCastlesAndStrongholds() >= 7 || resources.Lannister.totalCastlesAndStrongholds() >= 7 || resources.Baratheon.totalCastlesAndStrongholds() >= 7)
            {
                DeclareWinner();
            }
        }

        public void DeclareWinner()
        {

        }


        public void performBattle(LandTerritory attacker, LandTerritory defender)
        {

            if (attacker.getNumInfantry() + attacker.getNumKnight() > defender.getNumInfantry() + defender.getNumKnight())
            {
                attacker.setOrderToken(new PlaceHolderOrderToken());
                main.ConfirmAttack_Click();
            }
            else
            {

            }
        }
     }
}
