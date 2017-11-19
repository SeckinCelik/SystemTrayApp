using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SystemTrayApp
{
    public class FileOperation
    {
        public static string folderPath = Properties.Settings.Default.FilefolderPath;
        private static string filePath = Properties.Settings.Default.FilePath;

        public static void WriteTofile(List<SystemTrayApp.SharedItems.CopyItems> str, bool append = true)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamWriter sw = new StreamWriter(filePath, append))
                    {
                        sw.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(str));

                    }
                }
                else
                {
                    File.Create(filePath);
                }
            }
            catch (Exception)
            {

            }
        }

        public static List<SystemTrayApp.SharedItems.CopyItems> ReadFile()
        {
            try
            {
                List<SystemTrayApp.SharedItems.CopyItems> itmList = new List<SystemTrayApp.SharedItems.CopyItems>();

                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SystemTrayApp.SharedItems.CopyItems>>(sr.ReadToEnd());
                        return obj;
                    }
                }
                return new List<SystemTrayApp.SharedItems.CopyItems>() { new SystemTrayApp.SharedItems.CopyItems { Text = "", Date = DateTime.Now } }; ;
            }
            catch (Exception ex)
            {
                return new List<SystemTrayApp.SharedItems.CopyItems>() { new SystemTrayApp.SharedItems.CopyItems { Text = "", Date = DateTime.Now } };
            }
        }

        public static void ReplaceKeyword(string value, string keyword)
        {
            try
            {

                var allData = ReadFile();

                var CopyItemsChanged = allData.Where(x => x.Id == Convert.ToInt32(value)).Select(x => x).SingleOrDefault();

                CopyItemsChanged.Keyword = keyword;

                allData.Except(new List<SystemTrayApp.SharedItems.CopyItems> {CopyItemsChanged }).Select(x => x).ToList().Add(CopyItemsChanged);

                WriteTofile(allData, false);
            }
            catch (Exception ex)
            {

            }
        }

        public static void DeleteByValue(string degr)
        {
            try
            {
                var readAll = ReadFile().Where(c => c.Id != Convert.ToInt32(degr));

                WriteTofile(readAll.ToList(), false);
            }
            catch (Exception ex)
            {

            }
        }

    }

}
