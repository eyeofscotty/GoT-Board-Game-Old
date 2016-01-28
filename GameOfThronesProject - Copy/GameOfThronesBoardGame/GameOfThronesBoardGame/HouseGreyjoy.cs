using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public class HouseGreyjoy : House
    {
        private int numSupply;
        private int numPowerTokens;
        private int numCastles;
        private int numStrongholds;
        private int ravenTrack;
        private int ironThroneTrack;
        private int swordTrack;
        private int numStars;
        private int totalNumCastlesAndStrongHolds;
        private string name;
        //Store cards in a resource file later
        private string VICTARION_GREYJOY = "Victarion Greyjoy";
        private string EURON_CROWS_EYE = "Euoron Crow's Eye";
        private string THEON_GREYJOY = "Theon Greyjoy";
        private string BALON_GREYJOY = "Balon Greyjoy";
        private string ASHA_GREYJOY = "Asha Greyjoy";
        private string DAGMAR_CLEFTJAW = "Dagmar Cleftjaw";
        private string AERON_DAMPHAIR = "Aeron Damphair";
        private List<string> houseCardsInHand;
        private List<string> discardedHouseCards;
        List<OrderToken> availableOrderTokens;
        List<OrderToken> allOrderTokens;

        public HouseGreyjoy()
        {
            this.name = "Greyjoy";
            this.numSupply = 2;
            this.numPowerTokens = 5;
            this.numCastles = 0;
            this.numStrongholds = 1;
            this.totalNumCastlesAndStrongHolds = 1;
            this.ravenTrack = 6;
            this.ironThroneTrack = 5;
            this.swordTrack = 1;
            this.numStars = 0;
            this.houseCardsInHand = new List<string>();
            this.houseCardsInHand.Add(EURON_CROWS_EYE);
            this.houseCardsInHand.Add(VICTARION_GREYJOY);
            this.houseCardsInHand.Add(THEON_GREYJOY);
            this.houseCardsInHand.Add(BALON_GREYJOY);
            this.houseCardsInHand.Add(ASHA_GREYJOY);
            this.houseCardsInHand.Add(DAGMAR_CLEFTJAW);
            this.houseCardsInHand.Add(AERON_DAMPHAIR);
            discardedHouseCards = new List<string>();

        }

        public List<OrderToken> getAllOrderTokens()
        {
            return this.allOrderTokens;
        }

        public void setAllOrderTokens(List<OrderToken> allOrderTokens)
        {
            this.allOrderTokens = allOrderTokens;
        }

        public List<OrderToken> getAvailableOrderTokens()
        {
            return this.availableOrderTokens;
        }

        public void setAvailableOrderTokens(List<OrderToken> availableOrderTokens)
        {
            this.availableOrderTokens = availableOrderTokens;
        }

        public string getName()
        {
            return this.name;
        }
        public int getSupply()
        {
            return this.numSupply;
        }
        public void setSupply(int numSupply)
        {
            this.numSupply = numSupply;
        }
        public int getPowerTokens()
        {
            return this.numPowerTokens;
        }
        public void setPowerTokens(int numPowerTokens)
        {
            this.numPowerTokens = numPowerTokens;
        }
        public int getNumStrongholds()
        {
            return this.numStrongholds;
        }
        public void setNumStrongholds(int numStrongholds)
        {
            this.numStrongholds = numStrongholds;
        }
        public int getNumCastles()
        {
            return this.numCastles;
        }
        public void setNumCastles(int numCastles)
        {
            this.numCastles = numCastles;
        }
        public int getRavenTrack()
        {
            return this.ravenTrack;
        }
        public void setRavenTrack(int ravenTrack)
        {
            this.ravenTrack = ravenTrack;
        }
        public int getIronThroneTrack()
        {
            return this.ironThroneTrack;
        }
        public void setIronThroneTrack(int ironThroneTrack)
        {
            this.ironThroneTrack = ironThroneTrack;
        }
        public int getSwordTrack()
        {
            return this.swordTrack;
        }
        public void setSwordTrack(int swordTrack)
        {
            this.swordTrack = swordTrack;
        }
        public int getNumStars()
        {
            return this.numStars;
        }
        public void reSetNumStars()
        {
            switch (this.ravenTrack)
            {
                case 1:
                    this.numStars = 3;
                    break;
                case 2:
                    this.numStars = 3;
                    break;
                case 3:
                    this.numStars = 2;
                    break;
                case 4:
                    this.numStars = 1;
                    break;
                case 5:
                    this.numStars = 0;
                    break;
                case 6:
                    this.numStars = 0;
                    break;
                default:
                    numStars = 0;
                    break;
            }
        }
        public void startingPosition()
        {

        }
        public int totalCastlesAndStrongholds()
        {
            int totalNumCastlesAndStrongholds = this.numCastles + this.numStrongholds;
            return totalNumCastlesAndStrongholds;
        }
    }
}
