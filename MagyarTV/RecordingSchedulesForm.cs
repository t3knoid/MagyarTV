using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagyarTV
{
    public partial class RecordingSchedulesForm : Form
    {
        public RecordingSchedulesForm()
        {
            InitializeComponent();
        }

        private void RecordingSchedulesForm_Load(object sender, EventArgs e)
        {

            this.btOK.Location = new System.Drawing.Point((this.Width / 2) - (this.btOK.Width / 2), this.dataGridView1.Bottom + 10);
            RefreshDataViewGrid();
        }

        private void RefreshDataViewGrid()
        {
            Database database = new Database();
            List<ScheduleItem> scheduleItems = database.GetScheduleItems();
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Channel", "Channel");
            dataGridView1.Columns.Add("Start", "Start");
            dataGridView1.Columns.Add("End", "End");
            dataGridView1.Columns.Add("Monday", "Monday");
            dataGridView1.Columns.Add("Tuesday", "Tuesday");
            dataGridView1.Columns.Add("Wednesday", "Wednesday");
            dataGridView1.Columns.Add("Thursday", "Thursday");
            dataGridView1.Columns.Add("Friday", "Friday");
            dataGridView1.Columns.Add("Saturday", "Saturday");
            dataGridView1.Columns.Add("Sunday", "Sunday");
            dataGridView1.Columns.Add("Repeat", "Repeat");
            foreach (ScheduleItem item in scheduleItems)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    item.ID,
                    item.ChannelToRecord,
                    item.StartTime,
                    item.EndTime,
                    item.DaysToRecord["Monday"],
                    item.DaysToRecord["Tuesday"],
                    item.DaysToRecord["Wednesday"],
                    item.DaysToRecord["Thursday"],
                    item.DaysToRecord["Friday"],
                    item.DaysToRecord["Saturday"],
                    item.DaysToRecord["Sunday"],
                    item.Repeat,
                });
            }
            dataGridView1.Columns["Repeat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Fills the last column
            dataGridView1.Columns["Start"].DefaultCellStyle.Format = "HH:mm tt"; // Will show time only
            dataGridView1.Columns["End"].DefaultCellStyle.Format = "HH:mm tt";
        }

        private void btCancel_Click(object sender, EventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            AddRecordingForm scheduleRecording = new AddRecordingForm();
            scheduleRecording.Show();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {

        }

        private void RecordingSchedulesForm_Resize(object sender, EventArgs e)
        {
            this.btOK.Location = new System.Drawing.Point((this.Width / 2) - (this.btOK.Width / 2), this.dataGridView1.Bottom + 10);
        }

        private void btAdd_Click_1(object sender, EventArgs e)
        {
            AddRecordingForm addRecordingForm = new AddRecordingForm();
            addRecordingForm.ShowDialog();
            RefreshDataViewGrid();
        }

        private void btDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var item = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Database database = new Database();
            database.DeleteItem(item);
            RefreshDataViewGrid();
        }

        private void btView_Click(object sender, EventArgs e)
        {
            ScheduleItem scheduleItem = new ScheduleItem();
            scheduleItem.ChannelToRecord = dataGridView1.CurrentRow.Cells["Channel"].Value.ToString();
            scheduleItem.StartTime = DateTime.ParseExact(dataGridView1.CurrentRow.Cells["Start"].Value.ToString(), "M/dd/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
            scheduleItem.EndTime = DateTime.ParseExact(dataGridView1.CurrentRow.Cells["End"].Value.ToString(), "M/dd/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
            Dictionary<string, bool> daysToRecord = new Dictionary<string, bool>();  // Store days of week and checkbox value in a dictionary
            daysToRecord["Sunday"] = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Sunday"].Value);
            daysToRecord["Monday"] = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Monday"].Value);
            daysToRecord["Tuesday"] = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Tuesday"].Value);
            daysToRecord["Wednesday"] = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Wednesday"].Value);
            daysToRecord["Thursday"] = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Thursday"].Value);
            daysToRecord["Friday"] = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Friday"].Value);
            daysToRecord["Saturday"] = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Saturday"].Value);
            daysToRecord["Sunday"] = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Sunday"].Value);
            scheduleItem.DaysToRecord = daysToRecord;
            scheduleItem.Repeat = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Repeat"].Value);
            AddRecordingForm addRecordingForm = new AddRecordingForm() { ScheduleItem = scheduleItem };            
            addRecordingForm.InitializeFields();
            addRecordingForm.ShowDialog();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

