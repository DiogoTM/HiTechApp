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
    public class AppOperatorDA
    {
        //List objects in list
        public static void listBook(MetroListView list, Book abook)
        {
            ListViewItem aitem = new ListViewItem(abook.ID.ToString());
            aitem.SubItems.Add(abook.Title.ToString());         
            aitem.SubItems.Add(abook.Date.ToShortDateString());
            aitem.SubItems.Add(abook.Category.CName.ToString());             
            aitem.SubItems.Add(abook.Publisher.PubName.ToString());
            aitem.SubItems.Add(abook.Author.FirstName.ToString() + abook.Author.LastName.ToString());
            aitem.SubItems.Add("$"+abook.UnitPrice.ToString());
            aitem.SubItems.Add(abook.QOH.ToString());
            list.Items.Add(aitem);                        
        }
        public static void listSoft(MetroListView list, Software asoft)
        {
            ListViewItem aitem = new ListViewItem(asoft.ID.ToString());
            aitem.SubItems.Add(asoft.Title.ToString());
            aitem.SubItems.Add(asoft.Date.ToShortDateString());
            aitem.SubItems.Add(asoft.Category.CName.ToString());
            aitem.SubItems.Add(asoft.Publisher.PubName.ToString());
            aitem.SubItems.Add(asoft.Author.FirstName.ToString() + asoft.Author.LastName.ToString());
            aitem.SubItems.Add("$"+asoft.UnitPrice.ToString());
            aitem.SubItems.Add(asoft.QOH.ToString());
            list.Items.Add(aitem);
        }         
        public static void listOrd(MetroListView list, Order aord)
        {
            ListViewItem aitem = new ListViewItem(aord.OrdId.ToString());
            aitem.SubItems.Add(aord.OrdClient.ClientName.ToString());
            aitem.SubItems.Add(aord.OrdDate.ToShortDateString());
            aitem.SubItems.Add(aord.ShipDate.ToShortDateString());
            aitem.SubItems.Add("$"+aord.OrdCost.ToString());
            aitem.SubItems.Add(aord.OrdType.ToString());
            aitem.SubItems.Add(aord.OrdUser.Employee.ID.ToString());
       
            list.Items.Add(aitem);
        }

        //Fill ComboBoxes based on objects in list

        public static void comboFillAuthor(MetroComboBox cbox, List<Author> list)
        {
            cbox.Items.Clear();
            foreach (Author item in list)
            {
                cbox.Items.Add(item.FirstName + item.LastName);
            }                                                
        }
        public static void comboFillPublisher(MetroComboBox cbox, List<Publisher> list)
        {
            cbox.Items.Clear();
            foreach (Publisher item in list)
            {
                cbox.Items.Add(item.PubName);
            }
        }
        public static void comboFillCategory(MetroComboBox cbox, List<Category> list)
        {
            cbox.Items.Clear();
            foreach (Category item in list)
            {
                cbox.Items.Add(item.CName);
            }
        }
        public static void comboFillClient(MetroComboBox cbox, List<Client> list)
        {
            cbox.Items.Clear();
            foreach (Client item in list)
            {
                if (item.ClientStatus)
                {
                    cbox.Items.Add(item.ClientName);
                }                             
            }
        }                                                         
        public static void comboFillBook(MetroComboBox cbox, List<Book> list)
        {
            cbox.Items.Clear();
            foreach (Book item in list)
            {
                if (item.QOH>0)
                {
                    cbox.Items.Add(item.Title);
                }
             
            }
        }
        public static void comboFillSoft(MetroComboBox cbox, List<Software> list)
        {
            cbox.Items.Clear();
            foreach (Software item in list)
            {
                if (item.QOH > 0)
                {
                    cbox.Items.Add(item.Title);
                }
            }
        }
    

    }
}
