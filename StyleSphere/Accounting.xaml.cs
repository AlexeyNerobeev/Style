using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;
using System.Runtime.ConstrainedExecution;
using StyleLibrary;

namespace StyleSphere
{
    /// <summary>
    /// Логика взаимодействия для Accounting.xaml
    /// </summary>
    public partial class Accounting : Window
    {
        public List<ShowProdInfo> Products = new List<ShowProdInfo>();
        private string filePath = "Products.json";

        public Accounting()
        {
            InitializeComponent();
            LoadDataFromJson();
        }

        private void LoadDataFromJson()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if(json != "")
                {
                    Products = JsonSerializer.Deserialize<List<ShowProdInfo>>(json);

                    foreach (ShowProdInfo product in Products)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Content = product.Name;
                        productPanel.Items.Add(item);
                    }
                }
            }
        }

        private void SaveDataToJson()
        {
            var option = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Products, option);
            File.WriteAllText(filePath, json);
        }

        private void NewTov_Click(object sender, RoutedEventArgs e)
        {
            ShowProdInfo newProduct = new ShowProdInfo(1, "Новый товар", "", 0, "", "", 0);
            Products.Add(newProduct);

            ListBoxItem item = new ListBoxItem();
            item.Content = newProduct.Name;

            productPanel.Items.Add(item);
        }

        private void Prod_Click(object sender, MouseButtonEventArgs e)
        {
            string item = productPanel.SelectedItem.ToString();
            if (item.Length > 0)
            {
                ListBoxItem selectedItem = (ListBoxItem)productPanel.SelectedItem;
                string itemName = selectedItem.Content.ToString();
                ShowProdInfo selectedProduct = Products.Find(p => p.Name == itemName);

                if (selectedProduct != null)
                {
                    ProductInfo productInfo = new ProductInfo(selectedProduct);
                    this.Close();
                    productInfo.Show();
                }
            }
        }

        private void DelTov_Click(object sender, RoutedEventArgs e)
        {
            if (productPanel.SelectedItem != null)
            {
                ListBoxItem selectedItem = (ListBoxItem)productPanel.SelectedItem;
                string itemName = selectedItem.Content.ToString();
                ShowProdInfo selectedProduct = Products.Find(p => p.Name == itemName);

                if (selectedProduct != null)
                {
                    Products.Remove(selectedProduct);
                    productPanel.Items.Remove(selectedItem);

                    if(Products.Count == 0)
                    {
                        ClearJsonFile();
                    }
                    else
                    {
                        SaveDataToJson();
                    }
                }
            }
        }

        public static void ClearJsonFile()
        {
            File.WriteAllText("Products.json", string.Empty);
        }

        private void Summ_Click(object sender, RoutedEventArgs e)
        {
            int totalSum = 0;
            foreach (ShowProdInfo product in Products)
            {
                totalSum += product.Price;
            }
            int totalCount = Products.Sum(p => p.Count);

            MessageBox.Show($"Общая стоимость всех товаров: {totalSum}\nОбщее количество товаров: {totalCount}");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(searchTextBox.Text, out int id))
            {
                ShowProdInfo product = Products.Find(p => p.ID == id);
                if (product != null)
                {
                    MessageBox.Show($"Товар найден: {product.Name}, Цена: {product.Price}");
                }
                else
                {
                    MessageBox.Show("Товар с указанным ID не найден.");
                }
            }
            else
            {
                MessageBox.Show("Введите корректный ID для поиска товара.");
            }
        }
    }
}
