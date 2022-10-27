using EasyPlanner.Data;
using System.Globalization;

namespace EasyPlanner.Forms
{
    public partial class ProductInsertForm : Form
    {
        public ProductInsertForm()
        {
            InitializeComponent();

            txtMarca.TextChanged += TxtMarca_TextChanged;
            txtDescrizione.TextChanged += TxtDescrizione_TextChanged;
            txtPrezzoNetto.TextChanged += TxtPrezzoNetto_TextChanged;
            txtPrezzoIvato.TextChanged += TxtPrezzoIvato_TextChanged;
            nudAliquota.ValueChanged += NudAliquota_ValueChanged;
            txtNote.GotFocus += TxtNote_GotFocus;
            txtNote.LostFocus += TxtNote_LostFocus;
        }

        private void TxtMarca_TextChanged(object? sender, EventArgs e)
        {
            lblMarca.ForeColor = Color.Black;
        }

        private void TxtDescrizione_TextChanged(object? sender, EventArgs e)
        {
            lblDescrizione.ForeColor = Color.Black;
        }

        string? prezzoNetto;
        private void TxtPrezzoNetto_TextChanged(object? sender, EventArgs e)
        {
            lblPrezzoNetto.ForeColor = Color.Black;
            txtPrezzoIvato.ForeColor = Color.Red;
            if (txtPrezzoNetto.Text.Contains('.'))
                txtPrezzoNetto.Text = string.Empty;
            try
            {
                double value = double.Parse(txtPrezzoNetto.Text);
                prezzoNetto = value.ToString("C", CultureInfo.CurrentCulture);
            }
            catch
            {
                txtPrezzoNetto.Text = string.Empty;
            }
        }

        string? prezzoIvato;
        private void TxtPrezzoIvato_TextChanged(object? sender, EventArgs e)
        {
            txtPrezzoNetto.ForeColor = Color.Red;
            lblPrezzoIvato.ForeColor = Color.Black;
            if (txtPrezzoIvato.Text.Contains('.'))
                txtPrezzoIvato.Text = String.Empty;
            try
            {
                double value = double.Parse(txtPrezzoIvato.Text);
                prezzoIvato = value.ToString("C", CultureInfo.CurrentCulture);
            }
            catch
            {
                txtPrezzoIvato.Text = string.Empty;
            }
        }

        private void NudAliquota_ValueChanged(object? sender, EventArgs e)
        {
            lblAliquota.ForeColor = Color.Black;
            if (txtPrezzoNetto.Text != string.Empty && txtPrezzoIvato.Text != string.Empty)
            {
                txtPrezzoNetto.ForeColor = Color.Red;
                txtPrezzoIvato.ForeColor = Color.Red;
            }
        }
        
        private void TxtNote_GotFocus(object? sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void TxtNote_LostFocus(object? sender, EventArgs e)
        {
            this.AcceptButton = this.btnOk;
        }
       
        private void btnAddIVA_Click(object sender, EventArgs e)
        {
            if (txtPrezzoNetto.Text != string.Empty)
            {
                double value = double.Parse(txtPrezzoNetto.Text);
                double res = value + (value * int.Parse(nudAliquota.Value.ToString()) / 100);

                prezzoIvato = Math.Round(res, 2, MidpointRounding.AwayFromZero).ToString();

                txtPrezzoIvato.Text = prezzoIvato;

                txtPrezzoNetto.ForeColor = Color.Black;
                txtPrezzoIvato.ForeColor = Color.Black;
            }
        }

        private void btnRemoveIVA_Click(object sender, EventArgs e)
        {
            if (txtPrezzoIvato.Text != string.Empty)
            {
                double value = double.Parse(txtPrezzoIvato.Text);
                double res = value * 100 / (100 + int.Parse(nudAliquota.Value.ToString()));
                prezzoNetto = Math.Round(res, 2, MidpointRounding.AwayFromZero).ToString();
                
                txtPrezzoNetto.Text = prezzoNetto;

                txtPrezzoNetto.ForeColor = Color.Black;
                txtPrezzoIvato.ForeColor = Color.Black;
            }
        }

        bool InputCheck()
        {
            bool res0 = true;
            bool res1 = true;
            bool res2 = true;
            bool res3 = true;
            bool res4 = true;
            bool res5 = true;

            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                lblMarca.ForeColor = Color.Red;
                res1 = false;
            }
            if (string.IsNullOrEmpty(txtDescrizione.Text))
            {
                lblDescrizione.ForeColor = Color.Red;
                res2 = false;
            }
            if (string.IsNullOrEmpty(txtPrezzoNetto.Text))
            {
                lblPrezzoNetto.ForeColor = Color.Red;
                res3 = false;
            }
            if (string.IsNullOrEmpty(txtPrezzoIvato.Text))
            {
                lblPrezzoIvato.ForeColor = Color.Red;
                res4 = false;
            }

            if (txtPrezzoNetto.ForeColor == Color.Red || txtPrezzoIvato.ForeColor == Color.Red)
            {
                res5 = false;
            }

            return res0 && res1 && res2 && res3 && res4 && res5;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (InputCheck())
            {
                txtPrezzoNetto.TextChanged -= TxtPrezzoNetto_TextChanged;
                txtPrezzoIvato.TextChanged -= TxtPrezzoIvato_TextChanged;
                if (!string.IsNullOrEmpty(prezzoNetto))
                    txtPrezzoNetto.Text = prezzoNetto;
                if (!string.IsNullOrEmpty(prezzoIvato))
                    txtPrezzoIvato.Text = prezzoIvato;
                txtPrezzoNetto.TextChanged += TxtPrezzoNetto_TextChanged;
                txtPrezzoIvato.TextChanged += TxtPrezzoIvato_TextChanged;
                ModelProdotti.addProdotto(
                    dtpData.Value.ToShortDateString(),
                    txtMarca.Text.ToUpper(),
                    txtDescrizione.Text.ToUpper(),
                    nudAliquota.Value.ToString(),
                    nudQnt.Value.ToString(),
                    txtPrezzoNetto.Text,
                    txtPrezzoIvato.Text,
                    txtNote.Text.ToUpper());
                if (chkRipeti.Checked)
                {
                    dtpData.Value = DateTime.Now;
                    txtMarca.Text = string.Empty;
                    txtDescrizione.Text = string.Empty;
                    nudAliquota.Value = 22;
                    nudQnt.Value = 1;
                    txtPrezzoNetto.Text = string.Empty;
                    txtPrezzoIvato.Text = string.Empty;
                    txtNote.Text = string.Empty;

                    txtPrezzoNetto.ForeColor = Color.Black;
                    txtPrezzoIvato.ForeColor = Color.Black;
                }
                else
                    this.Close();
            }
        }
    }
}
