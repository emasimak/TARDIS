namespace Charge_States
{
    partial class TARDIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TARDIS));
            this.groupBoxDataInput = new System.Windows.Forms.GroupBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.dataInput = new System.Windows.Forms.GroupBox();
            this.velocityValueLabel = new System.Windows.Forms.Label();
            this.inChargeLabel = new System.Windows.Forms.Label();
            this.icBox = new System.Windows.Forms.TextBox();
            this.atmassLabel = new System.Windows.Forms.LinkLabel();
            this.defaultLabelInCharge = new System.Windows.Forms.Label();
            this.defaultLabelFactor = new System.Windows.Forms.Label();
            this.factorLabel = new System.Windows.Forms.Label();
            this.atnumLabel = new System.Windows.Forms.LinkLabel();
            this.factorBox = new System.Windows.Forms.TextBox();
            this.velocityLabel = new System.Windows.Forms.Label();
            this.eBox = new System.Windows.Forms.TextBox();
            this.energyLabel = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.zBox = new System.Windows.Forms.TextBox();
            this.mBox = new System.Windows.Forms.TextBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.stripperType = new System.Windows.Forms.GroupBox();
            this.zGasLabel = new System.Windows.Forms.Label();
            this.zGasBox = new System.Windows.Forms.TextBox();
            this.zFoilLabel = new System.Windows.Forms.Label();
            this.zFoilBox = new System.Windows.Forms.TextBox();
            this.gasStripperButton = new System.Windows.Forms.RadioButton();
            this.foilStripperButton = new System.Windows.Forms.RadioButton();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.qColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plot1 = new OxyPlot.WindowsForms.Plot();
            this.buttonPNG = new System.Windows.Forms.Button();
            this.groupBoxDataInput.SuspendLayout();
            this.dataInput.SuspendLayout();
            this.stripperType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxDataInput
            // 
            this.groupBoxDataInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDataInput.Controls.Add(this.aboutButton);
            this.groupBoxDataInput.Controls.Add(this.calculateButton);
            this.groupBoxDataInput.Controls.Add(this.dataInput);
            this.groupBoxDataInput.Controls.Add(this.stripperType);
            this.groupBoxDataInput.Location = new System.Drawing.Point(18, 18);
            this.groupBoxDataInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDataInput.Name = "groupBoxDataInput";
            this.groupBoxDataInput.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDataInput.Size = new System.Drawing.Size(1732, 174);
            this.groupBoxDataInput.TabIndex = 0;
            this.groupBoxDataInput.TabStop = false;
            this.groupBoxDataInput.Text = "Data Input";
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aboutButton.Location = new System.Drawing.Point(1653, 66);
            this.aboutButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(69, 63);
            this.aboutButton.TabIndex = 11;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calculateButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.calculateButton.ForeColor = System.Drawing.Color.Black;
            this.calculateButton.Location = new System.Drawing.Point(1258, 66);
            this.calculateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(386, 63);
            this.calculateButton.TabIndex = 10;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // dataInput
            // 
            this.dataInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataInput.Controls.Add(this.velocityValueLabel);
            this.dataInput.Controls.Add(this.inChargeLabel);
            this.dataInput.Controls.Add(this.icBox);
            this.dataInput.Controls.Add(this.atmassLabel);
            this.dataInput.Controls.Add(this.defaultLabelInCharge);
            this.dataInput.Controls.Add(this.defaultLabelFactor);
            this.dataInput.Controls.Add(this.factorLabel);
            this.dataInput.Controls.Add(this.atnumLabel);
            this.dataInput.Controls.Add(this.factorBox);
            this.dataInput.Controls.Add(this.velocityLabel);
            this.dataInput.Controls.Add(this.eBox);
            this.dataInput.Controls.Add(this.energyLabel);
            this.dataInput.Controls.Add(this.zLabel);
            this.dataInput.Controls.Add(this.zBox);
            this.dataInput.Controls.Add(this.mBox);
            this.dataInput.Controls.Add(this.mLabel);
            this.dataInput.Location = new System.Drawing.Point(9, 29);
            this.dataInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataInput.Name = "dataInput";
            this.dataInput.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataInput.Size = new System.Drawing.Size(852, 128);
            this.dataInput.TabIndex = 0;
            this.dataInput.TabStop = false;
            this.dataInput.Text = "Beam Characteristics";
            // 
            // velocityValueLabel
            // 
            this.velocityValueLabel.AutoSize = true;
            this.velocityValueLabel.Location = new System.Drawing.Point(456, 86);
            this.velocityValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.velocityValueLabel.Name = "velocityValueLabel";
            this.velocityValueLabel.Size = new System.Drawing.Size(31, 20);
            this.velocityValueLabel.TabIndex = 34;
            this.velocityValueLabel.Text = "0.0";
            // 
            // inChargeLabel
            // 
            this.inChargeLabel.AutoSize = true;
            this.inChargeLabel.Location = new System.Drawing.Point(546, 43);
            this.inChargeLabel.Name = "inChargeLabel";
            this.inChargeLabel.Size = new System.Drawing.Size(138, 20);
            this.inChargeLabel.TabIndex = 25;
            this.inChargeLabel.Text = "Incoming Charge :";
            // 
            // icBox
            // 
            this.icBox.Location = new System.Drawing.Point(692, 38);
            this.icBox.Name = "icBox";
            this.icBox.Size = new System.Drawing.Size(43, 26);
            this.icBox.TabIndex = 26;
            this.icBox.Text = "1";
            // 
            // atmassLabel
            // 
            this.atmassLabel.AutoSize = true;
            this.atmassLabel.Location = new System.Drawing.Point(202, 86);
            this.atmassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.atmassLabel.Name = "atmassLabel";
            this.atmassLabel.Size = new System.Drawing.Size(96, 20);
            this.atmassLabel.TabIndex = 33;
            this.atmassLabel.TabStop = true;
            this.atmassLabel.Text = "Mass values";
            // 
            // defaultLabelInCharge
            // 
            this.defaultLabelInCharge.AutoSize = true;
            this.defaultLabelInCharge.Location = new System.Drawing.Point(744, 43);
            this.defaultLabelInCharge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.defaultLabelInCharge.Name = "defaultLabelInCharge";
            this.defaultLabelInCharge.Size = new System.Drawing.Size(86, 20);
            this.defaultLabelInCharge.TabIndex = 28;
            this.defaultLabelInCharge.Text = "[Default: 1]";
            // 
            // defaultLabelFactor
            // 
            this.defaultLabelFactor.AutoSize = true;
            this.defaultLabelFactor.Location = new System.Drawing.Point(746, 86);
            this.defaultLabelFactor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.defaultLabelFactor.Name = "defaultLabelFactor";
            this.defaultLabelFactor.Size = new System.Drawing.Size(86, 20);
            this.defaultLabelFactor.TabIndex = 31;
            this.defaultLabelFactor.Text = "[Default: 1]";
            // 
            // factorLabel
            // 
            this.factorLabel.AutoSize = true;
            this.factorLabel.Location = new System.Drawing.Point(618, 86);
            this.factorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.factorLabel.Name = "factorLabel";
            this.factorLabel.Size = new System.Drawing.Size(63, 20);
            this.factorLabel.TabIndex = 30;
            this.factorLabel.Text = "Factor :";
            // 
            // atnumLabel
            // 
            this.atnumLabel.AutoSize = true;
            this.atnumLabel.Location = new System.Drawing.Point(202, 37);
            this.atnumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.atnumLabel.Name = "atnumLabel";
            this.atnumLabel.Size = new System.Drawing.Size(68, 20);
            this.atnumLabel.TabIndex = 32;
            this.atnumLabel.TabStop = true;
            this.atnumLabel.Text = "Z values";
            // 
            // factorBox
            // 
            this.factorBox.Location = new System.Drawing.Point(692, 82);
            this.factorBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.factorBox.Name = "factorBox";
            this.factorBox.Size = new System.Drawing.Size(43, 26);
            this.factorBox.TabIndex = 29;
            this.factorBox.Text = "1";
            // 
            // velocityLabel
            // 
            this.velocityLabel.AutoSize = true;
            this.velocityLabel.Location = new System.Drawing.Point(358, 86);
            this.velocityLabel.Name = "velocityLabel";
            this.velocityLabel.Size = new System.Drawing.Size(85, 20);
            this.velocityLabel.TabIndex = 27;
            this.velocityLabel.Text = "u [mm/ns] :";
            // 
            // eBox
            // 
            this.eBox.Location = new System.Drawing.Point(454, 32);
            this.eBox.Name = "eBox";
            this.eBox.Size = new System.Drawing.Size(43, 26);
            this.eBox.TabIndex = 24;
            this.eBox.Text = "12";
            // 
            // energyLabel
            // 
            this.energyLabel.AutoSize = true;
            this.energyLabel.Location = new System.Drawing.Point(303, 35);
            this.energyLabel.Name = "energyLabel";
            this.energyLabel.Size = new System.Drawing.Size(140, 20);
            this.energyLabel.TabIndex = 23;
            this.energyLabel.Text = "Stripping E [MeV] :";
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(114, 37);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(27, 20);
            this.zLabel.TabIndex = 19;
            this.zLabel.Text = "Z :";
            // 
            // zBox
            // 
            this.zBox.Location = new System.Drawing.Point(150, 32);
            this.zBox.Name = "zBox";
            this.zBox.Size = new System.Drawing.Size(43, 26);
            this.zBox.TabIndex = 20;
            this.zBox.Text = "6";
            // 
            // mBox
            // 
            this.mBox.Location = new System.Drawing.Point(150, 75);
            this.mBox.Name = "mBox";
            this.mBox.Size = new System.Drawing.Size(43, 26);
            this.mBox.TabIndex = 22;
            this.mBox.Text = "12";
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(44, 86);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(98, 20);
            this.mLabel.TabIndex = 21;
            this.mLabel.Text = "Mass [amu] :";
            // 
            // stripperType
            // 
            this.stripperType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stripperType.Controls.Add(this.zGasLabel);
            this.stripperType.Controls.Add(this.zGasBox);
            this.stripperType.Controls.Add(this.zFoilLabel);
            this.stripperType.Controls.Add(this.zFoilBox);
            this.stripperType.Controls.Add(this.gasStripperButton);
            this.stripperType.Controls.Add(this.foilStripperButton);
            this.stripperType.Location = new System.Drawing.Point(870, 29);
            this.stripperType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stripperType.Name = "stripperType";
            this.stripperType.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stripperType.Size = new System.Drawing.Size(273, 128);
            this.stripperType.TabIndex = 0;
            this.stripperType.TabStop = false;
            this.stripperType.Text = "Stripper Type";
            // 
            // zGasLabel
            // 
            this.zGasLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zGasLabel.AutoSize = true;
            this.zGasLabel.Location = new System.Drawing.Point(184, 86);
            this.zGasLabel.Name = "zGasLabel";
            this.zGasLabel.Size = new System.Drawing.Size(27, 20);
            this.zGasLabel.TabIndex = 36;
            this.zGasLabel.Text = "Z :";
            // 
            // zGasBox
            // 
            this.zGasBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zGasBox.Enabled = false;
            this.zGasBox.Location = new System.Drawing.Point(220, 82);
            this.zGasBox.Name = "zGasBox";
            this.zGasBox.Size = new System.Drawing.Size(43, 26);
            this.zGasBox.TabIndex = 37;
            this.zGasBox.Text = "7";
            // 
            // zFoilLabel
            // 
            this.zFoilLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zFoilLabel.AutoSize = true;
            this.zFoilLabel.Location = new System.Drawing.Point(184, 43);
            this.zFoilLabel.Name = "zFoilLabel";
            this.zFoilLabel.Size = new System.Drawing.Size(27, 20);
            this.zFoilLabel.TabIndex = 33;
            this.zFoilLabel.Text = "Z :";
            // 
            // zFoilBox
            // 
            this.zFoilBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zFoilBox.Location = new System.Drawing.Point(220, 38);
            this.zFoilBox.Name = "zFoilBox";
            this.zFoilBox.Size = new System.Drawing.Size(43, 26);
            this.zFoilBox.TabIndex = 34;
            this.zFoilBox.Text = "6";
            // 
            // gasStripperButton
            // 
            this.gasStripperButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gasStripperButton.AutoSize = true;
            this.gasStripperButton.Location = new System.Drawing.Point(39, 85);
            this.gasStripperButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gasStripperButton.Name = "gasStripperButton";
            this.gasStripperButton.Size = new System.Drawing.Size(124, 24);
            this.gasStripperButton.TabIndex = 2;
            this.gasStripperButton.Text = "Gas Stripper";
            this.gasStripperButton.UseVisualStyleBackColor = true;
            // 
            // foilStripperButton
            // 
            this.foilStripperButton.AutoSize = true;
            this.foilStripperButton.Checked = true;
            this.foilStripperButton.Location = new System.Drawing.Point(39, 40);
            this.foilStripperButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.foilStripperButton.Name = "foilStripperButton";
            this.foilStripperButton.Size = new System.Drawing.Size(119, 24);
            this.foilStripperButton.TabIndex = 1;
            this.foilStripperButton.TabStop = true;
            this.foilStripperButton.Text = "Foil Stripper";
            this.foilStripperButton.UseVisualStyleBackColor = true;
            this.foilStripperButton.CheckedChanged += new System.EventHandler(this.foilStripperButton_CheckedChanged);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExcel.Location = new System.Drawing.Point(1621, 472);
            this.buttonExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(129, 35);
            this.buttonExcel.TabIndex = 8;
            this.buttonExcel.Text = "Export to Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qColumn});
            this.dataGridView1.Location = new System.Drawing.Point(18, 200);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1732, 264);
            this.dataGridView1.TabIndex = 7;
            // 
            // qColumn
            // 
            this.qColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.qColumn.HeaderText = "Charge (q)";
            this.qColumn.Name = "qColumn";
            this.qColumn.ReadOnly = true;
            // 
            // plot1
            // 
            this.plot1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plot1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plot1.KeyboardPanHorizontalStep = 0.1D;
            this.plot1.KeyboardPanVerticalStep = 0.1D;
            this.plot1.Location = new System.Drawing.Point(18, 472);
            this.plot1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(1732, 358);
            this.plot1.TabIndex = 9;
            this.plot1.Text = "plot1";
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // buttonPNG
            // 
            this.buttonPNG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPNG.Location = new System.Drawing.Point(1621, 795);
            this.buttonPNG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPNG.Name = "buttonPNG";
            this.buttonPNG.Size = new System.Drawing.Size(129, 35);
            this.buttonPNG.TabIndex = 10;
            this.buttonPNG.Text = "Export to .png";
            this.buttonPNG.UseVisualStyleBackColor = true;
            this.buttonPNG.Click += new System.EventHandler(this.buttonPNG_Click);
            // 
            // TARDIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1768, 844);
            this.Controls.Add(this.buttonPNG);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBoxDataInput);
            this.Controls.Add(this.plot1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TARDIS";
            this.Text = "T.AR.DIS";
            this.groupBoxDataInput.ResumeLayout(false);
            this.dataInput.ResumeLayout(false);
            this.dataInput.PerformLayout();
            this.stripperType.ResumeLayout(false);
            this.stripperType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDataInput;
        private System.Windows.Forms.GroupBox stripperType;
        private System.Windows.Forms.GroupBox dataInput;
        private System.Windows.Forms.LinkLabel atmassLabel;
        private System.Windows.Forms.LinkLabel atnumLabel;
        private System.Windows.Forms.Label defaultLabelFactor;
        private System.Windows.Forms.Label factorLabel;
        private System.Windows.Forms.TextBox factorBox;
        private System.Windows.Forms.Label defaultLabelInCharge;
        private System.Windows.Forms.Label velocityLabel;
        private System.Windows.Forms.TextBox icBox;
        private System.Windows.Forms.Label inChargeLabel;
        private System.Windows.Forms.TextBox eBox;
        private System.Windows.Forms.Label energyLabel;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.TextBox zBox;
        private System.Windows.Forms.TextBox mBox;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label velocityValueLabel;
        private System.Windows.Forms.RadioButton gasStripperButton;
        private System.Windows.Forms.RadioButton foilStripperButton;
        private System.Windows.Forms.Label zGasLabel;
        private System.Windows.Forms.TextBox zGasBox;
        private System.Windows.Forms.Label zFoilLabel;
        private System.Windows.Forms.TextBox zFoilBox;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private OxyPlot.WindowsForms.Plot plot1;
        private System.Windows.Forms.Button buttonPNG;
        private System.Windows.Forms.DataGridViewTextBoxColumn qColumn;
    }
}