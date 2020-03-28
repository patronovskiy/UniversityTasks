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
            this.algorithmsTab = new System.Windows.Forms.TabPage();
            this.visualisationGroup = new System.Windows.Forms.GroupBox();
            this.visualizationTextBox = new System.Windows.Forms.TextBox();
            this.infoGroup = new System.Windows.Forms.GroupBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.complexity = new System.Windows.Forms.Label();
            this.complexityLabel = new System.Windows.Forms.Label();
            this.algorithmName = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.afterArrayGroup = new System.Windows.Forms.GroupBox();
            this.afterArrayTextBox = new System.Windows.Forms.TextBox();
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
            this.beforeArrayGroup = new System.Windows.Forms.GroupBox();
            this.beforeArrayTextBox = new System.Windows.Forms.TextBox();
            this.algorithmsGroup = new System.Windows.Forms.GroupBox();
            this.quickRadio = new System.Windows.Forms.RadioButton();
            this.mergeRadio = new System.Windows.Forms.RadioButton();
            this.shellRadio = new System.Windows.Forms.RadioButton();
            this.bubbleRadio = new System.Windows.Forms.RadioButton();
            this.insertionRadio = new System.Windows.Forms.RadioButton();
            this.serviceTab = new System.Windows.Forms.TabPage();
            this.tabs.SuspendLayout();
            this.algorithmsTab.SuspendLayout();
            this.visualisationGroup.SuspendLayout();
            this.infoGroup.SuspendLayout();
            this.afterArrayGroup.SuspendLayout();
            this.arrayGroup.SuspendLayout();
            this.beforeArrayGroup.SuspendLayout();
            this.algorithmsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.algorithmsTab);
            this.tabs.Controls.Add(this.serviceTab);
            this.tabs.Location = new System.Drawing.Point(1, 2);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1080, 665);
            this.tabs.TabIndex = 0;
            // 
            // algorithmsTab
            // 
            this.algorithmsTab.Controls.Add(this.visualisationGroup);
            this.algorithmsTab.Controls.Add(this.infoGroup);
            this.algorithmsTab.Controls.Add(this.afterArrayGroup);
            this.algorithmsTab.Controls.Add(this.arrayGroup);
            this.algorithmsTab.Controls.Add(this.beforeArrayGroup);
            this.algorithmsTab.Controls.Add(this.algorithmsGroup);
            this.algorithmsTab.Location = new System.Drawing.Point(4, 25);
            this.algorithmsTab.Name = "algorithmsTab";
            this.algorithmsTab.Padding = new System.Windows.Forms.Padding(3);
            this.algorithmsTab.Size = new System.Drawing.Size(1072, 636);
            this.algorithmsTab.TabIndex = 0;
            this.algorithmsTab.Text = "Algorithms";
            this.algorithmsTab.UseVisualStyleBackColor = true;
            // 
            // visualisationGroup
            // 
            this.visualisationGroup.Controls.Add(this.visualizationTextBox);
            this.visualisationGroup.Location = new System.Drawing.Point(711, 237);
            this.visualisationGroup.Name = "visualisationGroup";
            this.visualisationGroup.Size = new System.Drawing.Size(353, 393);
            this.visualisationGroup.TabIndex = 8;
            this.visualisationGroup.TabStop = false;
            this.visualisationGroup.Text = "Visualisation of sorting steps";
            // 
            // visualizationTextBox
            // 
            this.visualizationTextBox.Location = new System.Drawing.Point(14, 21);
            this.visualizationTextBox.Multiline = true;
            this.visualizationTextBox.Name = "visualizationTextBox";
            this.visualizationTextBox.ReadOnly = true;
            this.visualizationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.visualizationTextBox.ShortcutsEnabled = false;
            this.visualizationTextBox.Size = new System.Drawing.Size(325, 352);
            this.visualizationTextBox.TabIndex = 1;
            // 
            // infoGroup
            // 
            this.infoGroup.Controls.Add(this.descriptionTextBox);
            this.infoGroup.Controls.Add(this.descriptionLabel);
            this.infoGroup.Controls.Add(this.complexity);
            this.infoGroup.Controls.Add(this.complexityLabel);
            this.infoGroup.Controls.Add(this.algorithmName);
            this.infoGroup.Controls.Add(this.nameLabel);
            this.infoGroup.Location = new System.Drawing.Point(7, 264);
            this.infoGroup.Name = "infoGroup";
            this.infoGroup.Size = new System.Drawing.Size(339, 366);
            this.infoGroup.TabIndex = 5;
            this.infoGroup.TabStop = false;
            this.infoGroup.Text = "Algorithm info";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(8, 156);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(318, 190);
            this.descriptionTextBox.TabIndex = 5;
            this.descriptionTextBox.Text = "Алгоритм сортировки, в котором элементы входной последовательности просматриваютс" +
    "я по одному, и каждый новый поступивший элемент размещается в подходящее место с" +
    "реди ранее упорядоченных элементов";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.Location = new System.Drawing.Point(5, 136);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(95, 17);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "Description:";
            // 
            // complexity
            // 
            this.complexity.AutoSize = true;
            this.complexity.Location = new System.Drawing.Point(6, 80);
            this.complexity.Name = "complexity";
            this.complexity.Size = new System.Drawing.Size(42, 17);
            this.complexity.TabIndex = 3;
            this.complexity.Text = "O(n²)";
            // 
            // complexityLabel
            // 
            this.complexityLabel.AutoSize = true;
            this.complexityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.complexityLabel.Location = new System.Drawing.Point(6, 56);
            this.complexityLabel.Name = "complexityLabel";
            this.complexityLabel.Size = new System.Drawing.Size(166, 17);
            this.complexityLabel.TabIndex = 2;
            this.complexityLabel.Text = "Time complexity O(n):";
            // 
            // algorithmName
            // 
            this.algorithmName.AutoSize = true;
            this.algorithmName.Location = new System.Drawing.Point(71, 24);
            this.algorithmName.Name = "algorithmName";
            this.algorithmName.Size = new System.Drawing.Size(90, 17);
            this.algorithmName.TabIndex = 1;
            this.algorithmName.Text = "Insertion sort";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(6, 24);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(59, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name: ";
            // 
            // afterArrayGroup
            // 
            this.afterArrayGroup.Controls.Add(this.afterArrayTextBox);
            this.afterArrayGroup.Location = new System.Drawing.Point(352, 320);
            this.afterArrayGroup.Name = "afterArrayGroup";
            this.afterArrayGroup.Size = new System.Drawing.Size(353, 310);
            this.afterArrayGroup.TabIndex = 6;
            this.afterArrayGroup.TabStop = false;
            this.afterArrayGroup.Text = "AfterArray";
            // 
            // afterArrayTextBox
            // 
            this.afterArrayTextBox.Location = new System.Drawing.Point(14, 21);
            this.afterArrayTextBox.Multiline = true;
            this.afterArrayTextBox.Name = "afterArrayTextBox";
            this.afterArrayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.afterArrayTextBox.Size = new System.Drawing.Size(325, 270);
            this.afterArrayTextBox.TabIndex = 1;
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
            this.arrayGroup.Size = new System.Drawing.Size(355, 216);
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
            this.noDownloadCheckbox.Checked = true;
            this.noDownloadCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
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
            // beforeArrayGroup
            // 
            this.beforeArrayGroup.Controls.Add(this.beforeArrayTextBox);
            this.beforeArrayGroup.Location = new System.Drawing.Point(352, 6);
            this.beforeArrayGroup.Name = "beforeArrayGroup";
            this.beforeArrayGroup.Size = new System.Drawing.Size(353, 310);
            this.beforeArrayGroup.TabIndex = 5;
            this.beforeArrayGroup.TabStop = false;
            this.beforeArrayGroup.Text = "BeforeArray";
            // 
            // beforeArrayTextBox
            // 
            this.beforeArrayTextBox.Location = new System.Drawing.Point(14, 25);
            this.beforeArrayTextBox.Multiline = true;
            this.beforeArrayTextBox.Name = "beforeArrayTextBox";
            this.beforeArrayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.beforeArrayTextBox.Size = new System.Drawing.Size(325, 270);
            this.beforeArrayTextBox.TabIndex = 0;
            // 
            // algorithmsGroup
            // 
            this.algorithmsGroup.Controls.Add(this.quickRadio);
            this.algorithmsGroup.Controls.Add(this.mergeRadio);
            this.algorithmsGroup.Controls.Add(this.shellRadio);
            this.algorithmsGroup.Controls.Add(this.bubbleRadio);
            this.algorithmsGroup.Controls.Add(this.insertionRadio);
            this.algorithmsGroup.Location = new System.Drawing.Point(7, 6);
            this.algorithmsGroup.Name = "algorithmsGroup";
            this.algorithmsGroup.Size = new System.Drawing.Size(339, 252);
            this.algorithmsGroup.TabIndex = 4;
            this.algorithmsGroup.TabStop = false;
            this.algorithmsGroup.Text = "Algorithms";
            // 
            // quickRadio
            // 
            this.quickRadio.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.quickRadio.AllowDrop = true;
            this.quickRadio.AutoSize = true;
            this.quickRadio.Location = new System.Drawing.Point(6, 146);
            this.quickRadio.Name = "quickRadio";
            this.quickRadio.Size = new System.Drawing.Size(226, 21);
            this.quickRadio.TabIndex = 4;
            this.quickRadio.TabStop = true;
            this.quickRadio.Text = "Quick sort (быстрая сортировка)";
            this.quickRadio.UseCompatibleTextRendering = true;
            this.quickRadio.UseVisualStyleBackColor = true;
            // 
            // mergeRadio
            // 
            this.mergeRadio.AllowDrop = true;
            this.mergeRadio.AutoSize = true;
            this.mergeRadio.Location = new System.Drawing.Point(6, 119);
            this.mergeRadio.Name = "mergeRadio";
            this.mergeRadio.Size = new System.Drawing.Size(238, 21);
            this.mergeRadio.TabIndex = 3;
            this.mergeRadio.TabStop = true;
            this.mergeRadio.Text = "Merge sort (сортировка слиянием)";
            this.mergeRadio.UseCompatibleTextRendering = true;
            this.mergeRadio.UseVisualStyleBackColor = true;
            // 
            // shellRadio
            // 
            this.shellRadio.AllowDrop = true;
            this.shellRadio.AutoSize = true;
            this.shellRadio.Location = new System.Drawing.Point(6, 94);
            this.shellRadio.Name = "shellRadio";
            this.shellRadio.Size = new System.Drawing.Size(225, 21);
            this.shellRadio.TabIndex = 2;
            this.shellRadio.TabStop = true;
            this.shellRadio.Text = "Shell sort (сортировка Шелла)";
            this.shellRadio.UseVisualStyleBackColor = true;
            // 
            // bubbleRadio
            // 
            this.bubbleRadio.AllowDrop = true;
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
            this.insertionRadio.Checked = true;
            this.insertionRadio.Location = new System.Drawing.Point(6, 40);
            this.insertionRadio.Name = "insertionRadio";
            this.insertionRadio.Size = new System.Drawing.Size(273, 21);
            this.insertionRadio.TabIndex = 0;
            this.insertionRadio.TabStop = true;
            this.insertionRadio.Text = "Insertion sort (сортировка вставками)";
            this.insertionRadio.UseVisualStyleBackColor = true;
            // 
            // serviceTab
            // 
            this.serviceTab.Location = new System.Drawing.Point(4, 25);
            this.serviceTab.Name = "serviceTab";
            this.serviceTab.Padding = new System.Windows.Forms.Padding(3);
            this.serviceTab.Size = new System.Drawing.Size(1072, 636);
            this.serviceTab.TabIndex = 1;
            this.serviceTab.Text = "Service";
            this.serviceTab.UseVisualStyleBackColor = true;
            // 
            // algorithmBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1102, 679);
            this.Controls.Add(this.tabs);
            this.Name = "algorithmBar";
            this.Text = "AlgorithmsBar";
            this.tabs.ResumeLayout(false);
            this.algorithmsTab.ResumeLayout(false);
            this.visualisationGroup.ResumeLayout(false);
            this.visualisationGroup.PerformLayout();
            this.infoGroup.ResumeLayout(false);
            this.infoGroup.PerformLayout();
            this.afterArrayGroup.ResumeLayout(false);
            this.afterArrayGroup.PerformLayout();
            this.arrayGroup.ResumeLayout(false);
            this.arrayGroup.PerformLayout();
            this.beforeArrayGroup.ResumeLayout(false);
            this.beforeArrayGroup.PerformLayout();
            this.algorithmsGroup.ResumeLayout(false);
            this.algorithmsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage algorithmsTab;
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
        private System.Windows.Forms.TabPage serviceTab;
        private System.Windows.Forms.TextBox afterArrayTextBox;
        private System.Windows.Forms.TextBox beforeArrayTextBox;
        private System.Windows.Forms.RadioButton shellRadio;
        private System.Windows.Forms.GroupBox infoGroup;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label complexity;
        private System.Windows.Forms.Label complexityLabel;
        private System.Windows.Forms.Label algorithmName;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.GroupBox visualisationGroup;
        private System.Windows.Forms.TextBox visualizationTextBox;
        private System.Windows.Forms.RadioButton mergeRadio;
        private System.Windows.Forms.RadioButton quickRadio;
    }
}

