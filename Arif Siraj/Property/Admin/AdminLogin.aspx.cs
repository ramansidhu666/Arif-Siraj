using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Property_cls;

namespace Property.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {

        cls_Property clsobj = new cls_Property();
        protected void Page_Load(object sender, EventArgs e)
        {
          // this.Page.Title = "Arif Siraj Properties";
           SiteSetting();
            Session["IsLogin"] = null;
        }
        protected void SiteSetting()
        {
            try
            {
                DataTable dt = clsobj.GetSiteSettings();
           
                if (dt.Rows.Count > 0)
                {
                    siteTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                
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
    }
}