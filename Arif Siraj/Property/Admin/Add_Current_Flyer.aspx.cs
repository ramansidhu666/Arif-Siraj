﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Property_cls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Property.Admin
{
    public partial class Add_Current_Flyer : System.Web.UI.Page
    {
        #region Global
         SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString.ToString());

        cls_Property clsobj = new cls_Property();
        #endregion Global

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] != null)
            {
                if (!IsPostBack)
                {
                    FillGridData();
                }
            }
            else
            {
               Response.Redirect("~/Admin/AdminLogin.aspx", false);
            }
        }

        #endregion Page Load

        #region PageListGrid Events & Method

        protected void FillGridData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = clsobj.GetCurrentFlyer();
                grdcurrentflyer.DataSource = dt;
                grdcurrentflyer.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        protected void GrdBlogList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = 0;
            if (e.CommandName == "Deleterec")
            {
                id = Convert.ToInt32(e.CommandArgument);
                int result = clsobj.Deletecurrentflyer(id);
                FillGridData();
            }
            else if (e.CommandName == "Editrec")
            {
                id = Convert.ToInt32(e.CommandArgument);
                DataTable dt = new DataTable();
                dt = clsobj.GetCurrentFlyerID(id);
                //txtName.Text = dt.Rows[0]["Name"].ToString();
                hdnImg.Value = dt.Rows[0]["FileName"].ToString();
                imgbanner.ImageUrl = "/admin/uploadfiles/" + dt.Rows[0]["FileName"].ToString();
                //itemOrder.Value = dt.Rows[0]["ItemOrder"].ToString();
                imgbanner.Visible = true;
                FillGridData();
            }
            else
            {
                FillGridData();
            }
        }





        #endregion PageListGrid Events & Method

        #region Button Click

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (updBannerImage.HasFile)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [tblCurrentFlyer]";
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmd.CommandText = "delete from  [tblCurrentFlyer] where id='" + dt.Rows[0]["id"].ToString() + "'";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    System.Drawing.Image img = System.Drawing.Image.FromStream(updBannerImage.PostedFile.InputStream);
                    int height = img.Height;
                    int width = img.Width;
                    decimal size = Math.Round(((decimal)updBannerImage.PostedFile.ContentLength / (decimal)1024), 2);
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Size: " + size + "KB\\nHeight: " + height + "\\nWidth: " + width + "');", true);

                    //decimal size = Math.Round(((decimal)updBannerImage.PostedFile.ContentLength / (decimal)1024), 2);
                    //if (size == 732.27m && (height != 394 || width != 1170))
                    //{
                    string fname = System.IO.Path.GetFileName(updBannerImage.FileName);
                    string extention = System.IO.Path.GetExtension(updBannerImage.FileName);
                    if (extention == ".jpeg" || extention == ".jpg")
                    {
                        updBannerImage.SaveAs(Server.MapPath("UploadFiles") + "\\" + System.IO.Path.GetFileName(updBannerImage.FileName));
                        clsobj.InsertcurrentFlyer( fname);
                        FillGridData();
                        //txtName.Text = "";
                        imgbanner.Visible = false;
                        lblbannersize.Visible = false;
                    }
                    else
                    {
                        lblbannersize.Text = "Only .jpeg and .jpg files are allowed!";
                    }

                }
                else
                {
                    System.Drawing.Image img = System.Drawing.Image.FromStream(updBannerImage.PostedFile.InputStream);
                    int height = img.Height;
                    int width = img.Width;
                    decimal size = Math.Round(((decimal)updBannerImage.PostedFile.ContentLength / (decimal)1024), 2);
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Size: " + size + "KB\\nHeight: " + height + "\\nWidth: " + width + "');", true);

                    //decimal size = Math.Round(((decimal)updBannerImage.PostedFile.ContentLength / (decimal)1024), 2);
                    //if (size == 732.27m && (height != 394 || width != 1170))
                    //{
                    string fname = System.IO.Path.GetFileName(updBannerImage.FileName);
                    string extention = System.IO.Path.GetExtension(updBannerImage.FileName);
                    if (extention == ".jpeg" || extention == ".jpg")
                    {
                        updBannerImage.SaveAs(Server.MapPath("UploadFiles") + "\\" + System.IO.Path.GetFileName(updBannerImage.FileName));
                        clsobj.InsertcurrentFlyer( fname);
                        FillGridData();
                       
                        //itemOrder.Value = "1";
                        imgbanner.Visible = false;
                        lblbannersize.Visible = false;
                    }
                    else
                    {
                        lblbannersize.Text = "Only .jpeg and .jpg files are allowed!";
                    }
                }
            }
        }

        #endregion Button Click

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //txtName.Text = "";
            //itemOrder.Value = "1";
            imgbanner.Visible = false;
        }
    }
}