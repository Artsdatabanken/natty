﻿namespace Forms_dev3
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
            this.buttonUpdateKodelister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBoxBeskrivelsesvariabler = new System.Windows.Forms.CheckedListBox();
            this.textBoxBeskrivelsesvaiabler = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonUpdateValideringsenheter = new System.Windows.Forms.Button();
            this.comboBoxVurderingsenhet = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkedListBoxKartleggingsKode = new System.Windows.Forms.CheckedListBox();
            this.comboBoxNaturområdetyper = new System.Windows.Forms.ComboBox();
            this.dataGridViewRødlisteKlassifisering = new System.Windows.Forms.DataGridView();
            this.NaturområdeTyper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Beskrivelsesvariabler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RødlisteKlassifisering_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonUpdateRødlisteKlassifisering = new System.Windows.Forms.Button();
            this.buttonDeleteRødlisteKlassifisering = new System.Windows.Forms.Button();
            this.checkBoxShowAllBeskrivelsesvariabel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRødlisteKlassifisering)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonUpdateKodelister
            // 
            this.buttonUpdateKodelister.Location = new System.Drawing.Point(503, 541);
            this.buttonUpdateKodelister.Name = "buttonUpdateKodelister";
            this.buttonUpdateKodelister.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateKodelister.TabIndex = 0;
            this.buttonUpdateKodelister.Text = "Update";
            this.buttonUpdateKodelister.UseVisualStyleBackColor = true;
            this.buttonUpdateKodelister.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "NaturområdeType";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Beskrivelsesvariabel";
            // 
            // checkedListBoxBeskrivelsesvariabler
            // 
            this.checkedListBoxBeskrivelsesvariabler.FormattingEnabled = true;
            this.checkedListBoxBeskrivelsesvariabler.Location = new System.Drawing.Point(127, 192);
            this.checkedListBoxBeskrivelsesvariabler.Name = "checkedListBoxBeskrivelsesvariabler";
            this.checkedListBoxBeskrivelsesvariabler.Size = new System.Drawing.Size(124, 334);
            this.checkedListBoxBeskrivelsesvariabler.TabIndex = 5;
            // 
            // textBoxBeskrivelsesvaiabler
            // 
            this.textBoxBeskrivelsesvaiabler.Location = new System.Drawing.Point(127, 160);
            this.textBoxBeskrivelsesvaiabler.Name = "textBoxBeskrivelsesvaiabler";
            this.textBoxBeskrivelsesvaiabler.Size = new System.Drawing.Size(61, 20);
            this.textBoxBeskrivelsesvaiabler.TabIndex = 4;
            this.textBoxBeskrivelsesvaiabler.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxBeskrivelsesvariabler_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 546);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kodelister";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vurderingsenheter";
            // 
            // buttonUpdateValideringsenheter
            // 
            this.buttonUpdateValideringsenheter.Location = new System.Drawing.Point(363, 541);
            this.buttonUpdateValideringsenheter.Name = "buttonUpdateValideringsenheter";
            this.buttonUpdateValideringsenheter.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateValideringsenheter.TabIndex = 10;
            this.buttonUpdateValideringsenheter.Text = "Update";
            this.buttonUpdateValideringsenheter.UseVisualStyleBackColor = true;
            this.buttonUpdateValideringsenheter.Click += new System.EventHandler(this.buttonUpdateValideringsenheter_Click);
            // 
            // comboBoxVurderingsenhet
            // 
            this.comboBoxVurderingsenhet.FormattingEnabled = true;
            this.comboBoxVurderingsenhet.Location = new System.Drawing.Point(30, 51);
            this.comboBoxVurderingsenhet.Name = "comboBoxVurderingsenhet";
            this.comboBoxVurderingsenhet.Size = new System.Drawing.Size(158, 21);
            this.comboBoxVurderingsenhet.TabIndex = 11;
            this.comboBoxVurderingsenhet.SelectedIndexChanged += new System.EventHandler(this.comboBoxVurderingsenhet_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Vurderingsenheter";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(503, 22);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkedListBoxKartleggingsKode
            // 
            this.checkedListBoxKartleggingsKode.FormattingEnabled = true;
            this.checkedListBoxKartleggingsKode.Location = new System.Drawing.Point(32, 192);
            this.checkedListBoxKartleggingsKode.Name = "checkedListBoxKartleggingsKode";
            this.checkedListBoxKartleggingsKode.Size = new System.Drawing.Size(89, 334);
            this.checkedListBoxKartleggingsKode.TabIndex = 15;
            // 
            // comboBoxNaturområdetyper
            // 
            this.comboBoxNaturområdetyper.FormattingEnabled = true;
            this.comboBoxNaturområdetyper.Location = new System.Drawing.Point(32, 160);
            this.comboBoxNaturområdetyper.Name = "comboBoxNaturområdetyper";
            this.comboBoxNaturområdetyper.Size = new System.Drawing.Size(89, 21);
            this.comboBoxNaturområdetyper.TabIndex = 17;
            this.comboBoxNaturområdetyper.SelectedIndexChanged += new System.EventHandler(this.comboBoxNaturområdetyper_SelectedIndexChanged);
            // 
            // dataGridViewRødlisteKlassifisering
            // 
            this.dataGridViewRødlisteKlassifisering.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRødlisteKlassifisering.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NaturområdeTyper,
            this.Beskrivelsesvariabler,
            this.RødlisteKlassifisering_id});
            this.dataGridViewRødlisteKlassifisering.Location = new System.Drawing.Point(267, 160);
            this.dataGridViewRødlisteKlassifisering.Name = "dataGridViewRødlisteKlassifisering";
            this.dataGridViewRødlisteKlassifisering.Size = new System.Drawing.Size(311, 366);
            this.dataGridViewRødlisteKlassifisering.TabIndex = 18;
            this.dataGridViewRødlisteKlassifisering.SelectionChanged += new System.EventHandler(this.dataGridViewRødlisteKlassifisering_SelectionChanged);
            // 
            // NaturområdeTyper
            // 
            this.NaturområdeTyper.HeaderText = "NaturområdeTyper";
            this.NaturområdeTyper.Name = "NaturområdeTyper";
            // 
            // Beskrivelsesvariabler
            // 
            this.Beskrivelsesvariabler.HeaderText = "Beskrivelsesvariabler";
            this.Beskrivelsesvariabler.Name = "Beskrivelsesvariabler";
            // 
            // RødlisteKlassifisering_id
            // 
            this.RødlisteKlassifisering_id.HeaderText = "RødlisteKlassifisering_id";
            this.RødlisteKlassifisering_id.Name = "RødlisteKlassifisering_id";
            this.RødlisteKlassifisering_id.Visible = false;
            // 
            // buttonUpdateRødlisteKlassifisering
            // 
            this.buttonUpdateRødlisteKlassifisering.Location = new System.Drawing.Point(503, 51);
            this.buttonUpdateRødlisteKlassifisering.Name = "buttonUpdateRødlisteKlassifisering";
            this.buttonUpdateRødlisteKlassifisering.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateRødlisteKlassifisering.TabIndex = 19;
            this.buttonUpdateRødlisteKlassifisering.Text = "Update";
            this.buttonUpdateRødlisteKlassifisering.UseVisualStyleBackColor = true;
            this.buttonUpdateRødlisteKlassifisering.Click += new System.EventHandler(this.buttonUpdateRødlisteKlassifisering_Click);
            // 
            // buttonDeleteRødlisteKlassifisering
            // 
            this.buttonDeleteRødlisteKlassifisering.Location = new System.Drawing.Point(503, 80);
            this.buttonDeleteRødlisteKlassifisering.Name = "buttonDeleteRødlisteKlassifisering";
            this.buttonDeleteRødlisteKlassifisering.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteRødlisteKlassifisering.TabIndex = 20;
            this.buttonDeleteRødlisteKlassifisering.Text = "Delete";
            this.buttonDeleteRødlisteKlassifisering.UseVisualStyleBackColor = true;
            this.buttonDeleteRødlisteKlassifisering.Click += new System.EventHandler(this.buttonDeleteRødlisteKlassifisering_Click);
            // 
            // checkBoxShowAllBeskrivelsesvariabel
            // 
            this.checkBoxShowAllBeskrivelsesvariabel.AutoSize = true;
            this.checkBoxShowAllBeskrivelsesvariabel.Location = new System.Drawing.Point(195, 162);
            this.checkBoxShowAllBeskrivelsesvariabel.Name = "checkBoxShowAllBeskrivelsesvariabel";
            this.checkBoxShowAllBeskrivelsesvariabel.Size = new System.Drawing.Size(59, 17);
            this.checkBoxShowAllBeskrivelsesvariabel.TabIndex = 21;
            this.checkBoxShowAllBeskrivelsesvariabel.Text = "Vis alle";
            this.checkBoxShowAllBeskrivelsesvariabel.UseVisualStyleBackColor = true;
            this.checkBoxShowAllBeskrivelsesvariabel.CheckedChanged += new System.EventHandler(this.checkBoxShowAllBeskrivelsesvariabel_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 576);
            this.Controls.Add(this.checkBoxShowAllBeskrivelsesvariabel);
            this.Controls.Add(this.buttonDeleteRødlisteKlassifisering);
            this.Controls.Add(this.buttonUpdateRødlisteKlassifisering);
            this.Controls.Add(this.dataGridViewRødlisteKlassifisering);
            this.Controls.Add(this.comboBoxNaturområdetyper);
            this.Controls.Add(this.checkedListBoxKartleggingsKode);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxVurderingsenhet);
            this.Controls.Add(this.buttonUpdateValideringsenheter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBoxBeskrivelsesvariabler);
            this.Controls.Add(this.textBoxBeskrivelsesvaiabler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUpdateKodelister);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRødlisteKlassifisering)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdateKodelister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBoxBeskrivelsesvariabler;
        private System.Windows.Forms.TextBox textBoxBeskrivelsesvaiabler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonUpdateValideringsenheter;
        private System.Windows.Forms.ComboBox comboBoxVurderingsenhet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckedListBox checkedListBoxKartleggingsKode;
        private System.Windows.Forms.ComboBox comboBoxNaturområdetyper;
        private System.Windows.Forms.DataGridView dataGridViewRødlisteKlassifisering;
        private System.Windows.Forms.DataGridViewTextBoxColumn NaturområdeTyper;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beskrivelsesvariabler;
        private System.Windows.Forms.DataGridViewTextBoxColumn RødlisteKlassifisering_id;
        private System.Windows.Forms.Button buttonUpdateRødlisteKlassifisering;
        private System.Windows.Forms.Button buttonDeleteRødlisteKlassifisering;
        private System.Windows.Forms.CheckBox checkBoxShowAllBeskrivelsesvariabel;
    }
}

