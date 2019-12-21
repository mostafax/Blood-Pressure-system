using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace BloodPressureForms
{
    public partial class wasfety : Form
    {
        public wasfety()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            List<string> preventors = new List<string>() {
            "salt","oil","tomato","mango","butter"
            };
            bool iseatble = true;
            string Ingredans;
            string base64Image;
            string path;
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                path = fdlg.FileName;

                Image myImg = Image.FromFile(path);
                using (MemoryStream m = new MemoryStream())
                {
                    myImg.Save(m, myImg.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    base64Image = Convert.ToBase64String(imageBytes);
                }
                var json = new JavaScriptSerializer().Serialize(new
                {
                    base64Image


                });
                // Sending the Request To Wasfety APi
                //textBox1.Text = json;
                string url = "http://127.0.0.1:50880/test/";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                //request.ContentLength = url.Length+json.Length;

                JObject Json = JObject.Parse(json);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {

                    streamWriter.Write(Json);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Ingredans = result;
                    dynamic dynamicObject = JsonConvert.DeserializeObject(result);
                    var type = dynamicObject.Ingredients;
                    var title = dynamicObject.Title;
                    Console.WriteLine(title);
                    List<string> stringat = new List<string>();
                    foreach (var myscore in type)
                    {
                        string Ingredainats = myscore.ToString();
                        Console.WriteLine(Ingredainats);

                        for (int i = 0; i < preventors.Count; i++)
                        {
                            if (preventors[i] == Ingredainats)
                            {
                                iseatble = false;

                                textBox1.Text += "Don't eat it Contatins " + Ingredainats + "\n";

                                break;

                            }
                        }

                    }
                    if (iseatble == true)
                    {
                        textBox1.Text = "Its Safe You can eat it";
                    }

                }
            }
        }
    }
}
 