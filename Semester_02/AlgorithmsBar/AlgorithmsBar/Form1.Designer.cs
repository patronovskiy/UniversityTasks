namespace AlgorithmsBar
{
    partial class algorithmBar
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.arrayGroup = new System.Windows.Forms.GroupBox();
            this.uploadFileButton = new System.Windows.Forms.Button();
            this.createFileButton = new System.Windows.Forms.Button();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileNameInput = new System.Windows.Forms.TextBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.noDownloadCheckbox = new System.Windows.Forms.CheckBox();
            this.randomValueLabel = new System.Windows.Forms.Label();
            this.randomValueInput = new System.Windows.Forms.TextBox();
            this.arraySizeLabel = new System.Windows.Forms.Label();
            this.arraySizeInput = new System.Windows.Forms.TextBox();
            this.afterArrayGroup = new System.Windows.Forms.GroupBox();
            this.beforeArrayGroup = new System.Windows.Forms.GroupBox();
            this.algorithmsGroup = new System.Windows.Forms.GroupBox();
            this.bubbleRadio = new System.Windows.Forms.RadioButton();
            this.insertionRadio = new System.Windows.Forms.RadioButton();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.arrayGroup.SuspendLayout();
            this.algorithmsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Location = new System.Drawing.Point(1, 2);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1080, 539);
            this.tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.arrayGroup);
            this.tabPage1.Controls.Add(this.afterArrayGroup);
            this.tabPage1.Controls.Add(this.beforeArrayGroup);
            this.tabPage1.Controls.Add(this.algorithmsGroup);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1072, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1072, 510);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // arrayGroup
            // 
            this.arrayGroup.Controls.Add(this.uploadFileButton);
            this.arrayGroup.Controls.Add(this.createFileButton);
            this.arrayGroup.Controls.Add(this.fileNameLabel);
            this.arrayGroup.Controls.Add(this.fileNameInput);
            this.arrayGroup.Controls.Add(this.sortButton);
            this.arrayGroup.Controls.Add(this.noDownloadCheckbox);
            this.arrayGroup.Controls.Add(this.randomValueLabel);
            this.arrayGroup.Controls.Add(this.randomValueInput);
            this.arrayGroup.Controls.Add(this.arraySizeLabel);
            this.arrayGroup.Controls.Add(this.arraySizeInput);
            this.arrayGroup.Location = new System.Drawing.Point(711, 6);
            this.arrayGroup.Name = "arrayGroup";
            this.arrayGroup.Size = new System.Drawing.Size(355, 498);
            this.arrayGroup.TabIndex = 7;
            this.arrayGroup.TabStop = false;
            this.arrayGroup.Text = "Array";
            // 
            // uploadFileButton
            // 
            this.uploadFileButton.Location = new System.Drawing.Point(177, 161);
            this.uploadFileButton.Name = "uploadFileButton";
            this.uploadFileButton.Size = new System.Drawing.Size(146, 29);
            this.uploadFileButton.TabIndex = 9;
            this.uploadFileButton.Text = "Upload file";
            this.uploadFileButton.UseVisualStyleBackColor = true;
            // 
            // createFileButton
            // 
            this.createFileButton.Location = new System.Drawing.Point(9, 161);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(146, 29);
            this.createFileButton.TabIndex = 8;
            this.createFileButton.Text = "Create file";
            this.createFileButton.UseVisualStyleBackColor = true;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(6, 123);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(69, 17);
            this.fileNameLabel.TabIndex = 7;
            this.fileNameLabel.Text = "File name";
            // 
            // fileNameInput
            // 
            this.fileNameInput.Location = new System.Drawing.Point(83, 120);
            this.fileNameInput.Name = "fileNameInput";
            this.fileNameInput.Size = new System.Drawing.Size(240, 22);
            this.fileNameInput.TabIndex = 6;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(177, 76);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(146, 29);
            this.sortButton.TabIndex = 5;
            this.sortButton.Text = "SORT";
            this.sortButton.UseVisualStyleBackColor = true;
            // 
            // noDownloadCheckbox
            // 
            this.noDownloadCheckbox.AutoSize = true;
            this.noDownloadCheckbox.Location = new System.Drawing.Point(9, 84);
            this.noDownloadCheckbox.Name = "noDownloadCheckbox";
            this.noDownloadCheckbox.Size = new System.Drawing.Size(112, 21);
            this.noDownloadCheckbox.TabIndex = 4;
            this.noDownloadCheckbox.Text = "No download";
            this.noDownloadCheckbox.UseVisualStyleBackColor = true;
            // 
            // randomValueLabel
            // 
            this.randomValueLabel.AutoSize = true;
            this.randomValueLabel.Location = new System.Drawing.Point(154, 40);
            this.randomValueLabel.Name = "randomValueLabel";
            this.randomValueLabel.Size = new System.Drawing.Size(99, 17);
            this.randomValueLabel.TabIndex = 3;
            this.randomValueLabel.Text = "Random value";
            // 
            // randomValueInput
            // 
            this.randomValueInput.Location = new System.Drawing.Point(259, 37);
            this.randomValueInput.Name = "randomValueInput";
            this.randomValueInput.Size = new System.Drawing.Size(64, 22);
            this.randomValueInput.TabIndex = 2;
            this.randomValueInput.Text = "200";
            // 
            // arraySizeLabel
            // 
            this.arraySizeLabel.AutoSize = true;
            this.arraySizeLabel.Location = new System.Drawing.Point(6, 40);
            this.arraySizeLabel.Name = "arraySizeLabel";
            this.arraySizeLabel.Size = new System.Drawing.Size(71, 17);
            this.arraySizeLabel.TabIndex = 1;
            this.arraySizeLabel.Text = "Array size";
            // 
            // arraySizeInput
            // 
            this.arraySizeInput.Location = new System.Drawing.Point(83, 37);
            this.arraySizeInput.Name = "arraySizeInput";
            this.arraySizeInput.Size = new System.Drawing.Size(65, 22);
            this.arraySizeInput.TabIndex = 0;
            this.arraySizeInput.Text = "15";
            // 
            // afterArrayGroup
            // 
            this.afterArrayGroup.Location = new System.Drawing.Point(307, 264);
            this.afterArrayGroup.Name = "afterArrayGroup";
            this.afterArrayGroup.Size = new System.Drawing.Size(398, 240);
            this.afterArrayGroup.TabIndex = 6;
            this.afterArrayGroup.TabStop = false;
            this.afterArrayGroup.Text = "AfterArray";
            // 
            // beforeArrayGroup
            // 
            this.beforeArrayGroup.Location = new System.Drawing.Point(307, 6);
            this.beforeArrayGroup.Name = "beforeArrayGroup";
            this.beforeArrayGroup.Size = new System.Drawing.Size(398, 252);
            this.beforeArrayGroup.TabIndex = 5;
            this.beforeArrayGroup.TabStop = false;
            this.beforeArrayGroup.Text = "BeforeArray";
            // 
            // algorithmsGroup
            // 
            this.algorithmsGroup.Controls.Add(this.bubbleRadio);
            this.algorithmsGroup.Controls.Add(this.insertionRadio);
            this.algorithmsGroup.Location = new System.Drawing.Point(7, 6);
            this.algorithmsGroup.Name = "algorithmsGroup";
            this.algorithmsGroup.Size = new System.Drawing.Size(294, 498);
            this.algorithmsGroup.TabIndex = 4;
            this.algorithmsGroup.TabStop = false;
            this.algorithmsGroup.Text = "Algorithms";
            // 
            // bubbleRadio
            // 
            this.bubbleRadio.AutoSize = true;
            this.bubbleRadio.Location = new System.Drawing.Point(6, 67);
            this.bubbleRadio.Name = "bubbleRadio";
            this.bubbleRadio.Size = new System.Drawing.Size(266, 21);
            this.bubbleRadio.TabIndex = 1;
            this.bubbleRadio.TabStop = true;
            this.bubbleRadio.Text = "Bubble sort (сортировка пузырьком)";
            this.bubbleRadio.UseVisualStyleBackColor = true;
            // 
            // insertionRadio
            // 
            this.insertionRadio.AutoSize = true;
            this.insertionRadio.Location = new System.Drawing.Point(6, 40);
            this.insertionRadio.Name = "insertionRadio";
            this.insertionRadio.Size = new System.Drawing.Size(275, 21);
            this.insertionRadio.TabIndex = 0;
            this.insertionRadio.TabStop = true;
            this.insertionRadio.Text = "Insertion sort (Сортировка вставками)";
            this.insertionRadio.UseVisualStyleBackColor = true;
            // 
            // algorithmBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1102, 553);
            this.Controls.Add(this.tabs);
            this.Name = "algorithmBar";
            this.Text = "AlgorithmsBar";
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.arrayGroup.ResumeLayout(false);
            this.arrayGroup.PerformLayout();
            this.algorithmsGroup.ResumeLayout(false);
            this.algorithmsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox arrayGroup;
        private System.Windows.Forms.Button uploadFileButton;
        private System.Windows.Forms.Button createFileButton;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox fileNameInput;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.CheckBox noDownloadCheckbox;
        private System.Windows.Forms.Label randomValueLabel;
        private System.Windows.Forms.TextBox randomValueInput;
        private System.Windows.Forms.Label arraySizeLabel;
        private System.Windows.Forms.TextBox arraySizeInput;
        private System.Windows.Forms.GroupBox afterArrayGroup;
        private System.Windows.Forms.GroupBox beforeArrayGroup;
        private System.Windows.Forms.GroupBox algorithmsGroup;
        private System.Windows.Forms.RadioButton bubbleRadio;
        private System.Windows.Forms.RadioButton insertionRadio;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

