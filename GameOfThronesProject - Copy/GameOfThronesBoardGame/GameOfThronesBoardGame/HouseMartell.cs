using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public class HouseMartell:House
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
        private string AREO_HOTAH = "Robb Stark";
        private string THE_RED_VIPER = "Eddard Stark";
        private string OBARA_SAND = "Great John Umber";
        private string DARKSTAR = "Roose Bolton";
        private string NYMERIA_SAND = "The Blackfish";
        private string ARIANNE_MARTELL = "Rodrik Cassel";
        private string DORAN_MARTELL = "Catelyn Stark";
        private List<string> houseCardsInHand;
        private List<string> discardedHouseCards;
        List<OrderToken> availableOrderTokens;
        List<OrderToken> allOrderTokens;

        public HouseMartell()
        {
            this. name = "Martell";
            this.numSupply = 2;
            this.numPowerTokens = 5;
            this.numCastles = 0;
            this.numStrongholds = 1;
            this.totalNumCastlesAndStrongHolds = 1;
            this.ravenTrack = 3;
            this.ironThroneTrack = 4;
            this.swordTrack = 3;
            this.numStars = 2;
            this.houseCardsInHand = new List<string>();
            this.houseCardsInHand.Add(THE_RED_VIPER);
            this.houseCardsInHand.Add(AREO_HOTAH);
            this.houseCardsInHand.Add(OBARA_SAND);
            this.houseCardsInHand.Add(DARKSTAR);
            this.houseCardsInHand.Add(NYMERIA_SAND);
            this.houseCardsInHand.Add(ARIANNE_MARTELL);
            this.houseCardsInHand.Add(DORAN_MARTELL);
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
