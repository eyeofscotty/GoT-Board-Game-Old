using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public class HouseBaratheon : House
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
        private string RENLY_BARATHEON = "Renly Baratheon";
        private string STANNIS_BARATHEON = "Stannis Baratheon";
        private string SER_DAVOS_SEAWORTH = "Ser Davos Seaworth";
        private string BRIENNE_OF_TARTH = "Brienne of Tarth";
        private string SALLADHOR_SAAN = "Salladhor Saan";
        private string MELISANDRE = "Melisandre";
        private string PATCH_FACE = "Patchface";
        private List<string> houseCardsInHand;
        private List<string> discardedHouseCards;
        List<OrderToken> availableOrderTokens;
        List<OrderToken> allOrderTokens;

        public HouseBaratheon()
        {
            this.name = "Baratheon";
            this.numSupply = 2;
            this.numPowerTokens = 5;
            this.numCastles = 0;
            this.numStrongholds = 1;
            this.totalNumCastlesAndStrongHolds = 1;
            this.ravenTrack = 4;
            this.ironThroneTrack = 1;
            this.swordTrack = 5;
            this.numStars = 1;
            this.houseCardsInHand = new List<string>();
            this.houseCardsInHand.Add(STANNIS_BARATHEON);
            this.houseCardsInHand.Add(RENLY_BARATHEON);
            this.houseCardsInHand.Add(SER_DAVOS_SEAWORTH);
            this.houseCardsInHand.Add(BRIENNE_OF_TARTH);
            this.houseCardsInHand.Add(SALLADHOR_SAAN);
            this.houseCardsInHand.Add(MELISANDRE);
            this.houseCardsInHand.Add(PATCH_FACE);
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
