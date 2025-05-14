using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeapSolution;

namespace HeapSolution
{
    public partial class Form1 : Form
    {
        private IHeap<int> intHeap;
        private IHeap<string> stringHeap;
        private IHeap<Person> personHeap;
        private byte type; //1 - int, 2 - string, 3 - person
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            TypeLists.Items.Clear();
            TypeLists.Items.Add("Array heap");
            TypeLists.Items.Add("Linked heap");
            TypeLists.SelectedIndex = 0;
            convertComboBox.Items.Clear();
            convertComboBox.Items.Add("Array heap");
            convertComboBox.Items.Add("Linked heap");
            convertComboBox.Items.Add("Unmutable heap");
            convertComboBox.SelectedIndex = 0;
        }

        private void PrintToTextBox()
        {
            textList.Clear();

            if (type == 1 && intHeap != null)
            {
                textList.AppendText("Текущая куча (int):" + Environment.NewLine);
                intHeap.PrintHorizontal(textList);
            }
            else if (type == 2 && stringHeap != null)
            {
                textList.AppendText("Текущая куча (string):" + Environment.NewLine);
                stringHeap.PrintHorizontal(textList);
            }
            else if (type == 3 && personHeap != null)
            {
                textList.AppendText("Текущая куча (Person):" + Environment.NewLine);
                personHeap.PrintHorizontal(textList);
            }

            // Прокрутка вниз
            textList.SelectionStart = textList.Text.Length;
            textList.ScrollToCaret();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if (intRbtn.Checked) type = 1;
            if (stringRbtn.Checked) type = 2;
            if (personRbtn.Checked) type = 3;

            string selectedType = TypeLists.SelectedItem.ToString();

            try
            {
                if (type == 1)
                {
                    if (selectedType == "Array heap")
                        intHeap = new ArrayHeap<int>();
                    else if (selectedType == "Linked heap")
                        intHeap = new LinkedHeap<int>();

                    for (int i = 0; i < rnd.Next(5, 15); i++)
                        intHeap.Add(rnd.Next(500));

                    if (selectedType == "Unmutable heap")
                        intHeap = new UnmutableHeap<int>(intHeap);
                }
                else if (type == 2)
                {
                    if (selectedType == "Array heap")
                        stringHeap = new ArrayHeap<string>();
                    else if (selectedType == "Linked heap")
                        stringHeap = new LinkedHeap<string>();

                    string[] words = { "Apple", "Banana", "Cherry", "Dragon", "Elephant",
                                        "Falcon", "Giraffe", "Harbor", "Island", "Jungle",
                                        "Kitten", "Lemon", "Mountain", "Nebula", "Ocean",
                                        "Panda", "Quasar", "Rainbow", "Sunset", "Tiger" };

                    for (int i = 0; i < rnd.Next(5, 15); i++)
                    {
                        string res = words[rnd.Next(0,20)];
                        stringHeap.Add(res);
                    }

                    if (selectedType == "Unmutable heap")
                        stringHeap = new UnmutableHeap<string>(stringHeap);
                }
                else if (type == 3)
                {
                    if (selectedType == "Array heap")
                        personHeap = new ArrayHeap<Person>();
                    else if (selectedType == "Linked heap")
                        personHeap = new LinkedHeap<Person>();

                    string[] names = { "Valera", "Donald", "Joe", "Zhenya", "Maria",
                                    "Stepan", "Antony", "Olesya", "Oleg", "Svetlana" };

                    for (int i = 0; i < rnd.Next(5, 15); i++)
                    {
                        string name = names[rnd.Next(0, 9)];
                        byte age = (byte)rnd.Next(100);
                        personHeap.Add(new Person(name, age));
                    }

                    if (selectedType == "Unmutable heap")
                        personHeap = new UnmutableHeap<Person>(personHeap);
                }

                PrintToTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании кучи: {ex.Message}");
            }
        }

        private void ContainsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.TextContains.Text;

                if (type == 1)
                {
                    int value = int.Parse(str);
                    if (intHeap.Contains(value))
                    {
                        MessageBox.Show($"Элемент {value} существует в куче");
                    }
                    else
                        MessageBox.Show("Элемент не найден");
                }

                if (type == 2)
                {
                    if (stringHeap.Contains(str))
                    {
                        MessageBox.Show($"Элемент {str} существует в куче");
                    }
                    else
                        MessageBox.Show("Элемент не найден");
                }

                if (type == 3)
                {
                    Person value = new Person(str);
                    if (personHeap.Contains(value))
                    {
                        MessageBox.Show($"Элемент {value} существует в куче");
                    }
                    else
                        MessageBox.Show("Элемент не найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.textAdd.Text;
                if (type == 1)
                {
                    int value = int.Parse(str);
                    intHeap.Add(value);
                }
                if (type == 2)
                {
                    stringHeap.Add(str);
                }
                if (type == 3)
                {
                    Person value = new Person(str);
                    personHeap.Add(value);
                }
                this.textList.Clear();
                PrintToTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveBnt_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.textRemove.Text;
                if (type == 1)
                {
                    int value = int.Parse(str);
                    if (!intHeap.Remove(value)) MessageBox.Show("Элемент не найден");
                }
                if (type == 2)
                {
                    if (!stringHeap.Remove(str)) MessageBox.Show("Элемент не найден"); ;
                }
                if (type == 3)
                {
                    Person value = new Person(str);
                    if (!personHeap.Remove(value)) MessageBox.Show("Элемент не найден"); ;
                }
                this.textList.Clear();
                PrintToTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            if (type == 1)
            {
                intHeap.Clear();
            }
            if (type == 2)
            {
                stringHeap.Clear();
            }
            if (type == 3)
            {
                personHeap.Clear();
            }
            this.textList.Clear();
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            if (type == 1)
            {
                if (HeapUtils<int>.CheckForAll(intHeap, (int elem) => { return elem % 2 == 0; }))
                {
                    MessageBox.Show("В куче все элементы четные");
                }
                else
                {
                    MessageBox.Show("В куче НЕ все элементы четные");
                }
            }
            if (type == 2)
            {
                if (HeapUtils<string>.CheckForAll(stringHeap, (string elem) => { return elem.Length % 2 == 0; }))
                {
                    MessageBox.Show("В куче все элементы четной длины");
                }
                else
                {
                    MessageBox.Show("В куче НЕ все элементы четной длины");
                }
            }
            if (type == 3)
            {
                if (HeapUtils<Person>.CheckForAll(personHeap, (Person elem) => { return elem.Age % 2 == 0; }))
                {
                    MessageBox.Show("В куче возраст всех людей делится на 2");
                }
                else
                {
                    MessageBox.Show("В куче возраст НЕ всех людей делится на 2");
                }
            }
        }

        private void ForEachBtn_Click(object sender, EventArgs e)
        {
            try
            {
                textList.AppendText(Environment.NewLine + "Результат ForEach:" + Environment.NewLine);

                if (type == 1 && intHeap != null)
                {
                    var items = intHeap.ToList();
                    intHeap.Clear();
                    foreach (var elem in items)
                    {
                        intHeap.Add(elem * 2);
                    }
                    //var temp =;

                    //HeapUtils<int>.ForEach(intHeap, (int x) => { x *= 2; });
                    //intHeap.CopyTo(temp);
                    
                    intHeap.PrintHorizontal(textList);

                }
                else if (type == 2 && stringHeap != null)
                {

                    var items = stringHeap.ToList();
                    stringHeap.Clear();
                    foreach (var elem in items)
                    {
                        stringHeap.Add(elem + "TEST");
                    }
                    stringHeap.PrintHorizontal(textList);
                }
                else if (type == 3 && personHeap != null)
                {

                    var items = personHeap.ToList();
                    personHeap.Clear();
                    foreach (var elem in items)
                    {
                        personHeap.Add(new Person(elem.Name, (byte)(elem.Age + 1)));
                    }
                    personHeap.PrintHorizontal(textList);
                }
                else
                {
                    textList.AppendText("Куча не создана" + Environment.NewLine);
                }

                textList.SelectionStart = textList.Text.Length;
                textList.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка в ForEach: {ex.Message}");
            }
        }

        private void FindAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                textList.AppendText(Environment.NewLine + "Результат FindAll:" + Environment.NewLine);

                if (type == 1 && intHeap != null && !intHeap.isEmpty)
                {
                    var resultHeap = HeapUtils<int>.FindAll(
                        intHeap,
                        x => x % 2 == 0,
                        chkLinkedHeap.Checked ? HeapUtils<int>.LinkedHeapConstructor : HeapUtils<int>.ArrayHeapConstructor
                    );

                    resultHeap.PrintHorizontal(textList);
                }
                else if (type == 2 && stringHeap != null && !stringHeap.isEmpty)
                {
                    var resultHeap = HeapUtils<string>.FindAll(
                        stringHeap,
                        x => x.Length % 2 == 0,
                        chkLinkedHeap.Checked ? HeapUtils<string>.LinkedHeapConstructor : HeapUtils<string>.ArrayHeapConstructor
                    );

                    resultHeap.PrintHorizontal(textList);
                }
                else if (type == 3 && personHeap != null && !personHeap.isEmpty)
                {
                    var resultHeap = HeapUtils<Person>.FindAll(
                        personHeap,
                        x => x.Age % 2 == 0,
                        chkLinkedHeap.Checked ? HeapUtils<Person>.LinkedHeapConstructor : HeapUtils<Person>.ArrayHeapConstructor
                    );

                    resultHeap.PrintHorizontal(textList);
                }
                else
                {
                    textList.AppendText("Куча не создана или пуста" + Environment.NewLine);
                    return;
                }

                //textList.AppendText(Environment.NewLine + "Операция FindAll завершена" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                textList.AppendText("Ошибка в FindAll: " + ex.Message + Environment.NewLine);
            }

            // Прокрутка вниз
            textList.SelectionStart = textList.Text.Length;
            textList.ScrollToCaret();
        }


        private void ExistsBtn_Click(object sender, EventArgs e)
        {
            if (type == 1)
            {
                if (HeapUtils<int>.Exists(intHeap, (int elem) => { return elem % 2 == 0; }))
                {
                    MessageBox.Show("В куче содержатся четные элементы");
                }
                else
                {
                    MessageBox.Show("В куче НЕ содержатся четные элементы");
                }
            }
            else if (type == 2)
            {
                if (HeapUtils<string>.Exists(stringHeap, (string elem) => { return elem.Length % 2 == 0; }))
                {
                    MessageBox.Show("В куче содержатся элементы четной длины");
                }
                else
                {
                    MessageBox.Show("В куче НЕ содержатся элементы четной длины");
                }
            }
            else if (type == 3)
            {
                if (HeapUtils<Person>.Exists(personHeap, (Person elem) => { return elem.Age % 2 == 0; }))
                {
                    MessageBox.Show("В куче есть люди, чей возраст можно поделить на 2");
                }
                else
                {
                    MessageBox.Show("В куче НЕТ людей, чей возраст можно поделить на 2");
                }
            }
        }

        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string newType = convertComboBox.SelectedItem.ToString();

                if (type == 1 && intHeap != null)
                {
                    if (newType == "Array heap")
                        intHeap = HeapUtils<int>.FindAll(intHeap, x => true, HeapUtils<int>.ArrayHeapConstructor);
                    else if (newType == "Linked heap")
                        intHeap = HeapUtils<int>.FindAll(intHeap, x => true, HeapUtils<int>.LinkedHeapConstructor);
                    else if (newType == "Unmutable heap")
                        intHeap = new UnmutableHeap<int>(intHeap);
                }
                else if (type == 2 && stringHeap != null)
                {
                    if (newType == "Array heap")
                        stringHeap = HeapUtils<string>.FindAll(stringHeap, x => true, HeapUtils<string>.ArrayHeapConstructor);
                    else if (newType == "Linked heap")
                        stringHeap = HeapUtils<string>.FindAll(stringHeap, x => true, HeapUtils<string>.LinkedHeapConstructor);
                    else if (newType == "Unmutable heap")
                        stringHeap = new UnmutableHeap<string>(stringHeap);
                }
                else if (type == 3 && personHeap != null)
                {
                    if (newType == "Array heap")
                        personHeap = HeapUtils<Person>.FindAll(personHeap, x => true, HeapUtils<Person>.ArrayHeapConstructor);
                    else if (newType == "Linked heap")
                        personHeap = HeapUtils<Person>.FindAll(personHeap, x => true, HeapUtils<Person>.LinkedHeapConstructor);
                    else if (newType == "Unmutable heap")
                        personHeap = new UnmutableHeap<Person>(personHeap);
                }

                PrintToTextBox();
                MessageBox.Show($"Куча успешно преобразована в {newType}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при преобразовании: {ex.Message}");
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}



// Меняем исходную кучу
//var items = intHeap.ToList();
//intHeap.Clear();
//var newintHeap = intHeap.nodes;
//intHeap.Clear();
//foreach (var elem in newintHeap)
//{
//    intHeap.Add(elem);
////}
//int temp = 0;
//HeapUtils<int>.ForEach(intHeap, x => { temp = x; temp *= 2; x = temp; });
//intHeap.Clear();
//intHeap = newintHeap;
//intHeap.PrintHorizontal(textList);
//textBox.Text += "Преобразованный список (значение увеличивается в 2 раза):" + Environment.NewLine;
//intHeap = HeapUtils<int>.ConvertAll(intHeap, elem => elem * 2, HeapUtils<int>.ArrayHeapConstructor);
//HeapUtils<int>.ForEach(intHeap, elem => textList.Text += $"{elem}; ");
//intHeap.PrintHorizontal(textList);
