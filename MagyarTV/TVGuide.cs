using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private Dictionary<string, int> month = new Dictionary<string, int>
        {
            { "Január", 1 },
            { "Február", 2 },
            { "Március", 3 },
            { "Április", 4 },
            { "Május", 5 },
            { "Június", 6 },
            { "Július", 7 },
            { "Augusztus", 8 },
            { "Szeptember", 9 },
            { "október", 10 },
            { "November", 11 },
            { "December", 12 }
        };

        private Dictionary<string, int> daysoftheweek = new Dictionary<string, int>
        {
            { "hétfő", 1 },
            { "kedd", 2 },
            { "szerda", 3 },
            { "csütörtök", 4 },
            { "péntek", 5 },
            { "szombat", 6 },
            { "vasárnap", 7 },
        };

        public TVGuide()
        {
            InitializeComponent();
        }

        private void TVGuide_Load(object sender, EventArgs e)
        {
            HtmlWeb browser = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument pageresult = browser.Load("http://tv.animare.hu/default.aspx?c=3&t=20190302");


            List<string> dateSeparatorList = GetdateSeparatorList(pageresult);
            Dictionary<string, List<ShowEntry>> showList = GetShowList(pageresult, dateSeparatorList);

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
                }
                else
                {
                    string showTitle = String.Empty;
                    string timeStart;
                    string description;
                    string showProperty;

                    HtmlAgilityPack.HtmlDocument pr = new HtmlAgilityPack.HtmlDocument();
                    pr.LoadHtml(show.InnerHtml);
                    try
                    {
                        string[] summaryTime = pr.DocumentNode.SelectSingleNode(summaryTimeXPath).InnerText.Split();
                        timeStart = summaryTime[0].Trim();
                        showTitle = String.Join(" ", summaryTime.Skip(1).ToArray());  // Remove first item after split
                    }
                    catch (Exception)
                    {
                        timeStart = "";
                        showTitle = "";
                    }
                    try
                    {
                        description = pr.DocumentNode.SelectSingleNode(descriptionXPath).InnerText;
                    }
                    catch (Exception)
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
            List<ShowDate> showDateList = new List<ShowDate>();
            string daterangeXPath = "//*[@id=\"ctl00_C_p\"]/div[@class=\"tvhead\"]/div[@class=\"tvheadtitle\"]/h2[@class=\"tvh2\"]";
            HtmlAgilityPack.HtmlNode startdate = pageresult.DocumentNode.SelectSingleNode(daterangeXPath);  // This will be used to get the starting date
            dateSeparatorList.Add(startdate.InnerText);
            showDateList.Add(GetShowDate(startdate.InnerText));  // Need to fix up day of the week here since it is not provided in the HTML data. Will have to calculate

            foreach (HtmlAgilityPack.HtmlNode dateSeparator in dateSeparators)
            {
                dateSeparatorList.Add(dateSeparator.InnerText);
                showDateList.Add(GetShowDate(dateSeparator.InnerText));
            }
            string[] parts1 = dateSeparatorList[0].Split();
            string[] parts2 = dateSeparatorList[7].Split();
            dateSeparatorList[0] = string.Join(" ", String.Join(" ", parts1.Take(3).ToArray()), parts2[parts2.Count() - 1]);
            return dateSeparatorList;
        }

        //private static string CalculateDayoftheWeek(string datestring)
        //{
        //    string[] parts = datestring.Trim().Split('.');


        //}

        /// <summary>
        /// Parses a given string and returns a ShowDate equivalent object using values from the given string.
        /// </summary>
        /// <param name="datestring">A string with date value.s</param>
        /// <returns>A ShowDate object with values from the given string.</returns>
        private static ShowDate GetShowDate(string datestring)
        {
            // A typical string to split are:
            // "2019. március 3. vasárnap"
            // "2019. március 2. - 8."
            string[] parts = datestring.Trim().Split('.');  
            ShowDate showDate = new ShowDate()
            {
                Year = parts[0].Trim(),
                Month = parts[1].Trim().Split(' ')[0],
                Day = parts[1].Trim().Split()[1],
                DayOfWeek = parts[2].Trim()
            };
            return showDate;
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
        public string StartTime { get; set; }
        public string Properties { get; set; }
        public string Description { get; set; }
    }
}
