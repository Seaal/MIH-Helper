using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Matt_Mih_Helper
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string[] Ranks = { "Unranked", "Bronze V", "Bronze IV", "Bronze III", "Bronze II", "Bronze I" };

            cbElo1.DataSource = Ranks;

            string json = MakeRequest();

            ChampionJson champList = JsonConvert.DeserializeObject<ChampionJson>(json);

            cbChampions1.DataSource = new BindingSource(champList.data, null);
            cbChampions1.DisplayMember = "Value";
            cbChampions1.ValueMember = "Key";

        }

        private static string MakeRequest()
        {
            String urlRequest = "https://na.api.pvp.net/api/lol/static-data/na/v1.2/champion?api_key=63965c03-965b-4cfb-bb3e-e8b0a0601bd1";
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urlRequest);
            Stream response = null;

            // Sends the HttpWebRequest and waits for the response.
            HttpWebResponse myHttpWebResponse = myReq.GetResponse() as HttpWebResponse;
            try
            {
                response = myHttpWebResponse.GetResponseStream();
                StreamReader readStream = new StreamReader(response, System.Text.Encoding.GetEncoding("utf-8"));
                return readStream.ReadToEnd();
            }
            finally
            {
                // Releases the resources of the response.
                response.Dispose();
                myHttpWebResponse.Close();
            }
        }
    }
}
