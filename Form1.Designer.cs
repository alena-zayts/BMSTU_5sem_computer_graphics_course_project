﻿namespace Weatherwane
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.canvas = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnDeleteObject = new System.Windows.Forms.TabPage();
            this.choiceObject = new System.Windows.Forms.ComboBox();
            this.labelChoiceColor = new System.Windows.Forms.Label();
            this.ChoiceReflective = new System.Windows.Forms.NumericUpDown();
            this.ChoiceSpecular = new System.Windows.Forms.NumericUpDown();
            this.ChoiceColor = new System.Windows.Forms.PictureBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.labelChoiceSpecular = new System.Windows.Forms.Label();
            this.labelChoiceReflective = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AddLightIntensity = new System.Windows.Forms.NumericUpDown();
            this.btnDeleteLight = new System.Windows.Forms.Button();
            this.btnAddLight = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.AddLightPosZ = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ChangeLightIntensity = new System.Windows.Forms.NumericUpDown();
            this.ChangeLightPosZ = new System.Windows.Forms.NumericUpDown();
            this.btnChangeLightParams = new System.Windows.Forms.Button();
            this.AddLightPosY = new System.Windows.Forms.NumericUpDown();
            this.ChangeLightPosY = new System.Windows.Forms.NumericUpDown();
            this.label90 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.ChangeLightPosX = new System.Windows.Forms.NumericUpDown();
            this.AddLightPosX = new System.Windows.Forms.NumericUpDown();
            this.LightPosX = new System.Windows.Forms.TextBox();
            this.LightIntensity = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxLights = new System.Windows.Forms.ComboBox();
            this.labelLightPos = new System.Windows.Forms.Label();
            this.labelChangeLightPos = new System.Windows.Forms.Label();
            this.LightPosZ = new System.Windows.Forms.TextBox();
            this.LightPosY = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonRollCamera = new System.Windows.Forms.Button();
            this.rollCamera = new System.Windows.Forms.NumericUpDown();
            this.pitchCamera = new System.Windows.Forms.NumericUpDown();
            this.buttonPitchCamera = new System.Windows.Forms.Button();
            this.yawCamera = new System.Windows.Forms.NumericUpDown();
            this.buttonYawCamera = new System.Windows.Forms.Button();
            this.moveCameraDX = new System.Windows.Forms.NumericUpDown();
            this.moveCameraDY = new System.Windows.Forms.NumericUpDown();
            this.moveCameraDZ = new System.Windows.Forms.NumericUpDown();
            this.buttonMoveCamera = new System.Windows.Forms.Button();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.CameraPosX = new System.Windows.Forms.TextBox();
            this.CameraPosY = new System.Windows.Forms.TextBox();
            this.CameraPosZ = new System.Windows.Forms.TextBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.CameraRotOZ = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.CameraRotOY = new System.Windows.Forms.TextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.CameraRotOX = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.checkBoxNebo = new System.Windows.Forms.CheckBox();
            this.dynamicButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.offButton = new System.Windows.Forms.Button();
            this.trackBarN = new System.Windows.Forms.TrackBar();
            this.label21 = new System.Windows.Forms.Label();
            this.radioRight = new System.Windows.Forms.RadioButton();
            this.radioLeft = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.numericNumThreads = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.btnDeleteObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChoiceReflective)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoiceSpecular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoiceColor)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddLightIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddLightPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeLightIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeLightPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddLightPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeLightPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeLightPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddLightPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yawCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveCameraDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveCameraDY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveCameraDZ)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.InitialImage = ((System.Drawing.Image)(resources.GetObject("canvas.InitialImage")));
            this.canvas.Location = new System.Drawing.Point(1571, 96);
            this.canvas.Margin = new System.Windows.Forms.Padding(6);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1320, 1269);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.btnDeleteObject);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(745, 57);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(785, 772);
            this.tabControl1.TabIndex = 45;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // btnDeleteObject
            // 
            this.btnDeleteObject.Controls.Add(this.choiceObject);
            this.btnDeleteObject.Controls.Add(this.labelChoiceColor);
            this.btnDeleteObject.Controls.Add(this.ChoiceReflective);
            this.btnDeleteObject.Controls.Add(this.ChoiceSpecular);
            this.btnDeleteObject.Controls.Add(this.ChoiceColor);
            this.btnDeleteObject.Controls.Add(this.btnChange);
            this.btnDeleteObject.Controls.Add(this.labelChoiceSpecular);
            this.btnDeleteObject.Controls.Add(this.labelChoiceReflective);
            this.btnDeleteObject.Location = new System.Drawing.Point(8, 39);
            this.btnDeleteObject.Margin = new System.Windows.Forms.Padding(6);
            this.btnDeleteObject.Name = "btnDeleteObject";
            this.btnDeleteObject.Padding = new System.Windows.Forms.Padding(6);
            this.btnDeleteObject.Size = new System.Drawing.Size(769, 725);
            this.btnDeleteObject.TabIndex = 1;
            this.btnDeleteObject.Text = "Изменение примитивов";
            this.btnDeleteObject.UseVisualStyleBackColor = true;
            // 
            // choiceObject
            // 
            this.choiceObject.AutoCompleteCustomSource.AddRange(new string[] {
            "Сфера",
            "Цилиндр",
            "Конус",
            "Треугольная пирамида",
            "Четырехугольная пирамида",
            "Параллелепипед"});
            this.choiceObject.DisplayMember = "Сфера";
            this.choiceObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.choiceObject.FormattingEnabled = true;
            this.choiceObject.Items.AddRange(new object[] {
            "Сфера",
            "Конус",
            "Четырехугольная пирамида",
            "Треугольная пирамида",
            "Цилиндр",
            "Параллелепипед"});
            this.choiceObject.Location = new System.Drawing.Point(12, 12);
            this.choiceObject.Margin = new System.Windows.Forms.Padding(6);
            this.choiceObject.Name = "choiceObject";
            this.choiceObject.Size = new System.Drawing.Size(637, 33);
            this.choiceObject.TabIndex = 329;
            this.choiceObject.SelectedIndexChanged += new System.EventHandler(this.choiceObject_SelectedIndexChanged);
            // 
            // labelChoiceColor
            // 
            this.labelChoiceColor.AutoSize = true;
            this.labelChoiceColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChoiceColor.Location = new System.Drawing.Point(16, 67);
            this.labelChoiceColor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelChoiceColor.Name = "labelChoiceColor";
            this.labelChoiceColor.Size = new System.Drawing.Size(79, 30);
            this.labelChoiceColor.TabIndex = 325;
            this.labelChoiceColor.Text = "Цвет:";
            // 
            // ChoiceReflective
            // 
            this.ChoiceReflective.DecimalPlaces = 3;
            this.ChoiceReflective.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ChoiceReflective.Location = new System.Drawing.Point(349, 167);
            this.ChoiceReflective.Margin = new System.Windows.Forms.Padding(6);
            this.ChoiceReflective.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ChoiceReflective.Name = "ChoiceReflective";
            this.ChoiceReflective.Size = new System.Drawing.Size(96, 31);
            this.ChoiceReflective.TabIndex = 323;
            // 
            // ChoiceSpecular
            // 
            this.ChoiceSpecular.Location = new System.Drawing.Point(349, 117);
            this.ChoiceSpecular.Margin = new System.Windows.Forms.Padding(6);
            this.ChoiceSpecular.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ChoiceSpecular.Name = "ChoiceSpecular";
            this.ChoiceSpecular.Size = new System.Drawing.Size(96, 31);
            this.ChoiceSpecular.TabIndex = 322;
            // 
            // ChoiceColor
            // 
            this.ChoiceColor.BackColor = System.Drawing.Color.Red;
            this.ChoiceColor.Location = new System.Drawing.Point(349, 67);
            this.ChoiceColor.Margin = new System.Windows.Forms.Padding(6);
            this.ChoiceColor.Name = "ChoiceColor";
            this.ChoiceColor.Size = new System.Drawing.Size(116, 38);
            this.ChoiceColor.TabIndex = 321;
            this.ChoiceColor.TabStop = false;
            this.ChoiceColor.Click += new System.EventHandler(this.ChoiceColor_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(22, 226);
            this.btnChange.Margin = new System.Windows.Forms.Padding(6);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(150, 44);
            this.btnChange.TabIndex = 324;
            this.btnChange.Text = "Применить";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // labelChoiceSpecular
            // 
            this.labelChoiceSpecular.AutoSize = true;
            this.labelChoiceSpecular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChoiceSpecular.Location = new System.Drawing.Point(16, 117);
            this.labelChoiceSpecular.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelChoiceSpecular.Name = "labelChoiceSpecular";
            this.labelChoiceSpecular.Size = new System.Drawing.Size(212, 30);
            this.labelChoiceSpecular.TabIndex = 326;
            this.labelChoiceSpecular.Text = "Уровень блеска:";
            // 
            // labelChoiceReflective
            // 
            this.labelChoiceReflective.AutoSize = true;
            this.labelChoiceReflective.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChoiceReflective.Location = new System.Drawing.Point(16, 167);
            this.labelChoiceReflective.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelChoiceReflective.Name = "labelChoiceReflective";
            this.labelChoiceReflective.Size = new System.Drawing.Size(327, 30);
            this.labelChoiceReflective.TabIndex = 327;
            this.labelChoiceReflective.Text = "Коэффициент отражения:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(741, 725);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Просмотр примитивов";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Items.AddRange(new object[] {
            "name=Сфера_1 C=(3;0;5); R=1",
            "name=Сфера_2 C=(3;0;5); R=4",
            "name=Цилиндр_1 C=(3;0;5); V=(0;1;0); Rосн = 2; H =1"});
            this.listBox1.Location = new System.Drawing.Point(10, 10);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(725, 704);
            this.listBox1.TabIndex = 1;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(15, 841);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(718, 669);
            this.tabControl2.TabIndex = 46;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.AddLightIntensity);
            this.tabPage4.Controls.Add(this.btnDeleteLight);
            this.tabPage4.Controls.Add(this.btnAddLight);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.AddLightPosZ);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.ChangeLightIntensity);
            this.tabPage4.Controls.Add(this.ChangeLightPosZ);
            this.tabPage4.Controls.Add(this.btnChangeLightParams);
            this.tabPage4.Controls.Add(this.AddLightPosY);
            this.tabPage4.Controls.Add(this.ChangeLightPosY);
            this.tabPage4.Controls.Add(this.label90);
            this.tabPage4.Controls.Add(this.label88);
            this.tabPage4.Controls.Add(this.ChangeLightPosX);
            this.tabPage4.Controls.Add(this.AddLightPosX);
            this.tabPage4.Controls.Add(this.LightPosX);
            this.tabPage4.Controls.Add(this.LightIntensity);
            this.tabPage4.Controls.Add(this.label78);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.comboBoxLights);
            this.tabPage4.Controls.Add(this.labelLightPos);
            this.tabPage4.Controls.Add(this.labelChangeLightPos);
            this.tabPage4.Controls.Add(this.LightPosZ);
            this.tabPage4.Controls.Add(this.LightPosY);
            this.tabPage4.Location = new System.Drawing.Point(8, 39);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage4.Size = new System.Drawing.Size(702, 622);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Освещение";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(540, 448);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 30);
            this.label9.TabIndex = 211;
            this.label9.Text = " Z:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(392, 450);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 30);
            this.label10.TabIndex = 212;
            this.label10.Text = "Y:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(240, 451);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 30);
            this.label11.TabIndex = 213;
            this.label11.Text = "X:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(13, 405);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(450, 30);
            this.label8.TabIndex = 210;
            this.label8.Text = "Добавление точечного источника";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(550, 295);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 30);
            this.label5.TabIndex = 207;
            this.label5.Text = " Z:";
            // 
            // AddLightIntensity
            // 
            this.AddLightIntensity.DecimalPlaces = 3;
            this.AddLightIntensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.AddLightIntensity.Location = new System.Drawing.Point(302, 503);
            this.AddLightIntensity.Margin = new System.Windows.Forms.Padding(6);
            this.AddLightIntensity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AddLightIntensity.Name = "AddLightIntensity";
            this.AddLightIntensity.Size = new System.Drawing.Size(96, 31);
            this.AddLightIntensity.TabIndex = 211;
            // 
            // btnDeleteLight
            // 
            this.btnDeleteLight.Location = new System.Drawing.Point(245, 556);
            this.btnDeleteLight.Margin = new System.Windows.Forms.Padding(6);
            this.btnDeleteLight.Name = "btnDeleteLight";
            this.btnDeleteLight.Size = new System.Drawing.Size(218, 44);
            this.btnDeleteLight.TabIndex = 202;
            this.btnDeleteLight.Text = "Удалить";
            this.btnDeleteLight.UseVisualStyleBackColor = true;
            this.btnDeleteLight.Click += new System.EventHandler(this.btnDeleteLight_Click);
            // 
            // btnAddLight
            // 
            this.btnAddLight.Location = new System.Drawing.Point(442, 489);
            this.btnAddLight.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddLight.Name = "btnAddLight";
            this.btnAddLight.Size = new System.Drawing.Size(142, 44);
            this.btnAddLight.TabIndex = 187;
            this.btnAddLight.Text = "Добавить";
            this.btnAddLight.UseVisualStyleBackColor = true;
            this.btnAddLight.Click += new System.EventHandler(this.btnAddLight_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(402, 297);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 30);
            this.label6.TabIndex = 208;
            this.label6.Text = "Y:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(250, 298);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 30);
            this.label7.TabIndex = 209;
            this.label7.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(550, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 30);
            this.label4.TabIndex = 187;
            this.label4.Text = " Z:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(402, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 30);
            this.label3.TabIndex = 187;
            this.label3.Text = "Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(250, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 30);
            this.label2.TabIndex = 187;
            this.label2.Text = "X:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(85, 503);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(202, 30);
            this.label13.TabIndex = 208;
            this.label13.Text = "Интенсивность:";
            // 
            // AddLightPosZ
            // 
            this.AddLightPosZ.DecimalPlaces = 3;
            this.AddLightPosZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.AddLightPosZ.Location = new System.Drawing.Point(589, 446);
            this.AddLightPosZ.Margin = new System.Windows.Forms.Padding(6);
            this.AddLightPosZ.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AddLightPosZ.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.AddLightPosZ.Name = "AddLightPosZ";
            this.AddLightPosZ.Size = new System.Drawing.Size(96, 31);
            this.AddLightPosZ.TabIndex = 210;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 30);
            this.label1.TabIndex = 206;
            this.label1.Text = "Просмотр";
            // 
            // ChangeLightIntensity
            // 
            this.ChangeLightIntensity.DecimalPlaces = 3;
            this.ChangeLightIntensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ChangeLightIntensity.Location = new System.Drawing.Point(302, 357);
            this.ChangeLightIntensity.Margin = new System.Windows.Forms.Padding(6);
            this.ChangeLightIntensity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ChangeLightIntensity.Name = "ChangeLightIntensity";
            this.ChangeLightIntensity.Size = new System.Drawing.Size(96, 31);
            this.ChangeLightIntensity.TabIndex = 205;
            // 
            // ChangeLightPosZ
            // 
            this.ChangeLightPosZ.DecimalPlaces = 3;
            this.ChangeLightPosZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ChangeLightPosZ.Location = new System.Drawing.Point(597, 295);
            this.ChangeLightPosZ.Margin = new System.Windows.Forms.Padding(6);
            this.ChangeLightPosZ.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ChangeLightPosZ.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.ChangeLightPosZ.Name = "ChangeLightPosZ";
            this.ChangeLightPosZ.Size = new System.Drawing.Size(96, 31);
            this.ChangeLightPosZ.TabIndex = 204;
            // 
            // btnChangeLightParams
            // 
            this.btnChangeLightParams.Location = new System.Drawing.Point(442, 349);
            this.btnChangeLightParams.Margin = new System.Windows.Forms.Padding(6);
            this.btnChangeLightParams.Name = "btnChangeLightParams";
            this.btnChangeLightParams.Size = new System.Drawing.Size(150, 44);
            this.btnChangeLightParams.TabIndex = 192;
            this.btnChangeLightParams.Text = "Применить";
            this.btnChangeLightParams.UseVisualStyleBackColor = true;
            this.btnChangeLightParams.Click += new System.EventHandler(this.btnChangeLightParams_Click);
            // 
            // AddLightPosY
            // 
            this.AddLightPosY.DecimalPlaces = 3;
            this.AddLightPosY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.AddLightPosY.Location = new System.Drawing.Point(442, 449);
            this.AddLightPosY.Margin = new System.Windows.Forms.Padding(6);
            this.AddLightPosY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AddLightPosY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.AddLightPosY.Name = "AddLightPosY";
            this.AddLightPosY.Size = new System.Drawing.Size(96, 31);
            this.AddLightPosY.TabIndex = 209;
            // 
            // ChangeLightPosY
            // 
            this.ChangeLightPosY.DecimalPlaces = 3;
            this.ChangeLightPosY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ChangeLightPosY.Location = new System.Drawing.Point(442, 297);
            this.ChangeLightPosY.Margin = new System.Windows.Forms.Padding(6);
            this.ChangeLightPosY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ChangeLightPosY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.ChangeLightPosY.Name = "ChangeLightPosY";
            this.ChangeLightPosY.Size = new System.Drawing.Size(96, 31);
            this.ChangeLightPosY.TabIndex = 203;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label90.Location = new System.Drawing.Point(85, 354);
            this.label90.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(202, 30);
            this.label90.TabIndex = 197;
            this.label90.Text = "Интенсивность:";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label88.Location = new System.Drawing.Point(13, 243);
            this.label88.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(158, 30);
            this.label88.TabIndex = 195;
            this.label88.Text = "Изменение";
            // 
            // ChangeLightPosX
            // 
            this.ChangeLightPosX.DecimalPlaces = 3;
            this.ChangeLightPosX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ChangeLightPosX.Location = new System.Drawing.Point(302, 298);
            this.ChangeLightPosX.Margin = new System.Windows.Forms.Padding(6);
            this.ChangeLightPosX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ChangeLightPosX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.ChangeLightPosX.Name = "ChangeLightPosX";
            this.ChangeLightPosX.Size = new System.Drawing.Size(96, 31);
            this.ChangeLightPosX.TabIndex = 192;
            // 
            // AddLightPosX
            // 
            this.AddLightPosX.DecimalPlaces = 3;
            this.AddLightPosX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.AddLightPosX.Location = new System.Drawing.Point(302, 450);
            this.AddLightPosX.Margin = new System.Windows.Forms.Padding(6);
            this.AddLightPosX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AddLightPosX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.AddLightPosX.Name = "AddLightPosX";
            this.AddLightPosX.Size = new System.Drawing.Size(96, 31);
            this.AddLightPosX.TabIndex = 206;
            // 
            // LightPosX
            // 
            this.LightPosX.BackColor = System.Drawing.SystemColors.HighlightText;
            this.LightPosX.Enabled = false;
            this.LightPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LightPosX.Location = new System.Drawing.Point(302, 131);
            this.LightPosX.Margin = new System.Windows.Forms.Padding(6);
            this.LightPosX.Name = "LightPosX";
            this.LightPosX.Size = new System.Drawing.Size(88, 32);
            this.LightPosX.TabIndex = 194;
            // 
            // LightIntensity
            // 
            this.LightIntensity.BackColor = System.Drawing.SystemColors.HighlightText;
            this.LightIntensity.Enabled = false;
            this.LightIntensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LightIntensity.Location = new System.Drawing.Point(302, 186);
            this.LightIntensity.Margin = new System.Windows.Forms.Padding(6);
            this.LightIntensity.Name = "LightIntensity";
            this.LightIntensity.Size = new System.Drawing.Size(88, 32);
            this.LightIntensity.TabIndex = 193;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label78.Location = new System.Drawing.Point(85, 188);
            this.label78.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(202, 30);
            this.label78.TabIndex = 165;
            this.label78.Text = "Интенсивность:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(85, 447);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 30);
            this.label14.TabIndex = 207;
            this.label14.Text = "Позиция:";
            // 
            // comboBoxLights
            // 
            this.comboBoxLights.AutoCompleteCustomSource.AddRange(new string[] {
            "Сфера",
            "Цилиндр",
            "Конус",
            "Треугольная пирамида",
            "Четырехугольная пирамида",
            "Параллелепипед"});
            this.comboBoxLights.DisplayMember = "Сфера";
            this.comboBoxLights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLights.FormattingEnabled = true;
            this.comboBoxLights.Items.AddRange(new object[] {
            "диффузное освещение",
            "направленный (Солнце)"});
            this.comboBoxLights.Location = new System.Drawing.Point(12, 17);
            this.comboBoxLights.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxLights.Name = "comboBoxLights";
            this.comboBoxLights.Size = new System.Drawing.Size(494, 33);
            this.comboBoxLights.TabIndex = 163;
            this.comboBoxLights.SelectedIndexChanged += new System.EventHandler(this.comboBoxLights_SelectedIndexChanged);
            // 
            // labelLightPos
            // 
            this.labelLightPos.AutoSize = true;
            this.labelLightPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLightPos.Location = new System.Drawing.Point(85, 133);
            this.labelLightPos.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelLightPos.Name = "labelLightPos";
            this.labelLightPos.Size = new System.Drawing.Size(125, 30);
            this.labelLightPos.TabIndex = 164;
            this.labelLightPos.Text = "Позиция:";
            // 
            // labelChangeLightPos
            // 
            this.labelChangeLightPos.AutoSize = true;
            this.labelChangeLightPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChangeLightPos.Location = new System.Drawing.Point(85, 301);
            this.labelChangeLightPos.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelChangeLightPos.Name = "labelChangeLightPos";
            this.labelChangeLightPos.Size = new System.Drawing.Size(125, 30);
            this.labelChangeLightPos.TabIndex = 196;
            this.labelChangeLightPos.Text = "Позиция:";
            // 
            // LightPosZ
            // 
            this.LightPosZ.BackColor = System.Drawing.SystemColors.HighlightText;
            this.LightPosZ.Enabled = false;
            this.LightPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LightPosZ.Location = new System.Drawing.Point(597, 128);
            this.LightPosZ.Margin = new System.Windows.Forms.Padding(6);
            this.LightPosZ.Name = "LightPosZ";
            this.LightPosZ.Size = new System.Drawing.Size(88, 32);
            this.LightPosZ.TabIndex = 192;
            // 
            // LightPosY
            // 
            this.LightPosY.BackColor = System.Drawing.SystemColors.HighlightText;
            this.LightPosY.Enabled = false;
            this.LightPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LightPosY.Location = new System.Drawing.Point(450, 128);
            this.LightPosY.Margin = new System.Windows.Forms.Padding(6);
            this.LightPosY.Name = "LightPosY";
            this.LightPosY.Size = new System.Drawing.Size(88, 32);
            this.LightPosY.TabIndex = 191;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2930, 24);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonRollCamera
            // 
            this.buttonRollCamera.Location = new System.Drawing.Point(570, 414);
            this.buttonRollCamera.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRollCamera.Name = "buttonRollCamera";
            this.buttonRollCamera.Size = new System.Drawing.Size(150, 44);
            this.buttonRollCamera.TabIndex = 49;
            this.buttonRollCamera.Text = "Повернуть";
            this.buttonRollCamera.UseVisualStyleBackColor = true;
            this.buttonRollCamera.Click += new System.EventHandler(this.buttonRollCamera_Click);
            // 
            // rollCamera
            // 
            this.rollCamera.Location = new System.Drawing.Point(442, 420);
            this.rollCamera.Margin = new System.Windows.Forms.Padding(6);
            this.rollCamera.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rollCamera.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.rollCamera.Name = "rollCamera";
            this.rollCamera.Size = new System.Drawing.Size(116, 31);
            this.rollCamera.TabIndex = 50;
            this.rollCamera.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pitchCamera
            // 
            this.pitchCamera.Location = new System.Drawing.Point(442, 370);
            this.pitchCamera.Margin = new System.Windows.Forms.Padding(6);
            this.pitchCamera.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.pitchCamera.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.pitchCamera.Name = "pitchCamera";
            this.pitchCamera.Size = new System.Drawing.Size(116, 31);
            this.pitchCamera.TabIndex = 52;
            this.pitchCamera.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonPitchCamera
            // 
            this.buttonPitchCamera.Location = new System.Drawing.Point(570, 364);
            this.buttonPitchCamera.Margin = new System.Windows.Forms.Padding(6);
            this.buttonPitchCamera.Name = "buttonPitchCamera";
            this.buttonPitchCamera.Size = new System.Drawing.Size(150, 44);
            this.buttonPitchCamera.TabIndex = 51;
            this.buttonPitchCamera.Text = "Повернуть";
            this.buttonPitchCamera.UseVisualStyleBackColor = true;
            this.buttonPitchCamera.Click += new System.EventHandler(this.buttonPitchCamera_Click);
            // 
            // yawCamera
            // 
            this.yawCamera.Location = new System.Drawing.Point(442, 320);
            this.yawCamera.Margin = new System.Windows.Forms.Padding(6);
            this.yawCamera.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.yawCamera.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.yawCamera.Name = "yawCamera";
            this.yawCamera.Size = new System.Drawing.Size(116, 31);
            this.yawCamera.TabIndex = 54;
            this.yawCamera.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonYawCamera
            // 
            this.buttonYawCamera.Location = new System.Drawing.Point(570, 314);
            this.buttonYawCamera.Margin = new System.Windows.Forms.Padding(6);
            this.buttonYawCamera.Name = "buttonYawCamera";
            this.buttonYawCamera.Size = new System.Drawing.Size(150, 44);
            this.buttonYawCamera.TabIndex = 53;
            this.buttonYawCamera.Text = "Повернуть";
            this.buttonYawCamera.UseVisualStyleBackColor = true;
            this.buttonYawCamera.Click += new System.EventHandler(this.buttonYawCamera_Click);
            // 
            // moveCameraDX
            // 
            this.moveCameraDX.Location = new System.Drawing.Point(162, 312);
            this.moveCameraDX.Margin = new System.Windows.Forms.Padding(6);
            this.moveCameraDX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.moveCameraDX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.moveCameraDX.Name = "moveCameraDX";
            this.moveCameraDX.Size = new System.Drawing.Size(116, 31);
            this.moveCameraDX.TabIndex = 57;
            this.moveCameraDX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // moveCameraDY
            // 
            this.moveCameraDY.Location = new System.Drawing.Point(162, 362);
            this.moveCameraDY.Margin = new System.Windows.Forms.Padding(6);
            this.moveCameraDY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.moveCameraDY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.moveCameraDY.Name = "moveCameraDY";
            this.moveCameraDY.Size = new System.Drawing.Size(116, 31);
            this.moveCameraDY.TabIndex = 56;
            this.moveCameraDY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // moveCameraDZ
            // 
            this.moveCameraDZ.Location = new System.Drawing.Point(162, 412);
            this.moveCameraDZ.Margin = new System.Windows.Forms.Padding(6);
            this.moveCameraDZ.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.moveCameraDZ.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.moveCameraDZ.Name = "moveCameraDZ";
            this.moveCameraDZ.Size = new System.Drawing.Size(116, 31);
            this.moveCameraDZ.TabIndex = 55;
            this.moveCameraDZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonMoveCamera
            // 
            this.buttonMoveCamera.Location = new System.Drawing.Point(86, 462);
            this.buttonMoveCamera.Margin = new System.Windows.Forms.Padding(6);
            this.buttonMoveCamera.Name = "buttonMoveCamera";
            this.buttonMoveCamera.Size = new System.Drawing.Size(188, 44);
            this.buttonMoveCamera.TabIndex = 58;
            this.buttonMoveCamera.Text = "Переместить";
            this.buttonMoveCamera.UseVisualStyleBackColor = true;
            this.buttonMoveCamera.Click += new System.EventHandler(this.buttonMoveCamera_Click);
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label75.Location = new System.Drawing.Point(244, 85);
            this.label75.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(37, 30);
            this.label75.TabIndex = 143;
            this.label75.Text = "X:";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label76.Location = new System.Drawing.Point(424, 83);
            this.label76.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(36, 30);
            this.label76.TabIndex = 145;
            this.label76.Text = "Y:";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label77.Location = new System.Drawing.Point(596, 85);
            this.label77.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(43, 30);
            this.label77.TabIndex = 147;
            this.label77.Text = " Z:";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label79.Location = new System.Drawing.Point(376, 262);
            this.label79.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(136, 30);
            this.label79.TabIndex = 150;
            this.label79.Text = "Вращение";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label80.Location = new System.Drawing.Point(80, 262);
            this.label80.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(185, 30);
            this.label80.TabIndex = 151;
            this.label80.Text = "Перемещение";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label81.Location = new System.Drawing.Point(382, 320);
            this.label81.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(57, 30);
            this.label81.TabIndex = 152;
            this.label81.Text = "OX:";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label82.Location = new System.Drawing.Point(382, 370);
            this.label82.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(56, 30);
            this.label82.TabIndex = 153;
            this.label82.Text = "OY:";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label83.Location = new System.Drawing.Point(382, 420);
            this.label83.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(56, 30);
            this.label83.TabIndex = 154;
            this.label83.Text = "OZ:";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label84.Location = new System.Drawing.Point(88, 420);
            this.label84.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(50, 30);
            this.label84.TabIndex = 157;
            this.label84.Text = "dZ:";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label85.Location = new System.Drawing.Point(88, 370);
            this.label85.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(50, 30);
            this.label85.TabIndex = 156;
            this.label85.Text = "dY:";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label86.Location = new System.Drawing.Point(88, 320);
            this.label86.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(51, 30);
            this.label86.TabIndex = 155;
            this.label86.Text = "dX:";
            // 
            // CameraPosX
            // 
            this.CameraPosX.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CameraPosX.Enabled = false;
            this.CameraPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CameraPosX.Location = new System.Drawing.Point(290, 83);
            this.CameraPosX.Margin = new System.Windows.Forms.Padding(6);
            this.CameraPosX.Name = "CameraPosX";
            this.CameraPosX.Size = new System.Drawing.Size(108, 32);
            this.CameraPosX.TabIndex = 175;
            // 
            // CameraPosY
            // 
            this.CameraPosY.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CameraPosY.Enabled = false;
            this.CameraPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CameraPosY.Location = new System.Drawing.Point(470, 81);
            this.CameraPosY.Margin = new System.Windows.Forms.Padding(6);
            this.CameraPosY.Name = "CameraPosY";
            this.CameraPosY.Size = new System.Drawing.Size(108, 32);
            this.CameraPosY.TabIndex = 176;
            // 
            // CameraPosZ
            // 
            this.CameraPosZ.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CameraPosZ.Enabled = false;
            this.CameraPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CameraPosZ.Location = new System.Drawing.Point(642, 81);
            this.CameraPosZ.Margin = new System.Windows.Forms.Padding(6);
            this.CameraPosZ.Name = "CameraPosZ";
            this.CameraPosZ.Size = new System.Drawing.Size(108, 32);
            this.CameraPosZ.TabIndex = 177;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Location = new System.Drawing.Point(745, 841);
            this.tabControl3.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(790, 669);
            this.tabControl3.TabIndex = 178;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label15);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.label72);
            this.tabPage6.Controls.Add(this.label84);
            this.tabPage6.Controls.Add(this.label73);
            this.tabPage6.Controls.Add(this.CameraRotOZ);
            this.tabPage6.Controls.Add(this.label74);
            this.tabPage6.Controls.Add(this.label85);
            this.tabPage6.Controls.Add(this.label83);
            this.tabPage6.Controls.Add(this.CameraRotOY);
            this.tabPage6.Controls.Add(this.label82);
            this.tabPage6.Controls.Add(this.label86);
            this.tabPage6.Controls.Add(this.label87);
            this.tabPage6.Controls.Add(this.label81);
            this.tabPage6.Controls.Add(this.label80);
            this.tabPage6.Controls.Add(this.moveCameraDZ);
            this.tabPage6.Controls.Add(this.CameraRotOX);
            this.tabPage6.Controls.Add(this.moveCameraDY);
            this.tabPage6.Controls.Add(this.label39);
            this.tabPage6.Controls.Add(this.moveCameraDX);
            this.tabPage6.Controls.Add(this.label79);
            this.tabPage6.Controls.Add(this.buttonMoveCamera);
            this.tabPage6.Controls.Add(this.label75);
            this.tabPage6.Controls.Add(this.CameraPosZ);
            this.tabPage6.Controls.Add(this.label76);
            this.tabPage6.Controls.Add(this.CameraPosY);
            this.tabPage6.Controls.Add(this.label77);
            this.tabPage6.Controls.Add(this.yawCamera);
            this.tabPage6.Controls.Add(this.CameraPosX);
            this.tabPage6.Controls.Add(this.buttonYawCamera);
            this.tabPage6.Controls.Add(this.buttonRollCamera);
            this.tabPage6.Controls.Add(this.pitchCamera);
            this.tabPage6.Controls.Add(this.rollCamera);
            this.tabPage6.Controls.Add(this.buttonPitchCamera);
            this.tabPage6.Location = new System.Drawing.Point(8, 39);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage6.Size = new System.Drawing.Size(774, 622);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Камера";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(7, 202);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(158, 30);
            this.label15.TabIndex = 208;
            this.label15.Text = "Изменение";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(7, 31);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 30);
            this.label12.TabIndex = 207;
            this.label12.Text = "Просмотр";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label72.Location = new System.Drawing.Point(80, 133);
            this.label72.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(114, 30);
            this.label72.TabIndex = 186;
            this.label72.Text = "Поворот";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label73.Location = new System.Drawing.Point(224, 139);
            this.label73.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(57, 30);
            this.label73.TabIndex = 180;
            this.label73.Text = "ОX:";
            // 
            // CameraRotOZ
            // 
            this.CameraRotOZ.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CameraRotOZ.Enabled = false;
            this.CameraRotOZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CameraRotOZ.Location = new System.Drawing.Point(642, 133);
            this.CameraRotOZ.Margin = new System.Windows.Forms.Padding(6);
            this.CameraRotOZ.Name = "CameraRotOZ";
            this.CameraRotOZ.Size = new System.Drawing.Size(108, 32);
            this.CameraRotOZ.TabIndex = 185;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label74.Location = new System.Drawing.Point(404, 139);
            this.label74.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(56, 30);
            this.label74.TabIndex = 181;
            this.label74.Text = "ОY:";
            // 
            // CameraRotOY
            // 
            this.CameraRotOY.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CameraRotOY.Enabled = false;
            this.CameraRotOY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CameraRotOY.Location = new System.Drawing.Point(470, 133);
            this.CameraRotOY.Margin = new System.Windows.Forms.Padding(6);
            this.CameraRotOY.Name = "CameraRotOY";
            this.CameraRotOY.Size = new System.Drawing.Size(108, 32);
            this.CameraRotOY.TabIndex = 184;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label87.Location = new System.Drawing.Point(584, 137);
            this.label87.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(56, 30);
            this.label87.TabIndex = 182;
            this.label87.Text = "ОZ:";
            // 
            // CameraRotOX
            // 
            this.CameraRotOX.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CameraRotOX.Enabled = false;
            this.CameraRotOX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CameraRotOX.Location = new System.Drawing.Point(290, 137);
            this.CameraRotOX.Margin = new System.Windows.Forms.Padding(6);
            this.CameraRotOX.Name = "CameraRotOX";
            this.CameraRotOX.Size = new System.Drawing.Size(108, 32);
            this.CameraRotOX.TabIndex = 183;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label39.Location = new System.Drawing.Point(80, 83);
            this.label39.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(150, 30);
            this.label39.TabIndex = 179;
            this.label39.Text = "Положение";
            // 
            // checkBoxNebo
            // 
            this.checkBoxNebo.AutoSize = true;
            this.checkBoxNebo.Checked = true;
            this.checkBoxNebo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNebo.Location = new System.Drawing.Point(245, 338);
            this.checkBoxNebo.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxNebo.Name = "checkBoxNebo";
            this.checkBoxNebo.Size = new System.Drawing.Size(277, 29);
            this.checkBoxNebo.TabIndex = 216;
            this.checkBoxNebo.Text = "Рисовать изображение";
            this.checkBoxNebo.UseVisualStyleBackColor = true;
            this.checkBoxNebo.CheckedChanged += new System.EventHandler(this.checkBoxNebo_CheckedChanged);
            // 
            // dynamicButton
            // 
            this.dynamicButton.Location = new System.Drawing.Point(17, 455);
            this.dynamicButton.Margin = new System.Windows.Forms.Padding(6);
            this.dynamicButton.Name = "dynamicButton";
            this.dynamicButton.Size = new System.Drawing.Size(332, 71);
            this.dynamicButton.TabIndex = 187;
            this.dynamicButton.Text = "Запуск";
            this.dynamicButton.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(278, 558);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(392, 61);
            this.progressBar.TabIndex = 219;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage1);
            this.tabControl4.Location = new System.Drawing.Point(15, 57);
            this.tabControl4.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(718, 772);
            this.tabControl4.TabIndex = 220;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.offButton);
            this.tabPage1.Controls.Add(this.trackBarN);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.radioRight);
            this.tabPage1.Controls.Add(this.radioLeft);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.textBoxTime);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.trackBarSpeed);
            this.tabPage1.Controls.Add(this.numericNumThreads);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.progressBar);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.dynamicButton);
            this.tabPage1.Controls.Add(this.checkBoxNebo);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(702, 725);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Запуск флюгера";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // offButton
            // 
            this.offButton.Location = new System.Drawing.Point(361, 455);
            this.offButton.Margin = new System.Windows.Forms.Padding(6);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(332, 71);
            this.offButton.TabIndex = 339;
            this.offButton.Text = "Останов";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // trackBarN
            // 
            this.trackBarN.Location = new System.Drawing.Point(245, 214);
            this.trackBarN.Maximum = 144;
            this.trackBarN.Minimum = 5;
            this.trackBarN.Name = "trackBarN";
            this.trackBarN.Size = new System.Drawing.Size(360, 90);
            this.trackBarN.TabIndex = 338;
            this.trackBarN.Value = 36;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(20, 214);
            this.label21.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(149, 30);
            this.label21.TabIndex = 337;
            this.label21.Text = "Плавность:";
            // 
            // radioRight
            // 
            this.radioRight.AutoSize = true;
            this.radioRight.Location = new System.Drawing.Point(375, 28);
            this.radioRight.Name = "radioRight";
            this.radioRight.Size = new System.Drawing.Size(116, 29);
            this.radioRight.TabIndex = 336;
            this.radioRight.Text = "Вправо";
            this.radioRight.UseVisualStyleBackColor = true;
            this.radioRight.CheckedChanged += new System.EventHandler(this.radioRight_CheckedChanged);
            // 
            // radioLeft
            // 
            this.radioLeft.AutoSize = true;
            this.radioLeft.Checked = true;
            this.radioLeft.Location = new System.Drawing.Point(245, 26);
            this.radioLeft.Name = "radioLeft";
            this.radioLeft.Size = new System.Drawing.Size(104, 29);
            this.radioLeft.TabIndex = 330;
            this.radioLeft.TabStop = true;
            this.radioLeft.Text = "Влево";
            this.radioLeft.UseVisualStyleBackColor = true;
            this.radioLeft.CheckedChanged += new System.EventHandler(this.radioLeft_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(20, 650);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(257, 30);
            this.label20.TabIndex = 335;
            this.label20.Text = "Затраченное время:";
            // 
            // textBoxTime
            // 
            this.textBoxTime.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxTime.Enabled = false;
            this.textBoxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTime.Location = new System.Drawing.Point(314, 650);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(148, 32);
            this.textBoxTime.TabIndex = 209;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(12, 576);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(238, 30);
            this.label19.TabIndex = 334;
            this.label19.Text = "Процесс расчетов:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(20, 380);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(197, 30);
            this.label18.TabIndex = 333;
            this.label18.Text = "Число потоков:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(20, 338);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 30);
            this.label17.TabIndex = 332;
            this.label17.Text = "Фон:";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.LargeChange = 51;
            this.trackBarSpeed.Location = new System.Drawing.Point(245, 104);
            this.trackBarSpeed.Maximum = 299;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(360, 90);
            this.trackBarSpeed.SmallChange = 10;
            this.trackBarSpeed.TabIndex = 331;
            this.trackBarSpeed.Value = 150;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // numericNumThreads
            // 
            this.numericNumThreads.Location = new System.Drawing.Point(245, 379);
            this.numericNumThreads.Margin = new System.Windows.Forms.Padding(6);
            this.numericNumThreads.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericNumThreads.Name = "numericNumThreads";
            this.numericNumThreads.Size = new System.Drawing.Size(124, 31);
            this.numericNumThreads.TabIndex = 330;
            this.numericNumThreads.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(20, 104);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(133, 30);
            this.label16.TabIndex = 221;
            this.label16.Text = "Скорость:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(8, 25);
            this.label25.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 30);
            this.label25.TabIndex = 179;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label29.Location = new System.Drawing.Point(20, 22);
            this.label29.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(181, 30);
            this.label29.TabIndex = 147;
            this.label29.Text = "Направление:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(2930, 1647);
            this.Controls.Add(this.tabControl4);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Флюгер";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.btnDeleteObject.ResumeLayout(false);
            this.btnDeleteObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChoiceReflective)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoiceSpecular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoiceColor)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddLightIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddLightPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeLightIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeLightPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddLightPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeLightPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeLightPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddLightPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yawCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveCameraDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveCameraDY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveCameraDZ)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabControl4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonRollCamera;
        private System.Windows.Forms.NumericUpDown rollCamera;
        private System.Windows.Forms.NumericUpDown pitchCamera;
        private System.Windows.Forms.Button buttonPitchCamera;
        private System.Windows.Forms.NumericUpDown yawCamera;
        private System.Windows.Forms.Button buttonYawCamera;
        private System.Windows.Forms.NumericUpDown moveCameraDX;
        private System.Windows.Forms.NumericUpDown moveCameraDY;
        private System.Windows.Forms.NumericUpDown moveCameraDZ;
        private System.Windows.Forms.Button buttonMoveCamera;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.ComboBox comboBoxLights;
        private System.Windows.Forms.TextBox CameraPosX;
        private System.Windows.Forms.TextBox CameraPosY;
        private System.Windows.Forms.TextBox CameraPosZ;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox CameraRotOZ;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox CameraRotOY;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.TextBox CameraRotOX;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button btnAddLight;
        private System.Windows.Forms.NumericUpDown ChangeLightIntensity;
        private System.Windows.Forms.NumericUpDown ChangeLightPosZ;
        private System.Windows.Forms.NumericUpDown ChangeLightPosY;
        private System.Windows.Forms.NumericUpDown ChangeLightPosX;
        private System.Windows.Forms.Button btnDeleteLight;
        private System.Windows.Forms.Button btnChangeLightParams;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label labelChangeLightPos;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.TextBox LightPosX;
        private System.Windows.Forms.TextBox LightIntensity;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TextBox LightPosZ;
        private System.Windows.Forms.TextBox LightPosY;
        private System.Windows.Forms.Label labelLightPos;
        private System.Windows.Forms.NumericUpDown AddLightIntensity;
        private System.Windows.Forms.NumericUpDown AddLightPosZ;
        private System.Windows.Forms.NumericUpDown AddLightPosY;
        private System.Windows.Forms.NumericUpDown AddLightPosX;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox checkBoxNebo;
        private System.Windows.Forms.Button dynamicButton;
        private System.Windows.Forms.TabPage btnDeleteObject;
        private System.Windows.Forms.ComboBox choiceObject;
        private System.Windows.Forms.Label labelChoiceColor;
        private System.Windows.Forms.NumericUpDown ChoiceReflective;
        private System.Windows.Forms.NumericUpDown ChoiceSpecular;
        private System.Windows.Forms.PictureBox ChoiceColor;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label labelChoiceSpecular;
        private System.Windows.Forms.Label labelChoiceReflective;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.NumericUpDown numericNumThreads;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton radioRight;
        private System.Windows.Forms.RadioButton radioLeft;
        private System.Windows.Forms.TrackBar trackBarN;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button offButton;
    }
}

