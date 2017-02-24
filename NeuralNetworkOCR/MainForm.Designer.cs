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
            this.button3 = new System.Windows.Forms.Button();
            this.showReceptorsCheck = new System.Windows.Forms.CheckBox();
            this.currentReceptorsBox = new System.Windows.Forms.TextBox();
            this.receptorsBox = new System.Windows.Forms.TextBox();
            this.initialReceptorsBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.fontsCombo = new System.Windows.Forms.ComboBox();
            this.lettersCombo = new System.Windows.Forms.ComboBox();
            this.timesItalicCheck = new System.Windows.Forms.CheckBox();
            this.tahomaItalicCheck = new System.Windows.Forms.CheckBox();
            this.courierItalicCheck = new System.Windows.Forms.CheckBox();
            this.arialItalicCheck = new System.Windows.Forms.CheckBox();
            this.verdanaCheck = new System.Windows.Forms.CheckBox();
            this.timesCheck = new System.Windows.Forms.CheckBox();
            this.tahomaCheck = new System.Windows.Forms.CheckBox();
            this.courierCheck = new System.Windows.Forms.CheckBox();
            this.arialCheck = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.verdanaItalicCheck = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.misclassifiedBox = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.limit2Box = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.traintNetworkButton = new System.Windows.Forms.Button();
            this.limit1Box = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.createNetButton = new System.Windows.Forms.Button();
            this.layersCombo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGrid = new NeuralNetworkOCR.GridArray();
            this.drawingArea = new NeuralNetworkOCR.DrawingArea();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            // currentReceptorsBox
            // 
            this.currentReceptorsBox.Enabled = false;
            this.currentReceptorsBox.Location = new System.Drawing.Point(108, 79);
            this.currentReceptorsBox.Name = "currentReceptorsBox";
            this.currentReceptorsBox.Size = new System.Drawing.Size(82, 20);
            this.currentReceptorsBox.TabIndex = 5;
            // 
            // receptorsBox
            // 
            this.receptorsBox.Location = new System.Drawing.Point(108, 53);
            this.receptorsBox.Name = "receptorsBox";
            this.receptorsBox.Size = new System.Drawing.Size(82, 20);
            this.receptorsBox.TabIndex = 4;
            this.receptorsBox.Text = "100";
            // 
            // initialReceptorsBox
            // 
            this.initialReceptorsBox.Location = new System.Drawing.Point(108, 22);
            this.initialReceptorsBox.Name = "initialReceptorsBox";
            this.initialReceptorsBox.Size = new System.Drawing.Size(82, 20);
            this.initialReceptorsBox.TabIndex = 3;
            this.initialReceptorsBox.Text = "500";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Odfiltrowanych";
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
            // fontsCombo
            // 
            this.fontsCombo.FormattingEnabled = true;
            this.fontsCombo.Location = new System.Drawing.Point(53, 187);
            this.fontsCombo.Name = "fontsCombo";
            this.fontsCombo.Size = new System.Drawing.Size(75, 21);
            this.fontsCombo.TabIndex = 17;
            // 
            // lettersCombo
            // 
            this.lettersCombo.FormattingEnabled = true;
            this.lettersCombo.Location = new System.Drawing.Point(6, 187);
            this.lettersCombo.Name = "lettersCombo";
            this.lettersCombo.Size = new System.Drawing.Size(40, 21);
            this.lettersCombo.TabIndex = 16;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Italic";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Verdana";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tahoma";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Arial";
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.filterButton);
            this.groupBox4.Controls.Add(this.generateButton);
            this.groupBox4.Controls.Add(this.dataGrid);
            this.groupBox4.Location = new System.Drawing.Point(207, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(668, 485);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dane treningowe";
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(593, 458);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 21);
            this.filterButton.TabIndex = 2;
            this.filterButton.Text = "Filtruj";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(500, 456);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generuj";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.misclassifiedBox);
            this.groupBox5.Controls.Add(this.outputBox);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.errorBox);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.limit2Box);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.recognizeButton);
            this.groupBox5.Controls.Add(this.traintNetworkButton);
            this.groupBox5.Controls.Add(this.limit1Box);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.createNetButton);
            this.groupBox5.Controls.Add(this.layersCombo);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(881, 33);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(251, 561);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sieć neuronowa";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(14, 269);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(95, 14);
            this.label27.TabIndex = 39;
            this.label27.Text = "Źle rozpoznanych";
            // 
            // misclassifiedBox
            // 
            this.misclassifiedBox.Location = new System.Drawing.Point(115, 267);
            this.misclassifiedBox.Name = "misclassifiedBox";
            this.misclassifiedBox.ReadOnly = true;
            this.misclassifiedBox.Size = new System.Drawing.Size(121, 20);
            this.misclassifiedBox.TabIndex = 38;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(163, 306);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(73, 20);
            this.outputBox.TabIndex = 37;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(14, 306);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(127, 14);
            this.label26.TabIndex = 36;
            this.label26.Text = "Wartość:";
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(115, 242);
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(121, 20);
            this.errorBox.TabIndex = 35;
            this.errorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(14, 244);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(85, 14);
            this.label25.TabIndex = 34;
            this.label25.Text = "Błąd ogólny";
            // 
            // limit2Box
            // 
            this.limit2Box.Location = new System.Drawing.Point(115, 173);
            this.limit2Box.Name = "limit2Box";
            this.limit2Box.Size = new System.Drawing.Size(62, 20);
            this.limit2Box.TabIndex = 33;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(15, 182);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 14);
            this.label21.TabIndex = 32;
            this.label21.Text = "Limit Błędu";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(14, 156);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 14);
            this.label20.TabIndex = 29;
            this.label20.Text = "Drugi cykl:";
            // 
            // recognizeButton
            // 
            this.recognizeButton.Enabled = false;
            this.recognizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recognizeButton.Location = new System.Drawing.Point(141, 347);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(95, 23);
            this.recognizeButton.TabIndex = 28;
            this.recognizeButton.Text = "Rozpoznaj";
            this.recognizeButton.Click += new System.EventHandler(this.recognizeButton_Click);
            // 
            // traintNetworkButton
            // 
            this.traintNetworkButton.Enabled = false;
            this.traintNetworkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.traintNetworkButton.Location = new System.Drawing.Point(141, 207);
            this.traintNetworkButton.Name = "traintNetworkButton";
            this.traintNetworkButton.Size = new System.Drawing.Size(95, 23);
            this.traintNetworkButton.TabIndex = 27;
            this.traintNetworkButton.Text = "Ucz";
            this.traintNetworkButton.Click += new System.EventHandler(this.traintNetworkButton_Click);
            // 
            // limit1Box
            // 
            this.limit1Box.Location = new System.Drawing.Point(115, 112);
            this.limit1Box.Name = "limit1Box";
            this.limit1Box.Size = new System.Drawing.Size(62, 20);
            this.limit1Box.TabIndex = 16;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(14, 115);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 14);
            this.label19.TabIndex = 15;
            this.label19.Text = "Limit Błędu";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(11, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 14);
            this.label17.TabIndex = 9;
            this.label17.Text = "Pierwszy cykl:";
            // 
            // createNetButton
            // 
            this.createNetButton.Location = new System.Drawing.Point(115, 46);
            this.createNetButton.Name = "createNetButton";
            this.createNetButton.Size = new System.Drawing.Size(121, 23);
            this.createNetButton.TabIndex = 3;
            this.createNetButton.Text = "Stwórz sieć";
            this.createNetButton.UseVisualStyleBackColor = true;
            this.createNetButton.Click += new System.EventHandler(this.createNetButton_Click);
            // 
            // layersCombo
            // 
            this.layersCombo.FormattingEnabled = true;
            this.layersCombo.Items.AddRange(new object[] {
            "1",
            "2"});
            this.layersCombo.Location = new System.Drawing.Point(115, 19);
            this.layersCombo.Name = "layersCombo";
            this.layersCombo.Size = new System.Drawing.Size(121, 21);
            this.layersCombo.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Ilość warstw";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.stopButton);
            this.groupBox6.Controls.Add(this.progressBar);
            this.groupBox6.Controls.Add(this.statusBox);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.timeBox);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Location = new System.Drawing.Point(207, 503);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(668, 95);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Postęp";
            // 
            // stopButton
            // 
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Location = new System.Drawing.Point(250, 62);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(10, 45);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(648, 10);
            this.progressBar.TabIndex = 4;
            // 
            // statusBox
            // 
            this.statusBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBox.Location = new System.Drawing.Point(250, 20);
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(408, 20);
            this.statusBox.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(200, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 17);
            this.label16.TabIndex = 2;
            this.label16.Text = "Status:";
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(90, 20);
            this.timeBox.Name = "timeBox";
            this.timeBox.ReadOnly = true;
            this.timeBox.Size = new System.Drawing.Size(80, 20);
            this.timeBox.TabIndex = 1;
            this.timeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(10, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 19);
            this.label15.TabIndex = 0;
            this.label15.Text = "Czas:";
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
            this.dataGrid.Size = new System.Drawing.Size(655, 428);
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
            this.drawingArea.ScaleImage = true;
            this.drawingArea.Size = new System.Drawing.Size(150, 150);
            this.drawingArea.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 606);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button createNetButton;
        private System.Windows.Forms.ComboBox layersCombo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox misclassifiedBox;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox limit2Box;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.Button traintNetworkButton;
        private System.Windows.Forms.TextBox limit1Box;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.Label label15;
    }
}

