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

namespace HiTechApp.GUI
{
    public partial class Show_Products : MetroFramework.Forms.MetroForm
    {
        public Show_Products(Author aauthor)
        {
            InitializeComponent();

            foreach (Book item in HiTechForm.bookList)
            {
                if (item.Author.ID == aauthor.ID)
                {
                    AppOperatorDA.listBook(metroListViewProd, item);
                }
                
            }
            foreach (Software item in HiTechForm.softwareList)
            {

                if (item.Author.ID == aauthor.ID)
                {
                    AppOperatorDA.listSoft(metroListViewProd, item);
                }
            
            }
        }
        public Show_Products(Publisher apublisher)
        {
            InitializeComponent();              
            foreach (Book item in HiTechForm.bookList)
            {
                if (item.Publisher.PubId.Equals(apublisher.PubId))
                {
                    AppOperatorDA.listBook(metroListViewProd, item);
                }

            }
            foreach (Software item in HiTechForm.softwareList)
            {

                if (item.Publisher.PubId.Equals(apublisher.PubId))
                {
                    AppOperatorDA.listSoft(metroListViewProd, item);
                }

            }
        }            
        private void metroListViewProd_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = metroListViewProd.SelectedItems[0];
            long selectedID = Convert.ToInt64(item.SubItems[0].Text);
            Product aprod = new Product();
            if (HiTechForm.bookList.Find(t => t.ID.Equals(selectedID)) == null)
            {
                aprod = HiTechForm.softwareList.Find(t => t.ID.Equals(selectedID));
             
            }
            else
            {
                aprod = HiTechForm.bookList.Find(t => t.ID.Equals(selectedID));
              
            }
          
            pictureBoxProd.ImageLocation = aprod.Photo;
            return;
        }
    }
}
