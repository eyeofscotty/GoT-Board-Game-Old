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
    public class DrawUnits
    {
        MainWindow main;
        public DrawUnits(MainWindow main)
        {
            this.main = main;
        }

        public void DrawIt(LandTerritory passedTerritory)
        {
            passedTerritory.getStackPanel().Children.Clear();
            passedTerritory.getStackPanel().Orientation = System.Windows.Controls.Orientation.Horizontal;
            string fileString = "";

            foreach (Knight k in passedTerritory.getKnights())
            {
                fileString = "C:\\Users\\User\\Desktop\\GameOfThronesProject\\GameOfThronesUnits\\" + passedTerritory.getHouseOccupied().getName() + "Knight.jpg";
                System.Windows.Controls.Image image1 = new System.Windows.Controls.Image();
                image1.Source = new BitmapImage(new Uri(fileString, UriKind.RelativeOrAbsolute));
                passedTerritory.getStackPanel().Children.Add(image1);
            }

            foreach (Infantry i in passedTerritory.getInfantry())
            {
                fileString = "C:\\Users\\User\\Desktop\\GameOfThronesProject\\GameOfThronesUnits\\" + passedTerritory.getHouseOccupied().getName() + "Footman.jpg";
                System.Windows.Controls.Image image1 = new System.Windows.Controls.Image();
                image1.Source = new BitmapImage(new Uri(fileString, UriKind.RelativeOrAbsolute));
                passedTerritory.getStackPanel().Children.Add(image1);
            }
            
        }

        public void DrawIt(SeaTerritory passedTerritory)
        {

        }


    }
}
