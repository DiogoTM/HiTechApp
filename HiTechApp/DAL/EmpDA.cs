using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HiTechApp.BLL;
using HiTechAppLibrary.BLL;
using HiTechAppLibrary.DAL;
using HiTechAppLibrary.Validation;             
using MetroFramework;
using MetroFramework.Controls;

namespace HiTechApp.DAL
{
    public class EmpDA : IAppOperatorDA<Employee>
    {
        public void Search(MetroListView empList, List<Employee> employeeList, MetroTextBox tSearch, MetroComboBox cSel, MetroComboBox cSearch)
        {

            empList.Items.Clear();
            List<Employee> foundList = new List<Employee>();
            
            switch (cSel.SelectedIndex)
            {

                case -1:
                    MetroMessageBox.Show(Form.ActiveForm, "Please select a valid search option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    //need to insert validator    
                    foundList = employeeList.FindAll(t => t.ID.Equals(tSearch.Text));                        
                    
                    break;
                case 1:
                    foundList = employeeList.FindAll(t => t.FirstName.Contains(tSearch.Text));
              
                    break;
                case 2:
                    foundList = employeeList.FindAll(t => t.LastName.Contains(tSearch.Text));
                 
                    break;
                case 3:
                    foundList = employeeList.FindAll(t => t.Position.Contains(cSearch.Text));               
                 
                    break;
                case 4:
                    foundList = employeeList.FindAll(t => t.WorkHours.Contains(tSearch.Text));
                           
                    break;
                case 5:
                    foundList = employeeList.FindAll(t => t.Status.Equals(true));
                
                    break;
                case 6:
                    foundList = employeeList.FindAll(t => t.Status.Equals(false));           
                 
                    break;
            }
            foreach (Employee emp in foundList)
            {
                ListObj(empList, emp);
            }
            if (foundList.Count <= 0)
            {
                MetroMessageBox.Show(Form.ActiveForm, "Employee not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }
        public void ListObj(MetroListView list, Employee emp)
        {
            ListViewItem aemp = new ListViewItem(emp.ID.ToString());
            aemp.SubItems.Add(emp.FirstName.ToString());
            aemp.SubItems.Add(emp.LastName.ToString());
            aemp.SubItems.Add(emp.Position.ToString());
            aemp.SubItems.Add(emp.Phone.ToString());
            aemp.SubItems.Add(emp.Email.ToString());
            if (emp.Status == true)
            {
                aemp.SubItems.Add("Active");
            }
            else
            {
                aemp.SubItems.Add("Inactive");
            }
            aemp.SubItems.Add(emp.WorkHours.ToString());
            list.Items.Add(aemp);
        }
    }
}




