using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
public partial class formcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQR().Wait();
            }}

       private async Task LoadQR()
        {
            using (HttpClient client = new HttpClient())
            {
                var res = await client.GetStringAsync("http://localhost:3000/qr");
                JObject obj = JObject.Parse(res);

                bool ready = (bool)obj["ready"];
                string qr = (string)obj["qr"];

                if (!ready)
                {
                    imgQR.ImageUrl = qr;
                    lblStatus.Text = "Scan QR Code";
                }
                else
                {
                    lblStatus.Text = "WhatsApp Ready ✅";
                }
            }
        }
    protected void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage().Wait();
        }

        private async Task SendMessage()
        {
            string number = txtNumber.Text;
            string message = txtMessage.Text;

            using (HttpClient client = new HttpClient())
            {
                var payload = new
                {
                    number = number,
                    message = message
                };

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync("http://localhost:3000/send", content);
                string result = await res.Content.ReadAsStringAsync();

                lblResult.Text = result;
            }
        }
}