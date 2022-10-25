using ElementiumBrowser.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ElementiumBrowser.Functions;
namespace ElementiumBrowser.Controllers
{
    public class downloads
    {

        static DownloadedItem downloadedItem = new DownloadedItem();

        public static string view()
        {
            return Functions.view("downloads", "İndirilenler");
        }


        public static string getlist()
        {
            downloadedItem.ID = -1;
            var downloadedItems = downloadedItem.SelectList();

             string downloadData = "";

             foreach (DownloadedItem downloaditem in downloadedItems)
             {

                downloadData += "<div class=\"download-item\" file-id=\""+ downloaditem.ID + "\">" +
                                "<div class=\"item-icon\">" +
                                    "<img class=\"item-icon\">" +
                                "</div>" +
                                "<div class=\"item-content\" >"+
                                    "<div class=\"item-title\">"+ downloaditem.FileName+ "</div>" +
                                    "<div class=\"item-location\">" + downloaditem.FileURL + "</div>" +
                                    "<div class=\"item-info\">" + downloaditem.FileSize + " - " +downloadedItem.CreateDate+"</div>" +
                                "</div>" +
                                "<div>" +
                                    "<a href=\"#\" class=\"item-remove\">X</a>" +
                                "</div>" +
                            "</div>";
             }


             return downloadData;
        }

        public static string start(string file_id) {

            if (string.IsNullOrEmpty(file_id)) return "";
            int fid = Int32.Parse(file_id);

            downloadedItem.ID = fid;
            var downloadedItems = downloadedItem.SelectList();
            if (downloadedItems.Length <= 0) return "";

            Process.Start(downloadedItems[0].FilePath);
            return "";

        }

       /* public static bool addHistory(string _url, string _visit_date, string _page_title)
        {

            int entryID = Properties.Settings.Default.History.Count + 1;

            if (Functions.is_set(_url) && Functions.is_set(_visit_date) && Functions.is_set(_page_title))
            {
                Properties.Settings.Default.History.Add(entryID + "," + _url + "," + _visit_date + "," + _page_title);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static string deletehistory(string id)
        {
            try {
                foreach (string history in Properties.Settings.Default.History)
                {
                    string[] splitted_history = history.Split(',');
                    if (splitted_history[0] == id)
                    {
                        Properties.Settings.Default.History.Remove(history);
                    }
                }
                
            }
            catch
            {

            }
            return Functions.view("history", "Geçmiş");
        }

        public static string clearURL(string _url) {

            Uri process_uri = new Uri(_url);
            return process_uri.Host;

        }*/


    }
}
