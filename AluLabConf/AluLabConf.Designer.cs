﻿namespace AluLabConf
{
    partial class AluLabConfForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.oParentComboNodeB = new System.Windows.Forms.ComboBox();
            this.labAluBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oParentEnodeB = new System.Windows.Forms.Label();
            this.oParentBandFreq = new System.Windows.Forms.Label();
            this.oParentComboFreq = new System.Windows.Forms.ComboBox();
            this.oGroupBoxIntra = new System.Windows.Forms.GroupBox();
            this.oCheckBoxIntraActivate = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.oIntraComboNodeB = new System.Windows.Forms.Label();
            this.oIntranComboNodeB = new System.Windows.Forms.ComboBox();
            this.oInterGroupBox = new System.Windows.Forms.GroupBox();
            this.oCheckBoxInterActivate = new System.Windows.Forms.CheckBox();
            this.oCheckBoxInterS1 = new System.Windows.Forms.CheckBox();
            this.oCheckBoxInterX2 = new System.Windows.Forms.CheckBox();
            this.oInterRadio10 = new System.Windows.Forms.RadioButton();
            this.oInterRadio5 = new System.Windows.Forms.RadioButton();
            this.oInterTxtBandeFreq = new System.Windows.Forms.Label();
            this.oInterComboBandFreq = new System.Windows.Forms.ComboBox();
            this.oInterTxtNodeB = new System.Windows.Forms.Label();
            this.oInterComboNodeB = new System.Windows.Forms.ComboBox();
            this.oButton1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.oButton2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.labAluBindingSource)).BeginInit();
            this.oGroupBoxIntra.SuspendLayout();
            this.oInterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // oParentComboNodeB
            // 
            this.oParentComboNodeB.DataSource = this.labAluBindingSource;
            this.oParentComboNodeB.FormattingEnabled = true;
            this.oParentComboNodeB.Location = new System.Drawing.Point(103, 77);
            this.oParentComboNodeB.Name = "oParentComboNodeB";
            this.oParentComboNodeB.Size = new System.Drawing.Size(121, 21);
            this.oParentComboNodeB.TabIndex = 0;
            // 
            // oParentEnodeB
            // 
            this.oParentEnodeB.AutoSize = true;
            this.oParentEnodeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oParentEnodeB.Location = new System.Drawing.Point(129, 61);
            this.oParentEnodeB.Name = "oParentEnodeB";
            this.oParentEnodeB.Size = new System.Drawing.Size(63, 16);
            this.oParentEnodeB.TabIndex = 1;
            this.oParentEnodeB.Text = "EnodeB";
            this.oParentEnodeB.Click += new System.EventHandler(this.label1_Click);
            // 
            // oParentBandFreq
            // 
            this.oParentBandFreq.AutoSize = true;
            this.oParentBandFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oParentBandFreq.Location = new System.Drawing.Point(307, 61);
            this.oParentBandFreq.Name = "oParentBandFreq";
            this.oParentBandFreq.Size = new System.Drawing.Size(85, 16);
            this.oParentBandFreq.TabIndex = 3;
            this.oParentBandFreq.Text = "BandeFreq";
            // 
            // oParentComboFreq
            // 
            this.oParentComboFreq.FormattingEnabled = true;
            this.oParentComboFreq.Location = new System.Drawing.Point(284, 77);
            this.oParentComboFreq.Name = "oParentComboFreq";
            this.oParentComboFreq.Size = new System.Drawing.Size(121, 21);
            this.oParentComboFreq.TabIndex = 2;
            this.oParentComboFreq.SelectedIndexChanged += new System.EventHandler(this.oParentComboFreq_SelectedIndexChanged);
            // 
            // oGroupBoxIntra
            // 
            this.oGroupBoxIntra.Controls.Add(this.oCheckBoxIntraActivate);
            this.oGroupBoxIntra.Controls.Add(this.checkBox1);
            this.oGroupBoxIntra.Controls.Add(this.oIntraComboNodeB);
            this.oGroupBoxIntra.Controls.Add(this.oIntranComboNodeB);
            this.oGroupBoxIntra.Location = new System.Drawing.Point(3, 104);
            this.oGroupBoxIntra.Name = "oGroupBoxIntra";
            this.oGroupBoxIntra.Size = new System.Drawing.Size(248, 139);
            this.oGroupBoxIntra.TabIndex = 4;
            this.oGroupBoxIntra.TabStop = false;
            this.oGroupBoxIntra.Text = "Neighboring Intra";
            // 
            // oCheckBoxIntraActivate
            // 
            this.oCheckBoxIntraActivate.AutoSize = true;
            this.oCheckBoxIntraActivate.Location = new System.Drawing.Point(9, 20);
            this.oCheckBoxIntraActivate.Name = "oCheckBoxIntraActivate";
            this.oCheckBoxIntraActivate.Size = new System.Drawing.Size(89, 17);
            this.oCheckBoxIntraActivate.TabIndex = 13;
            this.oCheckBoxIntraActivate.Text = "Activate Intra";
            this.oCheckBoxIntraActivate.UseVisualStyleBackColor = true;
            this.oCheckBoxIntraActivate.Click += new System.EventHandler(this.click_CheckBoxIntraActivate);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(39, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "X2";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // oIntraComboNodeB
            // 
            this.oIntraComboNodeB.AutoSize = true;
            this.oIntraComboNodeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oIntraComboNodeB.Location = new System.Drawing.Point(32, 57);
            this.oIntraComboNodeB.Name = "oIntraComboNodeB";
            this.oIntraComboNodeB.Size = new System.Drawing.Size(63, 16);
            this.oIntraComboNodeB.TabIndex = 7;
            this.oIntraComboNodeB.Text = "EnodeB";
            // 
            // oIntranComboNodeB
            // 
            this.oIntranComboNodeB.FormattingEnabled = true;
            this.oIntranComboNodeB.Location = new System.Drawing.Point(6, 73);
            this.oIntranComboNodeB.Name = "oIntranComboNodeB";
            this.oIntranComboNodeB.Size = new System.Drawing.Size(121, 21);
            this.oIntranComboNodeB.TabIndex = 6;
            // 
            // oInterGroupBox
            // 
            this.oInterGroupBox.Controls.Add(this.oCheckBoxInterActivate);
            this.oInterGroupBox.Controls.Add(this.oCheckBoxInterS1);
            this.oInterGroupBox.Controls.Add(this.oCheckBoxInterX2);
            this.oInterGroupBox.Controls.Add(this.oInterRadio10);
            this.oInterGroupBox.Controls.Add(this.oInterRadio5);
            this.oInterGroupBox.Controls.Add(this.oInterTxtBandeFreq);
            this.oInterGroupBox.Controls.Add(this.oInterComboBandFreq);
            this.oInterGroupBox.Controls.Add(this.oInterTxtNodeB);
            this.oInterGroupBox.Controls.Add(this.oInterComboNodeB);
            this.oInterGroupBox.Location = new System.Drawing.Point(263, 104);
            this.oInterGroupBox.Name = "oInterGroupBox";
            this.oInterGroupBox.Size = new System.Drawing.Size(269, 139);
            this.oInterGroupBox.TabIndex = 5;
            this.oInterGroupBox.TabStop = false;
            this.oInterGroupBox.Text = "Neighboring Inter";
            // 
            // oCheckBoxInterActivate
            // 
            this.oCheckBoxInterActivate.AutoSize = true;
            this.oCheckBoxInterActivate.Location = new System.Drawing.Point(11, 20);
            this.oCheckBoxInterActivate.Name = "oCheckBoxInterActivate";
            this.oCheckBoxInterActivate.Size = new System.Drawing.Size(89, 17);
            this.oCheckBoxInterActivate.TabIndex = 12;
            this.oCheckBoxInterActivate.Text = "Activate Inter";
            this.oCheckBoxInterActivate.UseVisualStyleBackColor = true;
            this.oCheckBoxInterActivate.CheckStateChanged += new System.EventHandler(this.click_CheckBoxInterActivate);
            // 
            // oCheckBoxInterS1
            // 
            this.oCheckBoxInterS1.AutoSize = true;
            this.oCheckBoxInterS1.Location = new System.Drawing.Point(56, 111);
            this.oCheckBoxInterS1.Name = "oCheckBoxInterS1";
            this.oCheckBoxInterS1.Size = new System.Drawing.Size(39, 17);
            this.oCheckBoxInterS1.TabIndex = 11;
            this.oCheckBoxInterS1.Text = "S1";
            this.oCheckBoxInterS1.UseVisualStyleBackColor = true;
            // 
            // oCheckBoxInterX2
            // 
            this.oCheckBoxInterX2.AutoSize = true;
            this.oCheckBoxInterX2.Location = new System.Drawing.Point(11, 111);
            this.oCheckBoxInterX2.Name = "oCheckBoxInterX2";
            this.oCheckBoxInterX2.Size = new System.Drawing.Size(39, 17);
            this.oCheckBoxInterX2.TabIndex = 10;
            this.oCheckBoxInterX2.Text = "X2";
            this.oCheckBoxInterX2.UseVisualStyleBackColor = true;
            this.oCheckBoxInterX2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // oInterRadio10
            // 
            this.oInterRadio10.AutoSize = true;
            this.oInterRadio10.Location = new System.Drawing.Point(200, 109);
            this.oInterRadio10.Name = "oInterRadio10";
            this.oInterRadio10.Size = new System.Drawing.Size(60, 17);
            this.oInterRadio10.TabIndex = 9;
            this.oInterRadio10.TabStop = true;
            this.oInterRadio10.Text = "10 Mhz";
            this.oInterRadio10.UseVisualStyleBackColor = true;
            this.oInterRadio10.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // oInterRadio5
            // 
            this.oInterRadio5.AutoSize = true;
            this.oInterRadio5.Location = new System.Drawing.Point(144, 109);
            this.oInterRadio5.Name = "oInterRadio5";
            this.oInterRadio5.Size = new System.Drawing.Size(54, 17);
            this.oInterRadio5.TabIndex = 8;
            this.oInterRadio5.TabStop = true;
            this.oInterRadio5.Text = "5 Mhz";
            this.oInterRadio5.UseVisualStyleBackColor = true;
            // 
            // oInterTxtBandeFreq
            // 
            this.oInterTxtBandeFreq.AutoSize = true;
            this.oInterTxtBandeFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oInterTxtBandeFreq.Location = new System.Drawing.Point(156, 57);
            this.oInterTxtBandeFreq.Name = "oInterTxtBandeFreq";
            this.oInterTxtBandeFreq.Size = new System.Drawing.Size(85, 16);
            this.oInterTxtBandeFreq.TabIndex = 7;
            this.oInterTxtBandeFreq.Text = "BandeFreq";
            // 
            // oInterComboBandFreq
            // 
            this.oInterComboBandFreq.FormattingEnabled = true;
            this.oInterComboBandFreq.Location = new System.Drawing.Point(133, 73);
            this.oInterComboBandFreq.Name = "oInterComboBandFreq";
            this.oInterComboBandFreq.Size = new System.Drawing.Size(121, 21);
            this.oInterComboBandFreq.TabIndex = 6;
            // 
            // oInterTxtNodeB
            // 
            this.oInterTxtNodeB.AutoSize = true;
            this.oInterTxtNodeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oInterTxtNodeB.Location = new System.Drawing.Point(32, 57);
            this.oInterTxtNodeB.Name = "oInterTxtNodeB";
            this.oInterTxtNodeB.Size = new System.Drawing.Size(63, 16);
            this.oInterTxtNodeB.TabIndex = 5;
            this.oInterTxtNodeB.Text = "EnodeB";
            // 
            // oInterComboNodeB
            // 
            this.oInterComboNodeB.FormattingEnabled = true;
            this.oInterComboNodeB.Location = new System.Drawing.Point(6, 73);
            this.oInterComboNodeB.Name = "oInterComboNodeB";
            this.oInterComboNodeB.Size = new System.Drawing.Size(121, 21);
            this.oInterComboNodeB.TabIndex = 4;
            // 
            // oButton1
            // 
            this.oButton1.Location = new System.Drawing.Point(12, 9);
            this.oButton1.Name = "oButton1";
            this.oButton1.Size = new System.Drawing.Size(71, 25);
            this.oButton1.TabIndex = 6;
            this.oButton1.Text = "XML";
            this.oButton1.UseVisualStyleBackColor = true;
            this.oButton1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(434, 20);
            this.textBox1.TabIndex = 7;
            // 
            // oButton2
            // 
            this.oButton2.Location = new System.Drawing.Point(176, 246);
            this.oButton2.Name = "oButton2";
            this.oButton2.Size = new System.Drawing.Size(161, 54);
            this.oButton2.TabIndex = 8;
            this.oButton2.Text = "GENERATE";
            this.oButton2.UseVisualStyleBackColor = true;
            this.oButton2.Click += new System.EventHandler(this.ButtonGenerate);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 314);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(511, 20);
            this.textBox2.TabIndex = 9;
            // 
            // AluLabConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 379);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.oButton2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.oButton1);
            this.Controls.Add(this.oInterGroupBox);
            this.Controls.Add(this.oGroupBoxIntra);
            this.Controls.Add(this.oParentBandFreq);
            this.Controls.Add(this.oParentComboFreq);
            this.Controls.Add(this.oParentEnodeB);
            this.Controls.Add(this.oParentComboNodeB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AluLabConfForm";
            this.Text = "AluLabConf";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.labAluBindingSource)).EndInit();
            this.oGroupBoxIntra.ResumeLayout(false);
            this.oGroupBoxIntra.PerformLayout();
            this.oInterGroupBox.ResumeLayout(false);
            this.oInterGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox oParentComboNodeB;
        private System.Windows.Forms.Label oParentEnodeB;
        private System.Windows.Forms.Label oParentBandFreq;
        public System.Windows.Forms.ComboBox oParentComboFreq;
        private System.Windows.Forms.GroupBox oGroupBoxIntra;
        private System.Windows.Forms.GroupBox oInterGroupBox;
        public System.Windows.Forms.Label oIntraComboNodeB;
        public System.Windows.Forms.ComboBox oIntranComboNodeB;
        private System.Windows.Forms.Label oInterTxtBandeFreq;
        public System.Windows.Forms.ComboBox oInterComboBandFreq;
        private System.Windows.Forms.Label oInterTxtNodeB;
        public System.Windows.Forms.ComboBox oInterComboNodeB;
        public System.Windows.Forms.RadioButton oInterRadio10;
        public System.Windows.Forms.RadioButton oInterRadio5;
        public System.Windows.Forms.CheckBox oCheckBoxInterX2;
        public System.Windows.Forms.CheckBox oCheckBoxInterS1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.BindingSource labAluBindingSource;
        public System.Windows.Forms.Button oButton1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button oButton2;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox oCheckBoxIntraActivate;
        private System.Windows.Forms.CheckBox oCheckBoxInterActivate;
    }
}
