namespace Sedelnikov_0._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            double A = CovertToDouble(aInput.Text, "a");
            double B = CovertToDouble(bInput.Text, "b");
            double H = CovertToDouble(hInput.Text, "h");
            double M = CovertToDouble(mInput.Text, "m");

            if (A != -1 && B != -1 && H != -1 && M != -1)
            {
                A = CheckFormat(A, "a");
                B = CheckFormat(B, "b");
                H = CheckFormat(H, "h");
                M = CheckFormat(M, "m");

                if (A != -1 && B != -1 && H != -1 && M != -1)
                {
                    double V = A * B * H;
                    double P = M / V;

                    AnswerLabel.Text = $"{P.ToString()} г/см3";
                }
            }
        }

        private void aInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void mInput_TextChanged(object sender, EventArgs e)
        {

        }

        double CovertToDouble(string LabelText, string LabelName)
        {
            double LabelDouble;

            if (Double.TryParse(LabelText, out LabelDouble)) {
                return LabelDouble;
            }
            else
            {
                MessageBox.Show($"Неправильный формат '{LabelName}'");
                return -1;
            }
        }

        double CheckFormat(double Number, string NumberName)
        {
            double LabelDouble;

            if (Number <= 0)
            {
                MessageBox.Show($"'{NumberName}' не может быть меньше или равен 0!");
                return -1;
            }
            else if (Number > 100000)
            {
                MessageBox.Show($"'{NumberName}' не может быть больше 100000!");
                return -1;
            }
            else
            {
                return Number;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
