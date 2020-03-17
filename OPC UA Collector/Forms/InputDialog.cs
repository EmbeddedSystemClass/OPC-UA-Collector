using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerCollector.Forms
{
    public partial class InputDialog : Form
    {
        public InputDialog(string Text)
        {
            m_Text = Text;
            InitializeComponent();
        }
        public string getInputText()
        {
            return textBox1.Text;
        }
        #region private fields
        string m_Text;
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
