using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public interface House
    {
        //methods
        string getName();
        int getSupply();
        void setSupply(int supply);
        int getPowerTokens();
        void setPowerTokens(int powerTokens);
        int getNumStrongholds();
        void setNumStrongholds(int numStrongholds);
        int getNumCastles();
        void setNumCastles(int numCastles);
        int getRavenTrack();
        void setRavenTrack(int ravenTrack);
        int getIronThroneTrack();
        void setIronThroneTrack(int ironThroneTrack);
        int getSwordTrack();
        void setSwordTrack(int swordTrack);
        int getNumStars();
        //possibly have to adjust here if want to configure for less than 6 players
        void reSetNumStars();
        void startingPosition();
        int totalCastlesAndStrongholds();
        List<OrderToken> getAvailableOrderTokens();
        void setAvailableOrderTokens(List<OrderToken> availableOrderTokens);
        List<OrderToken> getAllOrderTokens();
        void setAllOrderTokens(List<OrderToken> allOrderTokens);

    }
}
