using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HiTechApp.BLL;
using HiTechApp.DAL;
using HiTechAppLibrary.BLL;
using HiTechAppLibrary.DAL;
using HiTechAppLibrary.Validation;
using MetroFramework;
using MetroFramework.Controls;



namespace HiTechApp.GUI
{
    public partial class HiTechForm : MetroFramework.Forms.MetroForm
    {
        public HiTechForm(User auser)
        {
            InitializeComponent();

            //Fill necessary comboboxes
            fillCombo();
            //Set object loggeduser as the user entered in the login form
            loggeduser = auser;

            //Disable all tabs
            metroTabControl.DisableTab(metroTabPageMIS);
            metroTabControl.DisableTab(metroTabPageSales);
            metroTabControl.DisableTab(metroTabPageInventory);
            metroTabControl.DisableTab(metroTabPageOrders);

            //Enable only tab available to current user
            switch (auser.AccessLevel)
            {
                case 0:
                    metroTabControl.EnableTab(metroTabPageMIS);
                    metroTabControl.SelectTab(metroTabPageMIS);
                    return;
                case 1:
                    metroTabControl.EnableTab(metroTabPageSales);
                    metroTabControl.SelectTab(metroTabPageSales);
                    return;
                case 2:
                    metroTabControl.EnableTab(metroTabPageInventory);
                    metroTabControl.SelectTab(metroTabPageInventory);
                    return;
                case 3:
                    metroTabControl.EnableTab(metroTabPageOrders);
                    metroTabControl.SelectTab(metroTabPageOrders);
                    return;
            }
        }


        //Create object loggeduser, information to be retrieved in several parts of the program

        public static User loggeduser;                      
           

        //Fill Comboxes based on data stored
        private void fillCombo()
        {
            AppOperatorDA.comboFillAuthor(metroComboBoxProdAuth, authorList);
            AppOperatorDA.comboFillPublisher(metroComboBoxProdPub, publisherList);
            AppOperatorDA.comboFillCategory(metroComboBoxProdCat, categoryList);         
        }

        //Generate lists based on information saved on file

        public static List<Employee> employeeList = OperatorDA.List<Employee>(filePaths.empPath);
        public static List<User> userList = OperatorDA.List<User>(filePaths.userPath);
        public static List<Author> authorList = OperatorDA.List<Author>(filePaths.authorPath);
        public static List<Book> bookList = OperatorDA.List<Book>(filePaths.bookPath);
        public static List<Software> softwareList = OperatorDA.List<Software>(filePaths.softwarePath);
        public static List<Client> clientList = OperatorDA.List<Client>(filePaths.clientPath);
        public static List<Publisher> publisherList = OperatorDA.List<Publisher>(filePaths.publisherPath);
        public static List<Category> categoryList = OperatorDA.List<Category>(filePaths.categoryPath);
        public static List<Order> ordList = OperatorDA.List<Order>(filePaths.orderPath);

        //General Tiles
        private void metroTileChgUser_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
            
        }                
        private void metroTileEditPsw_Click(object sender, EventArgs e)
        {
            ChangePswd changeApp = new ChangePswd();
            changeApp.ShowDialog();           
        }               
        private void metroTileExit_Click(object sender, EventArgs e)
        {
            //Exit Message and confirmation
            if (MetroMessageBox.Show(this, "Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }                
        private void metroTileInfo_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, " Hi-Tech Distribution Inc. (Virtual) \n 7122 18th Montreal, Quebec \n H2A2M8 \n Tel: (514) 721 - 8662 \n Fax: (514) 777 - 8665", "Company's Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //MIS Manager TAB
        //===============================================================================================         

        //Creates a employee object based on information provided
        private Employee createEmp()
        {
        

            //Validate information from boxes (not null, only letters for names, etc

            MetroTextBox[] textBoxes = {metroTextBoxFname, metroTextBoxLname , metroTextBoxEmail,metroTextBoxPhone , metroTextBoxWorkH };
            MetroTextBox[] names = { metroTextBoxFname, metroTextBoxLname };
            MetroComboBox[] comboBoxes = { metroComboBoxPos };
            if (!(Validator.isNotnull(textBoxes) && Validator.isNotnull(comboBoxes) && Validator.isValidName(names)))
            {                                          
                return null; 
            }
            //Store inforation in created object employee
            Employee aemp = new Employee();
            aemp.ID = metroTextBoxID.Text;
            aemp.FirstName = metroTextBoxFname.Text;
            aemp.LastName = metroTextBoxLname.Text;
            aemp.Phone = metroTextBoxPhone.Text;
            aemp.Position = metroComboBoxPos.Text;
            aemp.Email = metroTextBoxEmail.Text;
            aemp.Status = metroCheckBoxActiveEmp.Checked;
            aemp.WorkHours = metroTextBoxWorkH.Text;
            aemp.Photo = pictureBoxEmp.Tag.ToString();
            return aemp;

        }                
        //Creates oject empDA to perform search and list functions
        EmpDA empOp = new EmpDA();

        //Creates a user object based on information given
        private User createUser(Employee aemp)
        {
            //Validation
            MetroTextBox[] textBoxes = { metroTextBoxPswd };            
            MetroComboBox[] comboBoxes = { metroComboBoxPos };
            if (!(Validator.isNotnull(textBoxes) && Validator.isNotnull(comboBoxes)))
            {
                return null;
            }

            //User object creation
            User auser = new User();                              
            auser.Employee = aemp; 
            auser.Password = metroTextBoxPswd.Text;
            auser.AccessLevel = metroComboBoxPos.SelectedIndex;
            return auser;
        }

        //Calls method to insert picture
        private void pictureBoxEmp_Click(object sender, EventArgs e)
        {
            OperatorDA.addPhoto(pictureBoxEmp);
        }              
        //Add
        private void metroTileEmpAdd_Click(object sender, EventArgs e)
        {
            
            metroListViewEmp.Items.Clear();
            Employee aEmp = createEmp();
            if (aEmp == null)
            {
                return;
            }
           
            aEmp.ID = OperatorDA.uniqueID<Employee>(employeeList, aEmp.FirstName, aEmp.LastName);
            employeeList.Add(aEmp);                                            
            OperatorDA.SaveList(employeeList, filePaths.empPath);

            // If position selected is user:

            if (metroComboBoxPos.SelectedIndex <= 3)
            {
                User auser = createUser(aEmp);
                userList.Add(auser);
                OperatorDA.SaveList(userList, filePaths.userPath);
            }
           
            foreach (Employee item in employeeList)
            {
               empOp.ListObj(metroListViewEmp, item);
            }                                                     
          
        }                                        
        //Remove
        private void metroTileEmpRem_Click(object sender, EventArgs e)
        {
            Employee updateEmp = createEmp();
            //User updateUser = createUser(updateEmp);
            int empIndex = employeeList.FindIndex(t => t.ID.Equals(updateEmp.ID));
            //int userIndex = userList.FindIndex(t => t.Employee.ID.Equals(updateEmp.ID));

            if (employeeList.Find(t => t.ID.Equals(updateEmp.ID)) != null)
            {
                DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to deactivate this employee?", "Deactivation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)

                {
                    employeeList[empIndex].Status = false;
                    //employeeList.RemoveAt(empIndex);
                    //metroListViewEmp.Items.Clear();
                    OperatorDA.SaveList(employeeList, filePaths.empPath);
                    

                    //if (userList.Find(t => t.Employee.ID.Equals(updateEmp.ID)) != null)
                    //{
                    //    userList.RemoveAt(userIndex);
                    //    OperatorDA.SaveList<User>(userList, filePaths.userPath);
                    //}
                }                        
            }
            metroListViewEmp.Items.Clear();
            foreach (Employee item in employeeList)
            {                          
                empOp.ListObj(metroListViewEmp, item);
            }
            return;
        }                                           
        //Update
        private void metroTileEmpUp_Click(object sender, EventArgs e)
        {
            metroListViewEmp.Items.Clear();
            Employee updateEmp = createEmp();
            User updateUser = createUser(updateEmp);                 
            int empIndex = employeeList.FindIndex(t => t.ID.Equals(updateEmp.ID));
            int userIndex = userList.FindIndex(t => t.Employee.ID.Equals(updateEmp.ID));
            if (employeeList.Find(t => t.ID.Equals(updateEmp.ID)) != null)
            {
                DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to update this employee information?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    employeeList[empIndex] = updateEmp;
                    if (userList.Find(t => t.Employee.ID.Equals(updateEmp.ID)) != null)
                    {
                        userList[userIndex] = updateUser;
                        OperatorDA.SaveList(userList, filePaths.userPath);
                    }
                    OperatorDA.SaveList(employeeList, filePaths.empPath);
                    empOp.ListObj(metroListViewEmp, employeeList[empIndex]);
                }
                return;
            }
        }                                                     
        //Search
        private void metroTileEmpSearch_Click(object sender, EventArgs e)
        {
            
            empOp.Search(metroListViewEmp, employeeList, metroTextBoxSearchEmp, metroComboBoxSearchBy, metroComboBoxSearchPos);                       
            
        }
        //List
        private void metroTileEmpList_Click(object sender, EventArgs e)
        {
            metroListViewEmp.Items.Clear();
            foreach (Employee item in OperatorDA.List<Employee>(filePaths.empPath))
            {                   
                empOp.ListObj(metroListViewEmp, item);
            }

        }
        //Change password field depending on position selection                           
        private void metroComboBoxPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBoxPos.SelectedIndex < 4)
            {
                metroTextBoxPswd.Visible = true;
                metroLabelPwsd.Visible = true;
            }
            else
            {
                metroTextBoxPswd.Visible = false;
                metroLabelPwsd.Visible = false;
            }

        }                     
        //Shows combobox or textbox as search option
        private void metroComboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBoxSearchBy.SelectedIndex == 3)
            {
                metroComboBoxSearchPos.Visible = true;
                return;
            }
            if (metroComboBoxSearchBy.SelectedIndex >= 5)
            {
                metroTextBoxSearchEmp.Enabled = false;
                return;
            }
            metroComboBoxSearchPos.Visible = false;
            metroTextBoxSearchEmp.Enabled = true;

        }         
        //Fill fields according to object selected in the listview                                      
        private void metroListViewEmp_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = metroListViewEmp.SelectedItems[0];
            string selectedID = item.SubItems[0].Text;
            Employee aemp = employeeList.Find(t => t.ID.Equals(selectedID));
                    
            metroTextBoxID.Text = aemp.ID.ToString();
            metroTextBoxFname.Text = aemp.FirstName.ToString();
            metroTextBoxLname.Text = aemp.LastName.ToString(); 
            metroTextBoxEmail.Text = aemp.Email.ToString();
            metroTextBoxPhone.Text = aemp.Phone.ToString();
            metroComboBoxPos.Text = aemp.Position.ToString();   
            if (aemp.Status)
            {
                metroCheckBoxActiveEmp.Checked = true;
            }
            else
            {
                metroCheckBoxActiveEmp.Checked = false;
            }
            metroTextBoxWorkH.Text = aemp.WorkHours.ToString();                   
            pictureBoxEmp.ImageLocation = aemp.Photo;
            pictureBoxEmp.Tag = aemp.Photo;
            User auser = userList.Find(t => t.Employee.ID.Equals(aemp.ID));
            if (auser != null)
            {
                metroTextBoxPswd.Visible = true;
                metroTextBoxPswd.Text = auser.Password.ToString();
            }
            else
            {
                metroTextBoxPswd.Visible = false;
            }                                 

            return;

        }

        //Sales Manager TAB
        //===============================================================================================         


        //Create a Client object based on information given
        private Client createCl()
        {
            Client acl = new Client();
            MetroTextBox[] textBoxDec = { metroTextBoxClCredit };
            MetroTextBox[] textBoxes = { metroTextBoxClName, metroTextBoxClEmail, metroTextBoxClEmail, metroTextBoxClStreet, metroTextBoxClCity, metroTextBoxClPost , metroTextBoxClPhone , metroTextBoxClFax , metroTextBoxClCredit ,};
            if (!(Validator.isNotnull(textBoxes) && Validator.isNumberDecimal(textBoxDec)))
            {           
                return null;
            }             
            acl.ClientId =  metroTextBoxClid.Text;
            acl.ClientName = metroTextBoxClName.Text;
            acl.ClientEmail = metroTextBoxClEmail.Text;
            acl.ClientStreet = metroTextBoxClStreet.Text;
            acl.ClientCity = metroTextBoxClCity.Text;
            acl.ClientPostCode = metroTextBoxClPost.Text;
            acl.ClientPhone = metroTextBoxClPhone.Text;
            acl.ClientFax = metroTextBoxClFax.Text;
            acl.ClientCredit = Convert.ToDecimal(metroTextBoxClCredit.Text);
            acl.ClientStatus = metroCheckBoxClientActive.Checked;
            acl.ClientLogo = pictureBoxClient.Tag.ToString();
            return acl;
        }
        //Creates clientDA object to perform search an list methods
        ClientDA clientOp = new ClientDA();
        //Calls method to insert picture
        private void pictureBoxClient_Click(object sender, EventArgs e)
        {
            OperatorDA.addPhoto(pictureBoxClient);
        }               
        //Add
        private void metroTileClAdd_Click(object sender, EventArgs e)
        {
            metroListViewCl.Items.Clear();
            Client aclient = createCl();
            if (aclient == null)
            {
                return;
            }
            aclient.ClientId = OperatorDA.uniqueID(clientList, metroTextBoxClName.Text, metroTextBoxClName.Text);
            clientList.Add(aclient);
            foreach (Client item in clientList)
            {
                clientOp.ListObj(metroListViewCl, item);
            }
            OperatorDA.SaveList<Client>(clientList, filePaths.clientPath);
        }                 
        //Remove
        private void metroTileClRem_Click(object sender, EventArgs e)
        {
            Client updateCl = createCl();
            int clIndex = clientList.FindIndex(t => t.ClientId.Equals(updateCl.ClientId));
            if (clientList.Find(t => t.ClientId.Equals(updateCl.ClientId)) != null)
            {
                DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to deactivate this client?", "Deactivation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    metroListViewCl.Items.Clear();
                    clientList[clIndex].ClientStatus = false;
                    //clientList.RemoveAt(clIndex);
                    clientOp.ListObj(metroListViewCl, updateCl);
                    OperatorDA.SaveList<Client>(clientList, filePaths.clientPath);
                }
            }
            return;
        }               
        //Update
        private void metroTileClUp_Click(object sender, EventArgs e)
        {
            metroListViewCl.Items.Clear();
            Client updateCl = createCl();
            int clIndex = clientList.FindIndex(t => t.ClientId.Equals(updateCl.ClientId));
            if (clientList.Find(t => t.ClientId.Equals(updateCl.ClientId)) != null)
            {
                DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to update this client?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    clientList[clIndex] = updateCl;
                    clientOp.ListObj(metroListViewCl, updateCl);
                    OperatorDA.SaveList<Client>(clientList, filePaths.clientPath);
                }
            }
            return;
        }                  
        //List
        private void metroTileClList_Click(object sender, EventArgs e)
        {
            metroListViewCl.Items.Clear();
           foreach (Client item in clientList)
            {
                clientOp.ListObj(metroListViewCl, item);
            }
        }               
        //Search
        private void metroTileClSearch_Click(object sender, EventArgs e)
        {                     
            clientOp.Search(metroListViewCl, clientList, metroTextBoxClSearch, metroComboBoxClSearch, null);
        }
        //Show client's orders                                                  
        private void metroTileClOrd_Click(object sender, EventArgs e)
        {
            if (metroListViewCl.SelectedItems.Count >0)
            {

                ShowOrders orderList = new ShowOrders(createCl());
                orderList.Show();
           
            }
            else
            {
                MetroMessageBox.Show(ActiveForm, "Please select a client.", "Client not selected!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }                
        //Change search option(combobox or textbox) based on selection
        private void metroComboBoxClSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBoxClSearch.SelectedIndex >= 2)
            {
                metroTextBoxClSearch.Enabled = false;
            }
            metroTextBoxClSearch.Enabled = true;
        }              
        //Fill textboxes and comboboxes with information from client selected in the listview
        private void metroListViewCl_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = metroListViewCl.SelectedItems[0];
            string selectedID = item.SubItems[0].Text;     
            Client aclient = clientList.Find(t => t.ClientId.Equals(selectedID));
            metroTextBoxClid.Text = aclient.ClientId.ToString();
            metroTextBoxClName.Text = aclient.ClientName.ToString();
            metroTextBoxClStreet.Text = aclient.ClientStreet.ToString();
            metroTextBoxClCity.Text = aclient.ClientCity.ToString();
            metroTextBoxClPost.Text = aclient.ClientPostCode.ToString();
            metroTextBoxClPhone.Text = aclient.ClientPhone.ToString();
            metroTextBoxClFax.Text = aclient.ClientFax.ToString();
            metroTextBoxClCredit.Text = aclient.ClientCredit.ToString();
            metroTextBoxClEmail.Text = aclient.ClientEmail.ToString();
            if (aclient.ClientStatus)
            {
                metroCheckBoxClientActive.Checked = true;
            }
            pictureBoxClient.ImageLocation = aclient.ClientLogo;
            pictureBoxClient.Tag = aclient.ClientLogo;
            return;
            
        }

        //Inventory Controller TAB
        //===============================================================================================         

        //Creates object Book
        private Book createBook()
        {
            MetroTextBox[] textBoxes = { metroTextBoxProdID , metroTextBoxProdTitle , metroTextBoxProdPrice, metroTextBoxProdQOH };
            MetroTextBox[] textBoxDec = { metroTextBoxProdPrice };
            MetroTextBox[] textBoxInt = { metroTextBoxProdQOH };
            MetroComboBox[] comboBoxes = { metroComboBoxProdPub, metroComboBoxProdAuth, metroComboBoxProdCat, };
            if (!(Validator.isNotnull(textBoxes) && Validator.isNotnull(comboBoxes)
                && Validator.isNumberDecimal(textBoxDec) && Validator.isNumberInt(textBoxInt)
                && Validator.isUniqueLongID(metroTextBoxProdID.Text, bookList)&& Validator.isValidID(metroTextBoxProdID,13)))
            {
                return null;
            }
            Book abook = new Book();
            Publisher apub = publisherList.Find(t => t.PubName.Equals(metroComboBoxProdPub.Text));
            Author aauthor = authorList.Find(t => (t.FirstName + t.LastName).Equals((metroComboBoxProdAuth.Text)));        
            abook.ID = Convert.ToInt64(metroTextBoxProdID.Text);
            abook.Title = metroTextBoxProdTitle.Text;
            abook.Author = aauthor;
            abook.Category = categoryList.Find(t => t.CName.Equals(metroComboBoxProdCat.Text));
            abook.Date = Convert.ToDateTime(metroDateTimeProd.Text);
            abook.Publisher = apub;
            abook.UnitPrice = Convert.ToDecimal(metroTextBoxProdPrice.Text);
            abook.QOH = Convert.ToInt32(metroTextBoxProdQOH.Text);
            abook.Photo = pictureBoxProd.Tag.ToString();
            return abook;
        }                                         
        //Creates object Software
        private Software createSoft()
        {
            MetroTextBox[] textBoxes = { metroTextBoxProdID, metroTextBoxProdTitle, metroTextBoxProdPrice, metroTextBoxProdQOH };
            MetroTextBox[] textBoxDec = { metroTextBoxProdPrice };
            MetroTextBox[] textBoxInt = { metroTextBoxProdQOH };
            MetroComboBox[] comboBoxes = { metroComboBoxProdPub, metroComboBoxProdAuth, metroComboBoxProdCat, };
            if (!(Validator.isNotnull(textBoxes) && Validator.isNotnull(comboBoxes)
                && Validator.isNumberDecimal(textBoxDec) && Validator.isNumberInt(textBoxInt)
                && Validator.isUniqueLongID(metroTextBoxProdID.Text, bookList) && Validator.isValidID(metroTextBoxProdID, 13)))
            {
                return null;
            }
            Software asoft = new Software();             
            Publisher apub = publisherList.Find(t => t.PubName.Equals(metroComboBoxProdPub.Text));
            Author aauthor = authorList.Find(t => (t.FirstName + t.LastName).Equals((metroComboBoxProdAuth.Text)));
            asoft.ID = Convert.ToInt32(metroTextBoxProdID.Text);
            asoft.Title = metroTextBoxProdTitle.Text;
            asoft.Author = authorList.Find(t => t.FirstName.Equals((metroComboBoxProdAuth.Text)));
            asoft.Category = categoryList.Find(t => t.CName.Equals(metroComboBoxProdCat.Text));
            asoft.Date = Convert.ToDateTime(metroDateTimeProd.Text);
            asoft.Publisher = publisherList.Find(t => t.PubName.Equals(metroComboBoxProdPub.Text));
            asoft.UnitPrice = Convert.ToDecimal(metroTextBoxProdPrice.Text);
            asoft.QOH = Convert.ToInt32(metroTextBoxProdQOH.Text);
            asoft.Photo = pictureBoxProd.Tag.ToString();
            return asoft;
        }              
        //Calls insert picture method
        private void pictureBoxProd_Click(object sender, EventArgs e)
        {
            OperatorDA.addPhoto(pictureBoxProd);
        }
        //Add                       
        private void metroTileProdAdd_Click(object sender, EventArgs e)
        {
            metroListViewProd.Items.Clear();

            switch (metroComboBoxProdType.SelectedIndex)
            {
                case -1:
                    MetroMessageBox.Show(this, "Please select a valid Product option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 0:
                    Book abook = createBook();
                    if (abook == null)
                    {
                        return;
                    }
                    bookList.Add(abook);
                    OperatorDA.SaveList<Book>(bookList, filePaths.bookPath);
                    foreach (Book item in bookList)
                    {
                        AppOperatorDA.listBook(metroListViewProd, item);
                    }

                    return;
                case 1:
                    Software asoft = createSoft();
                    if (asoft == null)
                    {
                        return;
                    }
                    softwareList.Add(asoft);
                    OperatorDA.SaveList<Software>(softwareList, filePaths.softwarePath);
                    foreach (Software item in softwareList)
                    {
                        AppOperatorDA.listSoft(metroListViewProd, item);
                    }
                    return;
            }
        }         
        //Remove
        private void metroTileProdRem_Click(object sender, EventArgs e)
        {
            metroListViewProd.Items.Clear();
            switch (metroComboBoxProdType.SelectedIndex)
            {
                case -1:
                    MetroMessageBox.Show(this, "Please select a valid search option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 0:
                    Book updateBook = createBook();
                    int bookIndex = bookList.FindIndex(t => t.ID.Equals(updateBook.ID));
                    if (bookList.Find(t => t.ID.Equals(updateBook.ID)) != null)
                    {
                        DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to delete this Book?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (ans == DialogResult.Yes)
                        {
                            bookList.RemoveAt(bookIndex);
                            OperatorDA.SaveList<Book>(bookList, filePaths.bookPath);
                            metroListViewProd.Items.Clear();
                        }
                    }
                    foreach (Book item in bookList)
                    {
                        AppOperatorDA.listBook(metroListViewProd, item);
                    }
                    return;
                case 1:
                    Software updateSoft = createSoft();
                    int softIndex = softwareList.FindIndex(t => t.ID.Equals(updateSoft.ID));
                    if (softwareList.Find(t => t.ID.Equals(updateSoft.ID)) != null)
                    {
                        DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to delete this Software?", "Deactivation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (ans == DialogResult.Yes)
                        {
                            bookList.RemoveAt(softIndex);
                            OperatorDA.SaveList<Software>(softwareList, filePaths.softwarePath);
                            metroListViewProd.Items.Clear();
                        }
                    }
                    foreach (Software item in softwareList)
                    {
                        AppOperatorDA.listSoft(metroListViewProd, item);
                    }
                    return;
            }
        }        
        //Update
        private void metroTileRemUp_Click(object sender, EventArgs e)
        {
            switch (metroComboBoxProdType.SelectedIndex)
            {
                case -1:
                    MetroMessageBox.Show(this, "Please select a valid search option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 0:
                    Book updateBook = createBook();
                    int bookIndex = bookList.FindIndex(t => t.ID.Equals(updateBook.ID));
                    if (bookList.Find(t => t.ID.Equals(updateBook.ID)) != null)
                    {
                        DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to upate this Book?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (ans == DialogResult.Yes)
                        {
                            bookList[bookIndex] = updateBook;
                            OperatorDA.SaveList<Book>(bookList, filePaths.bookPath);
                            metroListViewProd.Items.Clear();
                        }
                    }
                    foreach (Book item in bookList)
                    {
                        AppOperatorDA.listBook(metroListViewProd, item);
                    }
                    return;
                case 1:
                    Software updateSoft = createSoft();
                    int softIndex = softwareList.FindIndex(t => t.ID.Equals(updateSoft.ID));
                    if (softwareList.Find(t => t.ID.Equals(updateSoft.ID)) != null)
                    {
                        DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to upate this Software?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (ans == DialogResult.Yes)
                        {
                            softwareList[softIndex] = updateSoft;
                            OperatorDA.SaveList<Software>(softwareList, filePaths.softwarePath);
                            metroListViewProd.Items.Clear();
                        }
                    }
                    foreach (Software item in softwareList)
                    {
                        AppOperatorDA.listSoft(metroListViewProd, item);
                    }
                    return;
            }
        }         
        //List
        private void metroTileProdList_Click(object sender, EventArgs e)
        {
            metroListViewProd.Items.Clear();
            if (metroCheckBoxBk.Checked)
            {
                foreach (Book item in bookList)
                {
                    AppOperatorDA.listBook(metroListViewProd, item);
                }
            }
            if (metroCheckBoxSft.Checked)
            {
                foreach (Software item in softwareList)
                {
                    AppOperatorDA.listSoft(metroListViewProd, item);
                }
            }
            if (!metroCheckBoxSft.Checked && !metroCheckBoxBk.Checked)
            {
                MetroMessageBox.Show(this, "Please select an option below:", "Product type not selected!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return;
        }      
        //Add Category
        private void metroTileCatAdd_Click(object sender, EventArgs e)
        {
            if (metroComboBoxProdCat.Items.Contains(metroTextBoxProdAddCat.Text))
            {
                MetroMessageBox.Show(this, "Category already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Category item = new Category();
                item.CName = metroTextBoxProdAddCat.Text;
                categoryList.Add(item);
                OperatorDA.SaveList(categoryList, filePaths.categoryPath);
            }
            return;
        }       
        //Search
        private void metroTileProdSearch_Click(object sender, EventArgs e)
        {
            metroListViewProd.Items.Clear();
            switch (metroComboBoxProdSearch.SelectedIndex)
            {
                case -1:
                    MetroMessageBox.Show(this, "Please select a valid search option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 0:
                    var foundListBook = bookList.FindAll(t => t.ID.Equals(Convert.ToInt64(metroTextBoxProdSearch.ToString())));
                    foreach (Book item in foundListBook)
                    {
                        AppOperatorDA.listBook(metroListViewProd, item);
                    }
                    if (foundListBook.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Book not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                case 1:
                    //SoftID
                    var foundListSoft = softwareList.FindAll(t => t.ID.Equals(Convert.ToInt64(metroTextBoxProdSearch.ToString())));
                    foreach (Software item in foundListSoft)
                    {
                        AppOperatorDA.listSoft(metroListViewProd, item);
                    }
                    if (foundListSoft.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Book not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                case 2:
                    //book title
                    foundListBook = bookList.FindAll(t => t.Title.Contains(metroTextBoxProdSearch.ToString()));
                    foreach (Book item in foundListBook)
                    {
                        AppOperatorDA.listBook(metroListViewProd, item);
                    }
                    if (foundListBook.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Book not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                case 3:
                    //soft title
                    foundListSoft = softwareList.FindAll(t => t.Title.Equals(metroTextBoxProdSearch.ToString()));
                    foreach (Software item in foundListSoft)
                    {
                        AppOperatorDA.listSoft(metroListViewProd, item);
                    }
                    if (foundListSoft.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Book not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                case 4:
                    //author name
                    foundListBook = bookList.FindAll(t => t.Author.FirstName.Contains(metroTextBoxProdSearch.ToString()) && t.Author.LastName.Contains(metroTextBoxProdSearch.ToString()));
                    foreach (Book item in foundListBook)
                    {
                        AppOperatorDA.listBook(metroListViewProd, item);
                    }

                    foundListSoft = softwareList.FindAll(t => t.Author.FirstName.Contains(metroTextBoxProdSearch.ToString()) && t.Author.LastName.Contains(metroTextBoxProdSearch.ToString()));

                    foreach (Software item in foundListSoft)
                    {
                        AppOperatorDA.listSoft(metroListViewProd, item);
                    }
                    if (foundListSoft.Count <= 0 && foundListSoft.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Author not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                case 5:
                    //publisher name
                    foundListBook = bookList.FindAll(t => t.Publisher.PubName.Contains(metroTextBoxProdSearch.ToString()));
                    foreach (Book item in foundListBook)
                    {
                        AppOperatorDA.listBook(metroListViewProd, item);
                    }

                    foundListSoft = softwareList.FindAll(t => t.Publisher.PubName.Contains(metroTextBoxProdSearch.ToString()));
                    foreach (Software item in foundListSoft)
                    {
                        AppOperatorDA.listSoft(metroListViewProd, item);
                    }
                    if (foundListSoft.Count <= 0 && foundListSoft.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Publisher not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                case 6:
                    //category
                    foundListBook = bookList.FindAll(t => t.Category.CName.Contains(metroComboBoxProdSearch.ToString()));
                    foreach (Book item in foundListBook)
                    {
                        AppOperatorDA.listBook(metroListViewProd, item);
                    }
                    foundListSoft = softwareList.FindAll(t => t.Category.CName.Contains(metroComboBoxProdSearch.ToString()));
                    foreach (Software item in foundListSoft)
                    {
                        AppOperatorDA.listSoft(metroListViewProd, item);
                    }
                    if (foundListSoft.Count <= 0 && foundListSoft.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Category not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
            }
        }           
        //Change search option(combobox or textbox) based on selection
        private void metroComboBoxProdSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBoxProdSearch.SelectedIndex == 6)
            {
                metroTextBoxProdSearch.Visible = false;
                metroComboBoxProdSearchDrop.Visible = true;
            }
            else
            {
                metroTextBoxProdSearch.Visible = true;
                metroComboBoxProdSearchDrop.Visible = false;
            }
        }
        //Update combobxes information
        private void metroComboBoxProdAuth_DropDown(object sender, EventArgs e)
        {
            AppOperatorDA.comboFillAuthor(metroComboBoxProdAuth, authorList);
        }
        private void metroComboBoxProdPub_DropDown(object sender, EventArgs e)
        {
            AppOperatorDA.comboFillPublisher(metroComboBoxProdPub, publisherList);
        }
        private void metroComboBoxProdCat_DropDown(object sender, EventArgs e)
        {
            AppOperatorDA.comboFillCategory(metroComboBoxProdCat, categoryList);
        }
        private void metroComboBoxProdSearchDrop_DropDown(object sender, EventArgs e)
        {
            AppOperatorDA.comboFillCategory(metroComboBoxProdCat, categoryList);
        }
        //Fill textboxes and comboboxes with information from product selected in the listview
        private void metroListViewProd_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = metroListViewProd.SelectedItems[0];
            long selectedID = Convert.ToInt64(item.SubItems[0].Text);
            Product aprod = new Product();
            if (bookList.Find(t => t.ID.Equals(selectedID)) == null)
            {
                aprod = softwareList.Find(t => t.ID.Equals(selectedID));
                metroComboBoxProdType.SelectedIndex = 1;                                   
            }
            else
            {
                aprod = bookList.Find(t => t.ID.Equals(selectedID));    
                metroComboBoxProdType.SelectedIndex=0;
            }
            metroTextBoxProdID.Text = aprod.ID.ToString();
            metroComboBoxProdPub.Text = aprod.Publisher.PubName.ToString();
            metroComboBoxProdAuth.Text = (aprod.Author.FirstName + aprod.Author.LastName).ToString();
            metroTextBoxProdTitle.Text = aprod.Title.ToString();
            metroComboBoxProdCat.Text = aprod.Category.CName.ToString();
            metroDateTimeProd.Text = aprod.Date.ToString();
            metroTextBoxProdPrice.Text = aprod.UnitPrice.ToString();
            metroTextBoxProdQOH.Text = aprod.QOH.ToString();
            pictureBoxProd.ImageLocation = aprod.Photo;
            pictureBoxProd.Tag = aprod.Photo;
            return;                          
                                         
        }


        //Author Registration=========================================================
        //============================================================================

        //Creates object Author
        private Author createAuth()
        {
            MetroTextBox[] textBoxes = { metroTextBoxAuthFn, metroTextBoxAuthLn };
            if (!(Validator.isNotnull(textBoxes)))
            {
                return null;
            }
            Author aauthor = new Author();
            aauthor.ID = metroTextBoxAuthID.Text;
            aauthor.FirstName = metroTextBoxAuthFn.Text;
            aauthor.LastName = metroTextBoxAuthLn.Text;
            aauthor.Photo = pictureBoxAuth.Tag.ToString();
            return aauthor;
        }
        //Creates object authorDA to perform list and search
        AuthorDA authOP = new AuthorDA();
        //Calls metho to insert picture
        private void pictureBoxAuth_Click(object sender, EventArgs e)
        {
            OperatorDA.addPhoto(pictureBoxAuth);
        }                         
        //Add
        private void metroTileAutAdd_Click(object sender, EventArgs e)
        {
            metroListViewAuth.Items.Clear();
            Author aauthor = createAuth();
            if (aauthor==null)
            {
                return;
            }
            aauthor.ID = OperatorDA.uniqueID(authorList, metroTextBoxAuthFn.Text, metroTextBoxAuthLn.Text);
            authorList.Add(aauthor);
            foreach (Author item in authorList)
            {
                authOP.ListObj(metroListViewAuth, item);
            }
            OperatorDA.SaveList<Author>(authorList, filePaths.authorPath);
        }                      
        //Delete
        private void metroTileautRem_Click(object sender, EventArgs e)
        {
            metroListViewAuth.Items.Clear();
            Author updateAuth = createAuth();
            int authIndex = authorList.FindIndex(t => t.ID.Equals(updateAuth.ID));
            if (authorList.Find(t => t.ID.Equals(updateAuth.ID)) != null)
            {
                DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to delete this Author?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    authorList.RemoveAt(authIndex);
                    OperatorDA.SaveList<Author>(authorList, filePaths.authorPath);
                    metroListViewAuth.Items.Clear();
                }
            }
            foreach (Author item in authorList)
            {
                authOP.ListObj(metroListViewAuth, item);
            }
            return;
        }                      
        //Update
        private void metroTileAutUp_Click(object sender, EventArgs e)
        {
            metroListViewAuth.Items.Clear();
            Author updateAuth = createAuth();
            int authIndex = authorList.FindIndex(t => t.ID.Equals(updateAuth.ID));
            if (authorList.Find(t => t.ID.Equals(updateAuth.ID)) != null)
            {
                DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to update this Author?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    authorList[authIndex] = updateAuth;
                    OperatorDA.SaveList<Author>(authorList, filePaths.authorPath);
                    authOP.ListObj(metroListViewAuth, authorList[authIndex]);
                }
            }
            return;
        }                     
        //List
        private void metroTileAutList_Click(object sender, EventArgs e)
        {
            metroListViewAuth.Items.Clear();
            foreach (Author item in authorList)
            {
                authOP.ListObj(metroListViewAuth, item);
            }
        }                  
        //List author's products registered
        private void metroTileAutListProd_Click(object sender, EventArgs e)
        {
            Show_Products showProd = new Show_Products(createAuth());
            showProd.Show();
        }             
        //Search
        private void metroTileAutSearch_Click(object sender, EventArgs e)
        {
           
            authOP.Search(metroListViewAuth, authorList, metroTextBoxAuthSearch, metroComboBoxAuthSearch, null);
        }
        //Fill textboxes and comboboxes with information from author selected in the listview
        private void metroListViewAuth_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = metroListViewAuth.SelectedItems[0];
            string selectedID = item.SubItems[0].Text;
            Author aauthor = authorList.Find(t => t.ID.Equals(selectedID));
            metroTextBoxAuthID.Text = aauthor.ID.ToString();
            metroTextBoxAuthFn.Text = aauthor.FirstName.ToString();
            metroTextBoxAuthLn.Text = aauthor.LastName.ToString();
            pictureBoxAuth.ImageLocation = aauthor.Photo;
            pictureBoxAuth.Tag = aauthor.Photo;
            return;
        }              
       

        //Publisher Registration======================================================
        //============================================================================

        //Creates object publisher
        private Publisher createPub()
        {
            MetroTextBox[] textBoxes = { metroTextBoxPubNm };                   
            if (!(Validator.isNotnull(textBoxes)))
            {
                return null;
            }
            Publisher apub = new Publisher();
            apub.PubId = metroTextBoxPubID.Text;
            apub.PubName = metroTextBoxPubNm.Text;
            apub.PubLogo = pictureBoxPub.Tag.ToString();
            return apub;               
        }
        //Creates object PubDA to perform search and list
        PubDA pubOp = new PubDA();
        //Calls method to insert picture
        private void pictureBoxPub_Click(object sender, EventArgs e)
        {
            OperatorDA.addPhoto(pictureBoxPub);
        }                          
        //Add
        private void metroTilePubAdd_Click(object sender, EventArgs e)
        {
            metroListViewPub.Items.Clear();
            Publisher apub = createPub();
            if (apub==null)
            {
                return;
            }
            apub.PubId = OperatorDA.uniqueID(publisherList, metroTextBoxPubNm.Text, metroTextBoxPubNm.Text);
            publisherList.Add(apub);
            foreach (Publisher item in publisherList)
            {
                pubOp.ListObj(metroListViewPub, item);
            }
            OperatorDA.SaveList<Publisher>(publisherList, filePaths.publisherPath);
        }    
        //Delete
        private void metroTilePubRem_Click(object sender, EventArgs e)
        {
            metroListViewPub.Items.Clear();
            Publisher updatePub = createPub();
            int pubIndex = publisherList.FindIndex(t => t.PubId.Equals(updatePub.PubId));
            if (publisherList.Find(t => t.PubId.Equals(updatePub.PubId)) != null)
            {
                DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to delete this Publisher?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    publisherList.RemoveAt(pubIndex);
                    OperatorDA.SaveList<Publisher>(publisherList, filePaths.publisherPath);
                }
            }
            foreach (Publisher item in publisherList)
            {
                pubOp.ListObj(metroListViewPub, item);
            }
            return;
        }                     
        //Update
        private void metroTilePubUp_Click(object sender, EventArgs e)
        {
            metroListViewPub.Items.Clear();
            Publisher updatePub = createPub();
            int pubIndex = publisherList.FindIndex(t => t.PubId.Equals(updatePub.PubId));
            if (publisherList.Find(t => t.PubId.Equals(updatePub.PubId)) != null)
            {
                DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to update this Publisher?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    publisherList[pubIndex] = updatePub;
                    OperatorDA.SaveList<Publisher>(publisherList, filePaths.publisherPath);
                    pubOp.ListObj(metroListViewPub, publisherList[pubIndex]);
                }
            }
            return;
        }                      
        //List
        private void metroTilePubList_Click(object sender, EventArgs e)
        {
            metroListViewPub.Items.Clear();
            foreach (Publisher item in publisherList)
            {
               pubOp.ListObj(metroListViewPub, item);
            }
            return;
        }                  
        //Search
        private void metroTilePubSearch_Click(object sender, EventArgs e)
        {
            
            pubOp.Search(metroListViewPub, publisherList, metroTextBoxPubSearch, metroComboBoxPubSearch, null); 
        }                 
        //Show publisher's products list
        private void metroTilePubProdSearch_Click(object sender, EventArgs e)
        {
            Publisher apub = publisherList.Find(t => t.PubId.Equals(metroTextBoxPubID.Text));
            Show_Products showProd = new Show_Products(apub);
            showProd.Show();
        }
        //Fill textboxes and comboboxes with information from publisher selected in the listview    
        private void metroListViewPub_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = metroListViewPub.SelectedItems[0];
            string selectedID = item.SubItems[0].Text;
            Publisher apub = publisherList.Find(t => t.PubId.Equals(selectedID));
            metroTextBoxPubID.Text = apub.PubId.ToString();
            metroTextBoxPubNm.Text = apub.PubName.ToString();
            pictureBoxPub.ImageLocation = apub.PubLogo;
            pictureBoxPub.Tag = apub.PubLogo;
            return;
        }


        ////Order Controller TAB
        ////==========================================================================


        //Creates object Order  
        public static Order selectedOrder;
        //Search                                                 
        private void metroTileOrdSearch_Click(object sender, EventArgs e)
        {
            switch (metroComboBoxOrdSearch.SelectedIndex)
            {
                case -1:
                    MetroMessageBox.Show(this, "Please select a valid search option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 0:
                    var foundList = ordList.FindAll(t => t.OrdId.Equals(metroTextBoxOrdSearch.Text));
                    foreach (Order item in foundList)
                    {
                        AppOperatorDA.listOrd(metroListViewOrdList, item);
                    }
                    if (foundList.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Order not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                case 1:
                    foundList = ordList.FindAll(t => t.OrdClient.ClientName.Contains(metroTextBoxOrdSearch.Text));
                    foreach (Order item in foundList)
                    {
                        AppOperatorDA.listOrd(metroListViewOrdList, item);
                    }
                    if (foundList.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Order not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                case 2:
                    foundList = ordList.FindAll(t => t.OrdDate.Equals(Convert.ToDateTime(metroDateTimeOrd.Text)));
                    foreach (Order item in foundList)
                    {
                        AppOperatorDA.listOrd(metroListViewOrdList, item);
                    }
                    if (foundList.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Order not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                case 3:
                    foundList = ordList.FindAll(t => t.ShipDate.Equals(Convert.ToDateTime(metroDateTimeOrd.Text)));
                    foreach (Order item in foundList)
                    {
                        AppOperatorDA.listOrd(metroListViewOrdList, item);
                    }
                    if (foundList.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Order not found!", "Search not successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;

            }
        }              
        //New order, opens form OrderForm
        private void metroTileOrdNew_Click(object sender, EventArgs e)
        {
            OrderForm ordForm = new OrderForm(null);
            ordForm.ShowDialog();
        }                
        //Edit order, opens form OrderForm with information of the selected order
        private void metroTileOrdEdit_Click(object sender, EventArgs e)
        {
                           
            if (metroListViewOrdList.SelectedItems.Count > 0)
            {
                ListViewItem item = metroListViewOrdList.SelectedItems[0];
                selectedOrder = ordList.Find(t => t.OrdId.Equals(item.SubItems[0].Text));
                OrderForm ordForm = new OrderForm(ordList.Find(t => t.OrdId.Equals(item.SubItems[0].Text)));
                ordForm.ShowDialog();
            }
            else
            {
                MetroMessageBox.Show(this, "Please select an order.", "Order not selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                                                                                                                                
        }              
        //Delete order
        private void metroTileOrdDel_Click(object sender, EventArgs e)
        {
            if ((metroListViewOrdList.SelectedItems.Count > 0))
            {
                ListViewItem item = metroListViewOrdList.SelectedItems[0];
                selectedOrder = ordList.Find(t => t.OrdId.Equals(item.SubItems[0].Text));
                metroListViewOrdList.Items.Clear();
                DialogResult ans = MetroMessageBox.Show(this, "Are you sure you want to delete this Order?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    ordList.Remove(selectedOrder);
                    Client updateCl = clientList.Find(t => t.ClientId.Equals(selectedOrder.OrdClient.ClientId));
                    int clIndex = clientList.FindIndex(t => t.ClientId.Equals(updateCl.ClientId));
                    clientList[clIndex].ClientCredit = updateCl.ClientCredit + selectedOrder.OrdCost;
                    OperatorDA.SaveList(clientList, filePaths.clientPath);
                    OperatorDA.SaveList(ordList, filePaths.orderPath);               
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Please select an order.", "Order not selected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }               
        //List 
        private void metroTileOrdList_Click(object sender, EventArgs e)
        {
            metroListViewOrdList.Items.Clear();
            foreach (Order item in ordList)
            {
                AppOperatorDA.listOrd(metroListViewOrdList, item);
            }
            return;
        }
        //Fill textboxes and comboboxes with information from order selected in the listview
        private void metroListViewOrdList_MouseClick(object sender, MouseEventArgs e)
        {
           
        }                                  
        //Change search option based on selection                                               
        private void metroComboBoxOrdSearch_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (metroComboBoxOrdSearch.SelectedIndex > 1)
            {
                metroDateTimeOrd.Visible = true;
                metroTextBoxOrdSearch.Visible = false;
            }
            else
            {
                metroDateTimeOrd.Visible = false;
                metroTextBoxOrdSearch.Visible = true;
            }
        }

        private void metroListViewOrdList_MouseClick_1(object sender, MouseEventArgs e)
        {
            ListViewItem item = metroListViewOrdList.SelectedItems[0];
            string selectedId = item.SubItems[0].Text;
            selectedOrder = ordList.Find(t => t.OrdId.Equals(selectedId));
            metroLabelOrderInfo.Text = "Selected Order:" + selectedOrder.OrdId.ToString() + " Total Cost: " + selectedOrder.OrdCost.ToString();
            metroLabelOrdSel.Text = "Client: " + selectedOrder.OrdClient.ClientName.ToString();
            return;
        }
    }
}

