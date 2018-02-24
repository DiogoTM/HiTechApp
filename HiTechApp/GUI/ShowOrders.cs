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
    public partial class ShowOrders : MetroFramework.Forms.MetroForm

    {
        public ShowOrders(Client aclient)
        {
            InitializeComponent();
            foreach (Order item in HiTechForm.ordList)
            {
                if (item.OrdClient.ClientId.Equals(aclient.ClientId))
                {
                    AppOperatorDA.listOrd(metroListViewOrdList, item);
                }

            }


        }
                                    
    }
}
