using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadFromFile();

            toDoBindingSource.DataSource = items;

            toDoDataGridView.AutoResizeColumns();
            toDoDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private string filename = "tmp.txt";
        private List<string> lines = new List<string>();

        private void LoadFromFile()
        {
            lines.Clear();
            items.Clear();

            if (System.IO.File.Exists(filename))
                lines = System.IO.File.ReadAllLines(filename).ToList<string>();
            if (lines != null && lines.Count > 0)
            {
                foreach (string line in lines)
                {
                    var p = new ToDo(line);
                    items.Add(p);
                }
            }
        }
        private void SaveToFile()
        {
            lines.Clear();
            foreach (ToDo p in items)
                lines.Add(p.ToString());
            System.IO.File.WriteAllLines(filename, lines);
        }


        public ObservableCollection<ToDo> items { get; set; } = new ObservableCollection<ToDo>();

        private void button5_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // items.Clear();
            LoadFromFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var item = toDoBindingSource.Current as ToDo;
            item.Status = ToDoStatusEnum.InProgress;
            toDoBindingSource.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // по аналогии установите статус выполнения задачи как ToDoStatusEnum.Planned
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // по аналогии установите статус выполнения задачи как ToDoStatusEnum.Completed
        }

        private void toDoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var item = toDoBindingSource.Current as ToDo;
            var row = e.RowIndex;
            if (row % 2 == 0)
                e.CellStyle.BackColor = Color.LightGray;
            else
                e.CellStyle.BackColor = Color.White;
            try
            {
                var value = (int)toDoDataGridView.Rows[row].Cells[5].Value;

                if (value == (int)ToDoStatusEnum.Planned)
                    e.CellStyle.BackColor = Color.AliceBlue;
                if (value == (int)ToDoStatusEnum.InProgress)
                    e.CellStyle.BackColor = Color.Orange;
                if (value == (int)ToDoStatusEnum.Completed)
                    e.CellStyle.BackColor = Color.LightGreen;

            }
            catch
            {

            }
        }

        private void toDoDataGridView_Resize(object sender, EventArgs e)
        {
            toDoDataGridView.AutoResizeColumns();
            toDoDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}