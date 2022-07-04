using System.Data;

namespace NoteApp
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
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
       
            if (editing)
            {
                notes.Rows[dataGridView1.CurrentCell.RowIndex]["Title"] = titelBox.Text;
                notes.Rows[dataGridView1.CurrentCell.RowIndex]["note"] = noteBox.Text;
            }
            else
            {
                notes.Rows.Add(titelBox.Text, noteBox.Text);
            }
            titelBox.Text = "Title";
            noteBox.Text = "";
            editing = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titelBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();

            editing = true;
        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("note");

            dataGridView1.DataSource = notes;
        }
    }
}