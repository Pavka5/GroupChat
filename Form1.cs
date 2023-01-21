using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GroupChat
{
    
    public partial class Form1 : Form
    {
        List<User> users  = new List<User>();
        Action<string, string> sending;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateUser();
        }

        public void CreateUser()
        {
            User user = new User();
            user.name = textBox1.Text;
            user.CreateUser();

            flowLayoutPanel1.Controls.Add(user);

            users.Add(user);
            user.Handle(this);

            user.onUserDeleted += User_OnUserDeleted;

            sending += user.ReceiveMessage;
        }
        public void User_OnUserDeleted(User user)
        {
            flowLayoutPanel1.Controls.Remove(user);
        }
        public void User_OnMessageSent(string name, string msg)
        {
            sending.Invoke(name, msg);
        }

    }
}