using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class FormGame : Form
    {
        Editor sea_user;
        Editor sea_comp;

        SeaGrid GridUser;
        SeaGrid GridComp;

        Mission mission;

        enum Mode
        {
            EditShips,
            PlayUser,
            PlayComp,
            Finish
        };

        Mode mode;

        public FormGame()
        {
            InitializeComponent();
            sea_user = new Editor();
            sea_user.ShowShip = ShowUserShip;
            sea_user.ShowFigth = ShowUserFight;

            sea_comp = new Editor();
            sea_comp.ShowShip = ShowCompShip;
            sea_comp.ShowFigth = ShowCompFight;

            GridUser = new SeaGrid(grid_user);
            GridComp = new SeaGrid(grid_comp);

            ReStart();
            timer1.Enabled = true;
        }

        private void ReStart()
        {
            mode = Mode.EditShips;
            sea_user.Reset();
            sea_comp.Reset();
            sea_comp.PlacePrecisely();
            buttonRandom.Visible = true;
            buttonClear.Visible = true;
            buttonStart.Visible = true;
            ShowUnPlacedShips();
        }

        //private void ShowShips(DataGridView grid, Editor sea)
        //{
        //    for (int x = 0; x < Sea.size_sea.x; x++)
        //        for (int y = 0; y < Sea.size_sea.y; y++)
        //            //int nr = ;
        //    if (sea.MapShips(new Dot(x, y)) < 0)
        //        grid[x, y].Style.BackColor = color_back;
        //    else
        //        grid[x, y].Style.BackColor = color_ship[sea.MapShips(new Dot(x, y))];                   
        //}

        private void ShowUserShip(Dot place, int nr)
        {
            GridUser.ShowShip(place, nr);
        }

        private void ShowCompShip(Dot place, int nr)
        {
            if(mode == Mode.EditShips)
            GridComp.ShowShip(place, nr);
        }

        private void ShowUserFight(Dot place, Status status)
        {
            GridUser.ShowFigth(place, status);
        }

        private void ShowCompFight(Dot place, Status status)
        {
            GridComp.ShowFigth(place, status);
        }

        private void grid_user_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            PlaceShip();
            grid_user.ClearSelection();
        }

        private void PlaceShip()
        {
            if (mode != Mode.EditShips) return;
            Dot [] ship = GridUser.GetSelectedCells();
            if (ship == null) return;
            if (ship.Length == 1)
                sea_user.CleanDot(ship[0]);
            sea_user.PlaceForDots(ship);
            ShowUnPlacedShips();
        }

        private void ShowUnPlacedShips()
        {
            sea_comp.PlacePrecisely();
            for (int j = 0; j < Sea.all_ships; j++)
                if (!sea_user.NoShip(j))
                    sea_comp.RemoveShip(j);
            buttonStart.Enabled = (sea_user.Created == Sea.all_ships);
        }

        private void grid_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PlaceShip();
            grid_user.ClearSelection();
        }

        private void FormGame_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                mode = Mode.EditShips;
                sea_comp.PlaceRandom();
                mode = Mode.PlayUser;
            }
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            if (mode != Mode.EditShips)
                return;
            sea_user.PlaceRandom();
            ShowUnPlacedShips();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            sea_user.Reset();
            ShowUnPlacedShips();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            ReStart();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (mode != Mode.EditShips)
                return;
            if(sea_user.Created == Sea.all_ships)
            {
                mode = Mode.PlayUser;
                sea_comp.PlaceRandom();
                mission = new Mission(sea_user);
                buttonRandom.Visible = false;
                buttonClear.Visible = false;
                buttonStart.Visible = false;
            }
        }

        private void grid_comp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grid_comp.ClearSelection();
            if (mode != Mode.PlayUser) return;
            Status status = sea_comp.Shot(new Dot(e.ColumnIndex, e.RowIndex));
            switch(status)
            {
                case Status.indefinitely:
                case Status.miss:
                    mode = Mode.PlayComp; break;
                case Status.slash:
                case Status.kill:
                    mode = Mode.PlayUser; break;
                case Status.win:
                    mode = Mode.Finish; 
                    WinUser();
                    break;
            }

        }

        private void CompFight()
        {
            Dot point;
            Status status = mission.Fight(out point);
            switch (status)
            {
                case Status.indefinitely:
                case Status.miss:
                    mode = Mode.PlayUser; break;
                case Status.slash:
                case Status.kill:
                    mode = Mode.PlayComp; break;
                case Status.win:
                    mode = Mode.Finish;
                    WinComp();
                    break;
            }
        }

        private void WinUser()
        {
            MessageBox.Show("Ты победил !");
        }

        private void WinComp()
        {
            MessageBox.Show("Комп потопил все твои корабли.... ");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mode == Mode.PlayComp)
                CompFight();
        }
    }
}
