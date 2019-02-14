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
    public partial class AddRecordingForm : Form
    {
        public ScheduleItem ScheduleItem { get; set; }
        public AddRecordingForm()
        {
            InitializeComponent();            
        }

        public void InitializeFields()
        {
            if (ScheduleItem != null)
            {
                cbChannel.Text = ScheduleItem.ChannelToRecord;
                dtpStart.Value = ScheduleItem.StartTime;
                dtpEnd.Value = ScheduleItem.EndTime;
                cbSunday.Checked = ScheduleItem.DaysToRecord["Sunday"];
                cbMonday.Checked = ScheduleItem.DaysToRecord["Monday"];
                cbTuesday.Checked = ScheduleItem.DaysToRecord["Tuesday"];
                cbWednesday.Checked = ScheduleItem.DaysToRecord["Wednesday"];
                cbThursday.Checked = ScheduleItem.DaysToRecord["Thursday"];
                cbFriday.Checked = ScheduleItem.DaysToRecord["Friday"];
                cbSaturday.Checked = ScheduleItem.DaysToRecord["Saturday"];
                cbRepeat.Checked = ScheduleItem.Repeat;
            }
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
            this.Close();
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            // Cancel
            this.Close();
        }
        private void ScheduleRecordingForm_Load(object sender, EventArgs e)
        {
            MediaKlikk mediaKlikk = new MediaKlikk();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = mediaKlikk.GetChannelNames(); ;
            this.cbChannel.DataSource = bindingSource.DataSource;
        }
    }
}
