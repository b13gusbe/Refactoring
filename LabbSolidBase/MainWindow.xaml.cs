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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LabbSolidBase.Interfaces;

namespace LabbSolidBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISortManager _sortManager;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SortingAlgorithm_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //This method is run if the selected value of the combo box with sorting algorithms changes.
            //Maybe do something here?
        }

        private void SortBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SortedList.Items.Clear();

            var selectedMethod = ((ComboBoxItem)SortingAlgorithm.SelectedItem).Content.ToString();

            var inputArray = InputText.Text.Split(',');
            if (!double.TryParse(inputArray[0], out var d))
            {
                //Implement sorting on strings if you want to.
            }
            else
            {
                var intArr = new int[inputArray.Length];
                for (var i = 0; i < inputArray.Length; i++)
                {
                    intArr[i] = int.Parse(inputArray[i]);
                }

                if (selectedMethod.Equals("Bubble Sort"))
                {
                    _sortManager = new BubbleSort();
                }
                else if (selectedMethod.Equals("Heap Sort"))
                {
                    _sortManager = new HeapSort();
                }
                else if (selectedMethod.Equals("Quick Sort"))
                {
                    _sortManager = new QuickSort();
                }

                _sortManager.ExecuteSort(ref intArr);

                foreach (var item in intArr)
                    SortedList.Items.Add(item);
            }
        }
    }
}
