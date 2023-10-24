using System.Windows.Forms;

namespace Alantev_mod8
{
    public partial class Form1 : Form
    {
        private ListBox tasks;
        private TextBox input;

        public Form1()
        {
            InitializeComponent();
            tasks = listBox1;
            input = textBox1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tasks.Items.Add(input.Text);
            input.Clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tasks.Items.Remove(tasks.SelectedItem);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int index = tasks.SelectedIndex;
            if (index != -1)
            {
                tasks.Items[index] = tasks.Items[index] + " (выполнено)";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchText = input.Text;
            var foundIndex = tasks.FindString(searchText);

            if (foundIndex != ListBox.NoMatches)
            {
                tasks.SelectedIndex = foundIndex;
                tasks.SetSelected(foundIndex, true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var sortedItems = tasks.Items.Cast<string>().OrderBy(item => item).ToList();

            tasks.Items.Clear();
            foreach (var item in sortedItems)
            {
                tasks.Items.Add(item);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string filterText = input.Text;
            var filteredItems = tasks.Items.Cast<string>().Where(item => item.Contains(filterText)).ToList();

            tasks.Items.Clear();
            foreach (var item in filteredItems)
            {
                tasks.Items.Add(item);
            }
        }
    }
}