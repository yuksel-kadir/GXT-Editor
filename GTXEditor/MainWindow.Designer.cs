
namespace GTXEditor
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioIV = new System.Windows.Forms.RadioButton();
            this.radioSA = new System.Windows.Forms.RadioButton();
            this.radioClassics = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOpenWith = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.compileTableButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupReloadTable = new System.Windows.Forms.GroupBox();
            this.refreshTableButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchGroup = new System.Windows.Forms.GroupBox();
            this.radioSearchValue = new System.Windows.Forms.RadioButton();
            this.radioSearchKey = new System.Windows.Forms.RadioButton();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchKeyInput = new System.Windows.Forms.TextBox();
            this.groupTextFont = new System.Windows.Forms.GroupBox();
            this.textFonts = new System.Windows.Forms.ComboBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.currentFilePathLabel = new System.Windows.Forms.Label();
            this.groupGxtTable = new System.Windows.Forms.GroupBox();
            this.GXTTable = new System.Windows.Forms.DataGridView();
            this.GXT_KEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GXT_VALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupTextPreview = new System.Windows.Forms.GroupBox();
            this.GXTValueTextBox = new System.Windows.Forms.TextBox();
            this.logBox = new System.Windows.Forms.TextBox();
            this.logBoxGroup = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGXTFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompileGXTFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileCurrentFileTogxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileATextFileTogxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentGXTFileAstxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubRepoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxGXTTables = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupReloadTable.SuspendLayout();
            this.searchGroup.SuspendLayout();
            this.groupTextFont.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.groupGxtTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GXTTable)).BeginInit();
            this.groupTextPreview.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.leftPanel);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1476, 832);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.groupReloadTable);
            this.panel3.Controls.Add(this.searchGroup);
            this.panel3.Controls.Add(this.groupTextFont);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1288, 24);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel3.Size = new System.Drawing.Size(188, 808);
            this.panel3.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioIV);
            this.groupBox3.Controls.Add(this.radioSA);
            this.groupBox3.Controls.Add(this.radioClassics);
            this.groupBox3.Location = new System.Drawing.Point(4, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 91);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Game";
            this.toolTip1.SetToolTip(this.groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // radioIV
            // 
            this.radioIV.AutoSize = true;
            this.radioIV.Location = new System.Drawing.Point(10, 65);
            this.radioIV.Name = "radioIV";
            this.radioIV.Size = new System.Drawing.Size(35, 17);
            this.radioIV.TabIndex = 2;
            this.radioIV.Text = "IV";
            this.radioIV.UseVisualStyleBackColor = true;
            // 
            // radioSA
            // 
            this.radioSA.AutoSize = true;
            this.radioSA.Location = new System.Drawing.Point(10, 42);
            this.radioSA.Name = "radioSA";
            this.radioSA.Size = new System.Drawing.Size(86, 17);
            this.radioSA.TabIndex = 1;
            this.radioSA.Text = "San Andreas";
            this.radioSA.UseVisualStyleBackColor = true;
            // 
            // radioClassics
            // 
            this.radioClassics.AutoSize = true;
            this.radioClassics.Checked = true;
            this.radioClassics.Location = new System.Drawing.Point(10, 19);
            this.radioClassics.Name = "radioClassics";
            this.radioClassics.Size = new System.Drawing.Size(134, 17);
            this.radioClassics.TabIndex = 0;
            this.radioClassics.TabStop = true;
            this.radioClassics.Text = "III, Vice City, LCS, VCS";
            this.radioClassics.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOpenWith);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(4, 589);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 146);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Open Current Text File With";
            // 
            // buttonOpenWith
            // 
            this.buttonOpenWith.Location = new System.Drawing.Point(74, 115);
            this.buttonOpenWith.Name = "buttonOpenWith";
            this.buttonOpenWith.Size = new System.Drawing.Size(95, 23);
            this.buttonOpenWith.TabIndex = 1;
            this.buttonOpenWith.Text = "Open With";
            this.buttonOpenWith.UseVisualStyleBackColor = true;
            this.buttonOpenWith.Click += new System.EventHandler(this.buttonOpenWith_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 101);
            this.label3.TabIndex = 0;
            this.label3.Text = "Open the current text file using the text editor of your choice to edit the text " +
    "file easily. After making your changes, simply refresh the table to see the upda" +
    "ted text.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.compileTableButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 423);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 160);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Table As GXT File";
            // 
            // compileTableButton
            // 
            this.compileTableButton.Location = new System.Drawing.Point(59, 129);
            this.compileTableButton.Name = "compileTableButton";
            this.compileTableButton.Size = new System.Drawing.Size(111, 23);
            this.compileTableButton.TabIndex = 1;
            this.compileTableButton.Text = "Compile The Table";
            this.compileTableButton.UseVisualStyleBackColor = true;
            this.compileTableButton.Click += new System.EventHandler(this.compileTableButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 101);
            this.label2.TabIndex = 0;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // groupReloadTable
            // 
            this.groupReloadTable.Controls.Add(this.refreshTableButton);
            this.groupReloadTable.Controls.Add(this.label1);
            this.groupReloadTable.Location = new System.Drawing.Point(4, 287);
            this.groupReloadTable.Name = "groupReloadTable";
            this.groupReloadTable.Size = new System.Drawing.Size(181, 130);
            this.groupReloadTable.TabIndex = 13;
            this.groupReloadTable.TabStop = false;
            this.groupReloadTable.Text = "Reload Table";
            // 
            // refreshTableButton
            // 
            this.refreshTableButton.Location = new System.Drawing.Point(58, 101);
            this.refreshTableButton.Name = "refreshTableButton";
            this.refreshTableButton.Size = new System.Drawing.Size(111, 23);
            this.refreshTableButton.TabIndex = 1;
            this.refreshTableButton.Text = "Refresh The Table";
            this.refreshTableButton.UseVisualStyleBackColor = true;
            this.refreshTableButton.Click += new System.EventHandler(this.refreshTableButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "If you\'ve edited the text within the present file using a text editor, simply ref" +
    "resh the table to view and apply your modifications.";
            // 
            // searchGroup
            // 
            this.searchGroup.Controls.Add(this.radioSearchValue);
            this.searchGroup.Controls.Add(this.radioSearchKey);
            this.searchGroup.Controls.Add(this.searchButton);
            this.searchGroup.Controls.Add(this.searchKeyInput);
            this.searchGroup.Location = new System.Drawing.Point(3, 163);
            this.searchGroup.Name = "searchGroup";
            this.searchGroup.Size = new System.Drawing.Size(181, 118);
            this.searchGroup.TabIndex = 12;
            this.searchGroup.TabStop = false;
            this.searchGroup.Text = "Search";
            // 
            // radioSearchValue
            // 
            this.radioSearchValue.AutoSize = true;
            this.radioSearchValue.Location = new System.Drawing.Point(7, 40);
            this.radioSearchValue.Name = "radioSearchValue";
            this.radioSearchValue.Size = new System.Drawing.Size(89, 17);
            this.radioSearchValue.TabIndex = 3;
            this.radioSearchValue.Text = "Search Value";
            this.toolTip1.SetToolTip(this.radioSearchValue, "Click this if you want to search for a GXT Value.");
            this.radioSearchValue.UseVisualStyleBackColor = true;
            this.radioSearchValue.CheckedChanged += new System.EventHandler(this.radioSearchValue_CheckedChanged);
            // 
            // radioSearchKey
            // 
            this.radioSearchKey.AutoSize = true;
            this.radioSearchKey.Checked = true;
            this.radioSearchKey.Location = new System.Drawing.Point(7, 19);
            this.radioSearchKey.Name = "radioSearchKey";
            this.radioSearchKey.Size = new System.Drawing.Size(80, 17);
            this.radioSearchKey.TabIndex = 2;
            this.radioSearchKey.TabStop = true;
            this.radioSearchKey.Text = "Search Key";
            this.toolTip1.SetToolTip(this.radioSearchKey, "Click this if you want to search for a GXT Key.");
            this.radioSearchKey.UseVisualStyleBackColor = true;
            this.radioSearchKey.CheckedChanged += new System.EventHandler(this.radioSearchKey_CheckedChanged);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(95, 89);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchKeyInput
            // 
            this.searchKeyInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchKeyInput.Location = new System.Drawing.Point(7, 63);
            this.searchKeyInput.Name = "searchKeyInput";
            this.searchKeyInput.Size = new System.Drawing.Size(163, 20);
            this.searchKeyInput.TabIndex = 0;
            this.toolTip1.SetToolTip(this.searchKeyInput, "Enter the keyword you want to search.");
            this.searchKeyInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchKeyTextBox_KeyPress);
            // 
            // groupTextFont
            // 
            this.groupTextFont.Controls.Add(this.textFonts);
            this.groupTextFont.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupTextFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupTextFont.Location = new System.Drawing.Point(4, 745);
            this.groupTextFont.Name = "groupTextFont";
            this.groupTextFont.Size = new System.Drawing.Size(180, 51);
            this.groupTextFont.TabIndex = 11;
            this.groupTextFont.TabStop = false;
            this.groupTextFont.Text = "Text Font";
            // 
            // textFonts
            // 
            this.textFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textFonts.FormattingEnabled = true;
            this.textFonts.Items.AddRange(new object[] {
            "Bank Gothic",
            "Beckett",
            "GTA VC Regular",
            "Old English",
            "Rage Italic"});
            this.textFonts.Location = new System.Drawing.Point(6, 19);
            this.textFonts.Name = "textFonts";
            this.textFonts.Size = new System.Drawing.Size(164, 21);
            this.textFonts.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textFonts, "Select a font to change the font of the preview text.");
            this.textFonts.SelectedIndexChanged += new System.EventHandler(this.textFonts_SelectedIndexChanged);
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.leftPanel.Controls.Add(this.currentFilePathLabel);
            this.leftPanel.Controls.Add(this.groupGxtTable);
            this.leftPanel.Controls.Add(this.groupTextPreview);
            this.leftPanel.Controls.Add(this.logBox);
            this.leftPanel.Controls.Add(this.logBoxGroup);
            this.leftPanel.Location = new System.Drawing.Point(0, 24);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(1282, 808);
            this.leftPanel.TabIndex = 8;
            // 
            // currentFilePathLabel
            // 
            this.currentFilePathLabel.AutoSize = true;
            this.currentFilePathLabel.Location = new System.Drawing.Point(18, 789);
            this.currentFilePathLabel.Name = "currentFilePathLabel";
            this.currentFilePathLabel.Size = new System.Drawing.Size(115, 13);
            this.currentFilePathLabel.TabIndex = 14;
            this.currentFilePathLabel.Text = "Current Text File Path: ";
            this.toolTip1.SetToolTip(this.currentFilePathLabel, "Double click the path to copy.");
            this.currentFilePathLabel.Click += new System.EventHandler(this.currentFilePathLabel_Click);
            // 
            // groupGxtTable
            // 
            this.groupGxtTable.Controls.Add(this.GXTTable);
            this.groupGxtTable.Location = new System.Drawing.Point(12, 3);
            this.groupGxtTable.Name = "groupGxtTable";
            this.groupGxtTable.Padding = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.groupGxtTable.Size = new System.Drawing.Size(1261, 544);
            this.groupGxtTable.TabIndex = 13;
            this.groupGxtTable.TabStop = false;
            this.groupGxtTable.Text = "GXT Table";
            // 
            // GXTTable
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GXTTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.GXTTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GXTTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.GXTTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GXTTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GXTTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GXT_KEY,
            this.GXT_VALUE});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GXTTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.GXTTable.Location = new System.Drawing.Point(6, 19);
            this.GXTTable.Name = "GXTTable";
            this.GXTTable.RowHeadersVisible = false;
            this.GXTTable.Size = new System.Drawing.Size(1249, 519);
            this.GXTTable.TabIndex = 10;
            this.GXTTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GXTTable_CellClick);
            // 
            // GXT_KEY
            // 
            this.GXT_KEY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GXT_KEY.DefaultCellStyle = dataGridViewCellStyle5;
            this.GXT_KEY.HeaderText = "GXT Key";
            this.GXT_KEY.MinimumWidth = 65;
            this.GXT_KEY.Name = "GXT_KEY";
            this.GXT_KEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GXT_KEY.ToolTipText = "The GXT key represents the GXT value in game script. The GXT keys are used by gam" +
    "e script to display text.";
            this.GXT_KEY.Width = 65;
            // 
            // GXT_VALUE
            // 
            this.GXT_VALUE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GXT_VALUE.HeaderText = "GXT Value";
            this.GXT_VALUE.Name = "GXT_VALUE";
            this.GXT_VALUE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GXT_VALUE.ToolTipText = "The value of the GXT key. The GXT value is displayed as in game text.";
            // 
            // groupTextPreview
            // 
            this.groupTextPreview.Controls.Add(this.GXTValueTextBox);
            this.groupTextPreview.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupTextPreview.Location = new System.Drawing.Point(12, 701);
            this.groupTextPreview.Name = "groupTextPreview";
            this.groupTextPreview.Size = new System.Drawing.Size(1261, 85);
            this.groupTextPreview.TabIndex = 12;
            this.groupTextPreview.TabStop = false;
            this.groupTextPreview.Text = "Text Preview";
            // 
            // GXTValueTextBox
            // 
            this.GXTValueTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GXTValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GXTValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GXTValueTextBox.ForeColor = System.Drawing.Color.Black;
            this.GXTValueTextBox.Location = new System.Drawing.Point(9, 15);
            this.GXTValueTextBox.Multiline = true;
            this.GXTValueTextBox.Name = "GXTValueTextBox";
            this.GXTValueTextBox.ReadOnly = true;
            this.GXTValueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GXTValueTextBox.Size = new System.Drawing.Size(1246, 64);
            this.GXTValueTextBox.TabIndex = 11;
            this.GXTValueTextBox.Text = "TEST";
            // 
            // logBox
            // 
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Location = new System.Drawing.Point(18, 572);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(1249, 108);
            this.logBox.TabIndex = 7;
            // 
            // logBoxGroup
            // 
            this.logBoxGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.logBoxGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.logBoxGroup.Location = new System.Drawing.Point(12, 553);
            this.logBoxGroup.Name = "logBoxGroup";
            this.logBoxGroup.Size = new System.Drawing.Size(1261, 142);
            this.logBoxGroup.TabIndex = 11;
            this.logBoxGroup.TabStop = false;
            this.logBoxGroup.Text = "Log";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1476, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGXTFileToolStripMenuItem,
            this.decompileGXTFilesToolStripMenuItem,
            this.compileCurrentFileTogxtToolStripMenuItem,
            this.compileATextFileTogxtToolStripMenuItem,
            this.saveCurrentGXTFileAstxtToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openGXTFileToolStripMenuItem
            // 
            this.openGXTFileToolStripMenuItem.Name = "openGXTFileToolStripMenuItem";
            this.openGXTFileToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.openGXTFileToolStripMenuItem.Text = "Open GXT File";
            this.openGXTFileToolStripMenuItem.Click += new System.EventHandler(this.openGXTFileToolStripMenuItem_Click);
            // 
            // decompileGXTFilesToolStripMenuItem
            // 
            this.decompileGXTFilesToolStripMenuItem.Name = "decompileGXTFilesToolStripMenuItem";
            this.decompileGXTFilesToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.decompileGXTFilesToolStripMenuItem.Text = "Decompile GXT Files";
            // 
            // compileCurrentFileTogxtToolStripMenuItem
            // 
            this.compileCurrentFileTogxtToolStripMenuItem.Name = "compileCurrentFileTogxtToolStripMenuItem";
            this.compileCurrentFileTogxtToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.compileCurrentFileTogxtToolStripMenuItem.Text = "Compile Current Table to .gxt";
            this.compileCurrentFileTogxtToolStripMenuItem.Click += new System.EventHandler(this.compileCurrentFileTogxtToolStripMenuItem_Click);
            // 
            // compileATextFileTogxtToolStripMenuItem
            // 
            this.compileATextFileTogxtToolStripMenuItem.Name = "compileATextFileTogxtToolStripMenuItem";
            this.compileATextFileTogxtToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.compileATextFileTogxtToolStripMenuItem.Text = "Compile A Text File to .gxt";
            // 
            // saveCurrentGXTFileAstxtToolStripMenuItem
            // 
            this.saveCurrentGXTFileAstxtToolStripMenuItem.Name = "saveCurrentGXTFileAstxtToolStripMenuItem";
            this.saveCurrentGXTFileAstxtToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.saveCurrentGXTFileAstxtToolStripMenuItem.Text = "Save Current GXT File as .txt";
            this.saveCurrentGXTFileAstxtToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentGXTFileAstxtToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.githubRepoToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // githubRepoToolStripMenuItem
            // 
            this.githubRepoToolStripMenuItem.Name = "githubRepoToolStripMenuItem";
            this.githubRepoToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.githubRepoToolStripMenuItem.Text = "Github Repo";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxGXTTables);
            this.groupBox4.Location = new System.Drawing.Point(4, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(180, 60);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select GXT Table";
            // 
            // comboBoxGXTTables
            // 
            this.comboBoxGXTTables.FormattingEnabled = true;
            this.comboBoxGXTTables.Location = new System.Drawing.Point(6, 19);
            this.comboBoxGXTTables.Name = "comboBoxGXTTables";
            this.comboBoxGXTTables.Size = new System.Drawing.Size(164, 21);
            this.comboBoxGXTTables.TabIndex = 0;
            this.comboBoxGXTTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxGXTTables_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 832);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "GXT Editor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupReloadTable.ResumeLayout(false);
            this.searchGroup.ResumeLayout(false);
            this.searchGroup.PerformLayout();
            this.groupTextFont.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.groupGxtTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GXTTable)).EndInit();
            this.groupTextPreview.ResumeLayout(false);
            this.groupTextPreview.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGXTFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompileGXTFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileCurrentFileTogxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentGXTFileAstxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubRepoToolStripMenuItem;
        private System.Windows.Forms.ComboBox textFonts;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.GroupBox logBoxGroup;
        private System.Windows.Forms.GroupBox groupTextFont;
        private System.Windows.Forms.GroupBox groupTextPreview;
        private System.Windows.Forms.TextBox GXTValueTextBox;
        private System.Windows.Forms.GroupBox groupGxtTable;
        private System.Windows.Forms.DataGridView GXTTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn GXT_KEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn GXT_VALUE;
        private System.Windows.Forms.GroupBox searchGroup;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchKeyInput;
        private System.Windows.Forms.RadioButton radioSearchKey;
        private System.Windows.Forms.RadioButton radioSearchValue;
        private System.Windows.Forms.ToolStripMenuItem compileATextFileTogxtToolStripMenuItem;
        private System.Windows.Forms.Label currentFilePathLabel;
        private System.Windows.Forms.GroupBox groupReloadTable;
        private System.Windows.Forms.Button refreshTableButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button compileTableButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonOpenWith;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioIV;
        private System.Windows.Forms.RadioButton radioSA;
        private System.Windows.Forms.RadioButton radioClassics;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxGXTTables;
    }
}

