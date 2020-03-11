using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaesarsCode
{
    public partial class Form1 : Form
    {
        //FIELDS (VARIABLES)
        //text inputed in textBoxInput
        private string initialText;
        //text encrypted / decrypted with key
        private string handledText;
        //key for encrypting/decrypting inputed in textBoxKey
        private int key;

        //service fields
        private bool isKeyDefault = true;
        private bool isTextDefault = true;


        //form methods
        //FORM WORK (INITIALIZING)
        public Form1()
        {
            InitializeComponent();

            //textBoxInput
            textBoxInput.Text = "Input text";
            textBoxInput.Click += TextBoxInput_Click;
            textBoxInput.TextChanged += TextBoxInput_TextChanged;

            //textBoxKey
            textBoxKey.Text = "Input key for encrypting / decrypting";
            textBoxKey.Click += TextBoxKey_Click;

            //buttonEncrypt
            buttonEncrypt.Click += ButtonEncrypt_Click;

            //buttonDecrypt
            buttonDecrypt.Click += ButtonDecrypt_Click;

            //buttonClear
            buttonClear.Click += ButtonClear_Click;
        }


        //BUTTONS
        //click on buttonDecrypt
        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                key = Int32.Parse(textBoxKey.Text);
                initialText = textBoxInput.Text;
                handledText = Decrypt(initialText, key);
                textBoxOutput.Text = handledText;
            }
            catch
            {
                //if text was inputed as key
                MessageBox.Show("You must input number (integer)");
                textBoxKey.Focus();
            }
        }

        //click on buttonEncrypt
        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                key = Int32.Parse(textBoxKey.Text);
                initialText = textBoxInput.Text;
                handledText = Encrypt(initialText, key);
                textBoxOutput.Text = handledText;
            }
            catch
            {
                //if text was inputed as key
                MessageBox.Show("You must input number (integer)");
                textBoxKey.Focus();
            }
        }

        //click on buttonClear (clear all text iputs and reset bool variables)
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxInput.Text = "Input text";
            textBoxKey.Text = "Input key for encrypting / decrypting";
            textBoxOutput.Text = "";

            isKeyDefault = true;
            isTextDefault = true;
        }


        //TEXT INPUTS

        //textBoxKey
        private void TextBoxKey_Click(object sender, EventArgs e)
        {
            if (isKeyDefault == true)
            {
                textBoxKey.Text = "";
                isKeyDefault = false;
            }
        }

        //textBoxInput
        //click on textBoxInput
        private void TextBoxInput_Click(object sender, EventArgs e)
        {
            if (isTextDefault == true)
            {
                textBoxInput.Text = "";
                isTextDefault = false;
            }
            
        }

        //input text in textBoxInput
        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            initialText = textBoxInput.Text;
        }


        // METHODS FOR ENCRYPT / DECRYPT

        //Encrypt - shifts Unicode characters by "key" value
        public string Encrypt(string text, int key)
        {
            char[] initialCharArray = text.ToCharArray();
            //char[] decryptedCharArray = new char[initialCharArray.Length];

            string encryptedText = "";

            for (int i = 0; i < initialCharArray.Length; i++)
            {
                encryptedText += (char)(initialCharArray[i] + key);
            }

            return encryptedText;
        }

        //Decrypt - shifts Unicode characters by inversed "key" value
        public string Decrypt(string text, int key)
        {
            key = -key;
            return Encrypt(text, key);
        }
    }
}
