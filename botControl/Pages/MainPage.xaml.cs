using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace botControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private string token;
        private string botName;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Auto_Click(object sender, RoutedEventArgs e)
        {
            token = tokenBox.Text;
            if(tokenBox.Text != "")
            {
                if (AutoBot())
                {
                    MessageBox.Show("Подключен к боту : " + botName);
                }
                else
                {
                    MessageBox.Show("Ошибка подлючение к боту, неверный токен");
                }
            }else
            {
                MessageBox.Show("Не введет токен");
            }
        }

        private bool AutoBot()
        {
            try
            {
                WebRequest request = WebRequest.Create("https://api.telegram.org/bot" + token + "/getMe");
                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string jsonResult = reader.ReadToEnd();
                        Classes.getMe.Root myDeserializedClass = JsonConvert.DeserializeObject<Classes.getMe.Root>(jsonResult);
                        botName = myDeserializedClass.result.username;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
