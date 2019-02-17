using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigramAndHistogram.Desktop
{
    public partial class GraphForm : Form
    {
        public System.Windows.Forms.DataVisualization.Charting.Chart Chart
        {
            get { return BigramChart; }
            set { BigramChart = value; }
        }


        public GraphForm()
        {
            InitializeComponent();
        }
    }
}
