namespace WinFormsApp_TASK1
{
    public partial class Form1 : Form
    {
        int downX = 0, downY = 0, upX, upY = 0;

        Label showSize = new Label();


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            var down = e as MouseEventArgs;
            if (down.Button == MouseButtons.Left)
            {
                downX = down.X;
                downY = down.Y;
               // showSize.Dispose();
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            var up = e as MouseEventArgs;
            Label rectangle = new Label();
            upX = up.X;
            upY = up.Y;
            int x = Math.Min(downX, upX);
            int y = Math.Min(downY, upY);
            if (Math.Abs(upX - downX) >= 10 && Math.Abs(upY - downY) >= 10)
            {

                rectangle.BackColor = Color.DarkSlateGray;
                rectangle.Size = new Size(Math.Abs(upX - downX), Math.Abs(upY - downY));
                rectangle.Location = new Point(x, y);
                
                this.Controls.Add(rectangle);
            }
            else
            {
                MessageBox.Show("Min size must be 10x10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            rectangle.Click += (s, e) =>
                   {
                       showSize.Dispose();
                       showSize = new Label();
                       var click = e as MouseEventArgs;
                       if (click!.Button == MouseButtons.Left)
                       {
                           showSize.ForeColor = Color.DarkSlateGray;
                           showSize.Font = new Font(showSize.Font, FontStyle.Bold);
                           showSize.Location = new Point(227, 25);
                           showSize.Size = new Size(200, 25);
                           showSize.Text = $"AREA: {Math.Abs(upX - downX)}x{Math.Abs(upY - downY)} Location:{x},{y}";
                           this.Controls.Add(showSize);

                       }
                   };
                rectangle.DoubleClick += (s, e) =>
                {
                    var click = e as MouseEventArgs;
                    if (click!.Button == MouseButtons.Left)
                    {
                        rectangle.Dispose();
                        showSize.Dispose();
                    }
                };

        }
    }
}