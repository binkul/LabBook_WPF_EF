﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace LabBook_WPF_EF.Commons
{
    public class WindowFunction : IPosition
    {
        public WindowParameter LoadWindowParamaters(string file)
        {
            WindowParameter windowParameter = new WindowParameter();

            string path = Directory.GetCurrentDirectory() + file;
            if (!File.Exists(path))
                return windowParameter;


            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(path);

                string x = xml.SelectSingleNode("//window/position/x").FirstChild.Value;
                string y = xml.SelectSingleNode("//window/position/y").FirstChild.Value;
                string width = xml.SelectSingleNode("//window/size/width").FirstChild.Value;
                string height = xml.SelectSingleNode("//window/size/height").FirstChild.Value;
                windowParameter.Left = double.Parse(x, CultureInfo.InvariantCulture);
                windowParameter.Top = double.Parse(y, CultureInfo.InvariantCulture);
                windowParameter.Width = double.Parse(width, CultureInfo.InvariantCulture);
                windowParameter.Height = double.Parse(height, CultureInfo.InvariantCulture);

                //XmlElement position = xml .Root.Element("window").Element("position");
                //windowParameter.Left = double.Parse(position.Element("x").Value, CultureInfo.InvariantCulture);
                //windowParameter.Top = double.Parse(position.Element("y").Value, CultureInfo.InvariantCulture);

                //XElement size = xml.Root.Element("window").Element("size");
                //windowParameter.Width = double.Parse(size.Element("width").Value, CultureInfo.InvariantCulture);
                //windowParameter.Height = double.Parse(size.Element("height").Value, CultureInfo.InvariantCulture);

                //XElement datagrid = xml.Root.Element("window").Element("datagrid");

                var items = xml.SelectNodes("//window/datagrid");
                if (items != null)
                {
                    foreach(XmlNode item in items)
                    {
                        string name = item.FirstChild.Name;
                        string value = item.FirstChild.InnerText;
                        windowParameter.AddColumnWidth(name, double.Parse(value));
                    }
                }
                //var root = xml.docu
                //foreach(var item in items)
                //{
                //    windowParameter.AddColumnWidth()
                //}

                //if (datagrid != null)
                //{
                //    IEnumerable<IDictionary<string, string>> data = (IEnumerable<IDictionary<string, string>>)datagrid.Elements();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przy zapisywaniu do pliku '" + file + "'\n" + ex.Message, "Błąd zapisu", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return windowParameter;
        }

        public bool SaveWindowParameters(WindowParameter parameter, string file)
        {
            bool result = true;

            var declaration = new XDeclaration("1.0", "utf-8", "yes");
            var comment = new XComment("Window position, size and DataGrid columns width");
            var parameters = new XElement("parameters");
            var window = new XElement("window");
            var dataGrid = new XElement("datagrid");
            var position = new XElement("position");
            var x = new XElement("x", parameter.Left);
            var y = new XElement("y", parameter.Top);
            var size = new XElement("size");
            var width = new XElement("width", parameter.Width);
            var height = new XElement("height", parameter.Height);

            try
            {

                position.Add(x);
                position.Add(y);
                size.Add(width);
                size.Add(height);
                window.Add(position);
                window.Add(size);

                int len = parameter.GridColumnWidth.Count;
                if (len > 0)
                {
                    foreach (KeyValuePair<string, double> column in parameter.GridColumnWidth)
                    {
                        XElement columnWidth = new XElement(column.Key, column.Value);
                        dataGrid.Add(columnWidth);
                    }
                    window.Add(dataGrid);
                }
                parameters.Add(window);

                XDocument xml = new XDocument { Declaration = declaration };
                xml.Add(comment);
                xml.Add(parameters);

                string path = Directory.GetCurrentDirectory() + file;
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    _ = Directory.CreateDirectory(Path.GetDirectoryName(path));

                xml.Save(path);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Błąd przy zapisywaniu do pliku '" + file + "'\n" + ex.Message, "Błąd zapisu", MessageBoxButton.OK, MessageBoxImage.Error);
                result = false;
            }

            return result;
        }
    }
}
