using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoMessenger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            button1.Click += Button1_Click; // button1의 Click 이벤트 핸들러 등록
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            string typed_msg = textBox1.Text; // TextBox에 입력된 내용 가져오기

            listBox1.Items.Add(typed_msg); // ListBox에 항목 추가

            textBox1.Text = "";// TextBox 비우기 (선택사항이지만 좋은 UX)
           
            textBox1.Focus(); // 커서를 TextBox로 돌리기 (선택사항)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
