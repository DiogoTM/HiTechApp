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
     public interface IAppOperatorDA<T>
    {
     void Search(MetroListView listView, List<T> alist, MetroTextBox tSearch, MetroComboBox cSel, MetroComboBox cSearch);
     void ListObj(MetroListView list, T aobject);                                                                            

    }
}
