using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MagyarTV
{
    public class TVGuide
    {
        private Dictionary<string, string> months = new Dictionary<string, string>
        {
            { "január", "Jan" },
            { "február", "Feb" },
            { "március", "Mar" },
            { "április", "Apr" },
            { "május", "May" },
            { "június", "Jun" },
            { "július", "Jul" },
            { "augusztus", "Aug" },
            { "szeptember", "Sep" },
            { "október", "Oct" },
            { "november", "Nov" },
            { "december", "Dec" }
        };

        private Dictionary<string, string> daysoftheweek = new Dictionary<string, string>
        {
            { "hétfő", "Mon" },
            { "kedd", "Tue" },
            { "szerda", "Wed" },
            { "csütörtök", "Thu" },
            { "péntek", "Fri" },
            { "szombat", "Sat" },
            { "vasárnap", "Sun" },
        };

        string urlFormat = "http://tv.animare.hu/default.aspx?c={0}&t={1}";

        public TVGuide()
        {
            
        }

        public void Initialize(Dictionary<string, Channel> channels)
        {
            Database database = new Database();
            List<ShowEntry> allschedule = new List<ShowEntry>();

            foreach (KeyValuePair<string, Channel> channel in channels)
            {
                database.EmptyTVGuideEntries(channel.Key);
                List<ShowEntry> schedule = GetShowScheduleList(channels[channel.Key]);
                allschedule.AddRange(schedule);
            }

            database.AddShowSchedule(allschedule);

        }
        /// <summary>
        /// Gets a list of TV Guide schedule for a given channel
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        private List<ShowEntry> GetShowScheduleList(Channel channel)
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            string pathToCachedFile = Path.Combine(Path.GetTempPath(), "MagyarTV-TVGuide-" + channel.Name + "-" + DateTime.Now.ToString("yyyy-dd-M-HH") + ".html"); // Web page is fetched at the very least on top of each hour
            HtmlAgilityPack.HtmlDocument htmlDocument = LoadFromCachedHtmlFile(pathToCachedFile);

            if (htmlDocument == null) // If there is no cached file, load it from the given URL
            {
                string url = String.Format(urlFormat, channel.TVGuideEntry, today);
                HtmlWeb browser = new HtmlWeb();
                htmlDocument = browser.Load(url);
                FileStream sw = new FileStream(pathToCachedFile, FileMode.Create);
                htmlDocument.Save(sw);
                sw.Close();
            }

            List<string> dateSeparatorList = GetdateSeparatorList(htmlDocument);
            List<ShowEntry> showScheduleList = GetShowList(channel, htmlDocument, dateSeparatorList);

            return showScheduleList;
        }

        /// <summary>
        /// Load from a saved page
        /// </summary>
        /// <param name="cachedFile">Fully qualified path to the cache file.</param>
        /// <returns></returns>
        private HtmlAgilityPack.HtmlDocument LoadFromCachedHtmlFile(string cachedFile)
        {
            HtmlAgilityPack.HtmlWeb browser = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDocument = null;

            if (File.Exists(cachedFile))
            {
                try
                {
                    htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    string cachedHtmlFileText = File.ReadAllText(cachedFile);
                    htmlDocument.LoadHtml(cachedHtmlFileText);
                }
                catch (Exception ex)
                {
                    // Log failure here
                }
            }

            return htmlDocument;
        }

        private List<ShowEntry> GetShowList(Channel channel, HtmlAgilityPack.HtmlDocument pageresult, List<string> dateSeparatorList)
        {
            //HtmlAgilityPack.HtmlNodeCollection shows = pageresult.DocumentNode.SelectNodes("//*[starts-with(@id, \"tv\")]/div[contains(@class,\"w2\")]"); // Each node is a show entry.
            HtmlAgilityPack.HtmlNodeCollection shows = pageresult.DocumentNode.SelectNodes("//*/div[starts-with(@class,\"w2\")]"); // Each node is a show entry.
            string descriptionXPath = "//*[contains(concat( \" \", @class, \" \" ), concat( \" \", \"w5\", \" \" ))]";
            string summaryTimeXPath = "//*[contains(concat( \" \", @class, \" \" ), concat( \" \", \"w33\", \" \" ))]";
            string showPropertyXPath = "//*[contains(concat( \" \", @class, \" \" ), concat( \" \", \"w4\", \" \" ))]";

            // Iterate the list of shows and group by date
            string dayoftheweekIndex = dateSeparatorList[0];
            List<ShowEntry> showsofthedayList = new List<ShowEntry>(); // Holds all of the shows for a given day
            string formattedDate = GetFormattedShowDate(dayoftheweekIndex);

            foreach (HtmlAgilityPack.HtmlNode show in shows)
            {
                if (String.IsNullOrEmpty(show.InnerText)) continue; // Make sure there is an entry

                string match = null;
                try
                {
                    match = dateSeparatorList.Find(stringToCheck => stringToCheck.Equals(show.InnerText));  // Check if the item is a date separator
                }
                catch (Exception ex)
                {
                    match = null;
                }
                if (match != null) // The node is a date separator
                {
                    dayoftheweekIndex = match;
                    formattedDate = GetFormattedShowDate(dayoftheweekIndex);
                }
                else
                {
                    string showTitle = String.Empty;
                    DateTime timeStart; // nullable
                    string description;
                    string showProperty;
                    string day = String.Empty;
                    string date = String.Empty;
                    string time = String.Empty;

                    HtmlAgilityPack.HtmlDocument pr = new HtmlAgilityPack.HtmlDocument();
                    pr.LoadHtml(show.InnerHtml);
                    try
                    {
                        string[] summaryTime = pr.DocumentNode.SelectSingleNode(summaryTimeXPath).InnerText.Split();
                        string datetime = formattedDate + " " + summaryTime[0].Trim() + ":00";
                        CultureInfo culture = new CultureInfo("hu-HU");
                        timeStart = Convert.ToDateTime(datetime, culture);
                        timeStart = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(timeStart, TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time").Id, TimeZoneInfo.Local.Id); // Convert to localtime from CET
                        day = timeStart.DayOfWeek.ToString();
                        date = timeStart.ToString("d");
                        time = timeStart.ToString("HH:mm");
                        showTitle = String.Join(" ", summaryTime.Skip(1).ToArray());  // Remove first item after split
                        description = pr.DocumentNode.SelectSingleNode(descriptionXPath).InnerText;
                        showProperty = pr.DocumentNode.SelectSingleNode(showPropertyXPath).InnerText;
                        ShowEntry showEntry = new ShowEntry()
                        {
                            Channel = channel,
                            Title = showTitle.Trim(),
                            Description = description.Trim(),
                            Properties = showProperty.Trim(),
                            StartTime = timeStart,
                            Day = day,
                            Date = date,
                            Time = time,
                        };
                        showsofthedayList.Add(showEntry);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            return showsofthedayList;
        }

        private static List<string> GetdateSeparatorList(HtmlAgilityPack.HtmlDocument pageresult)
        {
            string dateSeparatorXPath = "//*[contains(concat( \" \", @class, \" \" ), concat( \" \", \"w2g\", \" \" ))]";
            HtmlAgilityPack.HtmlNodeCollection dateSeparators = pageresult.DocumentNode.SelectNodes(dateSeparatorXPath); // Date separators, e.g. 2019. március 3. vasárnap. Typically there is 7 on a page.
            List<string> dateSeparatorList = new List<string>(); // This holds a list of date separator strings. 

            string daterangeXPath = "//*[@id=\"ctl00_C_p\"]/div[@class=\"tvhead\"]/div[@class=\"tvheadtitle\"]/h2[@class=\"tvh2\"]";
            HtmlAgilityPack.HtmlNode startdate = pageresult.DocumentNode.SelectSingleNode(daterangeXPath);  // This will be used to get the first day/date of the current week schedule
            dateSeparatorList.Add(startdate.InnerText); // start the dateseparatorList with the startdate

            string[] parts1 = startdate.InnerText.Split();  // Fix up first entry with proper day of the week
            string[] parts2 = dateSeparators[dateSeparators.Count - 1].InnerText.Split();
            List<ShowDate> showDateList = new List<ShowDate>();
            dateSeparatorList[0] = string.Join(" ", String.Join(" ", parts1.Take(3).ToArray()), parts2[parts2.Count() - 1]);

            foreach (HtmlAgilityPack.HtmlNode dateSeparator in dateSeparators)
            {
                dateSeparatorList.Add(dateSeparator.InnerText);
            }

            return dateSeparatorList;
        }

        /// <summary>
        /// Parses a given string and returns a ShowDate equivalent object using values from the given string.
        /// </summary>
        /// <param name="datestring">A string with date value.s</param>
        /// <returns>A ShowDate object with values from the given string.</returns>
        private string GetFormattedShowDate(string datestring)
        {
            // A typical string to split are:
            // "2019. március 3. vasárnap"
            // "2019. március 2. - 8."
            string[] parts = datestring.Trim().Split('.');

            string Year = parts[0].Trim();
            string m = parts[1].Trim().Split(' ')[0];
            string Month = months[m.ToLower()];
            string Day = parts[1].Trim().Split()[1];
            string DayOfWeek = daysoftheweek[parts[2].Trim()];

            string formattedDate = String.Format("{0}, {1} {2} {3}", DayOfWeek, Day, Month, Year);  // "Sat, 10 May 2008 14:32:17 GMT"
            return formattedDate;
        }
    }

    public class ShowDate
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string DayOfWeek { get; set; }
    }

    public class ShowEntry
    {
        public Channel Channel { get; internal set; }
        public string Title { get; internal set; }
        public DateTime StartTime { get; internal set; }
        public string Date { get; internal set; }
        public string Time { get; internal set; }
        public string Day { get; internal set; }
        public string Properties { get; internal set; }
        public string Description { get; internal set; }
    }
}
