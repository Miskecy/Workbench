using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Workbench.Models;
using Workbench.Utils.MongoDB;

namespace Workbench.Views
{
    public partial class Trade : Form
    {
        MongoCRUD db = new MongoCRUD("Workbench");
        private int index;
        public Trade()
        {
            InitializeComponent();

            gunaPanelMenuBottom.Size = new Size(1028, 45);
            gunaComboBoxActive.SelectedIndex = 0;

            SetDataGrid();

        }

        private void ToggleButton()
        {
            int szMenu = gunaPanelMenuBottom.Size.Height;
            if (szMenu > 45)
            {
                //style
                gunaButtonToggle.Image = Properties.Resources.collapse_arrow_50px;
                gunaTransition.ShowSync(gunaPanelMenuBottom);

                //collapse panel
                gunaPanelMenuBottom.Size = new Size(1028, 45);
            }
            else
            {
                //style
                gunaButtonToggle.Image = Properties.Resources.expand_arrow_50px1;
                gunaTransition.ShowSync(gunaPanelMenuBottom);

                //expand panel
                gunaPanelMenuBottom.Size = new Size(1028, 347);
            }
        }

        private void SetDataGrid()
        {
            gunaDataGridViewOperations.Rows.Clear();

            var trades = db.LoadData<Operation>("trades");

            foreach (var trade in trades)
            {
                Bitmap img;
                if (trade.Profit >= 0) img = Properties.Resources.increase_50px;
                else img = Properties.Resources.decrease_50px;

                index = gunaDataGridViewOperations.Rows.Add();
                gunaDataGridViewOperations.Rows[index].Cells[0].Value = img;
                gunaDataGridViewOperations.Rows[index].Cells[1].Value = trade.Date;
                gunaDataGridViewOperations.Rows[index].Cells[2].Value = trade.Active;
                gunaDataGridViewOperations.Rows[index].Cells[3].Value = trade.OpWin;
                gunaDataGridViewOperations.Rows[index].Cells[4].Value = trade.OpLoss;
                gunaDataGridViewOperations.Rows[index].Cells[5].Value = trade.Contract;
                gunaDataGridViewOperations.Rows[index].Cells[6].Value = trade.WinRate + "%";
                gunaDataGridViewOperations.Rows[index].Cells[7].Value = "R$" + trade.Win + ",00";
                gunaDataGridViewOperations.Rows[index].Cells[8].Value = "R$" + trade.Loss + ",00";
                gunaDataGridViewOperations.Rows[index].Cells[9].Value = "R$" + trade.Profit + ",00";
            }
        }

        private bool CheckTextEmptyField(GunaTextBox textbox)
        {
            if (textbox.Text == "")
            {
                textbox.BorderColor = Color.Red;
                return true;
            }
            else
            {
                textbox.BorderColor = Color.Silver;
                return false;
            }
        }
         
        private void gunaButtonToggle_Click(object sender, EventArgs e)
        {
            ToggleButton();
        }

        private void gunaButtonCreate_Click(object sender, EventArgs e)
        {
            if (CheckTextEmptyField(gunaTextBoxOpWin)) gunaTextBoxOpWin.Text = "0";
            if (CheckTextEmptyField(gunaTextBoxOpLoss)) gunaTextBoxOpLoss.Text = "0";
            if (CheckTextEmptyField(gunaTextBoxContracts)) return;
            if (CheckTextEmptyField(gunaTextBoxWin)) gunaTextBoxWin.Text = "0";
            if (CheckTextEmptyField(gunaTextBoxLoss)) gunaTextBoxLoss.Text = "0";

            double winrate;
            if (int.Parse(gunaTextBoxContracts.Text) <= 0 )
                winrate = 0;
            else
                winrate = (double.Parse(gunaTextBoxOpWin.Text) / ((double.Parse(gunaTextBoxOpLoss.Text) + double.Parse(gunaTextBoxOpWin.Text)))) * 100;

            double profit = int.Parse(gunaTextBoxWin.Text) - int.Parse(gunaTextBoxLoss.Text);

            Operation trade = new Operation
            {
                Date = new DateTime(2021, 05, 26, 0, 0, 0, DateTimeKind.Utc),
                Active = gunaComboBoxActive.Text,
                OpWin = Convert.ToInt32(gunaTextBoxOpWin.Text),
                OpLoss = Convert.ToInt32(gunaTextBoxOpLoss.Text),
                Contract = Convert.ToInt32(gunaTextBoxContracts.Text),
                WinRate = Math.Round(winrate, 2),
                Win = Convert.ToInt32(gunaTextBoxWin.Text),
                Loss = Convert.ToInt32(gunaTextBoxLoss.Text),
                Profit = profit,
            };

            db.CreateOne<Operation>("trades", trade);

            ToggleButton();
            SetDataGrid();
        }
    }
}
