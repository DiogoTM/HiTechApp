using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HiTechApp.BLL
{
    public class filePaths
    {
        public static string authorPath = Application.StartupPath.ToString() + @"\Data\Author.ser";
        public static string clientPath = Application.StartupPath.ToString() + @"\Data\Client.ser";
        public static string empPath = Application.StartupPath.ToString() + @"\Data\Employees.ser";
        public static string userPath = Application.StartupPath.ToString() + @"\Data\User.ser";
        public static string orderPath = Application.StartupPath.ToString() + @"\Data\Order.ser";
        public static string bookPath = Application.StartupPath.ToString() + @"\Data\Book.ser";
        public static string softwarePath = Application.StartupPath.ToString() + @"\Data\Software.ser";
        public static string publisherPath = Application.StartupPath.ToString() + @"\Data\Publisher.ser";             
        public static string categoryPath = Application.StartupPath.ToString() + @"\Data\Category.ser";                                            
    }
}
