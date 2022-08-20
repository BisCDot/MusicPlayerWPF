using MusicPlayer.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Windows;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void ApplicationStart(object sender, StartupEventArgs e)
        {
            Window login = new Login();
            login.Show();

            ObjectCache cache = MemoryCache.Default;
            string fileContents = cache["fileContents"] as string;
            if (fileContents == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                List<string> filePaths = new List<string>();
                filePaths.Add(@"E:\\Cache\token.txt");
                policy.ChangeMonitors.Add(new
                HostFileChangeMonitor(filePaths));
                fileContents = File.ReadAllText(@"E:\\Cache\token.txt");
                cache.Set("filecontents", fileContents, policy);
            }
            if (!string.IsNullOrEmpty(fileContents))
            {
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + fileContents);

                HttpResponseMessage responseUserStatus = await client.GetAsync("https://localhost:5001/api/Subscribers");
                if (responseUserStatus.StatusCode == HttpStatusCode.OK)
                {
                    var responseUser = await client.GetStringAsync("https://localhost:5001/api/Subscribers");
                    if (responseUser == "83h99UnCVN}.~1=AG]NU0gEekmqckTi&mDmEWByMw)")
                    {
                        login.Hide();

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                }

                HttpResponseMessage responseStatus = await client.GetAsync("https://localhost:5001/api/Customers");
                if (responseStatus.StatusCode == HttpStatusCode.OK)
                {
                    var responseAdmin = await client.GetStringAsync("https://localhost:5001/api/Customers");
                    if (responseAdmin == "[#B8^o&G{6U&n$#VF'(!}KTKfax8$((]#kh0,")
                    {
                        login.Hide();

                        AdminWindow mainWindow = new AdminWindow();
                        mainWindow.Show();
                    }
                }
            }
        }

        public App()
        {
        }
    }
}