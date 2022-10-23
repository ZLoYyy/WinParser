using System;
using System.Collections.Generic;
using System.Text;
using WinParser.Data;

namespace WinParser.Tools
{
    public static class Setts
    {
        private static List<Key> _KEYS = new List<Key>()
        {
            new Key(){ Value = "d58dcb3c-4757-4457-9489-c6712fb2ac4c", WaitData = null},
            new Key(){ Value = "3e1a2404-e036-44ae-b259-bfb0f7cf6a87", WaitData = null},
        };
        private static Key _selectedKey;
        //НЕ Рабочий
        private static readonly string _KEY = "d58dcb3c-4757-4457-9489-c6712fb2ac4c";
        //Рабочий
        //private readonly string _KEY = "3e1a2404-e036-44ae-b259-bfb0f7cf6a87";

        private static readonly string _URL = @"https://rosreestr.gov.ru/wps/portal/p/cc_present/ir_egrn";

        public static string Key 
        {
            get 
            {
                foreach (Key keyItem in _KEYS) 
                {
                    if (keyItem.WaitData != null && (DateTime.Now - keyItem.WaitData.Value).TotalMinutes < 5)
                        continue;

                    _selectedKey = keyItem;
                    break;
                }
                if (_selectedKey != null)
                {
                    
                    return _selectedKey.Value;
                }
                else 
                    return string.Empty;
            }
        }  

        public static void SetWaitKey()
        {
            if (_selectedKey == null)
                return;

            _selectedKey.WaitData = DateTime.Now;
        }
        public static string[] KeySplit 
        {
            get => Key.Split('-');
        }

        public static string URL => _URL;
    }
}
