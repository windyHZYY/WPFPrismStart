﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace FeiyaoAutoBaseLib
{


    public static class LanguageTool
    {
        public static string AppCurrentLanguage { get; set; }

        public static Dictionary<string, string> KeyValues { get; set; }

        public static void SetLanguage(string key)
        {
            var resource = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(t => t.Source != null &&
                 t.Source.OriginalString != null &&
                 t.Source.OriginalString.Contains(key));

            if (resource != null)
                Application.Current.Resources.MergedDictionaries.Remove(resource);

            Application.Current.Resources.MergedDictionaries.Add(resource);

            Dictionary<string, string> keyValues = new Dictionary<string, string>();

            foreach (DictionaryEntry item in resource)
                keyValues.Add(item.Key.ToString(), item.Value.ToString());

            AppCurrentLanguage = key;
            KeyValues = keyValues;

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(key);
        }
    }
}
