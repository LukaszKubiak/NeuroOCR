namespace NeuralNetworkOCR
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.initialReceptorsBox = new System.Windows.Forms.TextBox();
            this.receptorsBox = new System.Windows.Forms.TextBox();
            this.currentReceptorsBox = new System.Windows.Forms.TextBox();
            this.showReceptorsCheck = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.arialCheck = new System.Windows.Forms.CheckBox();
            this.courierCheck = new System.Windows.Forms.CheckBox();
            this.tahomaCheck = new System.Windows.Forms.CheckBox();
            this.timesCheck = new System.Windows.Forms.CheckBox();
            this.verdanaCheck = new System.Windows.Forms.CheckBox();
            this.arialItalicCheck = new System.Windows.Forms.CheckBox();
            this.courierItalicCheck = new System.Windows.Forms.CheckBox();
            this.tahomaItalicCheck = new System.Windows.Forms.CheckBox();
            this.timesItalicCheck = new System.Windows.Forms.CheckBox();
            this.verdanaItalicCheck = new System.Windows.Forms.CheckBox();
            this.lettersCombo = new System.Windows.Forms.ComboBox();
            this.fontsCombo = new System.Windows.Forms.ComboBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dataGrid = new NeuralNetworkOCR.GridArray();
            this.drawingArea = new NeuralNetworkOCR.DrawingArea();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.drawingArea);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 206);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drawing Area";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Wyczyść";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.showReceptorsCheck);
            this.groupBox2.Controls.Add(this.currentReceptorsBox);
            this.groupBox2.Controls.Add(this.receptorsBox);
            this.groupBox2.Controls.Add(this.initialReceptorsBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 148);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receptory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Początkowo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Odfiltrowanych";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Obecnie";
            // 
            // initialReceptorsBox
            // 
            this.initialReceptorsBox.Location = new System.Drawing.Point(108, 22);
            this.initialReceptorsBox.Name = "initialReceptorsBox";
            this.initialReceptorsBox.Size = new System.Drawing.Size(82, 20);
            this.initialReceptorsBox.TabIndex = 3;
            this.initialReceptorsBox.Text = "500";
            // 
            // receptorsBox
            // 
            this.receptorsBox.Location = new System.Drawing.Point(108, 53);
            this.receptorsBox.Name = "receptorsBox";
            this.receptorsBox.Size = new System.Drawing.Size(82, 20);
            this.receptorsBox.TabIndex = 4;
            this.receptorsBox.Text = "100";
            // 
            // currentReceptorsBox
            // 
            this.currentReceptorsBox.Enabled = false;
            this.currentReceptorsBox.Location = new System.Drawing.Point(108, 79);
            this.currentReceptorsBox.Name = "currentReceptorsBox";
            this.currentReceptorsBox.Size = new System.Drawing.Size(82, 20);
            this.currentReceptorsBox.TabIndex = 5;
            // 
            // showReceptorsCheck
            // 
            this.showReceptorsCheck.AutoSize = true;
            this.showReceptorsCheck.Location = new System.Drawing.Point(6, 114);
            this.showReceptorsCheck.Name = "showReceptorsCheck";
            this.showReceptorsCheck.Size = new System.Drawing.Size(103, 17);
            this.showReceptorsCheck.TabIndex = 6;
            this.showReceptorsCheck.Text = "Pokaż receptory";
            this.showReceptorsCheck.UseVisualStyleBackColor = true;
            this.showReceptorsCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(115, 114);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Generuj";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.drawButton);
            this.groupBox3.Controls.Add(this.fontsCombo);
            this.groupBox3.Controls.Add(this.lettersCombo);
            this.groupBox3.Controls.Add(this.timesItalicCheck);
            this.groupBox3.Controls.Add(this.tahomaItalicCheck);
            this.groupBox3.Controls.Add(this.courierItalicCheck);
            this.groupBox3.Controls.Add(this.arialItalicCheck);
            this.groupBox3.Controls.Add(this.verdanaCheck);
            this.groupBox3.Controls.Add(this.timesCheck);
            this.groupBox3.Controls.Add(this.tahomaCheck);
            this.groupBox3.Controls.Add(this.courierCheck);
            this.groupBox3.Controls.Add(this.arialCheck);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(9, 380);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 214);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dane Treningowe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Arial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Courier";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tahoma";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Times New Roman";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Verdana";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Normalna";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Italic";
            // 
            // arialCheck
            // 
            this.arialCheck.AutoSize = true;
            this.arialCheck.Checked = true;
            this.arialCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.arialCheck.Location = new System.Drawing.Point(123, 41);
            this.arialCheck.Name = "arialCheck";
            this.arialCheck.Size = new System.Drawing.Size(15, 14);
            this.arialCheck.TabIndex = 7;
            this.arialCheck.UseVisualStyleBackColor = true;
            this.arialCheck.CheckedChanged += new System.EventHandler(this.fontCheck_CheckedChanged);
            // 
            // courierCheck
            // 
            this.courierCheck.AutoSize = true;
            this.courierCheck.Location = new System.Drawing.Point(123, 67);
            this.courierCheck.Name = "courierCheck";
            this.courierCheck.Size = new System.Drawing.Size(15, 14);
            this.courierCheck.TabIndex = 8;
            this.courierCheck.UseVisualStyleBackColor = true;
            this.courierCheck.CheckedChanged += new System.EventHandler(this.fontCheck_CheckedChanged);
            // 
            // tahomaCheck
            // 
            this.tahomaCheck.AutoSize = true;
            this.tahomaCheck.Location = new System.Drawing.Point(123, 92);
            this.tahomaCheck.Name = "tahomaCheck";
            this.tahomaCheck.Size = new System.Drawing.Size(15, 14);
            this.tahomaCheck.TabIndex = 9;
            this.tahomaCheck.UseVisualStyleBackColor = true;
            this.tahomaCheck.CheckedChanged += new System.EventHandler(this.fontCheck_CheckedChanged);
            // 
            // timesCheck
            // 
            this.timesCheck.AutoSize = true;
            this.timesCheck.Location = new System.Drawing.Point(123, 118);
            this.timesCheck.Name = "timesCheck";
            this.timesCheck.Size = new System.Drawing.Size(15, 14);
            this.timesCheck.TabIndex = 10;
            this.timesCheck.UseVisualStyleBackColor = true;
            this.timesCheck.CheckedChanged += new System.EventHandler(this.fontCheck_CheckedChanged);
            // 
            // verdanaCheck
            // 
            this.verdanaCheck.AutoSize = true;
            this.verdanaCheck.Location = new System.Drawing.Point(123, 146);
            this.verdanaCheck.Name = "verdanaCheck";
            this.verdanaCheck.Size = new System.Drawing.Size(15, 14);
            this.verdanaCheck.TabIndex = 11;
            this.verdanaCheck.UseVisualStyleBackColor = true;
            this.verdanaCheck.CheckedChanged += new System.EventHandler(this.fontCheck_CheckedChanged);
            // 
            // arialItalicCheck
            // 
            this.arialItalicCheck.AutoSize = true;
            this.arialItalicCheck.Location = new System.Drawing.Point(158, 40);
            this.arialItalicCheck.Name = "arialItalicCheck";
            this.arialItalicCheck.Size = new System.Drawing.Size(15, 14);
            this.arialItalicCheck.TabIndex = 12;
            this.arialItalicCheck.UseVisualStyleBackColor = true;
            this.arialItalicCheck.CheckedChanged += new System.EventHandler(this.fontCheck_CheckedChanged);
            // 
            // courierItalicCheck
            // 
            this.courierItalicCheck.AutoSize = true;
            this.courierItalicCheck.Location = new System.Drawing.Point(158, 67);
            this.courierItalicCheck.Name = "courierItalicCheck";
            this.courierItalicCheck.Size = new System.Drawing.Size(15, 14);
            this.courierItalicCheck.TabIndex = 13;
            this.courierItalicCheck.UseVisualStyleBackColor = true;
            this.courierItalicCheck.CheckedChanged += new System.EventHandler(this.fontCheck_CheckedChanged);
            // 
            // tahomaItalicCheck
            // 
            this.tahomaItalicCheck.AutoSize = true;
            this.tahomaItalicCheck.Location = new System.Drawing.Point(158, 93);
            this.tahomaItalicCheck.Name = "tahomaItalicCheck";
            this.tahomaItalicCheck.Size = new System.Drawing.Size(15, 14);
            this.tahomaItalicCheck.TabIndex = 14;
            this.tahomaItalicCheck.UseVisualStyleBackColor = true;
            this.tahomaItalicCheck.CheckedChanged += new System.EventHandler(this.fontCheck_CheckedChanged);
            // 
            // timesItalicCheck
            // 
            this.timesItalicCheck.AutoSize = true;
            this.timesItalicCheck.Location = new System.Drawing.Point(158, 117);
            this.timesItalicCheck.Name = "timesItalicCheck";
            this.timesItalicCheck.Size = new System.Drawing.Size(15, 14);
            this.timesItalicCheck.TabIndex = 15;
            this.timesItalicCheck.UseVisualStyleBackColor = true;
            this.timesItalicCheck.CheckedChanged += new System.EventHandler(this.fontCheck_CheckedChanged);
            // 
            // verdanaItalicCheck
            // 
            this.verdanaItalicCheck.AutoSize = true;
            this.verdanaItalicCheck.Location = new System.Drawing.Point(167, 525);
            this.verdanaItalicCheck.Name = "verdanaItalicCheck";
            this.verdanaItalicCheck.Size = new System.Drawing.Size(15, 14);
            this.verdanaItalicCheck.TabIndex = 16;
            this.verdanaItalicCheck.UseVisualStyleBackColor = true;
            this.verdanaItalicCheck.CheckedChanged += new System.EventHandler(this.fontCheck_CheckedChanged);
            // 
            // lettersCombo
            // 
            this.lettersCombo.FormattingEnabled = true;
            this.lettersCombo.Location = new System.Drawing.Point(6, 187);
            this.lettersCombo.Name = "lettersCombo";
            this.lettersCombo.Size = new System.Drawing.Size(40, 21);
            this.lettersCombo.TabIndex = 16;
            // 
            // fontsCombo
            // 
            this.fontsCombo.FormattingEnabled = true;
            this.fontsCombo.Location = new System.Drawing.Point(53, 187);
            this.fontsCombo.Name = "fontsCombo";
            this.fontsCombo.Size = new System.Drawing.Size(75, 21);
            this.fontsCombo.TabIndex = 17;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(134, 185);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(50, 23);
            this.drawButton.TabIndex = 18;
            this.drawButton.Text = "Rysuj";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.filterButton);
            this.groupBox4.Controls.Add(this.generateButton);
            this.groupBox4.Controls.Add(this.dataGrid);
            this.groupBox4.Location = new System.Drawing.Point(207, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(668, 582);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dane treningowe";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(506, 551);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generuj";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(587, 553);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 21);
            this.filterButton.TabIndex = 2;
            this.filterButton.Text = "Filtruj";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dataGrid
            // 
            this.dataGrid.AutoSizeMinHeight = 10;
            this.dataGrid.AutoSizeMinWidth = 10;
            this.dataGrid.AutoStretchColumnsToFitWidth = false;
            this.dataGrid.AutoStretchRowsToFitHeight = false;
            this.dataGrid.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.dataGrid.GridToolTipActive = true;
            this.dataGrid.Location = new System.Drawing.Point(7, 21);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(655, 526);
            this.dataGrid.SpecialKeys = ((SourceGrid2.GridSpecialKeys)(((((((((((SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V) 
            | SourceGrid2.GridSpecialKeys.Ctrl_X) 
            | SourceGrid2.GridSpecialKeys.Delete) 
            | SourceGrid2.GridSpecialKeys.Arrows) 
            | SourceGrid2.GridSpecialKeys.Tab) 
            | SourceGrid2.GridSpecialKeys.PageDownUp) 
            | SourceGrid2.GridSpecialKeys.Enter) 
            | SourceGrid2.GridSpecialKeys.Escape) 
            | SourceGrid2.GridSpecialKeys.Control) 
            | SourceGrid2.GridSpecialKeys.Shift)));
            this.dataGrid.TabIndex = 0;
            // 
            // drawingArea
            // 
            this.drawingArea.Location = new System.Drawing.Point(15, 21);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Receptors = null;
            this.drawingArea.Size = new System.Drawing.Size(150, 150);
            this.drawingArea.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 606);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.verdanaItalicCheck);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "NeuralNetworkOCR";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DrawingArea drawingArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox showReceptorsCheck;
        private System.Windows.Forms.TextBox currentReceptorsBox;
        private System.Windows.Forms.TextBox receptorsBox;
        private System.Windows.Forms.TextBox initialReceptorsBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.ComboBox fontsCombo;
        private System.Windows.Forms.ComboBox lettersCombo;
        private System.Windows.Forms.CheckBox timesItalicCheck;
        private System.Windows.Forms.CheckBox tahomaItalicCheck;
        private System.Windows.Forms.CheckBox courierItalicCheck;
        private System.Windows.Forms.CheckBox arialItalicCheck;
        private System.Windows.Forms.CheckBox verdanaCheck;
        private System.Windows.Forms.CheckBox timesCheck;
        private System.Windows.Forms.CheckBox tahomaCheck;
        private System.Windows.Forms.CheckBox courierCheck;
        private System.Windows.Forms.CheckBox arialCheck;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox verdanaItalicCheck;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button generateButton;
        private GridArray dataGrid;
        private System.Windows.Forms.Timer timer;
    }
}

