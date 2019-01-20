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
    public partial class ScheduleRecordingForm : Form
    {
        public ScheduleItem ScheduleItem { get; set; }
        public List<string> Channels { get; set; }
        public ScheduleRecordingForm()
        {
            InitializeComponent();            
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            // Save the settings here

            Dictionary<string, bool> daysToRecord = new Dictionary<string, bool>();  // Store days of week and checkbox value in a dictionary
            foreach (Control p in pnlDays.Controls)
                if (p.GetType() == typeof(CheckBox))
                {
                    CheckBox cb = p as CheckBox;
                    daysToRecord.Add(cb.Text, cb.Checked);
                }
            
            ScheduleItem ScheduleItem = new ScheduleItem()
            {
                ChannelToRecord = this.cbChannel.Text,
                StartTime = this.dtpStart.Value,
                EndTime = this.dtpEnd.Value,
                DaysToRecord = daysToRecord,
                Repeat = this.cbRepeat.Checked,
            };

            Database database = new Database();
            database.AddScheduleItem(ScheduleItem);
            ScheduleItem si = database.GetScheduleItem(5);
             this.Close();
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            // Cancel
            this.Close();
        }
        private void ScheduleRecordingForm_Load(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = Channels;
            this.cbChannel.DataSource = bindingSource.DataSource;
        }
    }
}
