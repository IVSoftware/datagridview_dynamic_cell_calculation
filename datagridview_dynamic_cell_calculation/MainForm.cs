﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datagridview_dynamic_cell_calculation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dgv_Filho.CellEndEdit += dgv_Filho_CellEndEdit_1;
            cb_Iva.SelectedIndex = 0;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgv_Filho.DataSource = DataSource;
            // Add one or more items to autogenerate the columns.
            for (int i = 1; i <= 5; i++)
            {
                DataSource.Add(new Articulo { Descricao = $"Articulo {i}" });
            }
            foreach (DataGridViewColumn column in dgv_Filho.Columns)
            {
                switch (column.Name)
                {
                    case nameof(Articulo.Descricao):
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        column.MinimumWidth = 100;
                        break;
                    case nameof(Articulo.Check_Filho):
                        column.Width = 50;
                        column.HeaderText = string.Empty;
                        break;
                    default:
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        break;
                }
            }
        }
        BindingList<Articulo> DataSource = new BindingList<Articulo>();

        private void dgv_Filho_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            bool Check = Convert.ToBoolean(dgv_Filho.CurrentRow.Cells["Check_Filho"].Value);
            string Medida_1 = Convert.ToString(dgv_Filho.CurrentRow.Cells["Medida_1"].Value);
            string Medida_2 = Convert.ToString(dgv_Filho.CurrentRow.Cells["Medida_2"].Value);

            var Iva = decimal.Parse(cb_Iva.Text.Replace("%", string.Empty));

            if (Check)
            {
                if (!string.IsNullOrWhiteSpace(tb_CodigoArtigo.Text) || !string.IsNullOrWhiteSpace(tb_Descricao.Text))
                {
                    dgv_Filho.CurrentRow.Cells["ArtigoPai"].Value = tb_CodigoArtigo.Text;
                    dgv_Filho.CurrentRow.Cells["Descricao_Pai"].Value = tb_Descricao.Text + " " + Medida_1 + Medida_2;
                    dgv_Filho.CurrentRow.Cells["CodigoArtigoFilho"].Value = tb_CodigoArtigo.Text + Medida_1 + Medida_2;

                    decimal PrecoFilho = Convert.ToDecimal(dgv_Filho.CurrentRow.Cells["PrecoFilhoSemIva"].Value);
                    if (PrecoFilho > 0)
                    {
                        decimal PrecoFilhoComIva = PrecoFilho * Iva / 100 + PrecoFilho;
                        dgv_Filho.CurrentRow.Cells["PrecoFilhoComIva"].Value = PrecoFilhoComIva;
                    }
                }
                else
                {
                    dgv_Filho.CurrentRow.Cells["ArtigoPai"].Value = string.Empty;
                    dgv_Filho.CurrentRow.Cells["Descricao_Pai"].Value = string.Empty;
                }
            }
        }
    }
    class Articulo
    {
        public bool Check_Filho { get; set; }
        public string Descricao { get; set; }
        public string ArtigoPai { get; set; }
        public string Descricao_Pai { get; set; }
        public decimal PrecoFilhoSemIva { get; set; }
        public decimal PrecoFilhoComIva { get; set; }
        public decimal Medida_1 { get; set; }
        public decimal Medida_2 { get; set; }
        public string CodigoArtigo { get; set; }
        public string CodigoArtigoFilho { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}