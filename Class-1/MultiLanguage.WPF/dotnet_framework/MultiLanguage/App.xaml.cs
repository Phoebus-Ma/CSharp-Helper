using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MultiLanguage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string Culture { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            GetCulture();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            SetCulture();
        }

        #region Method
        private void GetCulture()
        {
            Culture = string.Empty;

            try
            {
                Culture = MultiLanguage.Properties.Settings.Default.Culture.Trim();
            }
            catch (Exception)
            {
            }

            Culture = string.IsNullOrEmpty(Culture) ? "English" : Culture;

            UpdateCulture();
        }

        private void SetCulture()
        {
            try
            {
                MultiLanguage.Properties.Settings.Default.Culture = Culture;
                MultiLanguage.Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
            }
        }

        public static void UpdateCulture()
        {
            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();

            foreach (ResourceDictionary dictionary in Application.Current.Resources.MergedDictionaries)
            {
                dictionaryList.Add(dictionary);
            }

            string requestedCulture = string.Format(@"Language\Language.{0}.xaml", Culture);
            ResourceDictionary resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(requestedCulture));

            if (resourceDictionary == null)
            {
                requestedCulture = @"Language\Language.English.xaml";
                resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(requestedCulture));
            }

            if (resourceDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
        }
        #endregion
    }
}
