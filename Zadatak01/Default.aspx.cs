using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01
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

        private SqlDataAdapter AdapterDrzave()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Drzava", new SqlConnection(cs));
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            return da;
        }

        private SqlDataAdapter AdapterGrad()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Grad", new SqlConnection(cs));
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            return da;
        }

        private void ShowDrzave()
        {
            ds = new DataSet();
            SqlDataAdapter daDrzave = AdapterDrzave();
            daDrzave.Fill(ds, "Drzava");

            ddlDrzave.Items.Clear();
            lbGradovi.Items.Clear();

            foreach (DataRow row in ds.Tables["Drzava"].Rows)
            {
                ddlDrzave.Items.Add(new ListItem
                {
                    Value = row["IDDrzava"].ToString(),
                    Text = row["Naziv"].ToString()
                });
            }
        }

        private void ShowGradoviForDrzava(int drzavaID)
        {
            ds = new DataSet();
            SqlDataAdapter daGrad = AdapterGrad();
            daGrad.Fill(ds, "Grad");

            DataView dvGrad = ds.Tables["Grad"].DefaultView;
            dvGrad.Sort = "Naziv";

            lbGradovi.Items.Clear();

            foreach (DataRowView row in dvGrad)
            {
                if (int.Parse(row["DrzavaID"].ToString()) == drzavaID)
                    lbGradovi.Items.Add(new ListItem
                    {
                        Value = row["IDGrad"].ToString(),
                        Text = row["Naziv"].ToString()
                    });
            }
        }

        protected void ddlDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDrzave.SelectedIndex < 0)
                return;

            ShowGradoviForDrzava(int.Parse(ddlDrzave.SelectedValue));
        }

        protected void lbGradovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbGradovi.SelectedIndex == -1)
                return;

            txtGrad.Text = lbGradovi.SelectedItem.Text;
        }

        protected void btnUpdateGrad_Click(object sender, EventArgs e)
        {
            if (lbGradovi.SelectedIndex == -1)
                return;

            UpdateGrad(int.Parse(lbGradovi.SelectedValue));
        }

        private void UpdateGrad(int idGrad)
        {
            ds = new DataSet();
            AdapterGrad().Fill(ds, "Grad");

            foreach (DataRow row in ds.Tables["Grad"].Rows)
            {
                if ((int)row["IDGrad"] == idGrad)
                {
                    row["Naziv"] = txtGrad.Text;
                    break;
                }
            }

            AdapterGrad().Update(ds, "Grad");
            ShowGradoviForDrzava(int.Parse(ddlDrzave.SelectedValue));
        }

        protected void btnAddGrad_Click(object sender, EventArgs e)
        {
            if (txtGrad.Text == "")
                return;

            InsertGrad(txtGrad.Text);
        }

        private void InsertGrad(string text)
        {
            ds = new DataSet();
            SqlDataAdapter daGrad = AdapterGrad();
            daGrad.Fill(ds, "Grad");

            DataRow newRow = ds.Tables["Grad"].NewRow();
            newRow["Naziv"] = txtGrad.Text;
            newRow["DrzavaID"] = ddlDrzave.SelectedValue;
            ds.Tables["Grad"].Rows.Add(newRow);

            daGrad.Update(ds, "Grad");

            txtGrad.Text = "";
            ShowGradoviForDrzava(int.Parse(ddlDrzave.SelectedValue));
        }

        protected void btnDeleteGrad_Click(object sender, EventArgs e)
        {
            if (lbGradovi.SelectedIndex == -1)
                return;

            DeleteGrad(int.Parse(lbGradovi.SelectedValue));
        }

        private void DeleteGrad(int idGrad)
        {
            ds = new DataSet();
            AdapterGrad().Fill(ds, "Grad");

            foreach (DataRow row in ds.Tables["Grad"].Rows)
            {
                if ((int)row["IDGrad"] == idGrad)
                {
                    row.Delete();
                    break;
                }
            }

            txtGrad.Text = "";
            AdapterGrad().Update(ds, "Grad");
            ShowGradoviForDrzava(int.Parse(ddlDrzave.SelectedValue));
        }

        protected void btnSaveToXML_Click(object sender, EventArgs e)
        {
            try
            {
                CreateXML();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private void CreateXML()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Drzava; SELECT * FROM Grad", cs);
            ds = new DataSet("DrzaveGradovi");
            da.Fill(ds);

            ds.Tables[0].TableName = "Drzava";
            ds.Tables[0].TableName = "Grad";

            DataRelation rel = new DataRelation("DrzavaGrad", ds.Tables[0].Columns["IDDrzava"], ds.Tables[1].Columns["DrzavaID"]);
            rel.Nested = true;
            ds.Relations.Add(rel);

            ds.WriteXml("D:/DataSet.xml", XmlWriteMode.WriteSchema);
        }
    }
}