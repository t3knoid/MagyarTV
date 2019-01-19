using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MagyarTV
{
    class Database
    {
        public string ConnnectionString;

        public Database()
        {
            ConnnectionString = "Data Source=Magyartv.sqlite;Version=3; FailIfMissing=True; Foreign Keys=True;";
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
                            while (reader.Read())
                            {
                                scheduleItem.ChannelToRecord = reader["Channel"].ToString();
                                //scheduleItem.StartTime = reader["StartTime"].ToString;
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            { }

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
                    cmd.Parameters.AddWithValue("@StartTime", schedule.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", schedule.EndTime);
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

                    }
                }
                conn.Close();
            }
            return result;
        }
    }

}
