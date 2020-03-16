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

        //state of download of files resolution from checkbox
        //if it is "true", files "input.txt", "output.txt" are not downloaded to computer
        bool isDownloadForbidden;

        //algorithms of sorting
        enum Algorithm
        {
            BubbleSort, 
            InsertionSort,
            ShellSort
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
            switch(currentSortAlgorithm)
            {
                case Algorithm.BubbleSort:
                    sortedIntArray = BubbleSort(initialIntArray, initialIntArray.Length);
                    break;
                case Algorithm.ShellSort:
                    break;
                default:
                    sortedIntArray = InsertionSort(initialIntArray, initialIntArray.Length);
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

            } else
            {
                //default algorithm is insertion sort
                return Algorithm.InsertionSort;
            }
        }



        //SORT METHODS
        private static int[] InsertionSort(int[] Array, int ArraySize)
        {
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
            }
            return Array;
        }

         private static int[] BubbleSort(int[] Array, int ArraySize)
        {
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
                }
                return Array;
            }
        }


        //RADIO BUTTONS CHANGES

        private void ShellRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (shellRadio.Checked == true)
            {
                algorithmName.Text = "Shell sort";
                complexity.Text = "The worst time - O(n²), \n the best time - O(n log² n)";
                currentSortAlgorithm = Algorithm.ShellSort;
            }
        }

        private void BubbleRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (bubbleRadio.Checked == true)
            {
                algorithmName.Text = "Bubble sort";
                complexity.Text = "O(n²)";
                currentSortAlgorithm = Algorithm.BubbleSort;
            }
        }

        private void InsertionRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (insertionRadio.Checked == true)
            {
                algorithmName.Text = "Insertion sort";
                complexity.Text = "O(n²)";
                currentSortAlgorithm = Algorithm.InsertionSort;
            }
        }


    }

}
