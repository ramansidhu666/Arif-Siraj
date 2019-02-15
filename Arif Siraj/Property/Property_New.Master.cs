using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Property_cls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace Property
{
    public partial class Property_New : System.Web.UI.MasterPage
    {
        #region Global

        cls_Property clsobj = new cls_Property();

        #endregion Global
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SiteSetting();
                BindMenusList();
                string PgNam = "";
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString.ToString());
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd;
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = conn;
                int pageid = 0;
                if (Session["pageid"] == null)
                    pageid = 17;
                else
                    pageid = Convert.ToInt32(Session["pageid"].ToString());
                cmd.CommandText = "select * from tbl_PageBlogs where id=" + pageid;
                System.Data.SqlClient.SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    HtmlMeta meta = new HtmlMeta();
                    meta.Name = "Meta Tag";
                    meta.Content = dr["MetaTag"].ToString();
                    Page.Header.Controls.Add(meta);
                    HtmlMeta meta1 = new HtmlMeta();
                    meta1.Name = "MetaDiscription";
                    meta1.Content = dr["MetaDiscription"].ToString();
                    Page.Header.Controls.Add(meta1);
                    Page.Title = dr["pagetitle"].ToString();
                }
                string BuyerPageId = ConfigurationManager.AppSettings["BuyerPageId"].ToString();
                //buyer.HRef = "StaticPages.aspx?PageID=" + BuyerPageId;
            }  
        }
        private void BindMenusList()
        {
            StringBuilder StrMenu = new StringBuilder();
            DataTable dt = new DataTable();
            DataTable dtSubmenu = new DataTable();
            dt = clsobj.GetMenuList();



            if (dt.Rows.Count > 0)
            {
                string PageName = dt.Rows[0]["PageName"].ToString();
                StrMenu.Append("<a class='toggleMenu' href='#'></a>");
                StrMenu.Append("<ul class='nav'>");
                StrMenu.Append("<li class='test' style='background:none;'><a href='../Default.aspx' title='Home' >Home</a></li>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsobj.PageID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    dtSubmenu = clsobj.GetSubMenuBy_PageID();
                    if (dtSubmenu.Rows.Count > 0)
                    {
                        StrMenu.Append("<li><a href=#>" + dt.Rows[i]["PageName"] + "</a>");//</li>
                        StrMenu.Append("<ul>");
                        for (int j = 0; j < dtSubmenu.Rows.Count; j++)
                        {
                            StrMenu.Append("<li><a href='../StaticPages.aspx?PageID=" + dtSubmenu.Rows[j]["id"] + "' title='" + dtSubmenu.Rows[j]["PageName"] + "'>" + dtSubmenu.Rows[j]["PageName"] + "</a> </li>");
                        }
                        StrMenu.Append("</ul>");
                        StrMenu.Append("</li>");
                    }
                    else
                    {
                        StrMenu.Append("<li><a href='../StaticPages.aspx?PageID=" + dt.Rows[i]["id"] + "' title='" + dt.Rows[i]["PageName"] + "'>" + dt.Rows[i]["PageName"] + "</a>");//</li>
                    }
                }
                StrMenu.Append("<li>");
                StrMenu.Append("<a href='../Calculators.aspx' title='Calculators'>Calculators</a>");
                StrMenu.Append("</li>");
                StrMenu.Append("<li>");
                StrMenu.Append("<a href='../RealEstateNews.aspx' title='Real Estate News'>Real Estate News</a>");
                StrMenu.Append("</li>");
                StrMenu.Append("<li class='test' style='background:none;'><a href='Free-home-evaluation.aspx' title='Home Evaluation'>Home Evaluation</a></li>");
                StrMenu.Append("<li class='test' style='background:none;'><a href='ContactUs.aspx' title='Contact Us'>Contact Us</a></li>");
                StrMenu.Append("</ul>");


            }


            dynamicmenus.Text = StrMenu.ToString();

        }
        protected void SiteSetting()
        {
            try
            {
                DataTable dt = clsobj.GetSiteSettings();
               
                if (dt.Rows.Count > 0)
                {
                    //string var = Convert.ToString(dt.Rows[0]["BannerImage"]);
                    //imginfo.ImageUrl = var;
                    siteTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                   // lblname.Text = Convert.ToString(dt1.Rows[0]["FirstName"]) + " " + Convert.ToString(dt1.Rows[0]["LastName"]);
                    lblPhone.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                    //lblphone.Text = Convert.ToString(dt.Rows[0]["PhoneNumber"]);
                    //lblphone1.Text = Convert.ToString(dt.Rows[0]["PhoneNumber"]);
                    //lblmobile.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                    //lblemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                    //lblfax.Text = Convert.ToString(dt.Rows[0]["Fax"]);
                    byte[] favimage = (byte[])dt.Rows[0]["Favicon.ico"];
                    if (favimage.Length > 0)
                    {
                        Session["MyFavicon"] = favimage;
                        favicon.Visible = true;
                        favicon.Href = "~/ShowFavicon.aspx";
                    }
                    else
                    {
                        favicon.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //protected void bindBnanners()
        //{
        //    StringBuilder html = new StringBuilder();
        //    DataTable dt = clsobj.GetAllBanner();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        string Images;
        //        Images = "/admin/uploadfiles/" + dt.Rows[i]["FileName"].ToString();
        //        if (Images != "")
        //        {
        //            html.AppendLine("<img src='" + Images + "'  data-thumb='" + Images + "'  alt='banner" + i + "' />");
        //        }
        //    }
        //    ltrImgs.Text = html.ToString();
        //}
    }
}