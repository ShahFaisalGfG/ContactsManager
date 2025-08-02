using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace ContactsManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabControlContacts.TabPages.Clear();
        }


        private string GetCountryCode(string phoneNumber)
        {
            // Assuming country code is at the beginning of the phone number, preceded by a '+'
            if (phoneNumber.StartsWith("+"))
            {
                //Note: If you add more country codes then uncomment "retun countryCode" and remove line "return Pakistani"
                string[] validCountryCodes = {
            "+92","+91"
        };

                // Iterate through the valid country codes in descending order of length
                foreach (string countryCode in validCountryCodes.OrderByDescending(code => code.Length))
                {
                    if (phoneNumber.StartsWith("+92"))
                    {
                        //If you add more country codes then uncomment "retun countryCode" and remove line "return Pakistani"
                        //return countryCode;
                        return "P";

                    }
                    if(phoneNumber.StartsWith("+91"))
                    {
                        return "I";
                    }
                }
                return "O";
            }

            // Default to an empty string if no valid country code is found
            return string.Empty;
        }

        private void btnLoadContacts_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|Excel Files (*.xlsx)|*.xlsx";
            openFileDialog.Filter = "Custom Files (*.txt, *.xlsx)|*.txt;*.xlsx";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                lblFilePath.Text = filePath;
                btnSaveAll.Visible = true;
                btnCSV.Visible = true;
                btnSaveAllExcel.Visible = true;

                if (filePath.EndsWith(".txt"))
                {
                    LoadContactsFromTextFile(filePath);
                }
                else if (filePath.EndsWith(".xlsx"))
                {
                    LoadContactsFromExcelFile(filePath);
                }
                else
                {
                    MessageBox.Show("Unsupported file format. Please select a .txt or .xlsx file.");
                }
            }
        }

        private void LoadContactsFromTextFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            tabControlContacts.TabPages.Clear();

            HashSet<string> contactsSet = new HashSet<string>();
            foreach (string contact in lines)
            {
                string cleanedContact = CleanContact(contact);
                if (!string.IsNullOrEmpty(cleanedContact))
                {
                    contactsSet.Add(cleanedContact);
                }
            }

            foreach (string contact in contactsSet)
            {
                string countryCode = GetCountryCode(contact);
                TabPage tabPage = FindOrCreateTabPage(countryCode);
                ListBox listBox = GetListBoxForTabPage(tabPage);
                listBox.Items.Add(contact);
            }

            MessageBox.Show("Contacts loaded successfully");
        }

        private void LoadContactsFromExcelFile(string filePath)
        {
            tabControlContacts.TabPages.Clear();
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    int startRow = worksheet.Dimension.Start.Row;
                    int endRow = worksheet.Dimension.End.Row;

                    HashSet<string> contactsSet = new HashSet<string>();

                    for (int row = startRow; row <= endRow; row++)
                    {
                        var cell = worksheet.Cells[row, 1];
                        string contact = cell.Text.Trim();

                        if (!string.IsNullOrEmpty(contact))
                        {
                            string cleanedContact = CleanContact(contact);
                            if (!string.IsNullOrEmpty(cleanedContact))
                            {
                                contactsSet.Add(cleanedContact);
                            }
                        }
                    }

                    foreach (string cleanedContact in contactsSet)
                    {
                        string countryCode = GetCountryCode(cleanedContact);
                        TabPage tabPage = FindOrCreateTabPage(countryCode);
                        ListBox listBox = GetListBoxForTabPage(tabPage);
                        listBox.Items.Add(cleanedContact);
                    }
                }
            }

            MessageBox.Show("Contacts loaded successfully.");
        }


        private string CleanContact(string contact)
        {
            // Keep only the valid characters: "+", "0"-"9"
            string validCharacters = "+0123456789";
            return new string(contact.Where(c => validCharacters.Contains(c)).ToArray());
        }

        private TabPage FindOrCreateTabPage(string countryCode)
        {
            // Check if a tab page for the country code already exists
            foreach (TabPage tabPage in tabControlContacts.TabPages)
            {
                if (tabPage.Text == countryCode)
                {
                    return tabPage;
                }
            }

            // Create a new tab page for the country code
            TabPage newTabPage = new TabPage(countryCode);
            tabControlContacts.TabPages.Add(newTabPage);

            // Create a ListBox control for the tab page
            ListBox listBox = new ListBox();
            listBox.Dock = DockStyle.Fill;
            newTabPage.Controls.Add(listBox);

            return newTabPage;
        }

        private ListBox GetListBoxForTabPage(TabPage tabPage)
        {
            // Iterate through the controls of the tab page to find the ListBox
            foreach (Control control in tabPage.Controls)
            {
                if (control is ListBox listBox)
                {
                    return listBox;
                }
            }

            return null; // ListBox not found
        }

        private void ExportContactsToCSV()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files|*.csv";
            saveFileDialog.FileName = $"Contacts_by_ContactsManager";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the headers to the CSV file
                    writer.WriteLine("Name,Given Name,Additional Name,Family Name,Yomi Name,Given Name Yomi,Additional Name Yomi,Family Name Yomi,Name Prefix,Name Suffix,Initials,Nickname,Short Name,Maiden Name,Birthday,Gender,Location,Billing Information,Directory Server,Mileage,Occupation,Hobby,Sensitivity,Priority,Subject,Notes,Language,Photo,Group Membership,Phone 1 - Type,Phone 1 - Value");

                    int contactIndex;
                    foreach (TabPage tabPage in tabControlContacts.TabPages)
                    {
                        string tabName = tabPage.Text;
                        ListBox listBox = GetListBoxForTabPage(tabPage);

                        contactIndex = 1; // Reset the contact index for each tab
                        foreach (string contact in listBox.Items)
                        {
                            // Generate the contact name using tabName and contactIndex
                            string contactName = $"{tabName}{contactIndex}";

                            // Generate a random 5-character string
                            string uniqueString = GenerateRandomString(5);

                            /*// Append the unique string to the contact name
                            contactName += " " + uniqueString;*/

                            // Write the CSV row with the required fields and values
                            writer.WriteLine($"\"{contactName}\",,,,,,,,,,,,,,,,,,,,,,,,,,,,\"Contacts Manager ::: * myContacts\",,\"{contact}\"");

                            contactIndex++;
                        }
                    }
                }


                MessageBox.Show("Contacts exported to CSV successfully.");
            }
        }

        private string GenerateRandomString(int length)
        {
            const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(characters, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            saveFileDialog.FileName = $"Contacts_by_ContactsManager";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (TabPage tabPage in tabControlContacts.TabPages)
                    {
                        writer.WriteLine("country code: " + tabPage.Text);

                        ListBox listBox = GetListBoxForTabPage(tabPage);

                        foreach (string contact in listBox.Items)
                        {
                            writer.WriteLine(contact);
                        }

                        writer.WriteLine();
                    }
                }

                MessageBox.Show("Contacts saved successfully.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add a context menu to the tab control
            tabControlContacts.ContextMenuStrip = new ContextMenuStrip();
            tabControlContacts.ContextMenuStrip.Items.Add("Copy Line", null, CopySelectedItem);
            tabControlContacts.ContextMenuStrip.Items.Add("Copy Tab", null, CopySelectedTab);
        }

        private void CopySelectedTab(object sender, EventArgs e)
        {
            if (tabControlContacts.SelectedTab != null)
            {
                TabPage selectedTab = tabControlContacts.SelectedTab;

                StringBuilder sb = new StringBuilder();
                foreach (Control control in selectedTab.Controls)
                {
                    if (control is ListBox listBox)
                    {
                        foreach (object item in listBox.Items)
                        {
                            sb.AppendLine(item.ToString());
                        }
                    }
                }

                Clipboard.SetText(sb.ToString());
            }
        }

        private void CopySelectedItem(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControlContacts.SelectedTab;
            if (selectedTab != null)
            {
                ListBox listBox = GetListBoxForTabPage(selectedTab);
                if (listBox.SelectedItem != null)
                {
                    string selectedLine = listBox.SelectedItem.ToString();
                    Clipboard.SetText(selectedLine);
                }
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            ExportContactsToCSV();
        }

        private void btnSaveAllExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.FileName = $"Contacts_by_ContactsManager";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (ExcelPackage package = new ExcelPackage())
                {
                    foreach (TabPage tabPage in tabControlContacts.TabPages)
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(tabPage.Text);

                        ListBox listBox = GetListBoxForTabPage(tabPage);
                        int rowIndex = 1;

                        foreach (string contact in listBox.Items)
                        {
                            worksheet.Cells[rowIndex, 1].Value = contact;
                            rowIndex++;
                        }
                    }

                    package.SaveAs(new FileInfo(filePath));
                }

                MessageBox.Show("Contacts saved to Excel successfully.");
            }
        }
    }
}
