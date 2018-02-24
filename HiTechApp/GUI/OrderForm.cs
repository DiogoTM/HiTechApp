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
    public partial class OrderForm : MetroFramework.Forms.MetroForm
    {
        //Inintialize Form according to selection
        public OrderForm(Order aorder)
        {
            InitializeComponent();
            fillCombo();
            //If is an order edition, displays order information
            if (aorder != null)
            {

                isEdit = true;                        
                currentOrder = aorder;               
                selClient = aorder.OrdClient;
                              
                metroDateTimeOrd.Text = aorder.OrdDate.ToString();
                metroDateTimeOrdShip.Text = aorder.ShipDate.ToString();
                metroComboBoxOrdType.Text = aorder.OrdType;
                metroComboBoxOrdCl.Text = aorder.OrdClient.ClientName;
                metroComboBoxOrdCl.Enabled = false;
                metroLabelTotalCost.Text = "Order Total Cost: $" + aorder.OrdCost.ToString();
                metroTextBoxOrdID.Text = aorder.OrdId;
                metroLabelClName.Text = aorder.OrdClient.ClientName;                                                         
                metroLabelClCredit.Text = "Credit Before Order: $" + (selClient.ClientCredit+aorder.OrdCost).ToString();
                pictureBoxOrdCl.ImageLocation = aorder.OrdClient.ClientLogo;

                foreach (var product in aorder.OrdItems)
                {                    
                    ListViewItem item = new ListViewItem(product.OrdItId.ToString());
                    item.SubItems.Add(product.OrdProd.ID.ToString());
                    if (product.OrdProd.GetType() == typeof(Book))
                    {
                        item.SubItems.Add("Book");
                    }
                    if (product.OrdProd.GetType() == typeof(Software))
                    {
                        item.SubItems.Add("Software");
                    }
                    item.SubItems.Add(product.OrdProd.Title.ToString());
                    item.SubItems.Add((product.OrdProd.Author.FirstName + product.OrdProd.Author.LastName).ToString());
                    item.SubItems.Add(product.OrdItQt.ToString());
                    item.SubItems.Add(product.OrdProd.UnitPrice.ToString());
                    item.SubItems.Add((product.OrdProd.UnitPrice * product.OrdItQt).ToString());
                    metroListViewOrder.Items.Add(item);
                    orderItemsList.Add(product);
                }
            }
        }
        //Create objects client and order to be used in case of a edit
        Client selClient = new Client();
        Order currentOrder = new Order();
        bool isEdit = false;                   
        //Create list for products
        List<OrdItem> orderItemsList = new List<OrdItem>();

        //Fill Comboboxes                                 
        private void fillCombo()
        {
            AppOperatorDA.comboFillClient(metroComboBoxOrdCl, HiTechForm.clientList);
        }
        //Create object Order                           
        public Order createOrd()
        {
            MetroComboBox[] comboBoxes = { metroComboBoxOrdCl, metroComboBoxOrdType };
            if (!(Validator.isNotnull(comboBoxes) && (orderItemsList != null)))
            {
                return null;
            }
            Order aorder = new Order();
            Client aclient = HiTechForm.clientList.Find(t => t.ClientName.Equals(metroComboBoxOrdCl.Text));
            User auser = HiTechForm.loggeduser;
            aorder.OrdId = metroTextBoxOrdID.Text;
            aorder.OrdClient = aclient;
            aorder.OrdCost = calculateTotal();
            aorder.OrdDate = Convert.ToDateTime(metroDateTimeOrd.Text);
            aorder.ShipDate = Convert.ToDateTime(metroDateTimeOrdShip.Text);
            aorder.OrdType = metroComboBoxOrdType.Text;
            aorder.OrdItems = orderItemsList;
            aorder.OrdUser = auser;
            return aorder;
        }                               

        //Create object order item
        private OrdItem createOrdItem()
        {
            MetroTextBox[] textBoxes = { metroTextBoxOrdQt };
            MetroComboBox[] comboBoxes = { metroComboBoxOrdProd };
            MetroTextBox[] textboxInt = { metroTextBoxOrdQt };
            if (!(Validator.isNotnull(textBoxes) && Validator.isNotnull(comboBoxes)&& Validator.isNumberInt(textboxInt)))
            {
                return null;
            }
            OrdItem aitem = new OrdItem();
            aitem.OrdItId = OperatorDA.uniqueID(orderItemsList, metroComboBoxOrdProd.Text, metroComboBoxOrdProd.Text);  
            if (metroComboBoxOrdProdType.SelectedIndex.Equals(0))
            {
                aitem.OrdProd = HiTechForm.bookList.Find(t => t.Title.Equals(metroComboBoxOrdProd.Text));
            }
            if (metroComboBoxOrdProdType.SelectedIndex.Equals(1))
            {
                aitem.OrdProd = HiTechForm.softwareList.Find(t => t.Title.Equals(metroComboBoxOrdProd.Text));
            }
            aitem.OrdItQt = Convert.ToInt32(metroTextBoxOrdQt.Text);
            return aitem;
        }          
        //List items
        private void listOrderItems()
        {
            metroListViewOrder.Items.Clear();
            foreach (var product in orderItemsList)
            {
                ListViewItem item = new ListViewItem(product.OrdItId.ToString());
                item.SubItems.Add(product.OrdProd.ID.ToString());
                if (product.OrdProd.GetType() == typeof(Book))
                {
                    item.SubItems.Add("Book");
                }
                if (product.OrdProd.GetType() == typeof(Software))
                {
                    item.SubItems.Add("Software");
                }
                item.SubItems.Add(product.OrdProd.Title.ToString());
                item.SubItems.Add((product.OrdProd.Author.FirstName + product.OrdProd.Author.LastName).ToString());
                item.SubItems.Add(product.OrdItQt.ToString());
                item.SubItems.Add(product.OrdProd.UnitPrice.ToString());
                item.SubItems.Add((product.OrdProd.UnitPrice * product.OrdItQt).ToString());      
                metroListViewOrder.Items.Add(item);
                metroLabelTotalCost.Text = "Order Total Cost:" + calculateTotal().ToString();
            }
        }
        //Calculates the order total
        private decimal calculateTotal()
        {
          return orderItemsList.Sum(t => t.OrdItQt * t.OrdProd.UnitPrice);
        }               
        //Changes the product combobox selection according to type (soft or book)
        private void metroComboBoxOrdProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBoxOrdProdType.SelectedIndex)
            {
                case 0:
                    AppOperatorDA.comboFillBook(metroComboBoxOrdProd, HiTechForm.bookList);
                    return;
                case 1:

                    AppOperatorDA.comboFillSoft(metroComboBoxOrdProd, HiTechForm.softwareList);
                    return;
            }
        }
        //Fills client combobox with valid clients names
        private void metroComboBoxOrdCl_DropDown(object sender, EventArgs e)
        {
            AppOperatorDA.comboFillClient(metroComboBoxOrdCl, HiTechForm.clientList);
        }
        //Fill texts with info about product selected
        private void metroComboBoxOrdProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBoxOrdProdType.SelectedIndex)
            {
                case 0:
                    Book abook = HiTechForm.bookList.Find(t => t.Title.Equals(metroComboBoxOrdProd.Text));
                    metroLabelProdTitle.Text ="Selected Product: " + (abook.Title).ToString() + ", by " + (abook.Author.FirstName + abook.Author.LastName).ToString() + ".";
                    metroLabelProdCosts.Text = "Unitary Cost: " + abook.UnitPrice.ToString();                            
                    return;
                case 1:
                    Software asoft = HiTechForm.softwareList.Find(t => t.Title.Equals(metroComboBoxOrdProd.Text));
                    metroLabelProdTitle.Text = "Selected Product: " + (asoft.Title).ToString() + ", by " + (asoft.Author.FirstName + asoft.Author.LastName).ToString() + ".";
                    metroLabelProdCosts.Text = "Unitary Cost: " + asoft.UnitPrice.ToString();
                    return;                         
            }                               
        }                      
        //Add item
        private void metroTileOrdAdd_Click(object sender, EventArgs e)
        {

            MetroTextBox[] textBoxes = { metroTextBoxOrdQt };
            MetroComboBox[] comboBoxes = { metroComboBoxOrdProd };
            if (!(Validator.isNotnull(textBoxes) && Validator.isNotnull(comboBoxes) && Validator.isNumberInt(textBoxes)))
            {
                return ;
            }
            metroListViewOrder.Items.Clear();
            orderItemsList.Add(createOrdItem());
            listOrderItems();
            metroLabelTotalCost.Text = "Order Total Cost:" + calculateTotal().ToString();  
                         
        }                    
        //Remove item
        private void metroTileOrdRem_Click(object sender, EventArgs e)
        {

            if (metroListViewOrder.SelectedItems.Count>0)
            {
                ListViewItem item = metroListViewOrder.SelectedItems[0];
                OrdItem updateOrd = orderItemsList.Find(t => t.OrdItId.Equals(item.SubItems[0].Text));
                int ordItIndex = orderItemsList.FindIndex(t => t.OrdItId.Equals(updateOrd.OrdItId));
                if (orderItemsList.Find(t => t.OrdItId.Equals(updateOrd.OrdItId)) != null)
                {
                    DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to delete this item?", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (ans == DialogResult.Yes)

                    {
                        metroListViewOrder.Items.Clear();
                        orderItemsList.RemoveAt(ordItIndex);
                        listOrderItems();
                        metroLabelTotalCost.Text = "Order Total Cost:" + calculateTotal().ToString();
                    }
                    return;
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Please select an item to remove.", "Item not selected!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
        //Save order
        private void metroTileOrdSav_Click(object sender, EventArgs e)
        {
            Order aOrder = createOrd();
            if (aOrder == null)
            {
                return;
            }
            //If is an edition, edit current order
            if (isEdit)
            {
                int ordIndex = HiTechForm.ordList.FindIndex(t => t.OrdId.Equals(currentOrder.OrdId));
                if (aOrder.OrdCost <= aOrder.OrdClient.ClientCredit)
                {
                    
                    HiTechForm.ordList[ordIndex] = aOrder;
                    OperatorDA.SaveList<Order>(HiTechForm.ordList, filePaths.orderPath);
                    //Update client's credit                                                                           
                    int clIndex = HiTechForm.clientList.FindIndex(t => t.ClientId.Equals(selClient.ClientId));
                    if (HiTechForm.clientList.Find(t => t.ClientId.Equals(selClient.ClientId)) != null)
                    {
                        HiTechForm.clientList[clIndex].ClientCredit = HiTechForm.clientList[clIndex].ClientCredit+currentOrder.OrdCost - aOrder.OrdCost;
                        OperatorDA.SaveList<Client>(HiTechForm.clientList, filePaths.clientPath);
                    }
                    this.Close();
                }
            }
            //If is a new order, save 
            else
            {
                aOrder.OrdId = OperatorDA.uniqueID(HiTechForm.ordList, metroComboBoxOrdCl.Text, metroDateTimeOrd.Text);
                if (aOrder.OrdCost <= aOrder.OrdClient.ClientCredit)
                {
                    HiTechForm.ordList.Add(aOrder);
                    OperatorDA.SaveList<Order>(HiTechForm.ordList, filePaths.orderPath);             
                    //Update client's credit
                    Client updateCl = HiTechForm.clientList.Find(t => t.ClientName.Equals(metroComboBoxOrdCl.Text));
                    int clIndex = HiTechForm.clientList.FindIndex(t => t.ClientId.Equals(updateCl.ClientId));
                    if (HiTechForm.clientList.Find(t => t.ClientId.Equals(updateCl.ClientId)) != null)
                    {
                        HiTechForm.clientList[clIndex].ClientCredit = updateCl.ClientCredit - aOrder.OrdCost;
                        OperatorDA.SaveList<Client>(HiTechForm.clientList, filePaths.clientPath);
                    }

                    this.Close();
                }
            }

        }         
        //List     
        private void metroTileOrdList_Click(object sender, EventArgs e)
        {
            listOrderItems();
        }             
        //Exit
        private void metroTileOrdExit_Click(object sender, EventArgs e)
        {
            //Exit Message and confirmation
            if (MetroMessageBox.Show(this, "Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }                
        //Fills information about client selected
        private void metroComboBoxOrdCl_SelectedIndexChanged(object sender, EventArgs e)
        {
            selClient = HiTechForm.clientList.Find(t => t.ClientName.Equals(metroComboBoxOrdCl.Text));
            metroLabelClName.Text = selClient.ClientName;
            metroLabelClCredit.Text = "Client's Credit: $"+ selClient.ClientCredit.ToString();
            pictureBoxOrdCl.ImageLocation = selClient.ClientLogo.ToString();                               
        }         

    }
}