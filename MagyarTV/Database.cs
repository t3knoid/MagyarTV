using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MagyarTV
{
    class Database
    {
        public string ConnnectionString { get; set;}
        public string DatabaseDir { get; set; }
        public string DatabasePath { get; set; }

        public Database()
        {
            this.DatabaseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MagyarTV");
            this.DatabasePath = Path.Combine(DatabaseDir, "Magyartv.sqlite");
            CreateSchema();
        }

        private void CreateSchema()
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            string sqlFile = Path.Combine(currentDirectory, "sqls", "CreateSchema.sqlite");
            string sql = String.Empty;
            try
            {
                sql = System.IO.File.ReadAllText(@sqlFile);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Failed to read {0}. {1}.",sqlFile,ex.Message));
            }
 
            if (!Directory.Exists(this.DatabaseDir))
            {
                try
                {
                    Directory.CreateDirectory(this.DatabaseDir);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(String.Format("Error creating database directory. {0}",ex.Message));
                }
            }
            if (!File.Exists(this.DatabasePath))
            {
                try
                {
                    // Create database file
                    System.Data.SQLite.SQLiteConnection.CreateFile(this.DatabasePath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            SQLiteResult sqliteresult = SQLite.Exec(DatabasePath, sql);
            if (!sqliteresult.success)
            {
               System.Windows.Forms.MessageBox.Show(String.Format("Error in creating schema. {0}", sqliteresult.message));
            }
        }
        internal void AddShowSchedule(List<ShowEntry> showSchedule)
        {
            string sqlformat = "INSERT INTO TVGuide(Channel,Title,Description,StartTime,Date,Time,Day,Duration,Properties) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')";

            string[] sqls = new string[showSchedule.Count];
            int i = 0;
            for(i=0; i < showSchedule.Count; i++)
            {
                var showentry = showSchedule[i];
                sqls[i] = string.Format(sqlformat, showentry.Channel.Name, showentry.Title.Replace("'", "''"), showentry.Description.Replace("'", "''"), showentry.StartTime, showentry.Date, showentry.Time, showentry.Day, "", showentry.Properties);
            }
            SQLiteResult sqliteResult = SQLite.Exec(DatabasePath, sqls);
            if (!sqliteResult.success)
            {
                throw new Exception(String.Format("Error in AddShowSchedule. {0}", sqliteResult.message));
            }
        }
        internal void AddShowSchedule(ShowEntry showentry)
        {
            string sql = string.Format("INSERT INTO TVGuide(Channel,Title,Description,StartTime,Date,Time,Day,Duration,Properties) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                showentry.Channel, showentry.Title, showentry.Description, showentry.StartTime, showentry.Date, showentry.Time, showentry.Day, "", showentry.Properties);
            SQLiteResult sqliteResult = SQLite.Exec(DatabasePath, sql);

            if (!sqliteResult.success)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error in AddShowSchedule. {0}", sqliteResult.message));
            }
            else
            {
                SQLite.CloseConnection(sqliteResult);
            }
        }

        internal void EmptyTVGuideEntries(string channel)
        {
            string sql = String.Format("DELETE FROM TVGuide where Channel = '{0}'", channel);
            SQLiteResult sqliteresult = SQLite.Exec(DatabasePath, sql);
            if (!sqliteresult.success)
            {
                throw new Exception(String.Format("Error in EmptyTVGuideEntries. {0}", sqliteresult.message));
            }
        }

        public ScheduleItem GetScheduleItem(int id)
        {
            ScheduleItem scheduleItem = new ScheduleItem();
            Dictionary<string, bool> daysToRecord = new Dictionary<string, bool>();
            string sql = "SELECT * FROM RecordingSchedules WHERE ID = " + id;
            SQLiteResult sqliteResult = SQLite.Select(DatabasePath, sql);
            if (sqliteResult.success)
            {
                while (sqliteResult.reader.Read())
                {
                    scheduleItem.ID = Convert.ToInt32(sqliteResult.reader["ID"].ToString());
                    scheduleItem.ChannelToRecord = sqliteResult.reader["Channel"].ToString();
                    scheduleItem.StartTime = DateTime.Parse(sqliteResult.reader["StartTime"].ToString());
                    scheduleItem.EndTime = DateTime.Parse(sqliteResult.reader["EndTime"].ToString());
                    daysToRecord["Monday"] = sqliteResult.reader["Monday"].ToString() == "0" ? false : true;
                    daysToRecord["Tuesday"] = sqliteResult.reader["Tuesday"].ToString() == "0" ? false : true;
                    daysToRecord["Wednesday"] = sqliteResult.reader["Wednesday"].ToString() == "0" ? false : true;
                    daysToRecord["Thursday"] = sqliteResult.reader["Thursday"].ToString() == "0" ? false : true;
                    daysToRecord["Friday"] = sqliteResult.reader["Friday"].ToString() == "0" ? false : true;
                    daysToRecord["Saturday"] = sqliteResult.reader["Saturday"].ToString() == "0" ? false : true;
                    daysToRecord["Sunday"] = sqliteResult.reader["Sunday"].ToString() == "0" ? false : true;
                    scheduleItem.DaysToRecord = daysToRecord;
                    scheduleItem.Repeat = sqliteResult.reader["Repeat"].ToString() == "0" ? false : true;
                }
                SQLite.CloseConnection(sqliteResult);
            }
            else
            { 
                throw new Exception(String.Format("Error in GetScheduleItem. {0}", sqliteResult.message));
            }

            return scheduleItem;
        }

        public void AddScheduleItem(ScheduleItem schedule)
        {
            var days = schedule.DaysToRecord;
            var channel = schedule.ChannelToRecord;
            var starttime = schedule.StartTime.ToShortTimeString();
            var endtime = schedule.EndTime.ToShortTimeString();
            var repeat = schedule.Repeat;
            string sql = String.Format("INSERT INTO RecordingSchedules(Channel,StartTime,EndTime,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,Repeat) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}",
                channel, starttime, endtime, days["Monday"], days["Tuesday"], days["Wednesday"], days["Thursday"], days["Friday"], days["Saturday"], days["Sunday"], repeat);
            SQLiteResult sqliteResult = SQLite.Exec(DatabasePath, sql);
            if (!sqliteResult.success)
            { 
                throw new Exception(String.Format("Error in GetScheduleItem. {0}", sqliteResult.message));
            }
        }
        public List<ScheduleItem> GetScheduleItems()
        {
            List<ScheduleItem> scheduleItems = new List<ScheduleItem>();
            string sql = "SELECT * FROM RecordingSchedules";
            SQLiteResult sqliteResult = SQLite.Select(DatabasePath, sql);
            if (sqliteResult.success)
            {
                while (sqliteResult.reader.Read())
                {
                    Dictionary<string, bool> days = new Dictionary<string, bool>();
                    ScheduleItem scheduleItem = new ScheduleItem();
                    scheduleItem.ID = Convert.ToInt32(sqliteResult.reader["ID"].ToString());
                    scheduleItem.ChannelToRecord = sqliteResult.reader["Channel"].ToString();
                    scheduleItem.StartTime = DateTime.Parse(sqliteResult.reader["StartTime"].ToString(), new System.Globalization.CultureInfo("en-US"));
                    scheduleItem.EndTime = DateTime.Parse(sqliteResult.reader["EndTime"].ToString(), new System.Globalization.CultureInfo("en-US"));
                    days["Monday"] = sqliteResult.reader["Monday"].ToString() == "0" ? false : true;
                    days["Tuesday"] = sqliteResult.reader["Tuesday"].ToString() == "0" ? false : true;
                    days["Wednesday"] = sqliteResult.reader["Wednesday"].ToString() == "0" ? false : true;
                    days["Thursday"] = sqliteResult.reader["Thursday"].ToString() == "0" ? false : true;
                    days["Friday"] = sqliteResult.reader["Friday"].ToString() == "0" ? false : true;
                    days["Saturday"] = sqliteResult.reader["Saturday"].ToString() == "0" ? false : true;
                    days["Sunday"] = sqliteResult.reader["Sunday"].ToString() == "0" ? false : true;
                    scheduleItem.DaysToRecord = days;
                    scheduleItem.Repeat = sqliteResult.reader["Repeat"].ToString() == "0" ? false : true;
                    scheduleItems.Add(scheduleItem);
                }
                SQLite.CloseConnection(sqliteResult);
            }
            else 
            {
                throw new Exception(String.Format("Error in GetScheduleItem. {0}", sqliteResult.message));
            }

            return scheduleItems;
        }

        public void DeleteItem(int id)
        {
            string sql = "Delete FROM RecordingSchedules WHERE ID = " + id;
            SQLiteResult sqliteResult = SQLite.Exec(DatabasePath, sql);
            if (!sqliteResult.success)
            { 
                throw new Exception(String.Format("Error in GetScheduleItem. {0}", sqliteResult.message));
            }
            else
            {
                SQLite.CloseConnection(sqliteResult);
            }
        }

        public void InitializeTVGuideDatatable()
        {

        }

    }

}
