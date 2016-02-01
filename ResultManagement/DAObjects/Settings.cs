using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

namespace ResultManagement.DAObjects
{
    public class Settings
    {
        private string xmlFilePath;
        private DataTable table;


        public Settings(string xmlFilePath)
        {
            this.xmlFilePath = xmlFilePath;

            this.table = new DataTable();
            this.table.TableName = "Settings";
            this.table.Columns.Add("Name", typeof(string));
            this.table.Columns.Add("Value", typeof(string));

            this.table.ReadXml(xmlFilePath);
        }


        public object GetValue(string settingName, SettingType settingType)
        {
            string str = getValue(settingName);

            object val;

            if (str == null)
            {
                throw new Exception("SettingName not found");
            }
            else if (settingType == SettingType.String)
            {
                val = str;
            }
            else if (settingType == SettingType.Int32)
            {
                try
                {
                    val = Int32.Parse(str);
                }
                catch
                {
                    throw new Exception("SettingType mismatch");
                }
            }
            else if (settingType == SettingType.Color)
            {
                try
                {
                    val = Color.FromArgb(Int32.Parse(str));
                }
                catch
                {
                    throw new Exception("SettingType mismatch");
                }
            }
            else
            {
                throw new Exception("SettingType not defined");
            }

            return val;
        }


        private string getValue(string settingName)
        {
            foreach (DataRow dr in this.table.Rows)
            {
                if ((string)dr["Name"] == settingName)
                {
                    return (string)dr["Value"];
                }
            }

            return (string)null;
        }


        public void SetValue(string settingName, SettingType settingType, object value)
        {
            foreach (DataRow dr in this.table.Rows)
            {
                if ((string)dr["Name"] == settingName)
                {
                    if (settingType == SettingType.String)
                    {
                        dr["Value"] = (string)value;
                    }
                    else if (settingType == SettingType.Int32)
                    {
                        dr["Value"] = ((int)value).ToString();
                    }
                    else if (settingType == SettingType.Color)
                    {
                        dr["Value"] = ((Color)value).ToArgb().ToString();
                    }

                    return;
                }              
            }

            throw new Exception("SettingName not found");
        }


        public void Save()
        {
            this.table.WriteXml(this.xmlFilePath);
        }

        public void Reload()
        {
            this.table.Rows.Clear();
            this.table.ReadXml(this.xmlFilePath);
        }

    }


    //*****************************
    public enum SettingType
    {
        String = 0,
        Int32 = 1,
        Color = 3
    }

}
