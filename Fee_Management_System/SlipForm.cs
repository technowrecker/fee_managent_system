using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class SlipForm : Form
    {
        public SlipForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

         PrintPreviewDialog printprev = new PrintPreviewDialog();
        PrintDocument pdoc = new PrintDocument();

        Bitmap bmp;
        private void Print_Click(object sender, EventArgs e)
        {
            Print(this.SlipPanel);
            
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();  
        }
        public void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            getPanelArea(pnl);
             printprev.Document = pdoc;
            pdoc.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
             printprev.ShowDialog();
        }

        private void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.SlipPanel.Width / 2), this.SlipPanel.Location.Y);
        }

        Bitmap MemoryImage;
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        private void getPanelArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        private void SlipForm_Load(object sender, EventArgs e)
        {
            lblid.Text = PrintSlipData.feeId.ToString();
            lblName.Text = PrintSlipData.studentName;
            lblFName.Text = PrintSlipData.fatherName;
            lblClass.Text = PrintSlipData.studentClass;
            lblFees.Text = PrintSlipData.amount;
            lblMonth.Text = PrintSlipData.feeMonth;
            lblDate.Text = DateTime.Now.ToString("dd-MMMM-yyy hh:mm:ss tt");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             e.Graphics.DrawImage(MemoryImage, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print(this.SlipPanel);
        }

        private void SlipPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
