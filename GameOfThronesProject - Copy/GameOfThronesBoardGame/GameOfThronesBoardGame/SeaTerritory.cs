using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    public class SeaTerritory : Territory
    {
        string name;
        int numShips;
        bool isOccupied;
        House houseOccupied;
        OrderToken orderToken;
        List<string> landConnections, seaConnections;
        public SeaTerritory(string name, int numShips, House houseOccupied, bool isOccupied, OrderToken orderToken, List<string> landConnections, List<string> seaConnections)
        {
            this.name = name;
            this.numShips = numShips;
            this.houseOccupied = houseOccupied;
            this.orderToken = orderToken;
            this.landConnections = landConnections;
            this.seaConnections = seaConnections;
            this.isOccupied = isOccupied;
        }


        public string getName()
        {
            return this.name;
        }
        public void setNumShips(int numShips)
        {
            this.numShips = numShips;
        }

        public int getNumShips()
        {
            return this.numShips;
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

        public List<string> getSeaConnections()
        {
            return this.seaConnections;
        }
        public List<string> getLandConnections()
        {
            return this.landConnections;
        }
        public void setLandConnections(List<string> landConnections)
        {
            this.landConnections = landConnections;
        }
        public void setSeaConections(List<string> seaConnections)
        {
            this.seaConnections = seaConnections;
        }
    }
}
