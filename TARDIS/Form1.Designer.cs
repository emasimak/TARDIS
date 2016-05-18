namespace Charge_States
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataInputBox = new System.Windows.Forms.GroupBox();
            this.atmassLabel = new System.Windows.Forms.LinkLabel();
            this.atnumLabel = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.factorLabel = new System.Windows.Forms.Label();
            this.factorBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.velLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.icBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.inChargeLabel = new System.Windows.Forms.Label();
            this.eBox = new System.Windows.Forms.TextBox();
            this.energyLabel = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.zBox = new System.Windows.Forms.TextBox();
            this.mBox = new System.Windows.Forms.TextBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.qColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ndFoilEqChargeState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ndFoilRatioInCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sFoilEqChargeStates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sFoilRationInCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sGasEqChargeStates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sGasRationInCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ssFoilEqChargeState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ssFoilRatioInCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.plot1 = new OxyPlot.WindowsForms.Plot();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.buttonPNG = new System.Windows.Forms.Button();
            this.dataInputBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataInputBox
            // 
            this.dataInputBox.Controls.Add(this.atmassLabel);
            this.dataInputBox.Controls.Add(this.atnumLabel);
            this.dataInputBox.Controls.Add(this.label4);
            this.dataInputBox.Controls.Add(this.factorLabel);
            this.dataInputBox.Controls.Add(this.factorBox);
            this.dataInputBox.Controls.Add(this.label3);
            this.dataInputBox.Controls.Add(this.velLabel);
            this.dataInputBox.Controls.Add(this.label1);
            this.dataInputBox.Controls.Add(this.icBox);
            this.dataInputBox.Controls.Add(this.button2);
            this.dataInputBox.Controls.Add(this.button1);
            this.dataInputBox.Controls.Add(this.inChargeLabel);
            this.dataInputBox.Controls.Add(this.eBox);
            this.dataInputBox.Controls.Add(this.energyLabel);
            this.dataInputBox.Controls.Add(this.zLabel);
            this.dataInputBox.Controls.Add(this.zBox);
            this.dataInputBox.Controls.Add(this.mBox);
            this.dataInputBox.Controls.Add(this.mLabel);
            this.dataInputBox.Location = new System.Drawing.Point(10, 11);
            this.dataInputBox.Margin = new System.Windows.Forms.Padding(2);
            this.dataInputBox.Name = "dataInputBox";
            this.dataInputBox.Padding = new System.Windows.Forms.Padding(2);
            this.dataInputBox.Size = new System.Drawing.Size(1160, 81);
            this.dataInputBox.TabIndex = 0;
            this.dataInputBox.TabStop = false;
            this.dataInputBox.Text = "Data Input";
            // 
            // atmassLabel
            // 
            this.atmassLabel.AutoSize = true;
            this.atmassLabel.Location = new System.Drawing.Point(196, 26);
            this.atmassLabel.Name = "atmassLabel";
            this.atmassLabel.Size = new System.Drawing.Size(66, 13);
            this.atmassLabel.TabIndex = 18;
            this.atmassLabel.TabStop = true;
            this.atmassLabel.Text = "Mass values";
            this.atmassLabel.Click += new System.EventHandler(this.atmassLabel_Click);
            // 
            // atnumLabel
            // 
            this.atnumLabel.AutoSize = true;
            this.atnumLabel.Location = new System.Drawing.Point(27, 26);
            this.atnumLabel.Name = "atnumLabel";
            this.atnumLabel.Size = new System.Drawing.Size(48, 13);
            this.atnumLabel.TabIndex = 17;
            this.atnumLabel.TabStop = true;
            this.atnumLabel.Text = "Z values";
            this.atnumLabel.Click += new System.EventHandler(this.atnumLabel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "[Default: 1]";
            // 
            // factorLabel
            // 
            this.factorLabel.AutoSize = true;
            this.factorLabel.Location = new System.Drawing.Point(289, 60);
            this.factorLabel.Name = "factorLabel";
            this.factorLabel.Size = new System.Drawing.Size(43, 13);
            this.factorLabel.TabIndex = 15;
            this.factorLabel.Text = "Factor :";
            // 
            // factorBox
            // 
            this.factorBox.Location = new System.Drawing.Point(338, 57);
            this.factorBox.Name = "factorBox";
            this.factorBox.Size = new System.Drawing.Size(76, 20);
            this.factorBox.TabIndex = 14;
            this.factorBox.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "[Default: 1]";
            // 
            // velLabel
            // 
            this.velLabel.AutoSize = true;
            this.velLabel.Location = new System.Drawing.Point(592, 60);
            this.velLabel.Name = "velLabel";
            this.velLabel.Size = new System.Drawing.Size(22, 13);
            this.velLabel.TabIndex = 12;
            this.velLabel.Text = "0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "u [mm/ns] :";
            // 
            // icBox
            // 
            this.icBox.Location = new System.Drawing.Point(104, 57);
            this.icBox.Margin = new System.Windows.Forms.Padding(2);
            this.icBox.Name = "icBox";
            this.icBox.Size = new System.Drawing.Size(76, 20);
            this.icBox.TabIndex = 10;
            this.icBox.Text = "1";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(1109, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 41);
            this.button2.TabIndex = 9;
            this.button2.Text = "About";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(846, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 41);
            this.button1.TabIndex = 8;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inChargeLabel
            // 
            this.inChargeLabel.AutoSize = true;
            this.inChargeLabel.Location = new System.Drawing.Point(7, 60);
            this.inChargeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.inChargeLabel.Name = "inChargeLabel";
            this.inChargeLabel.Size = new System.Drawing.Size(93, 13);
            this.inChargeLabel.TabIndex = 6;
            this.inChargeLabel.Text = "Incoming Charge :";
            // 
            // eBox
            // 
            this.eBox.Location = new System.Drawing.Point(591, 23);
            this.eBox.Margin = new System.Windows.Forms.Padding(2);
            this.eBox.Name = "eBox";
            this.eBox.Size = new System.Drawing.Size(76, 20);
            this.eBox.TabIndex = 5;
            this.eBox.Text = "12";
            // 
            // energyLabel
            // 
            this.energyLabel.AutoSize = true;
            this.energyLabel.Location = new System.Drawing.Point(510, 26);
            this.energyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.energyLabel.Name = "energyLabel";
            this.energyLabel.Size = new System.Drawing.Size(77, 13);
            this.energyLabel.TabIndex = 4;
            this.energyLabel.Text = "Energy [MeV] :";
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(80, 26);
            this.zLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(20, 13);
            this.zLabel.TabIndex = 0;
            this.zLabel.Text = "Z :";
            // 
            // zBox
            // 
            this.zBox.Location = new System.Drawing.Point(104, 23);
            this.zBox.Margin = new System.Windows.Forms.Padding(2);
            this.zBox.Name = "zBox";
            this.zBox.Size = new System.Drawing.Size(76, 20);
            this.zBox.TabIndex = 1;
            this.zBox.Text = "6";
            this.zBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // mBox
            // 
            this.mBox.Location = new System.Drawing.Point(338, 23);
            this.mBox.Margin = new System.Windows.Forms.Padding(2);
            this.mBox.Name = "mBox";
            this.mBox.Size = new System.Drawing.Size(76, 20);
            this.mBox.TabIndex = 3;
            this.mBox.Text = "12";
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(267, 26);
            this.mLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(67, 13);
            this.mLabel.TabIndex = 2;
            this.mLabel.Text = "Mass [amu] :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qColumn,
            this.ndFoilEqChargeState,
            this.ndFoilRatioInCurrent,
            this.sFoilEqChargeStates,
            this.sFoilRationInCurrent,
            this.sGasEqChargeStates,
            this.sGasRationInCurrent,
            this.ssFoilEqChargeState,
            this.ssFoilRatioInCurrent,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(10, 96);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1161, 244);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // qColumn
            // 
            this.qColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.qColumn.HeaderText = "Charge (q)";
            this.qColumn.Name = "qColumn";
            this.qColumn.ReadOnly = true;
            // 
            // ndFoilEqChargeState
            // 
            this.ndFoilEqChargeState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ndFoilEqChargeState.HeaderText = "F(q) [Foil Stripper, Nikolaev - Dmitriev formula]";
            this.ndFoilEqChargeState.Name = "ndFoilEqChargeState";
            this.ndFoilEqChargeState.ReadOnly = true;
            // 
            // ndFoilRatioInCurrent
            // 
            this.ndFoilRatioInCurrent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ndFoilRatioInCurrent.HeaderText = "I / I0 [Foil Stripper, Nikolaev - Dimitriev formula]";
            this.ndFoilRatioInCurrent.Name = "ndFoilRatioInCurrent";
            this.ndFoilRatioInCurrent.ReadOnly = true;
            // 
            // sFoilEqChargeStates
            // 
            this.sFoilEqChargeStates.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sFoilEqChargeStates.HeaderText = "F(q) [Foil Stripper, Sayer Formula]";
            this.sFoilEqChargeStates.Name = "sFoilEqChargeStates";
            this.sFoilEqChargeStates.ReadOnly = true;
            // 
            // sFoilRationInCurrent
            // 
            this.sFoilRationInCurrent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sFoilRationInCurrent.HeaderText = "I/I0 [Foil Stripper, Sayer formula]";
            this.sFoilRationInCurrent.Name = "sFoilRationInCurrent";
            this.sFoilRationInCurrent.ReadOnly = true;
            // 
            // sGasEqChargeStates
            // 
            this.sGasEqChargeStates.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sGasEqChargeStates.HeaderText = "F(q) [Foil Stripper, Betz Formula]";
            this.sGasEqChargeStates.Name = "sGasEqChargeStates";
            this.sGasEqChargeStates.ReadOnly = true;
            // 
            // sGasRationInCurrent
            // 
            this.sGasRationInCurrent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sGasRationInCurrent.HeaderText = "I/I0 [Foil Stripper, Betz Formula]";
            this.sGasRationInCurrent.Name = "sGasRationInCurrent";
            this.sGasRationInCurrent.ReadOnly = true;
            // 
            // ssFoilEqChargeState
            // 
            this.ssFoilEqChargeState.HeaderText = "F(q) [Foil Stripper, Schiwietz - Schmitt formula]";
            this.ssFoilEqChargeState.Name = "ssFoilEqChargeState";
            this.ssFoilEqChargeState.ReadOnly = true;
            // 
            // ssFoilRatioInCurrent
            // 
            this.ssFoilRatioInCurrent.HeaderText = "I/I0 [Foil Stripper, Schiwietz - Schmitt formula]";
            this.ssFoilRatioInCurrent.Name = "ssFoilRatioInCurrent";
            this.ssFoilRatioInCurrent.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "F(q) [Gas Stripper, Sayer Formula]";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "I/I0 [Gas Stripper, Sayer formula]";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "F(q) [Gas Stripper, Schiwietz - Schmitt Formula]";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "I/I0 [Gas Stripper, Schiwietz - Schmitt formula ]";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // toolTip1
            // 
            this.toolTip1.Tag = "";
            this.toolTip1.ToolTipTitle = "Nikolaev - Dmitriev Formula";
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipTitle = "Sayer Formula";
            // 
            // plot1
            // 
            this.plot1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plot1.KeyboardPanHorizontalStep = 0.1D;
            this.plot1.KeyboardPanVerticalStep = 0.1D;
            this.plot1.Location = new System.Drawing.Point(10, 345);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(1161, 416);
            this.plot1.TabIndex = 5;
            this.plot1.Text = "plot1";
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // buttonExcel
            // 
            this.buttonExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExcel.Location = new System.Drawing.Point(1085, 345);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(86, 23);
            this.buttonExcel.TabIndex = 6;
            this.buttonExcel.Text = "Export to Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click_1);
            // 
            // buttonPNG
            // 
            this.buttonPNG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPNG.Location = new System.Drawing.Point(1085, 738);
            this.buttonPNG.Name = "buttonPNG";
            this.buttonPNG.Size = new System.Drawing.Size(86, 23);
            this.buttonPNG.TabIndex = 7;
            this.buttonPNG.Text = "Export to .png";
            this.buttonPNG.UseVisualStyleBackColor = true;
            this.buttonPNG.Click += new System.EventHandler(this.buttonPNG_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 773);
            this.Controls.Add(this.buttonPNG);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.plot1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataInputBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Calculating Charge States";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.dataInputBox.ResumeLayout(false);
            this.dataInputBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox dataInputBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.TextBox zBox;
        private System.Windows.Forms.TextBox mBox;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.Label inChargeLabel;
        private System.Windows.Forms.TextBox eBox;
        private System.Windows.Forms.Label energyLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip3;
        private OxyPlot.WindowsForms.Plot plot1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox icBox;
        private System.Windows.Forms.Label velLabel;
        private System.Windows.Forms.Button buttonPNG;
        private System.Windows.Forms.Label factorLabel;
        private System.Windows.Forms.TextBox factorBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel atmassLabel;
        private System.Windows.Forms.LinkLabel atnumLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn qColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ndFoilEqChargeState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ndFoilRatioInCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn sFoilEqChargeStates;
        private System.Windows.Forms.DataGridViewTextBoxColumn sFoilRationInCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn sGasEqChargeStates;
        private System.Windows.Forms.DataGridViewTextBoxColumn sGasRationInCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssFoilEqChargeState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssFoilRatioInCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;


    }
}

