
namespace datagridview_dynamic_cell_calculation
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_Filho = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_CodigoArtigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Descricao = new System.Windows.Forms.TextBox();
            this.cb_Iva = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Filho)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Filho
            // 
            this.dgv_Filho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Filho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Filho.Location = new System.Drawing.Point(0, 0);
            this.dgv_Filho.Name = "dgv_Filho";
            this.dgv_Filho.RowHeadersWidth = 62;
            this.dgv_Filho.Size = new System.Drawing.Size(1478, 277);
            this.dgv_Filho.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo Artigo";
            // 
            // tb_CodigoArtigo
            // 
            this.tb_CodigoArtigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_CodigoArtigo.Location = new System.Drawing.Point(141, 351);
            this.tb_CodigoArtigo.Name = "tb_CodigoArtigo";
            this.tb_CodigoArtigo.Size = new System.Drawing.Size(200, 31);
            this.tb_CodigoArtigo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descricao";
            // 
            // tb_Descricao
            // 
            this.tb_Descricao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_Descricao.Location = new System.Drawing.Point(141, 307);
            this.tb_Descricao.Name = "tb_Descricao";
            this.tb_Descricao.Size = new System.Drawing.Size(200, 31);
            this.tb_Descricao.TabIndex = 2;
            // 
            // cb_Iva
            // 
            this.cb_Iva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_Iva.FormattingEnabled = true;
            this.cb_Iva.Items.AddRange(new object[] {
            "3.0%",
            "4.0%"});
            this.cb_Iva.Location = new System.Drawing.Point(141, 397);
            this.cb_Iva.Name = "cb_Iva";
            this.cb_Iva.Size = new System.Drawing.Size(182, 33);
            this.cb_Iva.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Iva";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 444);
            this.Controls.Add(this.cb_Iva);
            this.Controls.Add(this.tb_Descricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_CodigoArtigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Filho);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Filho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Filho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_CodigoArtigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Descricao;
        private System.Windows.Forms.ComboBox cb_Iva;
        private System.Windows.Forms.Label label3;
    }
}

