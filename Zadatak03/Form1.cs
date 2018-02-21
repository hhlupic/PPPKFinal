using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadatak03
{
    public partial class Form1 : Form
    {
        private PPPKVjezbe06DataSet ds;
        private PPPKVjezbe06DataSetTableAdapters.DrzavaTableAdapter taDrzava;
        private PPPKVjezbe06DataSetTableAdapters.GradTableAdapter taGrad;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataSet();
            ShowDrzave();
        }

        private void ShowDrzave()
        {
            foreach (PPPKVjezbe06DataSet.DrzavaRow row in ds.Drzava.Rows)
            {
                cbDrzave.Items.Add(row);
            }

            if (cbDrzave.Items.Count > 0)
            {
                cbDrzave.SelectedIndex = 0;
                ShowGradovi();
            }

        }

        private void ShowGradovi()
        {
            if (cbDrzave.SelectedIndex == -1)
                return;

            lbGradovi.Items.Clear();
            foreach (PPPKVjezbe06DataSet.GradRow row in ds.Grad.Rows)
            {
                PPPKVjezbe06DataSet.DrzavaRow drzava = (PPPKVjezbe06DataSet.DrzavaRow)cbDrzave.SelectedItem;
                if (row.DrzavaID == drzava.IDDrzava)
                    lbGradovi.Items.Add(row);
            }
        }

        private void LoadDataSet()
        {
            ds = new PPPKVjezbe06DataSet();

            taDrzava = new PPPKVjezbe06DataSetTableAdapters.DrzavaTableAdapter();
            taDrzava.Fill(ds.Drzava);

            taGrad = new PPPKVjezbe06DataSetTableAdapters.GradTableAdapter();
            taGrad.Fill(ds.Grad);
        }

        private void cbDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowGradovi();
        }
    }
}
