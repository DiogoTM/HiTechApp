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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }
        //Create objects employee and user 
        List<Employee> employeeList = OperatorDA.List<Employee>(filePaths.empPath);
        List<User> userList = OperatorDA.List<User>(filePaths.userPath);

        //Login
        private void metroTileLogin_Click(object sender, EventArgs e)
        {
          
            //If user is valid, checks password
            User auser = userList.Find(t => t.Employee.ID.Equals(metroTextBoxLogin.Text.ToUpper()));
            //HiTechForm appRun = new HiTechForm(auser);
            //this.Hide();
            //appRun.Show();
            if (auser != null && auser.Password == metroTextBoxPwsd.Text && auser.Employee.Status.Equals(true))
            {
                //Opens HiTechForm with user info  if password is correct
                HiTechForm appRun = new HiTechForm(auser);
                this.Hide();
                appRun.Show();

            }

            else
            {
                MetroMessageBox.Show(this, "Login error! The username or password provided are incorrect.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                metroTextBoxLogin.Clear();
                metroTextBoxPwsd.Clear();
                metroTextBoxLogin.Focus();
            }
        }
        //Exit
        private void metroTileExit_Click(object sender, EventArgs e)
        {
            //Exit Message and confirmation
            if (MetroMessageBox.Show(this, "Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //Info
        private void metroTileInfo_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Software designed by: Diogo Machado - 1630985 \n Course Number: 420-P34-AS \n Course Title: Advanced Object Prog. \n Teacher: Quang Hoang Cao", "Developer's Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
