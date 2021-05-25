using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Workbench.Views
{
    public partial class Trade : Form
    {
        public Trade()
        {
            InitializeComponent();

            gunaPanelSideMenuAdditional.Size = new Size(182, 38);
            gunaPanelSideMenuAdditional.Location = new Point(846, 675);

            //mock datagrid
            int index = gunaDataGridViewOperations.Rows.Add();

            gunaDataGridViewOperations.Rows[index].Cells[0].Value = Properties.Resources.increase_50px;
            gunaDataGridViewOperations.Rows[index].Cells[1].Value = "25/05/2021";
            gunaDataGridViewOperations.Rows[index].Cells[2].Value = 2;
            gunaDataGridViewOperations.Rows[index].Cells[3].Value = 1;
            gunaDataGridViewOperations.Rows[index].Cells[4].Value = "50%";
            gunaDataGridViewOperations.Rows[index].Cells[5].Value = 20;
            gunaDataGridViewOperations.Rows[index].Cells[6].Value = "R$ 250,00";
            gunaDataGridViewOperations.Rows[index].Cells[7].Value = "R$ 150,00";
            gunaDataGridViewOperations.Rows[index].Cells[8].Value = "R$ 100,00";

        }

        private void gunaButtonToggle_Click(object sender, EventArgs e)
        {
            int szMenu = gunaPanelSideMenuAdditional.Size.Height;
            if (szMenu > 38)
            {
                gunaPanelSideMenuAdditional.Size = new Size(182, 38);
                gunaPanelSideMenuAdditional.Location = new Point(846, 675);
                gunaButtonToggle.Image = Properties.Resources.expand_arrow_50px1;
            }
            else
            {
                gunaPanelSideMenuAdditional.Size = new Size(182, 436);
                gunaPanelSideMenuAdditional.Location = new Point(846, 279);
                gunaButtonToggle.Image = Properties.Resources.collapse_arrow_50px;
            }
        }
    }
}
