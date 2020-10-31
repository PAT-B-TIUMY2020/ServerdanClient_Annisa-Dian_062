using ServiceMtk_P1_20180140062;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Annisa_Dian_062
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                label3.Text = "Server Is ON";
                label2.Text = "Press Off button to turn off service";
                InitializeComponent();

                ServiceHost hostObj = null;
                Uri address = new Uri("http://localhost:1907/Matematika");
                BasicHttpBinding bind = new BasicHttpBinding();
                try
                {
                    hostObj = new ServiceHost(typeof(Matematika), address);
                    //ALAMAT BASE ADDRESS
                    hostObj.AddServiceEndpoint(typeof(IMatematika), bind, "");
                    //ALAMAT ENDPOINT
                    //wsdl
                    ServiceMetadataBehavior smb = new
                   ServiceMetadataBehavior(); //Service Runtime Player
                    smb.HttpGetEnabled = true; //untuk mengaktifkan wsdl

                    hostObj.Description.Behaviors.Add(smb);
                    //mex
                    System.ServiceModel.Channels.Binding mexbind =
                   MetadataExchangeBindings.CreateMexHttpBinding();
                    hostObj.AddServiceEndpoint(typeof(IMetadataExchange),
                   mexbind, "mex");
                    hostObj.Open();
                    Console.WriteLine("Server is ready!!!!");
                    Console.ReadLine();
                    hostObj.Close();
                }
                catch (Exception ex)
                {
                    hostObj = null;
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }
        }
    

