using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AlgorithmsBar
{
    public partial class algorithmBar : Form
    {
        //MAIN PROGRAMM CYCLE
        public algorithmBar()
        {
            InitializeComponent();

            //radiobuttons for choose sort method
            insertionRadio.CheckedChanged += InsertionRadio_CheckedChanged;
            bubbleRadio.CheckedChanged += BubbleRadio_CheckedChanged;
            shellRadio.CheckedChanged += ShellRadio_CheckedChanged;
            mergeRadio.CheckedChanged += MergeRadio_CheckedChanged;
            quickRadio.CheckedChanged += QuickRadio_CheckedChanged;

            //create File
            createFileButton.Click += CreateFileButton_Click;

            //upload File
            uploadFileButton.Click += UploadFileButton_Click;

            //sort array
            sortButton.Click += SortButton_Click;
        }


        //VARIABLES AND ENUMERATIONS
        //variable for save arrays of numbers and strings
        private string initialText;
        private string sortedText;
        private int[] initialIntArray;
        private int[] sortedIntArray;
        static string visualizationText;

        //state of download of files resolution from checkbox
        //if it is "true", files "input.txt", "output.txt" are not downloaded to computer
        bool isDownloadForbidden;

        //algorithms of sorting
        enum Algorithm
        {
            BubbleSort, 
            InsertionSort,
            ShellSort,
            MergeSort,
            QuickSort
        }

        //current algorithm of sorting
        //set default method of sorting - insertion sort
        Algorithm currentSortAlgorithm = Algorithm.InsertionSort;


        //UPLOAD TEXT FILE
        //button for upload file
        private void UploadFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                string defaultPath = "C:\\Program files\\input.txt";
                string path = fileNameInput.Text != "" ? fileNameInput.Text : defaultPath;
                System.IO.StreamReader sr = new StreamReader(path);
                string text = sr.ReadToEnd();
                beforeArrayTextBox.Text = text;
                initialText = text;
                sr.Close();
            } catch
            {
                MessageBox.Show("File not found");
            }
        }


        //CREATE TEXT FILE
        //Button for creating file
        private void CreateFileButton_Click(object sender, EventArgs e)
        {
            int arraySize = getArraySize();
            int randomValue = getRandomValue();
            isDownloadForbidden = noDownloadCheckbox.Checked;
            initialText = CreateCustomArrayInTxtFile(arraySize, randomValue, isDownloadForbidden);

            beforeArrayTextBox.Text = initialText;
        }

        //Methods for creating file
        //get size of array from input
        private int getArraySize()
        {
            try
            {
                int arraySize = Int32.Parse(arraySizeInput.Text);
                if (arraySize < 0)
                {
                    MessageBox.Show("Array size must be a positive integer");
                    arraySizeInput.Focus();
                    return 0;
                }
                return arraySize;
            }
            catch
            {
                MessageBox.Show("Array size must be a positive integer");
                arraySizeInput.Focus();
                return 0;
            }
        }

        //get maximum value of random array elemrnts from input
        private int getRandomValue()
        {
            try
            {
                int randomValue = Int32.Parse(randomValueInput.Text);
                if (randomValue < 0)
                {
                    MessageBox.Show("Random value must be a positive integer");
                    randomValueInput.Focus();
                    return 0;
                }
                return randomValue;
            }
            catch
            {
                MessageBox.Show("Array size must be a positive integer");
                randomValueInput.Focus();
                return 0;
            }
        }

        //create array 
        //and save it in "input.txt" file if it is not forbidden
        public string CreateCustomArrayInTxtFile(int ArraySize, int MaxValue, bool isDownloadForbidden)
        {
            Random rand = new Random();
            String Text = "";
            for (int i = 0; i < ArraySize; i++)
            {
                String spase = i == (ArraySize - 1) ? "" : " ";
                Text = Text + rand.Next(MaxValue).ToString() + spase;
            }

            if (isDownloadForbidden == false)
            {
                // Запись файла
                String WritePath = @"C:\Program files\input.txt";
                System.IO.StreamWriter sw = new StreamWriter(WritePath, false, System.Text.Encoding.Default);

                sw.WriteLine(Text);
                sw.Close();
            }

            return Text;
        }


        //CREATE INTEGER ARRAY FROM STRING
        private int[] getIntArray(string initialText)
        {
            try
            {
                string[] stringArray = initialText.Split(' ');
                int[] intArray = new int[stringArray.Length];
                for (int i = 0; i < stringArray.Length; i++)
                {
                    intArray[i] = Int32.Parse(stringArray[i]);
                }
                return intArray;
            } catch
            {
                MessageBox.Show("You must input or download array");
                int[] intArray = { };
                return intArray;
            }
        }


        //SORTING
        //button for sort
        private void SortButton_Click(object sender, EventArgs e)
        {
            //currentSortAlgorithm = getSortAlgorithm();
            initialIntArray = getIntArray(beforeArrayTextBox.Text);
            visualizationText = "";
            switch (currentSortAlgorithm)
            {
                case Algorithm.BubbleSort:
                    sortedIntArray = BubbleSort(initialIntArray, initialIntArray.Length);
                    visualizationTextBox.Text = visualizationText;
                    break;
                case Algorithm.ShellSort:
                    sortedIntArray = ShellSort(initialIntArray, initialIntArray.Length);
                    visualizationTextBox.Text = visualizationText;
                    break;
                case Algorithm.MergeSort:
                    sortedIntArray = MergeSort(initialIntArray);
                    visualizationTextBox.Text = visualizationText;
                    break;
                case Algorithm.QuickSort:
                    sortedIntArray = new int[initialIntArray.Length];
                    initialIntArray.CopyTo(sortedIntArray, 0);
                    QuickSort(sortedIntArray, 0, sortedIntArray.Length - 1);
                    visualizationTextBox.Text = visualizationText;
                    break;
                default:
                    sortedIntArray = InsertionSort(initialIntArray, initialIntArray.Length);
                    visualizationTextBox.Text = visualizationText;
                    break;
            }

            getOutput();
        }

        //create string from sorted array
        //and save in file output.txt if it is not forbidden
        private void getOutput()
        {
            sortedText = "";
            for (int i = 0; i < sortedIntArray.Length; i++)
            {
                string space = i == sortedIntArray.Length - 1 ? "" : " ";
                sortedText += sortedIntArray[i] + space;
            }

            afterArrayTextBox.Text = sortedText;

            isDownloadForbidden = noDownloadCheckbox.Checked;
            if (isDownloadForbidden == false)
            {
                String WritePath = @"C:\Program files\output.txt";
                System.IO.StreamWriter sw = new StreamWriter(WritePath, false, System.Text.Encoding.Default);

                sw.WriteLine(sortedText);
                sw.Close();
            }
        }


        //get algorithm of sort from radiobuttons
        private Algorithm getSortAlgorithm()
        {
            if (bubbleRadio.Checked == true)
            {
                return Algorithm.BubbleSort;
            } else if (shellRadio.Checked == true) {
                return Algorithm.ShellSort;

            } else if(quickRadio.Checked == true)
            {
                return Algorithm.QuickSort;
            } else if (mergeRadio.Checked == true)
            {
                return Algorithm.MergeSort;
            } else
            {
                //default algorithm is insertion sort
                return Algorithm.InsertionSort; 
            }
        }



        //SORT METHODS
        private static int[] InsertionSort(int[] Array, int ArraySize)
        {
            //для отображения шагов сортировки в окне визуализации
            foreach (int num in Array)
            {
                visualizationText += num + " ";
            }
            visualizationText += " --> ";

            for (int i = 1; i < ArraySize; i++)
            {
                int j = i;
                while (j > 0 && Array[j - 1] > Array[j])
                {
                    int temp = Array[j - 1];
                    Array[j - 1] = Array[j];
                    Array[j] = temp;
                    j--;
                }

                foreach (int num in Array)
                {
                    visualizationText += num + " ";
                }
                visualizationText += "\n-->\n";
            }

            visualizationText = visualizationText.Substring(0, visualizationText.Length - 4);

            return Array;
        }


        private static int[] ShellSort(int[] Array, int ArraySize)
        {
            foreach (int num in Array)
            {
                visualizationText += num + " ";
            }
            visualizationText += " --> ";

            int step = ArraySize / 2;
            while (step > 0)
            {
                for (int k = 0; k < ArraySize; k++)
                {
                    for (int i = k; i < ArraySize; i += step)
                    {
                        int j = i;
                        while (j > 0 && j - step >= 0 && Array[j - step] > Array[j])
                        {
                            int temp = Array[j - step];
                            Array[j - step] = Array[j];
                            Array[j] = temp;
                            j -= step;

                            //visualization of this step
                            foreach (int num in Array)
                            {
                                visualizationText += num + " ";
                            }
                            visualizationText += "\n-->\n";
                        }
                    }
                }
                step /= 2;
            }

            visualizationText = visualizationText.Substring(0, visualizationText.Length - 4);

            return Array;
        }

        private static int[] BubbleSort(int[] Array, int ArraySize)
        {
            foreach (int num in Array)
            {
                visualizationText += num + " ";
            }
            visualizationText += " --> ";

            if (ArraySize < 2)
            {
                return Array;
            } else
            {
                bool isArraySorted = false;
                while(isArraySorted != true)
                {
                    isArraySorted = true;
                    for (int i = 0; i < ArraySize - 1 ; i++)
                    {                     
                        if (Array[i] > Array[i+1])
                        {
                            int swap = Array[i];
                            Array[i] = Array[i + 1];
                            Array[i + 1] = swap;
                            isArraySorted = false;
                        }
                    }
                    foreach (int num in Array)
                    {
                        visualizationText += num + " ";
                    }
                    visualizationText += " --> ";
                }

                visualizationText = visualizationText.Substring(0, visualizationText.Length - 4);

                return Array;
            }
        }

        private static int[] Merge(int[] arr1, int[] arr2)
        //должны передаваться 2 упорядоченных массива
        {

            int pointer1 = 0;
            int pointer2 = 0;
            int[] mergedArr = new int[arr1.Length + arr2.Length];

            visualizationText += "Getted arrays:     1)";
            foreach (int num in arr1)
            {
                visualizationText += num + " ";
            }
            visualizationText += "  2)";
            foreach (int num in arr2)
            {
                visualizationText += num + " ";
            }
            visualizationText += " -- >";

            for (int i = 0; i < mergedArr.Length; i++)
            {
                if (pointer2 >= arr2.Length && pointer1 < arr1.Length)
                {
                    mergedArr[i] = arr1[pointer1];
                    pointer1++;
                }
                else if (pointer1 >= arr1.Length && pointer2 < arr2.Length)
                {
                    mergedArr[i] = arr2[pointer2];
                    pointer2++;
                }
                else if (arr1[pointer1] <= arr2[pointer2])
                {
                    mergedArr[i] = arr1[pointer1];
                    pointer1++;
                }
                else if (arr1[pointer1] > arr2[pointer2])
                {
                    mergedArr[i] = arr2[pointer2];
                    pointer2++;
                }
                
            }

            visualizationText += "  Merged array: ";
            foreach (int num in mergedArr)
            {
                visualizationText += num + " ";
            }

            return mergedArr;
        }

        private static int[] MergeSort(int[] Array)
        {

            if (Array.Length < 2)
            {
                return Array;
            }
            else
            {
                int[] leftArr = new int[Array.Length / 2];
                //учитываем массив с нечетным количеством элементов
                int rightArrLength = Array.Length % 2 == 0 ? Array.Length / 2 : (Array.Length / 2) + 1;
                int[] rightArr = new int[rightArrLength];

                for (int i = 0; i < leftArr.Length; i++)
                {
                    leftArr[i] = Array[i];
                }
                for (int i = 0; i < rightArr.Length; i++)
                {
                    rightArr[i] = Array[leftArr.Length + i];
                }

                rightArr = MergeSort(rightArr);
                leftArr = MergeSort(leftArr);

                return Merge(leftArr, rightArr);
            }
        }

        private static void QuickSort(int[] Array, int start, int end)
        {
            foreach (int num in Array)
            {
                visualizationText += num + " ";
            }
            visualizationText += " --> ";

            if (start >= end)
            {
                return;
            }
            else
            {
                int pivot = getParts(Array, start, end);
                QuickSort(Array, start, pivot - 1);
                QuickSort(Array, pivot + 1, end);
            }

            visualizationText = visualizationText.Substring(0, visualizationText.Length - 2);
        }

        private static int getParts(int[] Array, int start, int end)
        {
            int wall = start;

            foreach (int num in Array)
            {
                visualizationText += num + " ";
            }
            visualizationText += " --> ";

            for (int i = start; i <= end; i++)
            {
                if (Array[i] <= Array[end])
                {
                    int swap = Array[wall];
                    Array[wall] = Array[i];
                    Array[i] = swap;
                    wall++;
                }
            }
            return wall - 1;
        }


        //RADIO BUTTONS CHANGES

        private void ShellRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (shellRadio.Checked == true)
            {
                algorithmName.Text = "Shell sort";
                complexity.Text = "The worst time - O(n²), \n the best time - O(n log² n)";
                currentSortAlgorithm = Algorithm.ShellSort;
                descriptionTextBox.Text = "Сортировка Шелла (англ. Shell sort) — алгоритм сортировки, являющийся усовершенствованным вариантом сортировки вставками. " +
                    "Идея метода Шелла состоит в сравнении элементов, стоящих не только рядом, но и на определённом расстоянии друг от друга. " +
                    "Иными словами — это сортировка вставками с предварительными «грубыми» проходами.";
            }
        }

        private void BubbleRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (bubbleRadio.Checked == true)
            {
                algorithmName.Text = "Bubble sort";
                complexity.Text = "O(n²)";
                currentSortAlgorithm = Algorithm.BubbleSort;
                descriptionTextBox.Text = "Алгоритм состоит из повторяющихся проходов по сортируемому массиву. " +
                    "За каждый проход элементы последовательно сравниваются попарно и, если порядок в паре неверный, " +
                    "выполняется обмен элементов. Проходы по массиву повторяются N-1 раз или до тех пор, " +
                    "пока на очередном проходе не окажется, что обмены больше не нужны";
            }
        }

        private void InsertionRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (insertionRadio.Checked == true)
            {
                algorithmName.Text = "Insertion sort";
                complexity.Text = "O(n²)";
                
                descriptionTextBox.Text = "Алгоритм сортировки, в котором элементы " +
                    "входной последовательности просматриваются по одному, и каждый новый " +
                    "поступивший элемент размещается в подходящее место среди ранее упорядоченных элементов";
                currentSortAlgorithm = Algorithm.InsertionSort;
            }
        }

        private void QuickRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (quickRadio.Checked == true)
            {
                algorithmName.Text = "Quick sort";
                complexity.Text = "The worst time - O(n²), \n the best time - O(n log n)\n average time - O(n log n)";
                currentSortAlgorithm = Algorithm.QuickSort;
                descriptionTextBox.Text = "Выбрать из массива опорный элемент. " +
                    "Сравнить все остальные элементы с опорным и переставить их в массиве так, " +
                    "чтобы разбить массив на три непрерывных отрезка, следующих друг за другом: " +
                    "«элементы меньшие опорного», «равные» и «большие». " +
                    "Для отрезков выполнить рекурсивно ту же последовательность операций, " +
                    "если длина отрезка больше единицы.";
            }
        }

        private void MergeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (mergeRadio.Checked == true)
            {
                algorithmName.Text = "Merge sort";
                complexity.Text = "The worst time - O(n log2 n), \n the best time - O(n log2 n)\n average time - O(n log2 n)";
                currentSortAlgorithm = Algorithm.MergeSort;
                descriptionTextBox.Text = "Сортируемый массив разбивается на две части примерно одинакового размера." +
                    "Каждая из получившихся частей сортируется отдельно, например — тем же самым алгоритмом. " +
                    "Два упорядоченных массива половинного размера соединяются в один.";
            }
        }

    }

}
