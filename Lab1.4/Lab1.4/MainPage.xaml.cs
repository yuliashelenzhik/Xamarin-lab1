using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab1._4
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            Random random = new Random();
            int rowCount = 7;
            int columnCount = 7;

            List<List<int>> numbersMatrix = new List<List<int>>();

            for (int row = 0; row < rowCount; row++)
            {
                List<int> rowNumbers = new List<int>();
                for (int column = 0; column < columnCount; column++)
                {
                    int randomNumber = random.Next(1, 100);
                    rowNumbers.Add(randomNumber);

                    Label label = new Label
                    {
                        Text = randomNumber.ToString(),
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    };

                    matrixGrid.Children.Add(label, column, row);
                }
                numbersMatrix.Add(rowNumbers);
            }

            List<Label> minLabels = new List<Label>();
            for (int column = 0; column < columnCount; column++)
            {
                var columnValues = numbersMatrix.Select(row => row[column]).ToList();
                int min = columnValues.Min();

                Label minLabel = new Label
                {
                    Text = min.ToString(),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    TextColor = Color.FromHex("#6F5060"),
                    FontAttributes = FontAttributes.Bold,
                    Padding = new Thickness(0, 20, 0, 0)
                };
                matrixGrid.Children.Add(minLabel, column, rowCount);
            }
        }
    }
}

