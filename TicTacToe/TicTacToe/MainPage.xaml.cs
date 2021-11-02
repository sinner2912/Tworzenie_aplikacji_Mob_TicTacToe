using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        Button[] buttons;
        String move = "";
        String[] tab;
        int ScorePlayer = 0;
        int ComputerScore = 0;


        public MainPage()
        {
            InitializeComponent();
            buttons = new Button[9];
            tab = new String[9];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = (Button)FindByName("btn" + (i + 1).ToString());
            }

        }

        public void ClearButtons()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = "";
            }
        }

        public void EnableButtons()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].IsEnabled = true;
            }
        }

        public void ResetTable()
        {
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = null;
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            ClearButtons();
            EnableButtons();
            ResetTable();
            move = "O";
            labInfo.Text = "Ruch Gracza: O";

        }

        public void moveChange()
        {
            if (move == "O") move = "X";
            else move = "O";
            labInfo.Text = "Ruch Gracza: " + move;

            if (move == "X")
            {
                ComputerMove();
            }
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            MoveMethod(sender);
        }

        public void MoveMethod(object sender)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (sender.Equals(buttons[i]))
                {
                    buttons[i].Text = move;
                    buttons[i].IsEnabled = false;
                    tab[i] = move;
                    if (Win())
                    {
                        for (int j = 0; j < buttons.Length; j++)
                        {
                            buttons[j].IsEnabled = false;
                        }
                        if (move == "X") move = "Komputer";
                        labInfo.Text = "Wygrywa: " + move;
                    }
                    else if (tab[0] != null && tab[1] != null && tab[2] != null && tab[3] != null && tab[4] != null &&
                            tab[5] != null && tab[6] != null && tab[7] != null && tab[8] != null)
                    {
                        labInfo.Text = "REMIS";
                    }
                    else moveChange();
                }
            }
        }

        public void ComputerMove()
        {
            ComputerCanWinOrLose("X");

        }

        public void ComputerCanWinOrLose(string defOrOff)
        {
            //Pierwszy rząd
            if (tab[0] == tab[1] && tab[2] == null && tab[0] == defOrOff) MoveMethod(buttons[2]);
            else if (tab[0] == tab[2] && tab[1] == null && tab[0] == defOrOff) MoveMethod(buttons[1]);
            else if (tab[1] == tab[2] && tab[0] == null && tab[1] == defOrOff) MoveMethod(buttons[0]);

            //Drugi rząd
            else if (tab[3] == tab[4] && tab[5] == null && tab[3] == defOrOff) MoveMethod(buttons[5]);
            else if (tab[3] == tab[5] && tab[4] == null && tab[3] == defOrOff) MoveMethod(buttons[4]);
            else if (tab[4] == tab[5] && tab[3] == null && tab[4] == defOrOff) MoveMethod(buttons[3]);

            //Trzeci rząd
            else if (tab[6] == tab[7] && tab[8] == null && tab[7] == defOrOff) MoveMethod(buttons[8]);
            else if (tab[6] == tab[8] && tab[7] == null && tab[8] == defOrOff) MoveMethod(buttons[7]);
            else if (tab[7] == tab[8] && tab[6] == null && tab[7] == defOrOff) MoveMethod(buttons[6]);

            //Pierwsza Kolumna
            else if (tab[0] == tab[3] && tab[6] == null && tab[0] == defOrOff) MoveMethod(buttons[6]);
            else if (tab[0] == tab[6] && tab[3] == null && tab[0] == defOrOff) MoveMethod(buttons[3]);
            else if (tab[3] == tab[6] && tab[0] == null && tab[6] == defOrOff) MoveMethod(buttons[0]);

            //Druga kolumna
            else if (tab[1] == tab[4] && tab[7] == null && tab[1] == defOrOff) MoveMethod(buttons[7]);
            else if (tab[1] == tab[7] && tab[4] == null && tab[1] == defOrOff) MoveMethod(buttons[4]);
            else if (tab[4] == tab[7] && tab[1] == null && tab[7] == defOrOff) MoveMethod(buttons[1]);

            //Trzecia kolumna
            else if (tab[2] == tab[5] && tab[8] == null && tab[5] == defOrOff) MoveMethod(buttons[8]);
            else if (tab[2] == tab[8] && tab[5] == null && tab[8] == defOrOff) MoveMethod(buttons[5]);
            else if (tab[5] == tab[8] && tab[2] == null && tab[8] == defOrOff) MoveMethod(buttons[2]);

            //Lewy skos
            else if (tab[0] == tab[4] && tab[8] == null && tab[0] == defOrOff) MoveMethod(buttons[8]);
            else if (tab[0] == tab[8] && tab[4] == null && tab[0] == defOrOff) MoveMethod(buttons[4]);
            else if (tab[8] == tab[4] && tab[0] == null && tab[8] == defOrOff) MoveMethod(buttons[0]);

            //Prawy skos
            else if (tab[2] == tab[4] && tab[6] == null && tab[2] == defOrOff) MoveMethod(buttons[6]);
            else if (tab[2] == tab[6] && tab[4] == null && tab[2] == defOrOff) MoveMethod(buttons[4]);
            else if (tab[4] == tab[6] && tab[2] == null && tab[4] == defOrOff) MoveMethod(buttons[2]);

            else if (defOrOff == "X") ComputerCanWinOrLose("O");
            else RandomMove();

        }

        public void RandomMove()
        {
            Random rnd = new Random();
            int a;
            for (; ; )
            {
                a = rnd.Next(9);
                if (tab[a] == null) break;
            }
            MoveMethod(buttons[a]);
        }

        public bool Win()
        {
            if (//Poziomo
                (tab[0] == tab[1] && tab[1] == tab[2] && tab[0] != null) ||
                (tab[3] == tab[4] && tab[4] == tab[5] && tab[3] != null) ||
                (tab[6] == tab[7] && tab[7] == tab[8] && tab[8] != null) ||
                //Pionowo
                (tab[0] == tab[3] && tab[3] == tab[6] && tab[6] != null) ||
                (tab[1] == tab[4] && tab[4] == tab[7] && tab[7] != null) ||
                (tab[2] == tab[5] && tab[5] == tab[8] && tab[8] != null) ||
                //Skosy
                (tab[0] == tab[4] && tab[4] == tab[8] && tab[8] != null) ||
                (tab[2] == tab[4] && tab[4] == tab[6] && tab[6] != null))
                return true;
            else return false;
        }
    }
}
