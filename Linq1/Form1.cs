using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Linq1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] score = new int[] { 23, 45, 100, 87, 90, 65, 44 };
        private void Form1_Load(object sender, EventArgs e)
        {
            string s = "";
            for(int i =0; i<score.Length;i++)
            {
                s += score[i] + Environment.NewLine;
            }
            txtShow.Text = s;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int search;
            try
            {
                search = int.Parse(txtSearch.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            string s = "";
            var result = from r in score
                         where r == search
                         select r;

            if(result.Count()==0)
            {
                s = "查無資料";
            }
            else
            {
                s = "陣列內含";
                foreach(var r in result)
                {
                    s += r;
                }
            }
            txtShow.Text = s;
        }

        private void btnScoreList_Click(object sender, EventArgs e)
        {
            txtShow.Clear();
            Form1_Load(sender, e);//重複Form1_Load事件
        }

        private void btnSortAsc_Click(object sender, EventArgs e)
        {
            string s = "";
            var result = from r in score
                         orderby r
                         select r;
            foreach(var r in result)
            {
                s += r + Environment.NewLine;
                //Environment.NewLine
                //提供有關目前環境和平台的資訊，以及操作的方法。 這個類別無法被繼承。
            }
            txtShow.Text = "遞增排序：" + Environment.NewLine + s;
        }

        private void btnSorDesc_Click(object sender, EventArgs e)
        {
            string s = "";
            var result = from r in score
                         orderby r descending
                         select r;
            foreach(var r in result)
            {
                s += r + Environment.NewLine;
            }
            txtShow.Text = "遞減排序：" + Environment.NewLine + s;
        }


        private void btnScoreInfo_Click(object sender, EventArgs e)
        {
            txtShow.Text = "資料筆數：" + score.Count() + Environment.NewLine +
                "最高分數" + score.Max() + Environment.NewLine +
                "最低分數" + score.Min() + Environment.NewLine +
                "平均分數" + (int)score.Average() + Environment.NewLine +
                "分數總和" + score.Sum() + Environment.NewLine;
        }
    }
}
