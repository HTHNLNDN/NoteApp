using System.Data;

namespace NoteApp
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool writeable = false;
        public NoteTaker()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[dataGridView1.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex) { Console.WriteLine("Invalid note, no action taken"); }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            titelBox.Text = "";
            noteBox.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            notes.Rows.Add(titelBox.Text, noteBox.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titelBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();

        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("note");

            dataGridView1.DataSource = notes;
        }
    }
}