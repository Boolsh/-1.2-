using System;
using System.Drawing;
using System.Windows.Forms;

namespace HeapSolution 
{ 
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExitBtn = new System.Windows.Forms.Button();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.intRbtn = new System.Windows.Forms.RadioButton();
            this.stringRbtn = new System.Windows.Forms.RadioButton();
            this.personRbtn = new System.Windows.Forms.RadioButton();
            this.TypeLists = new System.Windows.Forms.ComboBox();
            this.textList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextContains = new System.Windows.Forms.TextBox();
            this.textAdd = new System.Windows.Forms.TextBox();
            this.textRemove = new System.Windows.Forms.TextBox();
            this.ContainsBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.RemoveBnt = new System.Windows.Forms.Button();
            this.ConvertBtn = new System.Windows.Forms.Button();
            this.convertComboBox = new System.Windows.Forms.ComboBox();
            this.ExistsBtn = new System.Windows.Forms.Button();
            this.FindAllBtn = new System.Windows.Forms.Button();
            this.ForEachBtn = new System.Windows.Forms.Button();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.chkLinkedHeap = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitBtn.Location = new System.Drawing.Point(591, 472);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(102, 31);
            this.ExitBtn.TabIndex = 0;
            this.ExitBtn.Text = "Выход";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // CreateBtn
            // 
            this.CreateBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CreateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateBtn.Location = new System.Drawing.Point(247, 24);
            this.CreateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(102, 31);
            this.CreateBtn.TabIndex = 1;
            this.CreateBtn.Text = "Создать";
            this.CreateBtn.UseVisualStyleBackColor = false;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // intRbtn
            // 
            this.intRbtn.AutoSize = true;
            this.intRbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.intRbtn.Location = new System.Drawing.Point(11, 9);
            this.intRbtn.Margin = new System.Windows.Forms.Padding(2);
            this.intRbtn.Name = "intRbtn";
            this.intRbtn.Size = new System.Drawing.Size(41, 19);
            this.intRbtn.TabIndex = 2;
            this.intRbtn.TabStop = true;
            this.intRbtn.Text = "Int";
            this.intRbtn.UseVisualStyleBackColor = true;
            // 
            // stringRbtn
            // 
            this.stringRbtn.AutoSize = true;
            this.stringRbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stringRbtn.Location = new System.Drawing.Point(62, 9);
            this.stringRbtn.Margin = new System.Windows.Forms.Padding(2);
            this.stringRbtn.Name = "stringRbtn";
            this.stringRbtn.Size = new System.Drawing.Size(63, 19);
            this.stringRbtn.TabIndex = 3;
            this.stringRbtn.TabStop = true;
            this.stringRbtn.Text = "String";
            this.stringRbtn.UseVisualStyleBackColor = true;
            // 
            // personRbtn
            // 
            this.personRbtn.AutoSize = true;
            this.personRbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.personRbtn.Location = new System.Drawing.Point(139, 9);
            this.personRbtn.Margin = new System.Windows.Forms.Padding(2);
            this.personRbtn.Name = "personRbtn";
            this.personRbtn.Size = new System.Drawing.Size(70, 19);
            this.personRbtn.TabIndex = 4;
            this.personRbtn.TabStop = true;
            this.personRbtn.Text = "Person";
            this.personRbtn.UseVisualStyleBackColor = true;
            // 
            // TypeLists
            // 
            this.TypeLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeLists.FormattingEnabled = true;
            this.TypeLists.Location = new System.Drawing.Point(37, 32);
            this.TypeLists.Margin = new System.Windows.Forms.Padding(2);
            this.TypeLists.Name = "TypeLists";
            this.TypeLists.Size = new System.Drawing.Size(149, 23);
            this.TypeLists.TabIndex = 5;
            // 
            // textList
            // 
            this.textList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textList.Location = new System.Drawing.Point(34, 59);
            this.textList.Margin = new System.Windows.Forms.Padding(2);
            this.textList.Multiline = true;
            this.textList.Name = "textList";
            this.textList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textList.Size = new System.Drawing.Size(659, 196);
            this.textList.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 340);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Найти элемент";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(219, 340);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Добавление:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(425, 340);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Удаление:";
            // 
            // TextContains
            // 
            this.TextContains.Location = new System.Drawing.Point(21, 376);
            this.TextContains.Margin = new System.Windows.Forms.Padding(2);
            this.TextContains.Name = "TextContains";
            this.TextContains.Size = new System.Drawing.Size(146, 20);
            this.TextContains.TabIndex = 11;
            // 
            // textAdd
            // 
            this.textAdd.Location = new System.Drawing.Point(222, 376);
            this.textAdd.Margin = new System.Windows.Forms.Padding(2);
            this.textAdd.Name = "textAdd";
            this.textAdd.Size = new System.Drawing.Size(146, 20);
            this.textAdd.TabIndex = 12;
            // 
            // textRemove
            // 
            this.textRemove.Location = new System.Drawing.Point(428, 376);
            this.textRemove.Margin = new System.Windows.Forms.Padding(2);
            this.textRemove.Name = "textRemove";
            this.textRemove.Size = new System.Drawing.Size(146, 20);
            this.textRemove.TabIndex = 13;
            // 
            // ContainsBtn
            // 
            this.ContainsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContainsBtn.Location = new System.Drawing.Point(21, 419);
            this.ContainsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ContainsBtn.Name = "ContainsBtn";
            this.ContainsBtn.Size = new System.Drawing.Size(92, 25);
            this.ContainsBtn.TabIndex = 14;
            this.ContainsBtn.Text = "Найти";
            this.ContainsBtn.UseVisualStyleBackColor = true;
            this.ContainsBtn.Click += new System.EventHandler(this.ContainsBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.Location = new System.Drawing.Point(222, 420);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(92, 24);
            this.AddBtn.TabIndex = 15;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // RemoveBnt
            // 
            this.RemoveBnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveBnt.Location = new System.Drawing.Point(428, 420);
            this.RemoveBnt.Margin = new System.Windows.Forms.Padding(2);
            this.RemoveBnt.Name = "RemoveBnt";
            this.RemoveBnt.Size = new System.Drawing.Size(92, 24);
            this.RemoveBnt.TabIndex = 16;
            this.RemoveBnt.Text = "Удалить";
            this.RemoveBnt.UseVisualStyleBackColor = true;
            this.RemoveBnt.Click += new System.EventHandler(this.RemoveBnt_Click);
            // 
            // ConvertBtn
            // 
            this.ConvertBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConvertBtn.Location = new System.Drawing.Point(428, 11);
            this.ConvertBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ConvertBtn.Name = "ConvertBtn";
            this.ConvertBtn.Size = new System.Drawing.Size(102, 37);
            this.ConvertBtn.TabIndex = 17;
            this.ConvertBtn.Text = "ConvertAll";
            this.ConvertBtn.UseVisualStyleBackColor = true;
            this.ConvertBtn.Click += new System.EventHandler(this.ConvertBtn_Click);
            // 
            // convertComboBox
            // 
            this.convertComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.convertComboBox.FormattingEnabled = true;
            this.convertComboBox.Location = new System.Drawing.Point(553, 19);
            this.convertComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.convertComboBox.Name = "convertComboBox";
            this.convertComboBox.Size = new System.Drawing.Size(149, 23);
            this.convertComboBox.TabIndex = 5;
            // 
            // ExistsBtn
            // 
            this.ExistsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExistsBtn.Location = new System.Drawing.Point(56, 278);
            this.ExistsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ExistsBtn.Name = "ExistsBtn";
            this.ExistsBtn.Size = new System.Drawing.Size(78, 37);
            this.ExistsBtn.TabIndex = 18;
            this.ExistsBtn.Text = "Exists";
            this.ExistsBtn.UseVisualStyleBackColor = true;
            this.ExistsBtn.Click += new System.EventHandler(this.ExistsBtn_Click);
            // 
            // FindAllBtn
            // 
            this.FindAllBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindAllBtn.Location = new System.Drawing.Point(189, 278);
            this.FindAllBtn.Margin = new System.Windows.Forms.Padding(2);
            this.FindAllBtn.Name = "FindAllBtn";
            this.FindAllBtn.Size = new System.Drawing.Size(78, 37);
            this.FindAllBtn.TabIndex = 19;
            this.FindAllBtn.Text = "FindAll";
            this.FindAllBtn.UseVisualStyleBackColor = true;
            this.FindAllBtn.Click += new System.EventHandler(this.FindAllBtn_Click);
            // 
            // ForEachBtn
            // 
            this.ForEachBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForEachBtn.Location = new System.Drawing.Point(325, 278);
            this.ForEachBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ForEachBtn.Name = "ForEachBtn";
            this.ForEachBtn.Size = new System.Drawing.Size(78, 37);
            this.ForEachBtn.TabIndex = 20;
            this.ForEachBtn.Text = "ForEach";
            this.ForEachBtn.UseVisualStyleBackColor = true;
            this.ForEachBtn.Click += new System.EventHandler(this.ForEachBtn_Click);
            // 
            // CheckBtn
            // 
            this.CheckBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckBtn.Location = new System.Drawing.Point(458, 278);
            this.CheckBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(78, 37);
            this.CheckBtn.TabIndex = 21;
            this.CheckBtn.Text = "CheckAll";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearBtn.Location = new System.Drawing.Point(588, 278);
            this.ClearBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(78, 37);
            this.ClearBtn.TabIndex = 22;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // chkLinkedHeap
            // 
            this.chkLinkedHeap.Location = new System.Drawing.Point(591, 477);
            this.chkLinkedHeap.Name = "chkLinkedHeap";
            this.chkLinkedHeap.Size = new System.Drawing.Size(104, 24);
            this.chkLinkedHeap.TabIndex = 0;
            this.chkLinkedHeap.Text = "Создать LinkedHeap";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 522);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.CheckBtn);
            this.Controls.Add(this.ForEachBtn);
            this.Controls.Add(this.FindAllBtn);
            this.Controls.Add(this.ExistsBtn);
            this.Controls.Add(this.ConvertBtn);
            this.Controls.Add(this.RemoveBnt);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.ContainsBtn);
            this.Controls.Add(this.textRemove);
            this.Controls.Add(this.textAdd);
            this.Controls.Add(this.TextContains);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textList);
            this.Controls.Add(this.convertComboBox);
            this.Controls.Add(this.TypeLists);
            this.Controls.Add(this.personRbtn);
            this.Controls.Add(this.stringRbtn);
            this.Controls.Add(this.intRbtn);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.chkLinkedHeap);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.RadioButton intRbtn;
        private System.Windows.Forms.RadioButton stringRbtn;
        private System.Windows.Forms.RadioButton personRbtn;
        private System.Windows.Forms.ComboBox TypeLists;
        private System.Windows.Forms.TextBox textList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextContains;
        private System.Windows.Forms.TextBox textAdd;
        private System.Windows.Forms.TextBox textRemove;
        private System.Windows.Forms.Button ContainsBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button RemoveBnt;
        private System.Windows.Forms.Button ConvertBtn;
        private System.Windows.Forms.ComboBox convertComboBox;
        private System.Windows.Forms.Button ExistsBtn;
        private System.Windows.Forms.Button FindAllBtn;
        private System.Windows.Forms.Button ForEachBtn;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Button ClearBtn;
        private CheckBox chkLinkedHeap;
    }
}

