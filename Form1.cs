using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace text_adventure_step_1
{
    public partial class Form1 : Form
    {
        int myLocation = 1;//this tells what room I am in
        bool allowed = false;


        // array used for directions for rooms
        int[,] roomPlanArray =
        {
            {2,4,3,5},
            {7,1,0,0 },
            {0,0,0,1 },
            {1,0,0,6 },
            {0,0,1,0 },
            {0,0,4,0 },
            {0,2,8,0 },
            {9,10,0,7 },
            {0,8,0,0 },
            {8,0,0,0 },
        };

        string[] roomInfo =
        {
            "This room is red.",
            "This room is green",
            "This room is yellow.",
            "This room is grey.",
            "this room is too dark and you cannont see the color of the room. You feel around hoping to find a way out.",
            "This room is blue",
            "This room is orange",
            "This room is black",
            "This room is fuschia",
            "This room is cyan. There is a panel that you cannot seem to open. Perhaps a wrench would help."
        };
        public Form1()
        {
            InitializeComponent();
            rtbOut.Text += "You awaken and find yourself on the ground in a place you never seen before. The light is dim but you can make out two doors. One is infront of you and one is behind you. The walls of the room are red. Try to get your bearings you pull out your trusty compass from your pocket. You see that you are facing north. You need to find out where you are in hopes of finding your way home.\nWhat will you do?\n Wait! You notice something in the room - you pickup:\n";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            rtbOut.Clear();
            rtbOut.Update();
            rtbOut.Text += "\nYou have choosen north";
            allowed = CanIGoHere(myLocation, "N");
            if (allowed)
            {
                rtbOut.Text += "\n" + roomInfo[myLocation - 1];
            }
            else
            {
                rtbOut.Text += "\nYou Cannot go in that direction in this room";
            }
        }



        private bool CanIGoHere(int where, string direction)
        {
            int col = 0;
            switch (direction)
            {
                case "N":
                    col = 0;
                    break;
                case "S":
                    col = 1;
                    break;
                case "E":
                    col = 2;
                    break;
                case "W":
                    col = 3;
                    break;
            }
            if (roomPlanArray[where-1,col]!= 0)
            {
                myLocation = roomPlanArray[where - 1, col];
                rtbOut.Text += myLocation;
                return true;
          
            }
            else
            {
                return false;
            }
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            rtbOut.Clear();
            rtbOut.Update();
            rtbOut.Text += "\nYou have choosen south";
            allowed = CanIGoHere(myLocation, "S");
            if (allowed)
            {
                rtbOut.Text += "\n" + roomInfo[myLocation - 1];
            }
            else
            {
                rtbOut.Text += "\nYou Cannot go in that direction in this room";
            }
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            rtbOut.Clear();
            rtbOut.Update();
            rtbOut.Text += "\nYou have choosen West";
            allowed = CanIGoHere(myLocation, "W");
            if (allowed)
            {
                rtbOut.Text += "\n" + roomInfo[myLocation - 1];
            }
            else
            {
                rtbOut.Text += "\nYou Cannot go in that direction in this room";
            }
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            rtbOut.Clear();
            rtbOut.Update();
            rtbOut.Text += "\nYou have choosen East";
            allowed = CanIGoHere(myLocation, "E");
            if (allowed)
            {
                rtbOut.Text += "\n" + roomInfo[myLocation - 1];
            }
            else
            {
                rtbOut.Text += "\nYou Cannot go in that direction in this room";
            }
        }
    }
}
