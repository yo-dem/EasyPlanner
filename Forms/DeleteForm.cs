namespace EasyPlanner.Forms
{
    public partial class DeleteForm : Form
    {
        public bool result;
        public DeleteForm(string text)
        {
            InitializeComponent();
            lblText.Text = text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            result = true;
            this.Close();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            result=false;
            this.Close();
        }
    }
}
