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
    public class PubDA : IAppOperatorDA<Publisher>
    {
        public void Search(MetroListView metroListViewPub, List<Publisher> publisherList, MetroTextBox metroTextBoxPubSearch, MetroComboBox metroComboBoxPubSearch, MetroComboBox cSearch)
        {
            metroListViewPub.Items.Clear();
            List<Publisher> foundList = new List<Publisher>();
            switch (metroComboBoxPubSearch.SelectedIndex)
            {
                case -1:
                    MetroMessageBox.Show(Form.ActiveForm, "Please select a valid search option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 0:
                     foundList = publisherList.FindAll(t => t.PubId.Equals(metroTextBoxPubSearch.Text));
         
                    return;
                case 1:
                    foundList = publisherList.FindAll(t => t.PubName.Equals(metroTextBoxPubSearch.Text));
                    break;
            }
            foreach (Publisher item in foundList)
            {
                ListObj(metroListViewPub, item);
            }
            if (foundList.Count <= 0)
            {
                MetroMessageBox.Show(Form.ActiveForm, "Publisher not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }

        public  void ListObj(MetroListView list, Publisher apub)
        {
            ListViewItem aitem = new ListViewItem(apub.PubId.ToString());
            aitem.SubItems.Add(apub.PubName.ToString());
            list.Items.Add(aitem);
        }
    }
            
                   
}




