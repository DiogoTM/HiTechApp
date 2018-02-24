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
    public class ClientDA : IAppOperatorDA<Client>
    {
        public void Search(MetroListView alist, List<Client> clientList, MetroTextBox tSearch, MetroComboBox cSel, MetroComboBox cSearch)
        {
            alist.Items.Clear();
            List <Client> foundList = new List<Client>();
            switch (cSel.SelectedIndex)
            {                      
                case -1:
                    MetroMessageBox.Show(Form.ActiveForm, "Please select a valid search option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 0:
                    //need to insert validator    
                     foundList = clientList.FindAll(t => t.ClientId.Equals(tSearch.Text));  
                    break;
                case 1:
                    foundList = clientList.FindAll(t => t.ClientName.Equals((tSearch.Text)));                    
                    break;
                case 2:
                    foundList = clientList.FindAll(t => t.ClientStatus.Equals(true));                           
                    break;
                case 3:
                    foundList = clientList.FindAll(t => t.ClientStatus.Equals(false));                     
                    break;
            }
            foreach (Client cl in foundList)
            {
                ListObj(alist, cl);
            }
            if (foundList.Count <= 0)
            {
                MetroMessageBox.Show(Form.ActiveForm, "Client not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public  void ListObj(MetroListView list, Client cl)
        {
            ListViewItem aclient = new ListViewItem(cl.ClientId.ToString());
            aclient.SubItems.Add(cl.ClientName.ToString());
            aclient.SubItems.Add(cl.ClientEmail.ToString());
            aclient.SubItems.Add(cl.ClientStreet.ToString());
            aclient.SubItems.Add(cl.ClientCity.ToString());
            aclient.SubItems.Add(cl.ClientPostCode.ToString());
            aclient.SubItems.Add(cl.ClientPhone.ToString());
            aclient.SubItems.Add(cl.ClientFax.ToString());
            aclient.SubItems.Add("$"+cl.ClientCredit.ToString());
            if (cl.ClientStatus)
            {
                aclient.SubItems.Add("Active");
            }
            else
            {
                aclient.SubItems.Add("Inactive");
            }
            //=====calculate qt of orders to client======
            // 
            list.Items.Add(aclient);         
        }
    }
}




