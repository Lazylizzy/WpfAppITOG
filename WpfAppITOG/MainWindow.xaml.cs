using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppITOG
/// <summary>
/// Логика взаимодействия для MainWindow.xaml
/// </summary>
{ 
public partial class MainWindow : Window
{


        public MainWindow()
    {
        InitializeComponent();
        foreach (UIElement el in SimpleButtonsGroup.Children) 
        {
            if (el is Button)
            {
                ((Button)el).Click += ButtonClick;
            }
        }
    }
    private void ButtonClick(Object sender, RoutedEventArgs e)
    {
        if (tbOut.Text == "0")
        {
            tbOut.Text = "";
        }
        try
        {
            string textButton = ((Button)e.OriginalSource).Content.ToString();
            if (textButton == "CE")
            {
                tbOut.Clear();
                tbOut.Text = "0";
            }
            else if (textButton == "←")
            {
                tbOut.Text = tbOut.Text.Remove(tbOut.Text.Length - 1);
                if (tbOut.Text == "") 
                {
                    tbOut.Text = "0";
                }
            }
            else if (textButton == "=") 
            {
                tbOut.Text = new DataTable().Compute(tbOut.Text, null).ToString().Replace(",", ".");

            }
            else tbOut.Text += textButton;
        }
        catch (Exception ex) 
        {

            MessageBox.Show(ex.Message);
        }
    }
    
}
}
