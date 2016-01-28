using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    public interface Territory
    {
        House getHouseOccupied();

        string getName();

        bool getIsOccupied();

        void setOrderToken(OrderToken orderToken);

        OrderToken getOrderToken();

        Button getButton();

        StackPanel getStackPanel();

        void setStackPanel(StackPanel stackPanel);


    }
}