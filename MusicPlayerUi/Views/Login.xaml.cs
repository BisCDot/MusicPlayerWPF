using MusicPlayer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace MusicPlayer.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private static readonly HttpClient _httpClient = new HttpClient();

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var email = txtUser.Text;
            var password = txtPass.Password;
            var user = new UserModel() { Email = email, Password = password };
            string url = "https://localhost:5001/api/Auth/login";

            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var request = await client.PostAsync(url, data);

            var responseJson = await request.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(responseJson);
            string urlSubscribers = "https://localhost:5001/api/Subscribers";
            string urlAdmin = "https://localhost:5001/api/Customers";
            if (request.StatusCode == HttpStatusCode.OK)
            {
                var token = jObject.GetValue("token").ToString();
                await File.WriteAllTextAsync(@"E:\\Cache\token.txt", token);
                //var sw = new StreamWriter(token, true);

                var success = jObject.GetValue("success").ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                HttpResponseMessage responseUserStatus = await client.GetAsync(urlSubscribers);
                if (responseUserStatus.StatusCode == HttpStatusCode.OK)
                {
                    string responseUser = await client.GetStringAsync(urlSubscribers);
                    if (success == "True" && responseUser == "83h99UnCVN}.~1=AG]NU0gEekmqckTi&mDmEWByMw)")
                    {
                        MessageBox.Show("Đăng nhập thành công user");
                        this.Hide();
                        Window login = new Login();
                        login.Hide();
                        login.Close();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("email và password không chính xác!", "email và password sai", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                HttpResponseMessage responseAdminStatus = await client.GetAsync(urlAdmin);
                if (responseAdminStatus.StatusCode == HttpStatusCode.OK)
                {
                    var responseAd = await client.GetStringAsync(urlAdmin);
                    if (success == "True" && responseAd == "[#B8^o&G{6U&n$#VF'(!}KTKfax8$((]#kh0,")
                    {
                        MessageBox.Show("Đăng nhập thành công");
                        this.Hide();
                        Window login = new Login();
                        login.Hide();
                        login.Close();
                        AdminWindow mainWindow = new AdminWindow();
                        mainWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("email và password không chính xác!", "email và password sai", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else if (request.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = jObject.GetValue("errors").ToString();

                MessageBox.Show(error, "lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }
    }
}