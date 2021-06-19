using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System.Diagnostics; // 匯入System.Diagnostics 命名空間

namespace Publish
{
    public partial class Form1 : Form
    {
        public static MqttClient client;//MqttClient


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client = new MqttClient(server_ip.Text);//MQTTServer在本機
            client.Connect("Publish", "Test1", "00000000", false, 0);//建立

            button2.Enabled = true;
        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            //MQTT接收的事件
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message); //ReceivedMessage接收到的東西
            string[] feedback = ReceivedMessage.Split(',');

            switch (feedback[0])
            {
                case "0":
                    feedback[0] = "Hexagon";
                    break;
                case "1":
                    feedback[0] = "Pentagon";
                    break;
                case "2":
                    feedback[0] = "Square";
                    break;
                case "3":
                    feedback[0] = "Triangle";
                    break;
                case "4":
                    feedback[0] = "Rectangle";
                    break;
                case "5":
                    feedback[0] = "Cirale";
                    break;
            }

            label4.Text = "Type: " + feedback[0];
            label6.Text = "Position: (" + Math.Round(Convert.ToDouble(feedback[1]), 2) + ", " + Math.Round(Convert.ToDouble(feedback[2]), 2) + ")";
            label5.Text = "Size: (" + Math.Round(Convert.ToDouble(feedback[3]), 2) + ", " + Math.Round(Convert.ToDouble(feedback[4]), 2) + ")";
            label7.Text = "Angle: " + Math.Round(Convert.ToDouble(feedback[5]) * 180 / Math.PI, 2) + " °";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int device = comboBox1.SelectedIndex;

            switch (device)
            {
                case 0:
                    client.Subscribe(new string[] { "Feedback" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });//訂閱主題
                    client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
                    break;
                case 1:
                    client.Subscribe(new string[] { "Nan" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });//訂閱主題
                    client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
                    break;
                case 2:
                    client.Subscribe(new string[] { "Nan" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });//訂閱主題
                    client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
                    break;
                case 3:
                    client.Subscribe(new string[] { "Nan" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });//訂閱主題
                    client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
                    break;
                case 4:
                    client.Subscribe(new string[] { "Nan" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });//訂閱主題
                    client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
                    break;
            }


            /*
            Mat img = Cv2.ImRead("D:/OneDrive - 國立成功大學/OneDrive - 逢甲大學/新增資料夾/138887927_1123543954726131_6424688964041855792_o.jpg");
            //pictureBox1.Image = img;
            Cv2.ImShow("1",img);
            Cv2.WaitKey(0);
            */
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] ok = Encoding.UTF8.GetBytes("OK");
            client.Publish("Command", ok);
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] start = Encoding.UTF8.GetBytes("Start");
            client.Publish("Start", start);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//關閉跨執行續偵錯
        }
    }
}
