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
            // button1의 Click 이벤트 핸들러 등록
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // TextBox에 입력된 내용 가져오기
            string typed_msg = textBox1.Text;
            
            // ListBox에 항목 추가
            listBox1.Items.Add(typed_msg);
            
            // TextBox 비우기 (선택사항이지만 좋은 UX)
            textBox1.Text = "";
            
            // 커서를 TextBox로 돌리기 (선택사항)
            textBox1.Focus();
        }
    }
}
