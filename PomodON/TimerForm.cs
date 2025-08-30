using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomodON
{
    public partial class TimerForm : Form
    {
        private Timer timer;
        private int totalSeconds;

        public TimerForm()
        {
            InitializeComponent();
            InitializeTimer();  // 타이머 초기화
            ResetTimer();      // 초기 시간 설정
        }

        // 1️⃣ 타이머 초기화 메서드
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1초마다 Tick
            timer.Tick += Timer_Tick;
        }

        // 2️⃣ Tick 이벤트 메서드
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0)
            {
                totalSeconds--;
                UpdateUI(); // 라벨, 프로그레스바 갱신
            }
            else
            {
                timer.Stop();
                MessageBox.Show("시간 완료!");
            }
        }

        // 3️⃣ UI 갱신 메서드
        private void UpdateUI()
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            lblTime.Text = $"{minutes:D2}:{seconds:D2}";
        }

        // 4️⃣ 타이머 시작 버튼 이벤트
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        // 5️⃣ 타이머 일시정지 버튼 이벤트
        private void btnPause_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        // 6️⃣ 타이머 리셋 메서드
        private void ResetTimer()
        {
            totalSeconds = 25 * 60; // 예: 25분
            UpdateUI();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            ResetTimer();
        }
    }

}

