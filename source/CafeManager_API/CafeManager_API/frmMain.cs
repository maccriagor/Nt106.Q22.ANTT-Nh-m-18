using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CafeManager_API
{
    public partial class frmMain : Form
    {
        public string UserFullName { get; set; }
        public string UserRole { get; set; }
        public frmMain(string name,string role)
        {
            InitializeComponent();
            UserFullName = name;
            UserRole = role;
        }
    }
}
