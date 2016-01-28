using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    public class LandTerritory : Territory
    {
        private string name;
        private int numSupply;
        private int numCrowns;
        private int numInfantry;
        private int numKnight;
        private int numSiegeEngine;
        private bool hasCastle;
        private bool hasStronghold;
        private bool isOccupied;
        private House houseOccupied;
        private OrderToken orderToken;
        private List<string> connections;
        private Button button;
        private StackPanel stackPanel;
        List<Knight> knights = new List<Knight>();
        List<Infantry> infantry = new List<Infantry>();

        public LandTerritory()
        {

        }

        public LandTerritory(string name, int numSupply, int numCrowns, int numInfantry, int numKnight, int numSiegeEngine,
            bool hasCastle, bool hasStronghold, bool isOccupied, House houseOccupied, OrderToken orderToken, Button button, List<string> connections)
        {
            this.name = name;
            this.numSupply = numSupply;
            this.numCrowns = numCrowns;
            this.hasCastle = hasCastle;
            this.hasStronghold = hasStronghold;
            this.numInfantry = numInfantry;
            this.numKnight = numKnight;
            this.isOccupied = isOccupied;
            this.numSiegeEngine = numSiegeEngine;
            this.houseOccupied = houseOccupied;
            this.orderToken = orderToken;
            this.connections = connections;
            this.button = button;
        }

        public StackPanel getStackPanel()
        {
            return this.stackPanel;
        }

        public void setStackPanel(StackPanel stackPanel)
        {
            this.stackPanel = stackPanel;
        }

        public void setInfantry(List<Infantry> infantry)
        {
            this.infantry = infantry; 
        }

        public List<Infantry> getInfantry()
        {
            return this.infantry;
        }

        public void setKnights(List<Knight> knights)
        {
            this.knights = knights;
        }

        public List<Knight> getKnights()
        {
            return this.knights;
        }

        public Button getButton()
        {
            return this.button;
        }

        public void setButton(Button button)
        {
            this.button = button;
        }

        public string getName()
        {
            return this.name;
        }

        public int getNumSupply()
        {
            return this.numSupply;
        }
        public int getNumCrowns()
        {
            return this.numCrowns;
        }

        public bool getHasCastle()
        {
            return this.hasCastle;
        }

        public bool getHasStronghold()
        {
            return this.hasStronghold;
        }

        public bool getIsOccupied()
        {
            if (houseOccupied == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setNumInfantry(int numInfantry)
        {
            this.numInfantry = numInfantry;
        }

        public int getNumInfantry()
        {
            return this.numInfantry;
        }

        public void setNumKnight(int numKnight)
        {
            this.numKnight = numKnight;
        }

        public int getNumKnight()
        {
            return this.numKnight;
        }

        public void setNumSiegeEngine(int numSiegeEngine)
        {
            this.numSiegeEngine = numSiegeEngine;
        }

        public int getNumSiegeEngine()
        {
            return this.numSiegeEngine;
        }

        public void setHouseOccupied(House houseOccupied)
        {
            this.houseOccupied = houseOccupied;
        }

        public House getHouseOccupied()
        {
            return this.houseOccupied;
        }

        public void setOrderToken(OrderToken orderToken)
        {
            this.orderToken = orderToken;
        }

        public OrderToken getOrderToken()
        {
            return this.orderToken;
        }

        public List<string> getConnections()
        {
            return this.connections;
        }

        public void setConnections(List<string> connections)
        {
            this.connections = connections;
        }

        
    }
}
