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
    public partial class Settings : Form
    {
        public BigramSettings bigramSetting;

        public Settings(BigramSettings settings)
        {
            InitializeComponent();
            bigramSetting = settings;
            bindUi();
        }

        private void cbPunctuation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPunctuation.Checked == true)
                bigramSetting.FilterPunctuation = true;
            else
                bigramSetting.FilterPunctuation = false;

        }

        private void cbNumbers_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNumbers.Checked == true)
                bigramSetting.FilterNumbers = true;
            else
                bigramSetting.FilterNumbers = false;
        }

        private void cbShowChart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowChart.Checked == true)
                bigramSetting.ShowBigramGraph = true;
            else
                bigramSetting.ShowBigramGraph = false;
        }

        private void cbOrderList_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOrderList.Checked == true)
                bigramSetting.OrderList = true;
            else
                bigramSetting.OrderList = false;
        }

        private void bindUi()
        {
            cbNumbers.Checked = bigramSetting.FilterNumbers;
            cbPunctuation.Checked = bigramSetting.FilterPunctuation;
            cbShowChart.Checked = bigramSetting.ShowBigramGraph;
            cbOrderList.Checked = bigramSetting.OrderList;

        }

        private void cbLetterFrequency_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLetterFrequency.Checked == true)
                bigramSetting.ShowLetterFrequency = true;
            else
                bigramSetting.ShowLetterFrequency = false;
        }
    }
}
