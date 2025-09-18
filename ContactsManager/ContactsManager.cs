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
// Removed dependency on Microsoft.VisualBasic.FileIO to avoid assembly reference issues

//import countries and codes
using static ContactsManager.CountryCodes;

namespace ContactsManager
{
    public partial class ContactsManager : Form
    {
        public ContactsManager()
        {
            InitializeComponent();
            tabControlContacts.TabPages.Clear();
        }
        
        private void btnOptions_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var location = btn.PointToScreen(new Point(0, btn.Height));
            this.contextMenuOptions.Show(location);
        }
        
        private void menuAbout_Click(object sender, EventArgs e)
        {
            using (var dlg = new AboutForm())
            {
                dlg.ShowDialog(this);
            }
        }
        
        private void menuUpdate_Click(object sender, EventArgs e)
        {
            using (var dlg = new UpdateForm())
            {
                dlg.ShowDialog(this);
            }
        }
        
        private void menuSettings_Click(object sender, EventArgs e)
        {
            using (var dlg = new SettingsForm())
            {
                dlg.ShowDialog(this);
            }
        }


        private string GetCountryCode(string phoneNumber)
        {
            // Assuming country code is at the beginning of the phone number, preceded by a '+'
            if (!phoneNumber.StartsWith("+"))
            {
            // Default to an empty string if no valid country code is found
            return string.Empty;
            }

            // Use the explicit `Items` list from `CountryCodes`.
            // Iterate longest-first so that '+1' doesn't match before '+1242', etc.
            foreach (var item in CountryCodes.Items.OrderByDescending(i => i.Code.Length))
            {
                var code = item.Code;
                var countryName = item.Country;
                if (!string.IsNullOrEmpty(code) && phoneNumber.StartsWith(code))
                {
                    return $"{countryName} ({code})";
                }
            }

            // No match found for a '+' prefixed number
            return "O";
        }

        // ...existing code...

        private void btnLoadContacts_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|Excel Files (*.xlsx)|*.xlsx";
            openFileDialog.Filter = "Custom Files (*.txt, *.xlsx, *.csv)|*.txt;*.xlsx;*.csv";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                lblFilePath.Text = filePath;
                btnSaveAll.Visible = true;
                btnCSV.Visible = true;
                btnSaveAllExcel.Visible = true;

                if (filePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    LoadContactsFromTextFile(filePath);
                }
                else if (filePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    LoadContactsFromExcelFile(filePath);
                }
                else if (filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    LoadContactsFromCsvFile(filePath);
                }
                else
                {
                    MessageBox.Show("Unsupported file format. Please select a .txt, .csv or .xlsx file.");
                }
                // Show the reload button now that a file has been selected
                this.btnReload.Visible = true;
            }
        }

        private void LoadContactsFromTextFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            tabControlContacts.TabPages.Clear();

            var contactsSet = new HashSet<string>();
            foreach (var line in lines)
            {
                var numbers = ExtractPhoneNumbers(line);
                foreach (var num in numbers)
                {
                    contactsSet.Add(num);
                }
            }

            foreach (var contact in contactsSet)
            {
                if (!IsAllowedLength(contact)) continue;
                var countryCode = GetCountryCode(contact);
                var tabPage = FindOrCreateTabPage(countryCode);
                var listBox = GetListBoxForTabPage(tabPage);
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
                    var contactsSet = new HashSet<string>();

                    for (int row = startRow; row <= endRow; row++)
                    {
                        var cell = worksheet.Cells[row, 1];
                        var text = cell.Text ?? string.Empty;
                        var numbers = ExtractPhoneNumbers(text);
                        foreach (var n in numbers) contactsSet.Add(n);
                    }

                    foreach (var cleanedContact in contactsSet)
                    {
                        if (!IsAllowedLength(cleanedContact)) continue;
                        var countryCode = GetCountryCode(cleanedContact);
                        var tabPage = FindOrCreateTabPage(countryCode);
                        var listBox = GetListBoxForTabPage(tabPage);
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

        // Extract phone numbers from an input string. Rules:
        // - A '+' starts a new phone number
        // - From each '+', collect digits (0-9) that appear until the next '+' or end
        //   — non-digit characters (spaces, dashes, parentheses) are ignored/skipped
        // - Return normalized numbers (e.g. "+923001234567")
        private IEnumerable<string> ExtractPhoneNumbers(string input)
        {
            if (string.IsNullOrEmpty(input)) yield break;

            int i = 0;
            while (i < input.Length)
            {
                int plus = input.IndexOf('+', i);
                if (plus == -1) yield break;

                var sb = new StringBuilder();
                sb.Append('+');

                int j = plus + 1;
                bool foundDigit = false;
                while (j < input.Length)
                {
                    char c = input[j];
                    if (c == '+')
                    {
                        // start of next number; stop current
                        break;
                    }
                    if (c >= '0' && c <= '9')
                    {
                        sb.Append(c);
                        foundDigit = true;
                    }
                    // otherwise skip separators and other characters
                    j++;
                }

                if (foundDigit)
                {
                    yield return sb.ToString();
                }

                // continue scanning after this plus (so overlapping pluses handled)
                i = plus + 1;
            }
        }

        // Return true if the given normalized phone number should be included
        // based on the ignore-length UI controls. If parsing of the textbox
        // values fails or the checkboxes are not checked, the corresponding
        // rule is ignored.
        private bool IsAllowedLength(string normalizedPhone)
        {
            if (string.IsNullOrEmpty(normalizedPhone)) return false;

            // Determine digit count, optionally excluding the recognized country code digits
            int digitCount = 0;
            string remaining = normalizedPhone;
            if (this.chkIgnoreCountryCode != null && this.chkIgnoreCountryCode.Checked && normalizedPhone.StartsWith("+"))
            {
                var matched = CountryCodes.Items.OrderByDescending(i => i.Code.Length)
                                .FirstOrDefault(i => !string.IsNullOrEmpty(i.Code) && normalizedPhone.StartsWith(i.Code));
                if (!string.IsNullOrEmpty(matched.Code))
                {
                    remaining = normalizedPhone.Substring(matched.Code.Length);
                }
                else
                {
                    // no known country code matched; strip leading '+' and count rest
                    remaining = normalizedPhone.Substring(1);
                }
            }
            digitCount = remaining.Count(char.IsDigit);

            // Ignore-less-than rule
            if (this.chkIgnoreLessThan != null && this.chkIgnoreLessThan.Checked)
            {
                if (!int.TryParse(this.txtIgnoreLessThan?.Text, out int min) || min <= 0)
                {
                    if (this.lblLessError != null)
                    {
                        this.lblLessError.Text = "Enter a positive integer";
                    }
                    return false;
                }
                else
                {
                    if (this.lblLessError != null)
                    {
                        this.lblLessError.Text = string.Empty;
                    }
                }
                if (digitCount < min) return false;
            }

            // Ignore-greater-than rule
            if (this.chkIgnoreGreaterThan != null && this.chkIgnoreGreaterThan.Checked)
            {
                if (!int.TryParse(this.txtIgnoreGreaterThan?.Text, out int max) || max <= 0)
                {
                    if (this.lblGreaterError != null)
                    {
                        this.lblGreaterError.Text = "Enter a positive integer";
                    }
                    return false;
                }
                else
                {
                    if (this.lblGreaterError != null)
                    {
                        this.lblGreaterError.Text = string.Empty;
                    }
                }
                if (digitCount > max) return false;
            }

            return true;
        }

        private void txtIgnoreLessThan_TextChanged(object sender, EventArgs e)
        {
            ValidateNumericTextBox(this.txtIgnoreLessThan, this.lblLessError);
        }

        private void txtIgnoreGreaterThan_TextChanged(object sender, EventArgs e)
        {
            ValidateNumericTextBox(this.txtIgnoreGreaterThan, this.lblGreaterError);
        }

        private void ValidateNumericTextBox(TextBox box, Label errorLabel)
        {
            if (box == null || errorLabel == null) return;
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                errorLabel.Text = "";
                return;
            }
            if (!int.TryParse(box.Text, out int val) || val <= 0)
            {
                errorLabel.Text = "Enter a positive integer";
            }
            else
            {
                errorLabel.Text = string.Empty;
            }
        }

        private void chkIgnoreLessThan_CheckedChanged(object sender, EventArgs e)
        {
            if (this.txtIgnoreLessThan != null)
            {
                this.txtIgnoreLessThan.Enabled = this.chkIgnoreLessThan.Checked;
            }
        }

        private void chkIgnoreGreaterThan_CheckedChanged(object sender, EventArgs e)
        {
            if (this.txtIgnoreGreaterThan != null)
            {
                this.txtIgnoreGreaterThan.Enabled = this.chkIgnoreGreaterThan.Checked;
            }
        }

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys, digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        // Very small CSV parser for a single line. Handles fields enclosed in double-quotes
        // and commas inside quoted fields. Returns an array of fields.
        private string[] ParseCsvLine(string line)
        {
            if (line == null) return new string[0];

            var fields = new List<string>();
            var sb = new StringBuilder();
            bool inQuotes = false;
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        // Escaped quote
                        sb.Append('"');
                        i++; // skip next quote
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    fields.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }
            fields.Add(sb.ToString());
            return fields.ToArray();
        }

        private void LoadContactsFromCsvFile(string filePath)
        {
            tabControlContacts.TabPages.Clear();

            var contactsSet = new HashSet<string>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                var fields = ParseCsvLine(line);
                foreach (var f in fields)
                {
                    var numbers = ExtractPhoneNumbers(f ?? string.Empty);
                    foreach (var n in numbers) contactsSet.Add(n);
                }
            }

            foreach (var contact in contactsSet)
            {
                if (!IsAllowedLength(contact)) continue;
                var countryCode = GetCountryCode(contact);
                var tabPage = FindOrCreateTabPage(countryCode);
                var listBox = GetListBoxForTabPage(tabPage);
                listBox.Items.Add(contact);
            }

            MessageBox.Show("Contacts loaded successfully");
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

        private void ContactsManager_Load(object sender, EventArgs e)
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            var filePath = lblFilePath.Text;
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("No file selected or file not found. Please select a valid contacts file to reload.");
                return;
            }

            try
            {
                if (filePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    LoadContactsFromTextFile(filePath);
                }
                else if (filePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    LoadContactsFromExcelFile(filePath);
                }
                else if (filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    LoadContactsFromCsvFile(filePath);
                }
                else
                {
                    MessageBox.Show("Unsupported file format. Please select a .txt, .csv or .xlsx file.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reloading contacts: " + ex.Message);
            }
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
