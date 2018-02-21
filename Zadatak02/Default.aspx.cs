using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak02
{
    public partial class Default : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ShowDrzave();
        }

        SqlDataAdapter AdapterDrzava()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Drzava", new SqlConnection(cs));
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            return da;
        }

        SqlDataAdapter AdapterGrad()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Grad", new SqlConnection(cs));
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            return da;
        }

        private void ShowDrzave()
        {
            ds = new DataSet();
            SqlDataAdapter daDrzava = AdapterDrzava();
            daDrzava.Fill(ds, "Drzava");

            lbDrzave.Items.Clear();
            foreach (DataRow row in ds.Tables["Drzava"].Rows)
            {
                lbDrzave.Items.Add(new ListItem
                {
                    Value = row["IDDrzava"].ToString(),
                    Text = row["Naziv"].ToString()
                });
            }
        }

        private void ShowGradovi(int idDrzava)
        {
            ds = new DataSet();
            SqlDataAdapter daGrad = AdapterGrad();
            daGrad.Fill(ds, "Grad");

            DataView dvGrad = ds.Tables["Grad"].DefaultView;
            dvGrad.Sort = "Naziv";

            lbGradovi.Items.Clear();
            foreach (DataRowView row in dvGrad)
            {
                if ((int)row["DrzavaID"] == idDrzava)
                    lbGradovi.Items.Add(new ListItem
                    {
                        Value = row["IDGrad"].ToString(),
                        Text = row["Naziv"].ToString()
                    });
            }
        }

        private void ShowGrad(int idGrad)
        {
            ds = new DataSet();
            SqlDataAdapter daGrad = AdapterGrad();
            daGrad.Fill(ds, "Grad");

            foreach (DataRow row in ds.Tables["Grad"].Rows)
            {
                if ((int)row["IDGrad"] == idGrad)
                {
                    txtGrad.Text = row["Naziv"].ToString();
                    break;
                }
            }
        }

        protected void lbDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDrzave.SelectedIndex == -1)
                return;

            ShowGradovi(int.Parse(lbDrzave.SelectedValue));
        }

        protected void lbGradovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbGradovi.SelectedIndex == -1)
                return;

            ShowGrad(int.Parse(lbGradovi.SelectedValue));
        }

        private void DeleteGrad()
        {
            ds = new DataSet();
            AdapterGrad().Fill(ds, "Grad");

            foreach (DataRow row in ds.Tables["Grad"].Rows)
            {
                if ((int)row["IDGrad"] == int.Parse(lbGradovi.SelectedValue))
                {
                    row.Delete();
                    break;
                }
            }

            txtGrad.Text = "";
            AdapterGrad().Update(ds, "Grad");

            ShowGradovi(int.Parse(lbDrzave.SelectedValue));
        }

        private void UpdateGrad()
        {
            ds = new DataSet();
            AdapterGrad().Fill(ds, "Grad");

            foreach (DataRow row in ds.Tables["Grad"].Rows)
            {
                if ((int)row["IDGrad"] == int.Parse(lbGradovi.SelectedValue))
                {
                    row["Naziv"] = txtGrad.Text;
                    break;
                }
            }

            AdapterGrad().Update(ds, "Grad");
            txtGrad.Text = "";
            ShowGradovi(int.Parse(lbDrzave.SelectedValue));
        }

        private void InsertGrad()
        {
            ds = new DataSet();
            AdapterGrad().Fill(ds, "Grad");

            DataRow row = ds.Tables["Grad"].NewRow();
            row["Naziv"] = txtGrad.Text;
            row["DrzavaID"] = int.Parse(lbDrzave.SelectedValue);

            ds.Tables["Grad"].Rows.Add(row);
            AdapterGrad().Update(ds, "Grad");

            txtGrad.Text = "";
            ShowGradovi(int.Parse(lbDrzave.SelectedValue));
        }

        protected void btnDeleteGrad_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbGradovi.SelectedValue) == -1)
                return;

            DeleteGrad();
        }

        protected void btnInsertGrad_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbDrzave.SelectedValue) == -1 || txtGrad.Text == "")
                return;

            InsertGrad();
        }

        protected void btnUpdateGrad_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbGradovi.SelectedValue) == -1)
                return;

            UpdateGrad();
        }

        protected void btnSaveToXML_Click(object sender, EventArgs e)
        {
            try
            {
                SaveToXML();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private void SaveToXML()
        {
            ds = new DataSet("DrzaveGradovi");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Drzava; SELECT * FROM Grad", new SqlConnection(cs));
            da.Fill(ds);

            ds.Tables[0].TableName = "Drzava";
            ds.Tables[1].TableName = "Grad";

            DataRelation rel = new DataRelation("Drzava_Grad", ds.Tables["Drzava"].Columns["IDDrzava"], ds.Tables["Grad"].Columns["DrzavaID"]);
            rel.Nested = true;
            ds.Relations.Add(rel);

            ds.WriteXml("D:/DataSet1.xml", XmlWriteMode.WriteSchema);
        }
    }
}