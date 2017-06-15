using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Frapid.Configuration;
using Frapid.Dashboard.ViewModels;
using Newtonsoft.Json;

namespace Frapid.Dashboard.Models
{
    public static class WidigetDashboardModel
    {
        public const string WidgetLocation = "/Tenants/{tenant}/Areas/Frapid.Dashboard/Widgets";

        public static List<string> GetAreas()
        {
            return Storage.GetDirectories(PathMapper.MapPath("/Areas"), "widgets");           
        }

        public static List<string> GetWidgets(string areaName)
        {
            var widgets = new List<string>();
            string areaRoot = PathMapper.MapPath("/Areas");
            string widgetPath = Path.Combine(areaRoot, $"{areaName}/widgets");

            if (!Storage.DirectoryExists(widgetPath))
            {
                return widgets;
            }

            widgets.AddRange(Storage.GetFiles(widgetPath, "*.html").Select(file => file.Replace(".html", "")));
            return widgets;
        }

        public static string SanitizePath(string filename)
        {
            return string.Join("-", filename.Split(Path.GetInvalidFileNameChars()));
        }

        public static void DeleteMy(string tenant, MyWidgetInfo info)
        {
            string container = PathMapper.MapPath($"{WidgetLocation.Replace("{tenant}", tenant)}/{info.Scope}/{info.Me}");

            string filePath = Path.Combine(container, SanitizePath(info.Name) + ".json");

            if (!Storage.FileExists(filePath))
            {
                return;
            }

            Storage.DeleteFile(filePath);
        }

        public static MyWidgetInfo GetMy(string tenant, MyWidgetInfo info)
        {
            string container = PathMapper.MapPath($"{WidgetLocation.Replace("{tenant}", tenant)}/{info.Scope}/{info.Me}");
            string filePath = Path.Combine(container, SanitizePath(info.Name) + ".json");

            if (!Storage.FileExists(filePath))
            {
                return info;
            }

            string contents = Storage.ReadAllText(filePath, new UTF8Encoding(false));
            info = JsonConvert.DeserializeObject<MyWidgetInfo>(contents);

            return info;
        }

        public static List<MyWidgetInfo> GetMy(string tenant, int userId, string scope)
        {
            var widgets = new List<MyWidgetInfo>();

            string container = PathMapper.MapPath($"{WidgetLocation.Replace("{tenant}", tenant)}/{scope}/{userId}");
            if (!Storage.DirectoryExists(container))
            {
                return widgets;
            }

            var files = Storage.GetFiles(container, "*.json");
            if (!files.Any())
            {
                return widgets;
            }

            foreach (var file in files)
            {
                string contents = Storage.ReadAllText(file/*.FullName*/, new UTF8Encoding(false));
                var info = JsonConvert.DeserializeObject<MyWidgetInfo>(contents);
                widgets.Add(info);
            }

            return widgets;
        }

        public static void SaveMy(string tenant, MyWidgetInfo info)
        {
            string container = PathMapper.MapPath($"{WidgetLocation.Replace("{tenant}", tenant)}/{info.Scope}/{info.Me}");

            if (!Storage.DirectoryExists(container))
            {
                Storage.CreateDirectory(container);
            }

            string filePath = Path.Combine(container, SanitizePath(info.Name) + ".json");

            foreach (var widget in info.Widgets)
            {
                widget.Scope = info.Scope;
            }

            string contents = JsonConvert.SerializeObject(info, Formatting.Indented);

            Storage.WriteAllText(filePath, contents, new UTF8Encoding(false));
        }
    }
}