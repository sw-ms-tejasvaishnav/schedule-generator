using System;
using System.Windows.Forms;
using RecurrenceGenerator;

namespace RecurrenceTester
{
    public partial class DateTester : Form
    {
        public DateTester()
        {
            InitializeComponent();
        }

        private void DateTester_Load(object sender, EventArgs e)
        {
            dtStartDate.Value = DateTime.Today;
            dtEndDate.Value = DateTime.Today.AddYears(10);

            // Monthly
            textBox4.Text = DateTime.Today.Day.ToString();
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            // Yearly
            cboYearEveryMonth.SelectedIndex = DateTime.Today.Month - 1;
            txtYearEvery.Text = DateTime.Today.Day.ToString();
            comboBox5.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox6.SelectedIndex = DateTime.Today.Month - 1;

            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    chkSunday.Checked = true;
                    break;
                case DayOfWeek.Monday:
                    chkMonday.Checked = true;
                    break;
                case DayOfWeek.Tuesday:
                    chkTuesday.Checked = true;
                    break;
                case DayOfWeek.Wednesday:
                    chkWednesday.Checked = true;
                    break;
                case DayOfWeek.Thursday:
                    chkThursday.Checked = true;
                    break;
                case DayOfWeek.Friday:
                    chkFriday.Checked = true;
                    break;
                case DayOfWeek.Saturday:
                    chkSaturday.Checked = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecurrenceValues values= null;

            switch (tabControl1.SelectedIndex)
            {
                case 0: // Daily
                    DailyRecurrenceSettings da;
                    if (radioOccurrences.Checked)
                        da = new DailyRecurrenceSettings(dtStartDate.Value, Convert.ToInt32(txtOccurrences.Text));
                    else
                        da = new DailyRecurrenceSettings(dtStartDate.Value, dtEndDate.Value);

                    if (radioButton1.Checked)
                        values = da.GetValues(int.Parse(textBox1.Text));
                    else
                        values = da.GetValues(1, DailyRegenType.OnEveryWeekday);
                    break;

                case 1: // Weekly
                    WeeklyRecurrenceSettings we;
                    SelectedDayOfWeekValues selectedValues = new SelectedDayOfWeekValues();

                    if (radioOccurrences.Checked)
                        we = new WeeklyRecurrenceSettings(dtStartDate.Value, Convert.ToInt32(txtOccurrences.Text));
                    else
                        we = new WeeklyRecurrenceSettings(dtStartDate.Value, dtEndDate.Value);

                    selectedValues.Sunday = chkSunday.Checked;
                    selectedValues.Monday = chkMonday.Checked;
                    selectedValues.Tuesday = chkTuesday.Checked;
                    selectedValues.Wednesday = chkWednesday.Checked;
                    selectedValues.Thursday = chkThursday.Checked;
                    selectedValues.Friday = chkFriday.Checked;
                    selectedValues.Saturday = chkSaturday.Checked;

                    values = we.GetValues(int.Parse(txtWeeklyRegenXWeeks.Text), selectedValues);
                    break;

                case 2: // Monthly
                    MonthlyRecurrenceSettings mo;
                    if (radioOccurrences.Checked)
                        mo = new MonthlyRecurrenceSettings(dtStartDate.Value, Convert.ToInt32(txtOccurrences.Text));
                    else
                        mo = new MonthlyRecurrenceSettings(dtStartDate.Value, dtEndDate.Value);


                    if (radioButton3.Checked)
                        values = mo.GetValues(int.Parse(textBox4.Text), Convert.ToInt32(textBox2.Text));
                    else
                    {
                        // Get the adjusted values
                        mo.AdjustmentValue = int.Parse(txtMonthlyAdjustedValue.Text);
                        values = mo.GetValues((MonthlySpecificDatePartOne)comboBox2.SelectedIndex, (MonthlySpecificDatePartTwo)comboBox3.SelectedIndex, int.Parse(textBox3.Text));
                    }
                    break;

                case 3: // Yearly
                    YearlyRecurrenceSettings yr;
                    if (radioOccurrences.Checked)
                        yr = new YearlyRecurrenceSettings(dtStartDate.Value, Convert.ToInt32(txtOccurrences.Text));
                    else
                        yr = new YearlyRecurrenceSettings(dtStartDate.Value, dtEndDate.Value);


                    if (radioYearlyEvery.Checked)
                        values = yr.GetValues(int.Parse(txtYearEvery.Text), cboYearEveryMonth.SelectedIndex + 1);
                    else
                    {
                        // Get the adjusted value
                        yr.AdjustmentValue = int.Parse(txtYearlyAdjustedValue.Text);
                        values = yr.GetValues((YearlySpecificDatePartOne)comboBox5.SelectedIndex, (YearlySpecificDatePartTwo)comboBox4.SelectedIndex, (YearlySpecificDatePartThree)(comboBox6.SelectedIndex + 1));
                    }
                    break;
            }

            txtSeriesInfo.Text = values.GetSeriesInfo();
            txtGetRecurrenceValues.Text = txtSeriesInfo.Text;

            lstResults.Items.Clear();
            DateTime[] bolded = new DateTime[values.Values.Count];
            int counter = 0;
            foreach (DateTime dt in values.Values)
            {
                bolded[counter] = dt;
                lstResults.Items.Add(new DateItem(dt));
                counter++;
            }
            monthCalendar1.BoldedDates = bolded;
            
            if (lstResults.Items.Count > 0)
                lstResults.SelectedIndex = 0;

            txtTotal.Text = lstResults.Items.Count.ToString();
            txtEndDate.Text = values.EndDate.ToShortDateString();
            txtStartDate.Text = values.StartDate.ToShortDateString();
            btnGetNextDate.Enabled = lstResults.Items.Count > 0;
            txtNextDate.Text = string.Empty;
            lstRecurrenceValues.Items.Clear();
            tabMain.SelectedTab = tabSecond;
            txtAdjustedTotal.Text = lstRecurrenceValues.Items.Count.ToString();

            // Get reccurrence info object to use for setting controls
            RecurrenceInfo info = RecurrenceHelper.GetFriendlySeriesInfo(values.GetSeriesInfo());
            dateTimePickerStartDate.Value = info.StartDate;
            if (info.EndDate.HasValue)
            {
                dateTimePickerStartDateEndDate.Value = info.EndDate.Value;
                dtAdjustedDateTime.Value = info.EndDate.Value;
                dateTimePicker1.Value = info.EndDate.Value;
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateItem dt = (DateItem)lstResults.SelectedItem;
            monthCalendar1.SetDate(dt.Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateItem dt = (DateItem)lstResults.SelectedItem;
            txtNextDate.Text = RecurrenceHelper.GetNextDate(dt.Value, txtSeriesInfo.Text).ToString("d MMM, yyyy   ddd");
        }

        private void btnGetRecurrenceValues_Click(object sender, EventArgs e)
        {
            RecurrenceValues values = RecurrenceHelper.GetRecurrenceValues(txtGetRecurrenceValues.Text);

            lstRecurrenceValues.Items.Clear();
            foreach (DateTime dt in values.Values)
            {
                lstRecurrenceValues.Items.Add(new DateItem(dt));
            }
            if (lstRecurrenceValues.Items.Count > 0)
                lstRecurrenceValues.SelectedIndex = 0;
            txtAdjustedTotal.Text = lstRecurrenceValues.Items.Count.ToString();
        }

        private void txtGetRecurrenceValues_TextChanged(object sender, EventArgs e)
        {
            btnGetRecurrenceValues.Enabled = (txtGetRecurrenceValues.Text.Trim().Length > 0);
            button3.Enabled = (txtGetRecurrenceValues.Text.Trim().Length > 0);
            button4.Enabled = (txtGetRecurrenceValues.Text.Trim().Length > 0);
            btnGetAdjustedOccurrencesValues.Enabled = (txtGetRecurrenceValues.Text.Trim().Length > 0);
            btnGetAdjustedEndDateValues.Enabled = (txtGetRecurrenceValues.Text.Trim().Length > 0);
            button2.Enabled = (txtGetRecurrenceValues.Text.Trim().Length > 0);
            button1.Enabled = (txtGetRecurrenceValues.Text.Trim().Length > 0);
            cmdAdjustOccurrencesForStartDate.Enabled = (txtGetRecurrenceValues.Text.Trim().Length > 0);
            cmdAdjustEndDateForStartDate.Enabled = (txtGetRecurrenceValues.Text.Trim().Length > 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RecurrenceValues values = RecurrenceHelper.GetRecurrenceValues(txtGetRecurrenceValues.Text, int.Parse(txtAdjustedOccurrences.Text));
            txtGetRecurrenceValues.Text = values.GetSeriesInfo();
            lstRecurrenceValues.Items.Clear();
            foreach (DateTime dt in values.Values)
            {
                lstRecurrenceValues.Items.Add(new DateItem(dt));
            }
            if (lstRecurrenceValues.Items.Count > 0)
                lstRecurrenceValues.SelectedIndex = 0;
            txtAdjustedTotal.Text = lstRecurrenceValues.Items.Count.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RecurrenceValues values = RecurrenceHelper.GetRecurrenceValues(txtGetRecurrenceValues.Text, dtAdjustedDateTime.Value);
            txtGetRecurrenceValues.Text = values.GetSeriesInfo();
            lstRecurrenceValues.Items.Clear();
            foreach (DateTime dt in values.Values)
            {
                lstRecurrenceValues.Items.Add(new DateItem(dt));
            }
            if (lstRecurrenceValues.Items.Count > 0)
                lstRecurrenceValues.SelectedIndex = 0;
            txtAdjustedTotal.Text = lstRecurrenceValues.Items.Count.ToString();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            RecurrenceValues values = RecurrenceHelper.GetPostRecurrenceValues(txtGetRecurrenceValues.Text, int.Parse(textBox5.Text));
            txtGetRecurrenceValues.Text = values.GetSeriesInfo();
            lstRecurrenceValues.Items.Clear();
            foreach (DateTime dt in values.Values)
            {
                lstRecurrenceValues.Items.Add(new DateItem(dt));
            }
            if (lstRecurrenceValues.Items.Count > 0)
                lstRecurrenceValues.SelectedIndex = 0;
            txtAdjustedTotal.Text = lstRecurrenceValues.Items.Count.ToString();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            RecurrenceValues values = RecurrenceHelper.GetPostRecurrenceValues(txtGetRecurrenceValues.Text, dateTimePicker1.Value);
            txtGetRecurrenceValues.Text = values.GetSeriesInfo();
            lstRecurrenceValues.Items.Clear();
            foreach (DateTime dt in values.Values)
            {
                lstRecurrenceValues.Items.Add(new DateItem(dt));
            }
            if (lstRecurrenceValues.Items.Count > 0)
                lstRecurrenceValues.SelectedIndex = 0;
            txtAdjustedTotal.Text = lstRecurrenceValues.Items.Count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pattern = RecurrenceHelper.GetPatternDefinitioin(txtGetRecurrenceValues.Text);
            PatternDefinitionViewer frm = new PatternDefinitionViewer();
            frm.LoadPattern(pattern);
            frm.Show(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RecurrenceInfo info = RecurrenceHelper.GetFriendlySeriesInfo(txtGetRecurrenceValues.Text);
            pgrpropertyGrid1.SelectedObject = info;
            tabMain.SelectedTab = tabProperty;
        }

        private void cmdAdjustOccurrencesForStartDate_Click(object sender, EventArgs e)
        {
            RecurrenceValues values;
            if (chkUseAdjustedStartDate.Checked)
            {
                values = RecurrenceHelper.GetRecurrenceValues(txtGetRecurrenceValues.Text, dateTimePickerStartDate.Value, int.Parse(textBox6.Text));
            }else{
                values = RecurrenceHelper.GetRecurrenceValues(txtGetRecurrenceValues.Text, int.Parse(textBox6.Text));
            }

            txtGetRecurrenceValues.Text = values.GetSeriesInfo();
            lstRecurrenceValues.Items.Clear();
            foreach (DateTime dt in values.Values)
            {
                lstRecurrenceValues.Items.Add(new DateItem(dt));
            }
            if (lstRecurrenceValues.Items.Count > 0)
                lstRecurrenceValues.SelectedIndex = 0;
            txtAdjustedTotal.Text = lstRecurrenceValues.Items.Count.ToString();

        }

        private void cmdAdjustEndDateForStartDate_Click(object sender, EventArgs e)
        {
            RecurrenceValues values;

            if (chkUseAdjustedStartDate.Checked)
            {
                values = RecurrenceHelper.GetRecurrenceValues(txtGetRecurrenceValues.Text, dateTimePickerStartDate.Value, dateTimePickerStartDateEndDate.Value);
            }
            else
            {
                values = RecurrenceHelper.GetRecurrenceValues(txtGetRecurrenceValues.Text, dateTimePickerStartDateEndDate.Value);
            }

            txtGetRecurrenceValues.Text = values.GetSeriesInfo();
            lstRecurrenceValues.Items.Clear();
            foreach (DateTime dt in values.Values)
            {
                lstRecurrenceValues.Items.Add(new DateItem(dt));
            }
            if (lstRecurrenceValues.Items.Count > 0)
                lstRecurrenceValues.SelectedIndex = 0;
            txtAdjustedTotal.Text = lstRecurrenceValues.Items.Count.ToString();
        }


    }
}