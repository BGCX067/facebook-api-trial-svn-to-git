using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook.Session;
using Facebook.Schema;

namespace FacebookFriend
{
    public partial class Form1 : Form
    {
        DesktopSession ds = new DesktopSession("429267130467465", true);
        IList<user> friends;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.LoginCompleted += new EventHandler<AsyncCompletedEventArgs>(ds_LoginCompleted);
            ds.LogoutCompleted += new EventHandler<AsyncCompletedEventArgs>(ds_LogoutCompleted);
            button2.Enabled = false;
            ds.Login();
        }
        void ds_LogoutCompleted(object sender, AsyncCompletedEventArgs e)
        {
            button2.Enabled = false;
        }

        void ds_LoginCompleted(object sender, AsyncCompletedEventArgs e)
        {

            button2.Enabled = true;
            label1.Text = ds.UserId.ToString();
            facebookService1.ApplicationKey = ds.ApplicationKey;
            facebookService1.SessionKey = ds.SessionKey;
            facebookService1.uid = ds.UserId;
            facebookService1.ConnectToFacebook();
            facebookService1.Users.Session.SessionSecret = ds.SessionSecret;
            friends = facebookService1.Friends.GetUserObjects();
            int sira = 0;
            listView1.LargeImageList = ımageList1;

            foreach (user fr in friends)
            {
                ımageList1.Images.Add(sira.ToString(), fr.picture);
                listView1.Items.Add(new ListViewItem(fr.name, sira.ToString()));
                sira = sira + 1;
            }
            //outlookkontaktdoldur();
        }
    }
}
