using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Data.SqlClient;
using System.Data;
using FinalProject.Models;
using System.Reflection;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinalProject
{
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<User> userList = new ObservableCollection<User>();
        private ObservableCollection<Product> shoppingCart = new ObservableCollection<Product>();
        private ObservableCollection<Product> currentList = new ObservableCollection<Product>();
        private ObservableCollection<Feedback> feedbackList = new ObservableCollection<Feedback>();
        private decimal discountAmount = 0;
        private decimal subtotalAmount = 0;
        private decimal totalAmount = 0;


        SqlConnection conn = new SqlConnection();
        //private string conString = "SERVER = KARAN-PC; DATABASE = 2022Exam; USER ID = KaranWinter2022; PASSWORD = 12345";
        private string conString = "SERVER = LAPTOP-V3EC844G; DATABASE = 2022Exam; USER ID = PapaDario; PASSWORD = 12345";
        SqlCommand cmd;

        public MainPage()
        {
            this.InitializeComponent();
            loadUsers(userList);
        }

        public void loadFeedback(ObservableCollection<Feedback> list)
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "select * from Feedback;";
                cmd.CommandText = query;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string text = (string)reader["FeedbackText"];
                    list.Add(new Feedback { feedbackText = text });
                }
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public void loadAppetizers(ObservableCollection<Product> list)
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "select * from Appetizers;";
                cmd.CommandText = query;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["AppetizerID"];
                    string name = (string)reader["AppetizerName"];
                    decimal price = Math.Round((decimal)reader["AppetizerPrice"], 2);
                    list.Add(new Product { ProductId = id, ProductName = name, ProductPrice = price });
                }
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public void loadMains(ObservableCollection<Product> list)
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "select * from Mains;";
                cmd.CommandText = query;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["MainID"];
                    string name = (string)reader["MainName"];
                    decimal price = Math.Round((decimal)reader["MainPrice"], 2);
                    list.Add(new Product { ProductId = id, ProductName = name, ProductPrice = price });
                }
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public void loadSides(ObservableCollection<Product> list)
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "select * from Sides;";
                cmd.CommandText = query;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["SideID"];
                    string name = (string)reader["SideName"];
                    decimal price = Math.Round((decimal)reader["SidePrice"], 2);
                    list.Add(new Product { ProductId = id, ProductName = name, ProductPrice = price });
                }
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public void loadDesserts(ObservableCollection<Product> list)
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "select * from Desserts;";
                cmd.CommandText = query;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["DessertID"];
                    string name = (string)reader["DessertName"];
                    decimal price = Math.Round((decimal)reader["DessertPrice"], 2);
                    list.Add(new Product { ProductId = id, ProductName = name, ProductPrice = price });
                }
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }


        private void addToCart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var button = (Button)sender;
            int addedProduct = (int)button.Tag;
            string table = listLabel.Text;
            string pId = listLabel.Text.TrimEnd('s') + "Id";
            string pName = listLabel.Text.TrimEnd('s') + "Name";
            string pPrice = listLabel.Text.TrimEnd('s') + "Price";
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "select * from " + table + " where " + pId + " = " + addedProduct + ";";
                cmd.CommandText = query;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader[pId];
                    string name = (string)reader[pName];
                    decimal price = Math.Round((decimal)reader[pPrice], 2);
                    shoppingCart.Add(new Product { ProductId = id, ProductName = name, ProductPrice = price });
                    calculateTotal();
                }
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        private void appetizers_Click(object sender, RoutedEventArgs e)
        {
            listLabel.Text = "Appetizers";
            currentList.Clear();
            loadAppetizers(currentList);
        }

        private void mains_Click(object sender, RoutedEventArgs e)
        {
            listLabel.Text = "Mains";
            currentList.Clear();
            loadMains(currentList);
        }

        private void sides_Click(object sender, RoutedEventArgs e)
        {
            listLabel.Text = "Sides";
            currentList.Clear();
            loadSides(currentList);
        }

        private void dessert_Click(object sender, RoutedEventArgs e)
        {
            listLabel.Text = "Desserts";
            currentList.Clear();
            loadDesserts(currentList);
        }

        private void removeFromCart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var button = (Button)sender;
            string productToRemove = (string)button.Tag;
            foreach (Product product in shoppingCart)
            {
                if (product.ProductName == productToRemove)
                {
                    shoppingCart.Remove(product);
                    calculateTotal();
                    break;
                }
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            loadUsers(userList);
            bool signedIn = false;
            string inputName = username.Text;
            string inputPass = password.Text;
            foreach (User user in userList)
            {
                if (user.Username == inputName && user.Password == inputPass)
                {
                    signedIn = true;
                    error.Text = "";
                    username.Text = "";
                    password.Text = "";
                    username.Visibility = Visibility.Collapsed;
                    password.Visibility = Visibility.Collapsed;
                    login.Visibility = Visibility.Collapsed;
                    Register.Visibility = Visibility.Collapsed;
                    loggedIn.Visibility = Visibility.Visible;
                    loggedIn.Text = "Welcome " + user.Username;
                    logout.Visibility = Visibility.Visible;
                    if (user.Role == "Admin")
                    {
                        insertName.Visibility = Visibility.Visible;
                        insertPrice.Visibility = Visibility.Visible;
                        insertButton.Visibility = Visibility.Visible;
                        deleteButton.Visibility = Visibility.Visible;
                        feedback.Visibility = Visibility.Collapsed;
                        feedbackBox.Visibility = Visibility.Collapsed;
                        loadFeedback(feedbackList);
                        listOfFeedback.Visibility = Visibility.Visible;
                        feedbackLabel.Visibility = Visibility.Visible;
                    }
                    discountAmount = 10;
                    calculateTotal();
                }
            }
            if (signedIn == true)
            {
                error.Text = "";
            }
            else
            {
                error.Text = "User not found or wrong password!";
            }

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            bool userExists = false;
            string inputName = username.Text;
            string inputPass = password.Text;
            foreach (User user in userList)
            {
                if (user.Username == inputName)
                {
                    userExists = true;
                    break;
                }
            }
            if (userExists == false && inputName != "" && inputPass != "")
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "INSERT INTO Users (Username, UserPass) VALUES ('" + inputName + "', '" + inputPass + "');";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
                error.Text = "";
                username.Text = "";
                password.Text = "";
                username.Visibility = Visibility.Collapsed;
                password.Visibility = Visibility.Collapsed;
                login.Visibility = Visibility.Collapsed;
                Register.Visibility = Visibility.Collapsed;
                loggedIn.Visibility = Visibility.Visible;
                loggedIn.Text = "Welcome " + inputName;
                logout.Visibility = Visibility.Visible;
                discountAmount = 10;
                calculateTotal();
            }
            else
            {
                error.Text = "User exists or fields not complete!";
            }
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            adminText.Text = "";
            string prodName = insertName.Text;
            decimal prodPrice;
            bool isNumber = Decimal.TryParse(insertPrice.Text, out prodPrice);
            string table = listLabel.Text;
            string pName = listLabel.Text.TrimEnd('s') + "Name";
            string pPrice = listLabel.Text.TrimEnd('s') + "Price";

            if (prodName != "" && isNumber == true && table != "Pick a Category")
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "INSERT INTO " + table + " (" + pName + ", " + pPrice + ") VALUES ('" + prodName + "', " + prodPrice + ");";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    insertName.Text = "";
                    insertPrice.Text = "";
                    adminText.Text = "Successfully inserted";
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
                if (table == "Appetizers")
                {
                    currentList.Clear();
                    loadAppetizers(currentList);
                }
                else if (table == "Mains")
                {
                    currentList.Clear();
                    loadMains(currentList);
                }
                else if (table == "Sides")
                {
                    currentList.Clear();
                    loadSides(currentList);
                }
                else if (table == "Desserts")
                {
                    currentList.Clear();
                    loadDesserts(currentList);
                }
            }
            else
            {
                adminText.Text = "An error occured";
            }
        }

        private void feedback_Click(object sender, RoutedEventArgs e)
        {
            string feedbackText = feedbackBox.Text;
            if (feedbackText != "")
            {
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                try
                {
                    string query = "INSERT INTO Feedback (FeedbackText) VALUES ('" + feedbackText + "');";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    feedbackBox.Text = "Thanks for your feedback!";
                    feedbackBox.IsReadOnly = true;
                    feedback.IsEnabled = false;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        private void loadUsers(ObservableCollection<User> list)
        {
            list.Clear();
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "select * from Users;";
                cmd.CommandText = query;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["UserID"];
                    string name = (string)reader["UserName"];
                    string pass = (string)reader["UserPass"];
                    string role = (string)reader["UserRole"];
                    list.Add(new User { UserId = id, Username = name, Password = pass, Role = role });
                }
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            adminText.Text = "";
            string prodName = insertName.Text;
            decimal prodPrice;
            bool isNumber = Decimal.TryParse(insertPrice.Text, out prodPrice);
            string table = listLabel.Text;
            string pName = listLabel.Text.TrimEnd('s') + "Name";
            string pPrice = listLabel.Text.TrimEnd('s') + "Price";

            if (prodName != "" && isNumber == true && table != "Pick a Category")
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "DELETE FROM " + table + " WHERE " + pName + " = '" + prodName + "' AND " + pPrice + " = " + prodPrice + ";";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    insertName.Text = "";
                    insertPrice.Text = "";
                    adminText.Text = "Deleted successfully";
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
                if (table == "Appetizers")
                {
                    currentList.Clear();
                    loadAppetizers(currentList);
                }
                else if (table == "Mains")
                {
                    currentList.Clear();
                    loadMains(currentList);
                }
                else if (table == "Sides")
                {
                    currentList.Clear();
                    loadSides(currentList);
                }
                else if (table == "Desserts")
                {
                    currentList.Clear();
                    loadDesserts(currentList);
                }
            }
            else
            {
                adminText.Text = "An error occured";
            }
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            error.Text = "";
            username.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Visible;
            login.Visibility = Visibility.Visible;
            Register.Visibility = Visibility.Visible;
            loggedIn.Visibility = Visibility.Collapsed;
            loggedIn.Text = "";
            logout.Visibility = Visibility.Collapsed;
            insertName.Visibility = Visibility.Collapsed;
            insertPrice.Visibility = Visibility.Collapsed;
            insertButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
            feedbackList.Clear();
            feedbackBox.Visibility = Visibility.Visible;
            feedback.Visibility = Visibility.Visible;
            listOfFeedback.Visibility = Visibility.Collapsed;
            feedbackLabel.Visibility = Visibility.Collapsed;
            discountAmount = 0;
            calculateTotal();
        }

        private void calculateTotal()
        {
            subtotalAmount = 0;
            totalAmount = 0;

            foreach (Product product in shoppingCart)
            {
                decimal price = Math.Round(product.ProductPrice, 2);
                subtotalAmount += price;
            }
            totalAmount = Math.Round(subtotalAmount * ((100 - discountAmount) / 100) * 1.13m, 2);
            subtotal.Text = "Subtotal: $" + subtotalAmount;
            discount.Text = "Discount: " + Math.Round(discountAmount, 0) + "%";
            total.Text = "Total: $" + totalAmount;
        }

        private async void checkout_Click(object sender, RoutedEventArgs e)
        {
            if (shoppingCart.Count > 0)
            {
                var folder = await StorageFolder.GetFolderFromPathAsync("C:");
                var subFolder = await folder.CreateFolderAsync("Receipts", 
                    CreationCollisionOption.ReplaceExisting);
                var file = await subFolder.CreateFileAsync("receipt.txt", 
                    CreationCollisionOption.ReplaceExisting);
                List<string> output = new List<string>();
                output.Add("******Receipt******");
                output.Add($"{ "Item", -30}{ "Price", 6}");
                foreach (Product product in shoppingCart)
                {
                    string productName = product.ProductName;
                    decimal productPrice = Math.Round(product.ProductPrice, 2);
                    output.Add($"{ productName,-30}{ "$"+productPrice,6}");
                }
                output.Add($"{"Subtotal:",-30}{ "$" + subtotalAmount,6}");
                output.Add($"{"Discount:",-30}{ discountAmount + "%",6}");
                output.Add($"{"Total:",-30}{ "$" + totalAmount,6}");
                await Windows.Storage.FileIO.WriteLinesAsync(file, output);
                shoppingCart.Clear();
                calculateTotal();
            }
        }

    }
}
