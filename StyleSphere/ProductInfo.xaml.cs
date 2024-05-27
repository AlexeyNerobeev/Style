using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using System.IO;
using StyleLibrary;

namespace StyleSphere
{
    /// <summary>
    /// Логика взаимодействия для ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Window
    {
        private ShowProdInfo product;
        public List<ShowProdInfo> Products = new List<ShowProdInfo>();
        private string filePath = "Products.json";
        public ProductInfo(ShowProdInfo product)
        {
            InitializeComponent();

            this.product = product;

            ProdId.Text = product.ID.ToString();
            ProdName.Text = product.Name;
            BrandName.Text = product.Brand;
            Price.Text = product.Price.ToString();
            Size.Text = product.Size;
            Colors.Text = product.Color;
            ProdCount.Text = product.Count.ToString();
        }

        private void ChangeProd_Click(object sender, RoutedEventArgs e)
        {
            Change();
            Accounting accounting = new Accounting();
            this.Close();
            accounting.Show();
        }

        private void SaveDataToJson()
        {
            var option = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Products, option);
            File.WriteAllText(filePath, json);
        }

        public void Change()
        {
            int id = int.Parse(ProdId.Text);
            string name = ProdName.Text;
            string brand = BrandName.Text;
            int price = int.Parse(Price.Text);
            string size = Size.Text;
            string color = Colors.Text;
            int count = int.Parse(ProdCount.Text);

            product.UpdateValues(id, name, brand, price, size, color, count);

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if (json != "")
                {
                    Products = JsonSerializer.Deserialize<List<ShowProdInfo>>(json);
                }
            }
            Products.Add(product);
            SaveDataToJson();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Accounting accounting = new Accounting();
            this.Close();
            accounting.Show();
        }
    }
}
