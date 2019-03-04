using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

namespace MagyarTV
{
    public partial class TVGuide : Form
    {

        public string Url { get; internal set; }
        public Dictionary<string, List<ShowEntry>> ShowsbyDate { get; internal set; }

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

        public TVGuide()
        {
            InitializeComponent();
        }

        private void TVGuide_Load(object sender, EventArgs e)
        {
            string pathToCachedFile = Path.Combine(Path.GetTempPath(), "MagyarTV-TVGuide-" + DateTime.Now.ToString("yyyy-dd-M-HH") + ".html"); // Web page is fetched at the very least on top of each hour
            HtmlAgilityPack.HtmlDocument htmlDocument = LoadFromCachedHtmlFile(pathToCachedFile);

            if (htmlDocument == null) // If there is no cached file, load it from the given URL
            {
                // Load from given URL
                HtmlWeb browser = new HtmlWeb();
                htmlDocument = browser.Load(Url);
                FileStream sw = new FileStream(pathToCachedFile, FileMode.Create);
                htmlDocument.Save(sw);
                sw.Close();
            }
            
            List<string> dateSeparatorList = GetdateSeparatorList(htmlDocument);
            Dictionary<string, List<ShowEntry>> showList = GetShowList(htmlDocument, dateSeparatorList);

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

        /// <summary>
        /// Creates a dictionary of shows for every given day.
        /// </summary>
        /// <param name="pageresult"></param>
        /// <param name="dateSeparatorList"></param>
        /// <returns></returns>
        private Dictionary<string, List<ShowEntry>> GetShowList(HtmlAgilityPack.HtmlDocument pageresult, List<string> dateSeparatorList)
        {
            HtmlAgilityPack.HtmlNodeCollection shows = pageresult.DocumentNode.SelectNodes("//*[starts-with(@id, \"tv\")]/div[contains(@class,\"w2\")]"); // Each node is a show entry.
            string descriptionXPath = "//*[contains(concat( \" \", @class, \" \" ), concat( \" \", \"w5\", \" \" ))]";
            string summaryTimeXPath = "//*[contains(concat( \" \", @class, \" \" ), concat( \" \", \"w33\", \" \" ))]";
            string showPropertyXPath = "//*[contains(concat( \" \", @class, \" \" ), concat( \" \", \"w4\", \" \" ))]";

            // Iterate the list of shows and group by date
            string dayoftheweekIndex = dateSeparatorList[0];
            List<ShowEntry> showsofthedayList = new List<ShowEntry>(); // Holds all of the shows for a given day
            Dictionary<string, List<ShowEntry>> showsbyDate = new Dictionary<string, List<ShowEntry>>();
            showsbyDate.Add(dayoftheweekIndex, showsofthedayList);
            string formattedDate = GetFormattedShowDate(dayoftheweekIndex);

            foreach (HtmlAgilityPack.HtmlNode show in shows)
            {
                if (String.IsNullOrEmpty(show.InnerText)) continue; // Make sure there is an entry

                string match = null;
                try
                {
                    match = dateSeparatorList.First(stringToCheck => stringToCheck.Contains(show.InnerText));  // Check if the item is a date separator
                }
                catch (Exception)
                {
                    match = null;
                }
                if (match != null) // The node is a date separator
                {
                    dayoftheweekIndex = match;
                    showsofthedayList = new List<ShowEntry>();
                    showsbyDate.Add(dayoftheweekIndex, showsofthedayList);
                    formattedDate = GetFormattedShowDate(dayoftheweekIndex);
                }
                else
                {
                    string showTitle = String.Empty;
                    DateTime timeStart; // nullable
                    string description;
                    string showProperty;

                    HtmlAgilityPack.HtmlDocument pr = new HtmlAgilityPack.HtmlDocument();
                    pr.LoadHtml(show.InnerHtml);
                    try
                    {
                        string[] summaryTime = pr.DocumentNode.SelectSingleNode(summaryTimeXPath).InnerText.Split();
                        string datetime = formattedDate + " " + summaryTime[0].Trim() + ":00";
                        CultureInfo culture = new CultureInfo("hu-HU");
                        timeStart = Convert.ToDateTime(datetime,culture);
                        timeStart = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(timeStart, TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time").Id, TimeZoneInfo.Local.Id);
                        showTitle = String.Join(" ", summaryTime.Skip(1).ToArray());  // Remove first item after split
                    }
                    catch (Exception ex)
                    {
                        timeStart = DateTime.MinValue;
                        showTitle = "";
                    }
                    try
                    {
                        description = pr.DocumentNode.SelectSingleNode(descriptionXPath).InnerText;
                    }
                    catch (Exception ex)
                    {
                        description = "";
                    }
                    try
                    {
                        showProperty = pr.DocumentNode.SelectSingleNode(showPropertyXPath).InnerText;
                    }
                    catch (Exception)
                    {
                        showProperty = "";
                    }
                    ShowEntry showEntry = new ShowEntry()
                    {
                        Title = showTitle,
                        Description = description,
                        Properties = showProperty,
                        StartTime = timeStart
                    };
                    showsbyDate[dayoftheweekIndex].Add(showEntry);
                }
            }

            return showsbyDate;
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
            string[] parts2 = dateSeparators[dateSeparators.Count-1].InnerText.Split();
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
        private void TVGuide_FormClosing(object sender, FormClosingEventArgs e)
        {

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
        public string Title { get; set; }
        public DateTime? StartTime { get; set; }
        public string Properties { get; set; }
        public string Description { get; set; }
    }
}
