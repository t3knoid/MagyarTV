using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

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
            this.ConnnectionString = String.Format("Data Source={0};Version=3; FailIfMissing=True; Foreign Keys=True;", DatabasePath);
            CreateSchema();
        }

        private void CreateSchema()
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            string sql = Path.Combine(currentDirectory, "sqls", "CreateSchema.sqlite");

            if (!Directory.Exists(this.DatabaseDir))
            {
                try
                {
                    Directory.CreateDirectory(this.DatabaseDir);
                }
                catch (Exception ex)
                {
                    // Do something
                }
            }
            if (!File.Exists(this.DatabasePath))
            {
                try
                {
                    // Create database file
                    System.Data.SQLite.SQLiteConnection.CreateFile(this.DatabasePath);
                    using (SQLiteConnection conn = new SQLiteConnection(ConnnectionString))
                    {
                        conn.Open();

                        SQLiteCommand cmd = new SQLiteCommand(ConnnectionString, conn);
                        cmd.CommandText = File.ReadAllText(@sql);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Do something
                }
            }

        }


        public ScheduleItem GetScheduleItem(int id)
        {
            ScheduleItem scheduleItem = new ScheduleItem();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnnectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM RecordingSchedules WHERE ID = " + id;
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            Dictionary<string, bool> daysToRecord = new Dictionary<string, bool>();
                            while (reader.Read())
                            {
                                scheduleItem.ID = Convert.ToInt32(reader["ID"].ToString());
                                scheduleItem.ChannelToRecord = reader["Channel"].ToString();
                                scheduleItem.StartTime = DateTime.Parse(reader["StartTime"].ToString());
                                scheduleItem.EndTime = DateTime.Parse(reader["EndTime"].ToString());
                                daysToRecord["Monday"] = reader["Monday"].ToString() == "0" ? false : true;
                                daysToRecord["Tuesday"] = reader["Tuesday"].ToString() == "0" ? false : true;
                                daysToRecord["Wednesday"] = reader["Wednesday"].ToString() == "0" ? false : true;
                                daysToRecord["Thursday"] = reader["Thursday"].ToString() == "0" ? false : true;
                                daysToRecord["Friday"] = reader["Friday"].ToString() == "0" ? false : true;
                                daysToRecord["Saturday"] = reader["Saturday"].ToString() == "0" ? false : true;
                                daysToRecord["Sunday"] = reader["Sunday"].ToString() == "0" ? false : true;
                                scheduleItem.DaysToRecord = daysToRecord;
                                scheduleItem.Repeat = reader["Repeat"].ToString() == "0" ? false : true;
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error in GetScheduleItem. {0}", ex.Message));
            }

            return scheduleItem;
        }

        public int AddScheduleItem(ScheduleItem schedule)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(ConnnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO RecordingSchedules(Channel,StartTime,EndTime,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,Repeat) VALUES (@Channel,@StartTime,@EndTime,@Monday,@Tuesday,@Wednesday,@Thursday,@Friday,@Saturday,@Sunday,@Repeat)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Channel", schedule.ChannelToRecord);
                    cmd.Parameters.AddWithValue("@StartTime", schedule.StartTime.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@EndTime", schedule.EndTime.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@Monday", schedule.DaysToRecord["Monday"]);
                    cmd.Parameters.AddWithValue("@Tuesday", schedule.DaysToRecord["Tuesday"]);
                    cmd.Parameters.AddWithValue("@Wednesday", schedule.DaysToRecord["Wednesday"]);
                    cmd.Parameters.AddWithValue("@Thursday", schedule.DaysToRecord["Thursday"]);
                    cmd.Parameters.AddWithValue("@Friday", schedule.DaysToRecord["Friday"]);
                    cmd.Parameters.AddWithValue("@Saturday", schedule.DaysToRecord["Saturday"]);
                    cmd.Parameters.AddWithValue("@Sunday", schedule.DaysToRecord["Sunday"]);
                    cmd.Parameters.AddWithValue("@Repeat", schedule.Repeat);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(String.Format("Error in GetScheduleItem. {0}", ex.Message));
                    }
                }
                conn.Close();
            }
            return result;
        }
        public List<ScheduleItem> GetScheduleItems()
        {
            List<ScheduleItem> scheduleItems = new List<ScheduleItem>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnnectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM RecordingSchedules";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Dictionary<string, bool> daysToRecord = new Dictionary<string, bool>();
                                ScheduleItem scheduleItem = new ScheduleItem();
                                scheduleItem.ID = Convert.ToInt32(reader["ID"].ToString());
                                scheduleItem.ChannelToRecord = reader["Channel"].ToString();
                                scheduleItem.StartTime = DateTime.Parse(reader["StartTime"].ToString(),new System.Globalization.CultureInfo("en-US"));
                                scheduleItem.EndTime = DateTime.Parse(reader["EndTime"].ToString(), new System.Globalization.CultureInfo("en-US"));
                                daysToRecord["Monday"] = reader["Monday"].ToString() == "0" ? false : true;
                                daysToRecord["Tuesday"] = reader["Tuesday"].ToString() == "0" ? false : true;
                                daysToRecord["Wednesday"] = reader["Wednesday"].ToString() == "0" ? false : true;
                                daysToRecord["Thursday"] = reader["Thursday"].ToString() == "0" ? false : true;
                                daysToRecord["Friday"] = reader["Friday"].ToString() == "0" ? false : true;
                                daysToRecord["Saturday"] = reader["Saturday"].ToString() == "0" ? false : true;
                                daysToRecord["Sunday"] = reader["Sunday"].ToString() == "0" ? false : true;
                                scheduleItem.DaysToRecord = daysToRecord;
                                scheduleItem.Repeat = reader["Repeat"].ToString() == "0" ? false : true;
                                scheduleItems.Add(scheduleItem);
                            }
                            
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error in GetScheduleItem. {0}", ex.Message));
            }

            return scheduleItems;
        }

        public void DeleteItem(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnnectionString))
                {
                    conn.Open();
                    string sql = "Delete FROM RecordingSchedules WHERE ID = " + id;
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error in GetScheduleItem. {0}", ex.Message));
            }
        }


    }

}
