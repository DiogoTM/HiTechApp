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
    public class AuthorDA : IAppOperatorDA<Author>
    {
        public void Search(MetroListView metroListViewAuth, List<Author> authorList, MetroTextBox metroTextBoxAuthSearch, MetroComboBox metroComboBoxAuthSearch, MetroComboBox cSearch)
        {
            metroListViewAuth.Items.Clear();
            List<Author> foundList = new List<Author>();
            switch (metroComboBoxAuthSearch.SelectedIndex)
            {
                case -1:
                    MetroMessageBox.Show(Form.ActiveForm, "Please select a valid search option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    foundList = authorList.FindAll(t => t.ID.Equals(metroTextBoxAuthSearch.Text));
                    break;
                case 1:
                    foundList = authorList.FindAll(t => t.FirstName.Equals((metroTextBoxAuthSearch.Text)));
                 
                    break;
                case 2:
                    foundList = authorList.FindAll(t => t.LastName.Equals((metroTextBoxAuthSearch.Text)));
             
                    break;
            }
            foreach (Author item in foundList)
            {
                ListObj(metroListViewAuth, item);
            }
            if (foundList.Count <= 0)
            {
                MetroMessageBox.Show(Form.ActiveForm, "Author not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }        
                         
        public  void ListObj(MetroListView list, Author auth)
        {
            ListViewItem aauthor = new ListViewItem(auth.ID.ToString());
            aauthor.SubItems.Add(auth.FirstName.ToString());
            aauthor.SubItems.Add(auth.LastName.ToString());
            list.Items.Add(aauthor);
        }
    }
            
                   
}




