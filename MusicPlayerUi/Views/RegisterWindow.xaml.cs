using MusicPlayer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicPlayer.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private async void btnResgiter_Click(object sender, RoutedEventArgs e)
        {
            var userName = txtUser.Text;
            var email = txtEmail.Text;
            var password = txtPass.Password;
            var user = new UserRegister() { Username = userName, Email = email, Password = password };
            string url = "https://localhost:5001/api/Auth/Register";
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var request = await client.PostAsync(url, data);
            var responseJson = await request.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(responseJson);
            if (request.StatusCode == HttpStatusCode.OK)
            {
                var success = jObject.GetValue("success").ToString();
                if (success == "True")
                {
                    MessageBox.Show("Đăng kí thành công");
                    this.Close();
                }
            }
            if (request.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = jObject.GetValue("errors").ToString();

                MessageBox.Show(error, "lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}