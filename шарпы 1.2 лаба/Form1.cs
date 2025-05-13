using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                if (intHeap is ArrayHeap<int> arrayHeap)
                    arrayHeap.PrintHorizontal(textList);
                else if (intHeap is LinkedHeap<int> linkedHeap)
                    linkedHeap.PrintHorizontal(textList);
                else
                    foreach (var item in intHeap)
                        textList.Text += item + " ";
            }
            else if (type == 2 && stringHeap != null)
            {
                if (stringHeap is ArrayHeap<string> arrayHeap)
                    arrayHeap.PrintHorizontal(textList);
                else if (stringHeap is LinkedHeap<string> linkedHeap)
                    linkedHeap.PrintHorizontal(textList);
                else
                    foreach (var item in stringHeap)
                        textList.Text += item + " ";
            }
            else if (type == 3 && personHeap != null)
            {
                if (personHeap is ArrayHeap<Person> arrayHeap)
                    arrayHeap.PrintHorizontal(textList);
                else if (personHeap is LinkedHeap<Person> linkedHeap)
                    linkedHeap.PrintHorizontal(textList);
                else
                    foreach (var item in personHeap)
                        textList.Text += item + " ";
            }
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

                    for (int i = 0; i < rnd.Next(5, 15); i++)
                    {
                        string res = "";
                        for (int j = 0; j < rnd.Next(5, 15); j++)
                            res += (char)('a' + rnd.Next(0, 25));
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

                    string[] names = { "Bob", "Alexey", "Mykola", "Ostap", "Maria",
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
                    intHeap.Remove(value);
                }
                if (type == 2)
                {
                    stringHeap.Remove(str);
                }
                if (type == 3)
                {
                    Person value = new Person(str);
                    personHeap.Remove(value);
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
                textList.Text += Environment.NewLine;
                if (type == 1)
                {
                    textList.Text += "Преобразованный список (значение увеличивается в 2 раза):" + Environment.NewLine;
                    HeapUtils<int>.ForEach(intHeap, elem => textList.Text += $"{elem * 2}; ");
                }
                if (type == 2)
                {
                    textList.Text += "Преобразованный список (добавлена строка):" + Environment.NewLine;
                    HeapUtils<string>.ForEach(stringHeap, elem => textList.Text += $"{elem}TEST; ");
                }
                if (type == 3)
                {
                    textList.Text += "Преобразованный список (добавлен 1 год к возрасту):" + Environment.NewLine;
                    HeapUtils<Person>.ForEach(personHeap, elem => textList.Text += $"{elem++}; ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FindAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (type == 1 && intHeap != null && !intHeap.isEmpty)
                {
                    intHeap = HeapUtils<int>.FindAll(
                        intHeap,
                        x => x % 2 == 0,
                        chkLinkedHeap.Checked ? HeapUtils<int>.LinkedHeapConstructor : HeapUtils<int>.ArrayHeapConstructor
                    );
                }
                else if (type == 2 && stringHeap != null && !stringHeap.isEmpty)
                {
                    stringHeap = HeapUtils<string>.FindAll(
                        stringHeap,
                        x => x.Length % 2 == 0,
                        chkLinkedHeap.Checked ? HeapUtils<string>.LinkedHeapConstructor : HeapUtils<string>.ArrayHeapConstructor
                    );
                }
                else if (type == 3 && personHeap != null && !personHeap.isEmpty)
                {
                    personHeap = HeapUtils<Person>.FindAll(
                        personHeap,
                        x => x.Age % 2 == 0,
                        chkLinkedHeap.Checked ? HeapUtils<Person>.LinkedHeapConstructor : HeapUtils<Person>.ArrayHeapConstructor
                    );
                }
                else
                {
                    MessageBox.Show("Куча не создана или пуста");
                    return;
                }

                PrintToTextBox();
                MessageBox.Show("Операция FindAll выполнена успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка в FindAll: {ex.Message}");
            }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}