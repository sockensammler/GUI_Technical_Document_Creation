using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDataReader;

namespace DocFillGUI
{
    public class ArticleItem
    {
        public DataRow Row { get; }

        public ArticleItem(DataRow row)
        {
            Row = row;
        }

        public override string ToString()
        {
            // Display the entire row
            return string.Join(", ", Row.ItemArray);
        }
    }

    public partial class Form1 : Form
    {
        private Dictionary<string, DataSet> dataSetsBySheet;
        private DataTable firstTable;

        public Form1()
        {
            InitializeComponent();
            LoadExcelData();
            DisplayFirstDataSetRowsInListBox();
        }

        private void LoadExcelData()
        {
            string filePath = @"C:\Users\max.roehrig\Desktop\Work Automation\Work-automation\Document filling\Verkaufsartikel mit Abhängigkeiten.xlsx";
            DataSet result;

            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        result = reader.AsDataSet(new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });
                    }
                }

                dataSetsBySheet = new Dictionary<string, DataSet>();

                foreach (DataTable table in result.Tables)
                {
                    DataSet singleDataSet = new DataSet(table.TableName);
                    singleDataSet.Tables.Add(table.Copy());
                    dataSetsBySheet[table.TableName] = singleDataSet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void DisplayFirstDataSetRowsInListBox()
        {
            if (dataSetsBySheet != null && dataSetsBySheet.Count > 0)
            {
                DataSet firstDataSet = dataSetsBySheet.Values.First();

                if (firstDataSet.Tables.Count > 0)
                {
                    firstTable = firstDataSet.Tables[0];

                    // Clear the listbox
                    available_articles_list.Items.Clear();

                    // Add each row as an ArticleItem
                    foreach (DataRow row in firstTable.Rows)
                    {
                        available_articles_list.Items.Add(new ArticleItem(row));
                    }
                }
            }
        }

        private void available_articles_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle listbox selection if needed
        }

        private void add_art_button_Click(object sender, EventArgs e)
        {
            if (available_articles_list.SelectedItem is ArticleItem selectedItem)
            {
                // Add the entire ArticleItem to added_articles_list
                added_articles_list.Items.Add(selectedItem);

                // After adding an article, update the connected articles list
                UpdateConnectedArticlesList();
            }
            else
            {
                MessageBox.Show("Please select an article to add.");
            }
        }

        private void remove_art_button_Click(object sender, EventArgs e)
        {
            if (added_articles_list.SelectedItem is ArticleItem selectedItem)
            {
                // Remove the selected ArticleItem
                added_articles_list.Items.Remove(selectedItem);

                // After removal, update the connected articles list
                UpdateConnectedArticlesList();
            }
            else
            {
                MessageBox.Show("Please select an article to remove.");
            }
        }

        private void UpdateConnectedArticlesList()
        {
            available_connected_articles_list.Items.Clear();

            // Check if we have the necessary columns
            if (firstTable == null ||
                !firstTable.Columns.Contains("Suchwort") ||
                !firstTable.Columns.Contains("Artikelnummer") ||
                !firstTable.Columns.Contains("Abhängigkeiten_Verkaufsartikel"))
            {
                return;
            }

            // Gather all connected article numbers from currently added articles
            HashSet<string> allConnectedArticleNumbers = new HashSet<string>();

            foreach (var obj in added_articles_list.Items)
            {
                if (obj is ArticleItem addedItem)
                {
                    DataRow articleRow = addedItem.Row;
                    object dependenciesObj = articleRow["Abhängigkeiten_Verkaufsartikel"];

                    if (dependenciesObj != DBNull.Value && !string.IsNullOrEmpty(dependenciesObj.ToString()))
                    {
                        string dependencies = dependenciesObj.ToString();
                        string[] connectedArticleNumbers = dependencies.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string artNum in connectedArticleNumbers)
                        {
                            string trimmedArtNum = artNum.Trim();
                            allConnectedArticleNumbers.Add(trimmedArtNum);
                        }
                    }
                }
            }

            // Now display all connected articles found, with full info
            foreach (string artNum in allConnectedArticleNumbers)
            {
                DataRow[] connectedRows = firstTable.Select($"Artikelnummer = '{artNum.Replace("'", "''")}'");
                if (connectedRows.Length > 0)
                {
                    DataRow connectedRow = connectedRows[0];

                    // Instead of just using Suchwort, wrap the entire row in an ArticleItem
                    ArticleItem connectedItem = new ArticleItem(connectedRow);
                    available_connected_articles_list.Items.Add(connectedItem);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void button6_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
    }
}
