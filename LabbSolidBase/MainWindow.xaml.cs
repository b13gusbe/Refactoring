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

namespace LabbSolidBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SortingAlgorithm_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //This method is run if the selected value of the combo box with sorting algorithms changes.
            //Maybe do something here?
        }
        //Hello test
        private void SortBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SortedList.Items.Clear();

            var selectedMethod = ((ComboBoxItem)SortingAlgorithm.SelectedItem).Content.ToString();

            var arr = InputText.Text.Split(',');
            if (!double.TryParse(arr[0], out var d))
            {
                //Implement sorting on strings if you want to.
            }
            else
            {
                var intArr = new int[arr.Length];
                for (var i = 0; i < arr.Length; i++)
                {
                    intArr[i] = int.Parse(arr[i]);
                }

                if (selectedMethod.Equals("Bubble Sort"))
                {
                    BubbleSort(ref intArr);
                }
                else if (selectedMethod.Equals("Heap Sort"))
                {
                    HeapSort(ref intArr);
                }
                else if (selectedMethod.Equals("Quick Sort"))
                {
                    QuickSort(ref intArr, 0, intArr.Length-1);
                }

                foreach (var item in intArr)
                    SortedList.Items.Add(item);
            }
        }

        static void BubbleSort(ref int[] intArr)
        {
            for (var j = 0; j <= intArr.Length - 2; j++)
            {
                for (var i = 0; i <= intArr.Length - 2; i++)
                {
                    if (intArr[i] <= intArr[i + 1]) continue;

                    (intArr[i + 1], intArr[i]) = (intArr[i], intArr[i + 1]);
                }
            }
        }

        static void QuickSort(ref int[] data, int left, int right)
        {
            var pivot = data[(left + right) / 2];
            var leftHold = left;
            var rightHold = right;
            
            while (leftHold < rightHold)
            {
                while ((data[leftHold] < pivot) && (leftHold <= rightHold)) leftHold++;
                while ((data[rightHold] > pivot) && (rightHold >= leftHold)) rightHold--;

                if (leftHold >= rightHold) continue;

                (data[leftHold], data[rightHold]) = (data[rightHold], data[leftHold]);
                if (data[leftHold] == pivot && data[rightHold] == pivot)
                    leftHold++;
            }
            if (left < leftHold - 1) QuickSort(ref data, left, leftHold - 1);
            if (right > rightHold + 1) QuickSort(ref data, rightHold + 1, right);
        }
        
        static void HeapSort(ref int[] data)
        {
            int heapSize = data.Length;

            for (int p = (heapSize - 1) / 2; p >= 0; --p)
                Heapify(ref data, heapSize, p);

            for (int i = data.Length - 1; i > 0; --i)
            {
                (data[i], data[0]) = (data[0], data[i]);

                --heapSize;
                Heapify(ref data, heapSize, 0);
            }
        }
        static void Heapify(ref int[] data, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest;

            if (left < heapSize && data[left] > data[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && data[right] > data[largest])
                largest = right;

            if (largest != index)
            {
                (data[index], data[largest]) = (data[largest], data[index]);

                Heapify(ref data, heapSize, largest);
            }
        }
    }
}
