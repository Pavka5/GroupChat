using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupChat
{
    public partial class User : UserControl
    {
        public string name;

        public Action<User> onUserDeleted;

        public Action<string, string> onMessageSent;

        public List<User> users = new List<User>();

        public string appendedText;

        public User()
        {
            InitializeComponent();
        }

        public void CreateUser()
        {
            label1.Text = name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onUserDeleted?.Invoke(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onMessageSent?.Invoke(name, textBox1.Text);
        }

        public void Handle(Form1 form)
        {
            onMessageSent += form.User_OnMessageSent;
        }

        public void ReceiveMessage(string name, string msg)
        {
            label2.Text += name + ": " + msg + "\n";
        }
    }
}
