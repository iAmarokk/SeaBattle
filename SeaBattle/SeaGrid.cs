using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    class SeaGrid
    {
        DataGridView grid;

        static string abc = "РЕСПУБЛИКА";//"АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩ";

        Color color_back = Color.DarkSeaGreen;
        Color[] color_ship = {
            Color.Violet,
            Color.Violet, Color.Violet,
            Color.Violet, Color.Violet, Color.Violet,
            Color.Violet, Color.Violet, Color.Violet, Color.Violet };

        Color[] color_figth = {
            Color.DarkSeaGreen,
            Color.SeaGreen, Color.Orange,
            Color.OrangeRed,
            Color.OrangeRed };

        public SeaGrid(DataGridView grid)
        {
            this.grid = grid;
            InitGrid();
        }

        private void InitGrid()
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            grid.DefaultCellStyle.BackColor = color_back;
            for (int x = 0; x < Sea.size_sea.x; x++)
                grid.Columns.Add("col_" + x.ToString(), abc.Substring(x, 1));
            for (int y = 0; y < Sea.size_sea.y; y++)
            {
                grid.Rows.Add();
                grid.Rows[y].HeaderCell.Value = (y + 1).ToString();
            }
            grid.Height = Sea.size_sea.y * grid.Rows[0].Height + grid.ColumnHeadersHeight + 0;
            grid.ClearSelection();
        }

        public void ShowShip(Dot place, int nr)
        {
            if (nr < 0)
                grid[place.x, place.y].Style.BackColor = color_back;
            else
                grid[place.x, place.y].Style.BackColor = color_ship[nr];
        }

        public void ShowFigth(Dot place, Status status)
        {
            grid[place.x, place.y].Style.BackColor =
                   color_figth[(int)status];
        }

        public Dot [] GetSelectedCells()
        {
            if (grid.SelectedCells.Count == 0)
                return null;
            Dot[] ship = new Dot[grid.SelectedCells.Count];
            int j = 0;
            foreach (DataGridViewCell cell in grid.SelectedCells)
            {
                ship[j++] = new Dot(cell.ColumnIndex, cell.RowIndex);
            }
            grid.ClearSelection();
            return ship;
        }
    }
}
