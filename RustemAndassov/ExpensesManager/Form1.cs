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

namespace ExpensesManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        { 
            string path = inputTextBox.Text;
            resultTextBox.Clear();
            try
            {
                string wholeText = File.ReadAllText(path);
                resultTextBox.Text = wholeText.Replace('|', '\t');
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void summarizeButton_Click(object sender, EventArgs e)
        {
            string path = inputTextBox.Text;

            if (File.Exists(path)) 
            {
                SummarizeFile(path);
            }
            else {
                MessageBox.Show("File does not exist", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void SummarizeFile(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                List<string[]> expenses = new List<string[]>();

                foreach (var line in lines.Skip(1))
                {
                    string[] split = line.Split('|');
                    expenses.Add(split);
                }

                decimal totalExpenses = expenses.Sum(x => decimal.Parse(x[1].Replace('.', ',')));
                int categoriesCount = expenses.Select(x => x[2]).Distinct().Count();
                int datesCount = expenses.Select(x => DateTime.Parse(x[0])).Distinct().Count();

                StringBuilder builder = new StringBuilder();
                builder.AppendLine($"Total expenses: {totalExpenses}");
                builder.AppendLine($"Number of categories: {categoriesCount}");
                builder.AppendLine($"Total dates of payments: {datesCount}");
                builder.AppendLine();
                builder.AppendLine("Categories:");

                var categoryGroups = expenses.GroupBy(x => x[2]);

                foreach ( var group in categoryGroups)
                { 
                    int count = group.Count();
                    string months = string.Join(", ", group.Select(
                                x => DateTime.Parse(x[0]).ToString("MMMM")).Distinct());
                    decimal total = group.Sum(x => decimal.Parse(x[1].Replace('.', ',')));
                 
                    if (count > 1) builder.AppendLine($"{group.Key} - bought {count} times in total. Purchases in: {months}. Total expense: {total}");
                    if (count <= 1) builder.AppendLine($"{group.Key} - bought {count} time in total. Purchases in: {months}. Total expense: {total}");
                }
                resultTextBox.Text = builder.ToString();
              
            } catch (Exception ex) {
                MessageBox.Show($"Error occurred - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
