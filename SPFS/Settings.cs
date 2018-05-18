using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPFS
{
    class Settings
    {
        static FileInfo SettingsFile= new FileInfo("Settings.ini");
        static string FullName = SettingsFile.FullName;

        private static void IsExist()
        {

        }

        public static string ReedSettings(string aSection, string aKey)
        {
            //файл для настроек
            FileInfo SettingsFile = new FileInfo("Settings.ini");
            //получаем файл настроек 
            INIManager SettingsMngr = new INIManager(SettingsFile.FullName);
            IsExist();
            return SettingsMngr.GetPrivateString(aSection, aKey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSection">Секция</param>
        /// <param name="aKey">Ключ</param>
        /// <param name="aValue">Параметр</param>
        public static void WriteSettings(string aSection, string aKey, string aValue)
        {
            //файл для настроек
            FileInfo SettingsFile = new FileInfo("Settings.ini");
            //получаем файл настроек 
            INIManager SettingsMngr = new INIManager(SettingsFile.FullName);
            SettingsMngr.WritePrivateString(aSection, aKey, aValue);
        }

        private void SetSettings()
        {
            //файл для настроек
            //FileInfo SettingsFile = new FileInfo("Settings.ini");
            //получаем файл настроек 
            //INIManager SettingsMngr = new INIManager(SettingsFile.FullName);
            //если файл не существует,
            //if (!SettingsFile.Exists)
            //{
            //    MessageBox.Show("afqkf ytn");
            //     то создаём его
            //    CreateSettingsFile();
            //}
            //настройки окна
            //SettingsMngr.WritePrivateString("Window", "Width", this.Width.ToString());
            //SettingsMngr.WritePrivateString("Window", "Height", this.Height.ToString());
            //SettingsMngr.WritePrivateString("Window", "Top", this.Top.ToString());
            //SettingsMngr.WritePrivateString("Window", "Left", this.Left.ToString());

            //WriteSettings("Window", "Width", this.Width.ToString());
            //WriteSettings("Window", "Height", this.Height.ToString());
            //WriteSettings("Window", "Top", this.Top.ToString());
            //WriteSettings("Window", "Left", this.Left.ToString());

        }

        private void GetSettings()
        {
            //файл для настроек
            //FileInfo SettingsFile = new FileInfo("Settings.ini");
            ////получаем файл настроек 
            //INIManager SettingsMngr = new INIManager(SettingsFile.FullName);

            //Получить значение по ключу name из секции main
            //string name = SettingsMngr.GetPrivateString("main", "age");
            //this.Width= Convert.ToDouble(SettingsMngr.GetPrivateString("Window", "Width"));
            //this.Height = Convert.ToDouble(SettingsMngr.GetPrivateString("Window", "Height"));
            //this.Top = Convert.ToDouble(SettingsMngr.GetPrivateString("Window", "Top"));
            //this.Left = Convert.ToDouble(SettingsMngr.GetPrivateString("Window", "Left"));

            //string name = ReedSettings("main", "age");
            //this.Width = Convert.ToDouble(ReedSettings("Window", "Width"));
            //this.Height = Convert.ToDouble(ReedSettings("Window", "Height"));
            //this.Top = Convert.ToDouble(ReedSettings("Window", "Top"));
            //this.Left = Convert.ToDouble(ReedSettings("Window", "Left"));

            //настройки сервера
            //String URL="192.168.0.101";
            //URL=SettingsMngr.GetPrivateString("SQLServer", "URL");
        }

    }
}
