using System;
using System.Windows.Forms;

namespace RecurrenceTester
{
    public partial class PatternDefinitionViewer : Form
    {
        public PatternDefinitionViewer()
        {
            InitializeComponent();
        }

        public void LoadPattern(string patternDefinition)
        {
            textBox1.Text = patternDefinition;
            textBox1.SelectionStart = 0;
        }
    }
}