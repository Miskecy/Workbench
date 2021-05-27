using Guna.UI.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using Workbench.Views;

namespace Workbench
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            gunaPanelSetting.Size = new Size(0, 513);
            gunaPanelSideMenuAdditional.Size = new Size(0, 513);

            LoadForm(new Dashboard());
        }

        private void LoadForm(Form form)
        {
            if (gunaPanelBodyContainer.Controls.Count > 0)
                gunaPanelBodyContainer.Controls.Clear();

            Form newForm = form as Form;
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            gunaPanelBodyContainer.Controls.Add(newForm);
            gunaPanelBodyContainer.Tag = newForm;
            newForm.Show();
        } 

        private void gunaButtonDashboard_Click(object sender, EventArgs e)
        {

        }

        private void gunaButtonDashboard_Click_1(object sender, EventArgs e)
        {
            LoadForm(new Trade());
            gunaButtonTrades.Focus();
        }

        private void gunaImageButtonMenu_Click(object sender, EventArgs e)
        {
            int szSidemenu = gunaPanelSideMenu.Size.Width;
            if (szSidemenu > 68)
                gunaPanelSideMenu.Size = new Size(68, 550);
            else
                gunaPanelSideMenu.Size = new Size(172, 550);
        }

        private void gunaButtonSettings_Click(object sender, EventArgs e)
        {
            int szSideMenuSetting = gunaPanelSetting.Size.Width;
            if (szSideMenuSetting < 172)
            {
                gunaPanelSetting.Size = new Size(172, 513);
                gunaButtonSettings.BaseColor = Color.FromArgb(255, 100, 88, 255);
                gunaButtonSettings.ForeColor = Color.FromArgb(255, 255, 255, 255);
                gunaButtonSettings.Image = Properties.Resources.settings_50pxl;
            }
            
        }

        private void gunaButtonSettingClose_Click(object sender, EventArgs e)
        {
            int szSideMenuSetting = gunaPanelSetting.Size.Width;
            if (szSideMenuSetting > 68)
            {
                gunaPanelSetting.Size = new Size(0, 513);
                gunaButtonSettings.BaseColor = Color.FromArgb(255, 100, 88, 255);
                gunaButtonSettings.ForeColor = Color.FromArgb(255, 255, 255, 255);
                gunaButtonSettings.Image = Properties.Resources.settings_50pxl;
            }
        }        

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            LoadForm(new Dashboard());
        }
    }
}
