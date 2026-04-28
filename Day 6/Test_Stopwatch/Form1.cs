using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_StopWatch {
    public partial class Form1 : Form {
        // Variables to store time
        private int hours = 0;
        private int minutes = 0;
        private int seconds = 0;

        public Form1() {
            InitializeComponent();
            // Make sure timer is not running at start
            stopWatchTimer.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            // This can be empty - it's just here for the designer
        }

        private void label2_Click(object sender, EventArgs e) {
            // This can be empty - it's just here for the designer
        }

        private void label1_Click(object sender, EventArgs e) {
            // This can be empty - it's just here for the designer
        }

        private void buttonStart_Click(object sender, EventArgs e) {
            // Start the timer
            stopWatchTimer.Start();

            // Disable Start button (can't start an already running timer)
            buttonStart.Enabled = false;

            // Enable Stop button
            buttonStop.Enabled = true;

            // Disable Reset button while running? (optional - you can remove this line if you want)
            // buttonReset.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e) {
            // Stop the timer
            stopWatchTimer.Stop();

            // Enable Start button again
            buttonStart.Enabled = true;

            // Disable Stop button
            buttonStop.Enabled = false;

            // Re-enable Reset button if you disabled it
            // buttonReset.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            // Get the current time from label1
            string currentTime = label1.Text;

            // Add timestamp to make each entry unique
            string savedEntry = $"{DateTime.Now:HH:mm:ss} - Stopwatch: {currentTime}";

            // Add to the ListBox
            listBox1.Items.Add(savedEntry);

            // Scroll to the newest entry automatically
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        private void stopWatchTimer_Tick(object sender, EventArgs e) {
            // Increment seconds each time timer ticks (every 1000ms = 1 second)
            seconds++;

            // If seconds reach 60, reset to 0 and increment minutes
            if (seconds == 60) {
                seconds = 0;
                minutes++;
            }

            // If minutes reach 60, reset to 0 and increment hours
            if (minutes == 60) {
                minutes = 0;
                hours++;
            }

            // Update the label to show current time
            // "D2" means display as 2 digits with leading zero (01, 02, 03...)
            label1.Text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        private void buttonReset_Click(object sender, EventArgs e) {
            // Stop the timer if it's running
            stopWatchTimer.Stop();

            // Reset all time variables to zero
            hours = 0;
            minutes = 0;
            seconds = 0;

            // Update the display
            label1.Text = "00:00:00";

            // Reset button states
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            // Clear all saved times from the list box
            listBox1.Items.Clear();
        }
    }
}