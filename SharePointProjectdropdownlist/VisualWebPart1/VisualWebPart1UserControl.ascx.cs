using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SharePointProjectdropdownlist.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        SPWeb  site = SPContext.Current.Web;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var listcol = site.Lists;
                List<string> str = new List<string>();
                foreach (SPList item in listcol)
                {
                    string s = "" + item.Title;
                    str.Add(s);
                }
                DropDownList1.DataSource = str;
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var listcol = site.Lists[DropDownList1.SelectedValue];
            SPListItemCollection col = listcol.Items;
            GridView1.DataSource = col.GetDataTable();
            GridView1.DataBind();
        }
    }
}
