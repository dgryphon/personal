using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWallyWorld
{
    public partial class _Default : System.Web.UI.Page
    {

        static string txtresult = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            txtresult += FileUpload1.FileName.ToString()+ "<br>";
            //txtresult += "a";
            lblResult.Text = txtresult;
        }
    }
}
