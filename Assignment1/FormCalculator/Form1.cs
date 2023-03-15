namespace FormCalculator
{
    public partial class Form1 : Form
    {
        double a, b, c;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c = a + b;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out float result))
            {
                a = result;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox2.Text, out float result))
            {
                b = result;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c = a - b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c = a * b;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (b == 0.0)
            {
                Console.WriteLine("error!");
            }
            else
            {
                c = a / b;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            string s = c + " ";
            textBox3.Text = s;
        }
    }
}