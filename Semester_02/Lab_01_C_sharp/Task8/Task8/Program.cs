using System;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass baseObj = new BaseClass();
            baseObj.text = "Base text";
            Console.WriteLine(baseObj.ToString());
            Console.WriteLine();

            SubClass subObj = new SubClass();
            subObj.text = "12 34";
            Console.WriteLine(subObj.ToString());
        }
    }

    class BaseClass
    {
        protected string textField;

        public virtual string text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        public override string ToString()
        {
            return ("Class: " + this.GetType() + "\ntext: " + text);
        }
    }

    class SubClass: BaseClass
    {
        protected string subTextField;

        public override string text
        {
            get
            {
                return textField + " " + subTextField;
            }
            set
            {
                int index = value.IndexOf(" ");
                if (index == -1)
                {
                    textField = value;
                    subTextField = "";
                } else
                {
                    textField = value.Substring(0, index);
                    subTextField = value.Substring(index + 1);
                }
            }
        }

        public override string ToString()
        {
            return ("Class: " + this.GetType() + "\ntext: " + text + 
                    "\nSubClass text fields: \n" + this.textField + "\n" + this.subTextField);
        }
    }
}
