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
            TextMessage.KeyDown += TextBox1_KeyDown; // TextBox의 KeyDown 이벤트 핸들러 등록
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            string typed_msg = TextMessage.Text; // TextBox에 입력된 내용 가져오기

           
            if (string.IsNullOrWhiteSpace(typed_msg))  // 빈 문자열이거나 공백만 있으면 전송하지 않음
            {
                return;
            }

            typed_msg = typed_msg.Trim(); // 문자열 정제: Trim()으로 앞뒤 공백 제거

            
            string timestamp = DateTime.Now.ToString("[HH:mm:ss]");
            string message_with_timestamp = timestamp + " " + typed_msg; // 타임스탬프 추가: 현재 시간을 [HH:mm:ss] 형식으로 추가

            EchoMessageList.Items.Add(message_with_timestamp); // ListBox에 항목 추가

            
            label2.Text = "현재대화: " + EchoMessageList.Items.Count + "개"; // 메시지 카운팅: ListBox의 총 아이템 개수로 label2 업데이트

            TextMessage.Clear();  // TextBox 비우기 (Clear() 메서드 사용함.
            TextMessage.Focus(); // 커서를 TextBox로 돌리기
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Return) // Enter 키로도 전송 가능하게 구현
            {
                Button1_Click(null, null); // Button1_Click 메서드 호출
                e.Handled = true; // Enter 키의 기본 동작(새로운 줄) 방지
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EchoMessageList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
