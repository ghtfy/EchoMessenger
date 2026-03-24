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
        private const int MaxMessageLength = 50;

        public Form1()
        {
            InitializeComponent();
            
            button1.Click += Button1_Click; // button1의 Click 이벤트 핸들러 등록
            TextMessage.KeyDown += TextBox1_KeyDown; // Enter 키 전송 처리를 위한 KeyDown 이벤트 핸들러 등록
            TextMessage.KeyPress += TextMessage_KeyPress; // 글자수 제한 초과 입력 방지
            btnDelete.Click += BtnDelete_Click; // 삭제 버튼 클릭 이벤트
            btnClearAll.Click += BtnClearAll_Click; // 대화기록삭제 버튼 클릭 이벤트
            
            TextMessage.MaxLength = MaxMessageLength;
            // 글자수 제한: MaxLength를 50으로 설정
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string typed_msg = TextMessage.Text; // TextBox에 입력된 내용 가져오기

            // 과제2 입력 방어: 빈 문자열 또는 공백만 입력된 경우 전송 차단
            if (string.IsNullOrWhiteSpace(typed_msg))
            {
                return;
            }

            typed_msg = typed_msg.Trim(); // 문자열 정제: Trim()으로 앞뒤 공백 제거

            if (typed_msg.Length > MaxMessageLength)
            {
                MessageBox.Show("메시지는 최대 50자까지 전송할 수 있습니다.", "입력 제한", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string timestamp = DateTime.Now.ToString("[HH:mm:ss]");
            string message_with_timestamp = timestamp + " " + typed_msg; // 타임스탬프 추가: 현재 시간을 [HH:mm:ss] 형식으로 추가

            EchoMessageList.Items.Add(message_with_timestamp); // ListBox에 항목 추가

            label2.Text = "현재대화: " + EchoMessageList.Items.Count + "개"; // 메시지 카운팅: ListBox의 총 아이템 개수로 label2 업데이트

            // 과제2 UX: 전송 후 입력창 초기화 및 포커스 복귀로 연속 입력 편의성 개선
            TextMessage.Clear();
            TextMessage.Focus();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V && Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                int futureLength = TextMessage.TextLength - TextMessage.SelectionLength + clipboardText.Length;

                if (futureLength > MaxMessageLength)
                {
                    e.SuppressKeyPress = true;
                    MessageBox.Show("메시지는 최대 50자까지 입력할 수 있습니다.", "입력 제한", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            // 과제2 UX: Enter 키 입력 시 버튼 클릭 없이 메시지 전송
            if (e.KeyCode == Keys.Return)
            {
                Button1_Click(null, null); // Button1_Click 메서드 호출
                e.Handled = true; // Enter 키의 기본 동작(새로운 줄) 방지
            }
        }

        private void TextMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && TextMessage.TextLength >= MaxMessageLength && TextMessage.SelectionLength == 0)
            {
                e.Handled = true;
                MessageBox.Show("메시지는 최대 50자까지 입력할 수 있습니다.", "입력 제한", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
//GitHub Copilot을 활용한 과제4번 데이터 관리 및 심화기능 코드 

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // 선택된 항목이 있는지 확인
            if (EchoMessageList.SelectedIndex == -1)
            {
                MessageBox.Show("삭제할 메시지를 선택하세요!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 선택된 항목의 인덱스로 삭제
                EchoMessageList.Items.RemoveAt(EchoMessageList.SelectedIndex);

                // 메시지 개수 업데이트
                label2.Text = "현재대화: " + EchoMessageList.Items.Count + "개";
            }
            catch (Exception ex)
            {
                MessageBox.Show("삭제 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            // 확인 대화상자 표시
            DialogResult result = MessageBox.Show("모든 대화기록을 삭제하시겠습니까?", "대화기록 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // ListBox의 모든 항목 삭제
                EchoMessageList.Items.Clear();

                // 메시지 개수 업데이트
                label2.Text = "현재대화: 0개";

                MessageBox.Show("모든 대화기록이 삭제되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
