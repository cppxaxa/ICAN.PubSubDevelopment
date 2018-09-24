using ICAN.SIC.Abstractions;
using ICAN.SIC.Abstractions.IMessageVariants;
using ICAN.SIC.PubSub;
using PubSub_Experiment.Extras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PubSub_Experiment
{
    public partial class PubSub : Form
    {
        IHub hub = new Hub("Root");
        IHub child = new Hub("Child1");

        public PubSub()
        {
            InitializeComponent();

            hub.PassThrough(child);

            hub.Subscribe<IUserResponse>(this.Print);
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            hub.PublishDownwards<IUserResponse>(new UserResponse("Hello"));
        }

        private void Print(IUserResponse message)
        {
            Console.WriteLine("Message: " + message.Text);
        }
    }
}
