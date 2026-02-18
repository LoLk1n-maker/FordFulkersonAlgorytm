namespace CableTracingFordFulkerson
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewCapacity;
        private System.Windows.Forms.DataGridView dataGridViewFlow;
        private System.Windows.Forms.NumericUpDown numericUpDownVertices;
        private System.Windows.Forms.NumericUpDown numericUpDownSource;
        private System.Windows.Forms.NumericUpDown numericUpDownSink;
        private System.Windows.Forms.TextBox textBoxMaxFlow;
        private System.Windows.Forms.ListBox listBoxPaths;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button buttonCreateMatrix;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label labelVertices;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelSink;
        private System.Windows.Forms.Label labelMaxFlow;
        private System.Windows.Forms.Label labelCapacityMatrix;
        private System.Windows.Forms.Label labelFlowMatrix;
        private System.Windows.Forms.Label labelPaths;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMatrices;
        private System.Windows.Forms.TabPage tabPagePaths;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.Panel panelInput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelInput = new System.Windows.Forms.Panel();
            this.labelVertices = new System.Windows.Forms.Label();
            this.numericUpDownVertices = new System.Windows.Forms.NumericUpDown();
            this.buttonCreateMatrix = new System.Windows.Forms.Button();
            this.labelSource = new System.Windows.Forms.Label();
            this.numericUpDownSource = new System.Windows.Forms.NumericUpDown();
            this.labelSink = new System.Windows.Forms.Label();
            this.numericUpDownSink = new System.Windows.Forms.NumericUpDown();
            this.labelMaxFlow = new System.Windows.Forms.Label();
            this.textBoxMaxFlow = new System.Windows.Forms.TextBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMatrices = new System.Windows.Forms.TabPage();
            this.labelCapacityMatrix = new System.Windows.Forms.Label();
            this.dataGridViewCapacity = new System.Windows.Forms.DataGridView();
            this.labelFlowMatrix = new System.Windows.Forms.Label();
            this.dataGridViewFlow = new System.Windows.Forms.DataGridView();
            this.tabPagePaths = new System.Windows.Forms.TabPage();
            this.labelPaths = new System.Windows.Forms.Label();
            this.listBoxPaths = new System.Windows.Forms.ListBox();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.labelLog = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVertices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSink)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageMatrices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlow)).BeginInit();
            this.tabPagePaths.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInput.Controls.Add(this.labelVertices);
            this.panelInput.Controls.Add(this.numericUpDownVertices);
            this.panelInput.Controls.Add(this.buttonCreateMatrix);
            this.panelInput.Controls.Add(this.labelSource);
            this.panelInput.Controls.Add(this.numericUpDownSource);
            this.panelInput.Controls.Add(this.labelSink);
            this.panelInput.Controls.Add(this.numericUpDownSink);
            this.panelInput.Controls.Add(this.labelMaxFlow);
            this.panelInput.Controls.Add(this.textBoxMaxFlow);
            this.panelInput.Controls.Add(this.buttonCalculate);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInput.Location = new System.Drawing.Point(0, 0);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(300, 761);
            this.panelInput.TabIndex = 0;
            // 
            // labelVertices
            // 
            this.labelVertices.AutoSize = true;
            this.labelVertices.Location = new System.Drawing.Point(20, 20);
            this.labelVertices.Name = "labelVertices";
            this.labelVertices.Size = new System.Drawing.Size(136, 16);
            this.labelVertices.TabIndex = 0;
            this.labelVertices.Text = "Количество узлов:";
            // 
            // numericUpDownVertices
            // 
            this.numericUpDownVertices.Location = new System.Drawing.Point(180, 18);
            this.numericUpDownVertices.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownVertices.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownVertices.Name = "numericUpDownVertices";
            this.numericUpDownVertices.Size = new System.Drawing.Size(100, 22);
            this.numericUpDownVertices.TabIndex = 1;
            this.numericUpDownVertices.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // buttonCreateMatrix
            // 
            this.buttonCreateMatrix.Location = new System.Drawing.Point(20, 50);
            this.buttonCreateMatrix.Name = "buttonCreateMatrix";
            this.buttonCreateMatrix.Size = new System.Drawing.Size(260, 30);
            this.buttonCreateMatrix.TabIndex = 2;
            this.buttonCreateMatrix.Text = "Создать матрицу";
            this.buttonCreateMatrix.UseVisualStyleBackColor = true;
            this.buttonCreateMatrix.Click += new System.EventHandler(this.ButtonCreateMatrix_Click);
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(20, 90);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(151, 16);
            this.labelSource.TabIndex = 3;
            this.labelSource.Text = "Источник (0-based):";
            // 
            // numericUpDownSource
            // 
            this.numericUpDownSource.Location = new System.Drawing.Point(180, 88);
            this.numericUpDownSource.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.numericUpDownSource.Name = "numericUpDownSource";
            this.numericUpDownSource.Size = new System.Drawing.Size(100, 22);
            this.numericUpDownSource.TabIndex = 4;
            // 
            // labelSink
            // 
            this.labelSink.AutoSize = true;
            this.labelSink.Location = new System.Drawing.Point(20, 120);
            this.labelSink.Name = "labelSink";
            this.labelSink.Size = new System.Drawing.Size(110, 16);
            this.labelSink.TabIndex = 5;
            this.labelSink.Text = "Сток (0-based):";
            // 
            // numericUpDownSink
            // 
            this.numericUpDownSink.Location = new System.Drawing.Point(180, 118);
            this.numericUpDownSink.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.numericUpDownSink.Name = "numericUpDownSink";
            this.numericUpDownSink.Size = new System.Drawing.Size(100, 22);
            this.numericUpDownSink.TabIndex = 6;
            this.numericUpDownSink.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // labelMaxFlow
            // 
            this.labelMaxFlow.AutoSize = true;
            this.labelMaxFlow.Location = new System.Drawing.Point(20, 160);
            this.labelMaxFlow.Name = "labelMaxFlow";
            this.labelMaxFlow.Size = new System.Drawing.Size(148, 16);
            this.labelMaxFlow.TabIndex = 7;
            this.labelMaxFlow.Text = "Максимальный поток:";
            // 
            // textBoxMaxFlow
            // 
            this.textBoxMaxFlow.Location = new System.Drawing.Point(180, 157);
            this.textBoxMaxFlow.Name = "textBoxMaxFlow";
            this.textBoxMaxFlow.ReadOnly = true;
            this.textBoxMaxFlow.Size = new System.Drawing.Size(100, 22);
            this.textBoxMaxFlow.TabIndex = 8;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.BackColor = System.Drawing.Color.LightBlue;
            this.buttonCalculate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCalculate.Location = new System.Drawing.Point(20, 200);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(260, 40);
            this.buttonCalculate.TabIndex = 9;
            this.buttonCalculate.Text = "Рассчитать";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            this.buttonCalculate.Click += new System.EventHandler(this.ButtonCalculate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMatrices);
            this.tabControl1.Controls.Add(this.tabPagePaths);
            this.tabControl1.Controls.Add(this.tabPageLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(300, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 761);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageMatrices
            // 
            this.tabPageMatrices.Controls.Add(this.labelCapacityMatrix);
            this.tabPageMatrices.Controls.Add(this.dataGridViewCapacity);
            this.tabPageMatrices.Controls.Add(this.labelFlowMatrix);
            this.tabPageMatrices.Controls.Add(this.dataGridViewFlow);
            this.tabPageMatrices.Location = new System.Drawing.Point(4, 25);
            this.tabPageMatrices.Name = "tabPageMatrices";
            this.tabPageMatrices.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMatrices.Size = new System.Drawing.Size(876, 732);
            this.tabPageMatrices.TabIndex = 0;
            this.tabPageMatrices.Text = "Матрицы";
            this.tabPageMatrices.UseVisualStyleBackColor = true;
            // 
            // labelCapacityMatrix
            // 
            this.labelCapacityMatrix.AutoSize = true;
            this.labelCapacityMatrix.Location = new System.Drawing.Point(10, 10);
            this.labelCapacityMatrix.Name = "labelCapacityMatrix";
            this.labelCapacityMatrix.Size = new System.Drawing.Size(263, 16);
            this.labelCapacityMatrix.TabIndex = 0;
            this.labelCapacityMatrix.Text = "Матрица пропускных способностей:\n(если поле пустое, или содержит неправильные данные, вес ребра считается равным 0)";
            // 
            // dataGridViewCapacity
            // 
            this.dataGridViewCapacity.AllowUserToAddRows = false;
            this.dataGridViewCapacity.AllowUserToDeleteRows = false;
            this.dataGridViewCapacity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCapacity.Location = new System.Drawing.Point(10, 50);
            this.dataGridViewCapacity.Name = "dataGridViewCapacity";
            this.dataGridViewCapacity.RowHeadersWidth = 51;
            this.dataGridViewCapacity.RowTemplate.Height = 24;
            this.dataGridViewCapacity.Size = new System.Drawing.Size(400, 200);
            this.dataGridViewCapacity.TabIndex = 1;
            // 
            // labelFlowMatrix
            // 
            this.labelFlowMatrix.AutoSize = true;
            this.labelFlowMatrix.Location = new System.Drawing.Point(10, 260);
            this.labelFlowMatrix.Name = "labelFlowMatrix";
            this.labelFlowMatrix.Size = new System.Drawing.Size(118, 16);
            this.labelFlowMatrix.TabIndex = 2;
            this.labelFlowMatrix.Text = "Матрица потока:";
            // 
            // dataGridViewFlow
            // 
            this.dataGridViewFlow.AllowUserToAddRows = false;
            this.dataGridViewFlow.AllowUserToDeleteRows = false;
            this.dataGridViewFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlow.Location = new System.Drawing.Point(10, 290);
            this.dataGridViewFlow.Name = "dataGridViewFlow";
            this.dataGridViewFlow.ReadOnly = true;
            this.dataGridViewFlow.RowHeadersWidth = 51;
            this.dataGridViewFlow.RowTemplate.Height = 24;
            this.dataGridViewFlow.Size = new System.Drawing.Size(400, 200);
            this.dataGridViewFlow.TabIndex = 3;
            // 
            // tabPagePaths
            // 
            this.tabPagePaths.Controls.Add(this.labelPaths);
            this.tabPagePaths.Controls.Add(this.listBoxPaths);
            this.tabPagePaths.Location = new System.Drawing.Point(4, 25);
            this.tabPagePaths.Name = "tabPagePaths";
            this.tabPagePaths.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePaths.Size = new System.Drawing.Size(876, 732);
            this.tabPagePaths.TabIndex = 1;
            this.tabPagePaths.Text = "Пути трассировки";
            this.tabPagePaths.UseVisualStyleBackColor = true;
            // 
            // labelPaths
            // 
            this.labelPaths.AutoSize = true;
            this.labelPaths.Location = new System.Drawing.Point(10, 10);
            this.labelPaths.Name = "labelPaths";
            this.labelPaths.Size = new System.Drawing.Size(207, 16);
            this.labelPaths.TabIndex = 0;
            this.labelPaths.Text = "Найденные пути для кабелей:";
            // 
            // listBoxPaths
            // 
            this.listBoxPaths.Font = new System.Drawing.Font("Courier New", 10F);
            this.listBoxPaths.FormattingEnabled = true;
            this.listBoxPaths.ItemHeight = 20;
            this.listBoxPaths.Location = new System.Drawing.Point(10, 40);
            this.listBoxPaths.Name = "listBoxPaths";
            this.listBoxPaths.Size = new System.Drawing.Size(500, 604);
            this.listBoxPaths.TabIndex = 1;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.labelLog);
            this.tabPageLog.Controls.Add(this.listBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 25);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Size = new System.Drawing.Size(876, 732);
            this.tabPageLog.TabIndex = 2;
            this.tabPageLog.Text = "Лог выполнения";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(10, 10);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(207, 16);
            this.labelLog.TabIndex = 0;
            this.labelLog.Text = "Процесс выполнения алгоритма:";
            // 
            // listBoxLog
            // 
            this.listBoxLog.Font = new System.Drawing.Font("Courier New", 9F);
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 17;
            this.listBoxLog.Location = new System.Drawing.Point(10, 40);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(500, 684);
            this.listBoxLog.TabIndex = 1;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelInput);
            this.Name = "MainForm";
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVertices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSink)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageMatrices.ResumeLayout(false);
            this.tabPageMatrices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlow)).EndInit();
            this.tabPagePaths.ResumeLayout(false);
            this.tabPagePaths.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}