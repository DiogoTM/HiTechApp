using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HiTechApp.BLL;
using HiTechApp.DAL;
using HiTechAppLibrary.BLL;
using HiTechAppLibrary.DAL;
using HiTechAppLibrary.Validation;
using MetroFramework;
using MetroFramework.Controls;


namespace HiTechApp.GUI
{
    public partial class ChangePswd : MetroFramework.Forms.MetroForm
    {
        public ChangePswd()
        {
            InitializeComponent();                
        }                                                                                                                  
        //Exit Button        
        private void metroTileExit_Click(object sender, EventArgs e)
        {
            //Exit Message and confirmation
            if (MetroMessageBox.Show(this, "Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                       
                this.Close();       
            }
        }      
        //Info Button
        private void metroTileInfo_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, " Hi-Tech Distribution Inc. (Virtual) \n 7122 18th Montreal, Quebec \n H2A2M8 \n Tel: (514) 721 - 8662 \n Fax: (514) 777 - 8665", "Company's Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }      
        //Edit Password
        private void metroTileEditPsw_Click(object sender, EventArgs e)
        {
            //Check if inforation entered matches database
            if (HiTechForm.loggeduser.Password == metroTextBoxOldPwsd.Text && HiTechForm.loggeduser.Password != metroTextBoxNewPswd.Text)
            {
                int userIndex = HiTechForm.userList.FindIndex(t => t.Employee.ID.Equals(HiTechForm.loggeduser.Employee.ID));
                MessageBox.Show(userIndex.ToString());
                HiTechForm.userList[userIndex].Password = metroTextBoxNewPswd.Text;
                OperatorDA.SaveList(HiTechForm.userList, filePaths.userPath);
                MetroMessageBox.Show(ActiveForm, "Password updated successfully!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //If info does not match, erro message is displayed
            else
            {
                MetroMessageBox.Show(ActiveForm, "Current password provided is incorrect, please try again!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
