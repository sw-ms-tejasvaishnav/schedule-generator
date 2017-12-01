using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOCA.RecurrenceGenerator;

namespace RecurrenceTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DailyRecurrenceSettings daily = new DailyRecurrenceSettings(DateTime.Today);
            daily.RecurrenceInterval = 8;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            YearlyRecurrenceSettings yr = new YearlyRecurrenceSettings(DateTime.Today, this.trackBarControl1.Value);
            RecurrenceValues values = yr.GetValues(dateEdit1.DateTime.Day, dateEdit1.DateTime.Month);
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt);
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();
        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            textEdit2.Text = trackBarControl1.Value.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            YearlyRecurrenceSettings yr = new YearlyRecurrenceSettings(DateTime.Today, dtEndDate.DateTime);
            RecurrenceValues values = yr.GetValues(dateEdit1.DateTime.Day, dateEdit1.DateTime.Month);
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt);
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            YearlyRecurrenceSettings yr = new YearlyRecurrenceSettings(dateEdit1.DateTime,  dtEndDate.DateTime);
            RecurrenceValues values = yr.GetValues(YearlySpecificDatePartOne.Last, YearlySpecificDatePartTwo.Wednesday, YearlySpecificDatePartThree.August);
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt.ToString("d MMM, yyyy   ddd"));
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, this.trackBarControl1.Value);
            RecurrenceValues values = mo.GetValues(Convert.ToInt32(txtDayofMonth.Text), Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt);
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, dtEndDate.DateTime);
            RecurrenceValues values = mo.GetValues(Convert.ToInt32(txtDayofMonth.Text), Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt);
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo;
            if (comboBoxEdit1.SelectedIndex == 0)
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, dtEndDate.DateTime);
            else
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, trackBarControl1.Value);

            
            RecurrenceValues values = mo.GetValues(MonthlySpecificDatePartOne.First, MonthlySpecificDatePartTwo.Day, Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt.ToString("d MMM, yyyy   ddd"));
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo;
            if (comboBoxEdit1.SelectedIndex == 0)
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, dtEndDate.DateTime);
            else
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, trackBarControl1.Value);

            RecurrenceValues values = mo.GetValues(MonthlySpecificDatePartOne.Last, MonthlySpecificDatePartTwo.Day, Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt.ToString("d MMM, yyyy   ddd"));
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo;
            if (comboBoxEdit1.SelectedIndex == 0)
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, dtEndDate.DateTime);
            else
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, trackBarControl1.Value);

            RecurrenceValues values = mo.GetValues(MonthlySpecificDatePartOne.First, MonthlySpecificDatePartTwo.Weekday, Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt.ToString("d MMM, yyyy   ddd"));
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo;
            if (comboBoxEdit1.SelectedIndex == 0)
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, dtEndDate.DateTime);
            else
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, trackBarControl1.Value);

            RecurrenceValues values = mo.GetValues(MonthlySpecificDatePartOne.First, MonthlySpecificDatePartTwo.WeekendDay, Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt.ToString("d MMM, yyyy   ddd"));
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo;
            if (comboBoxEdit1.SelectedIndex == 0)
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, dtEndDate.DateTime);
            else
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, trackBarControl1.Value);

            RecurrenceValues values = mo.GetValues(MonthlySpecificDatePartOne.Second, MonthlySpecificDatePartTwo.Day, Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt.ToString("d MMM, yyyy   ddd"));
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo;
            if (comboBoxEdit1.SelectedIndex == 0)
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, dtEndDate.DateTime);
            else
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, trackBarControl1.Value);

            RecurrenceValues values = mo.GetValues(MonthlySpecificDatePartOne.Fourth, MonthlySpecificDatePartTwo.Tuesday, Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt.ToString("d MMM, yyyy   ddd"));
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo;
            if (comboBoxEdit1.SelectedIndex == 0)
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, dtEndDate.DateTime);
            else
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, trackBarControl1.Value);

            RecurrenceValues values = mo.GetValues(MonthlySpecificDatePartOne.Second, MonthlySpecificDatePartTwo.Saturday, Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt.ToString("d MMM, yyyy   ddd"));
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo;
            if (comboBoxEdit1.SelectedIndex == 0)
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, dtEndDate.DateTime);
            else
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, trackBarControl1.Value);

            RecurrenceValues values = mo.GetValues(MonthlySpecificDatePartOne.Third, MonthlySpecificDatePartTwo.Weekday, Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt.ToString("d MMM, yyyy   ddd"));
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }

        private void simpleButton11_Click_1(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            MonthlyRecurrenceSettings mo;
            if (comboBoxEdit1.SelectedIndex == 0)
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, dtEndDate.DateTime);
            else
                mo = new MonthlyRecurrenceSettings(dateEdit1.DateTime, trackBarControl1.Value);

            RecurrenceValues values = mo.GetValues(MonthlySpecificDatePartOne.Fourth, MonthlySpecificDatePartTwo.Tuesday, Convert.ToInt32(txtEveryXMonths.Text));
            foreach (DateTime dt in values.Values)
            {
                listBoxControl1.Items.Add(dt.ToString("d MMM, yyyy   ddd"));
            }
            textEdit1.Text = values.Values.Count.ToString();
            txtStart.Text = values.StartDate.ToString();
            txtEnd.Text = values.EndDate.ToString();

        }
    }
}