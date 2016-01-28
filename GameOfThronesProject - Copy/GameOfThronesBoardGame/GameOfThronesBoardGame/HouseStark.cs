using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public class HouseStark : House
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
        private string ROBB_STARK = "Robb Stark";
        private string EDDARD_STARK = "Eddard Stark";
        private string GREAT_JOHN_UMBER = "Great John Umber";
        private string ROOSE_BOLTON = "Roose Bolton";
        private string THE_BLACK_FISH = "The Blackfish";
        private string RODRIK_CASSEL = "Rodrik Cassel";
        private string CATELYN_STARK = "Catelyn Stark";
        private List<string> houseCardsInHand;
        private List<string> discardedHouseCards;
        List<OrderToken> availableOrderTokens;
        List<OrderToken> allOrderTokens;

        public HouseStark()
        {
            this.name = "Stark";
            this.numSupply = 1;
            this.numPowerTokens = 5;
            this.numCastles = 1;
            this.numStrongholds = 1;
            this.totalNumCastlesAndStrongHolds = 2;
            this.ravenTrack = 2;
            this.ironThroneTrack = 3;
            this.swordTrack = 4;
            this.numStars = 3;
            this.houseCardsInHand = new List<string>();
            this.houseCardsInHand.Add(EDDARD_STARK);
            this.houseCardsInHand.Add(ROBB_STARK);
            this.houseCardsInHand.Add(GREAT_JOHN_UMBER);
            this.houseCardsInHand.Add(ROOSE_BOLTON);
            this.houseCardsInHand.Add(THE_BLACK_FISH);
            this.houseCardsInHand.Add(RODRIK_CASSEL);
            this.houseCardsInHand.Add(CATELYN_STARK);
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
