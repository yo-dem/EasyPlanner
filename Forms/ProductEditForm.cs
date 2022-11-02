using EasyPlanner.Data;
using System.Data;
using System.Globalization;

namespace EasyPlanner.Forms
{
    public partial class ProductEditForm : Form
    {
        public bool isDelete = false;
        string idProdotto;
        public ProductEditForm(string idProdotto)
        {
            InitializeComponent();

            txtMarca.TextChanged += TxtMarca_TextChanged;
            txtMarca.KeyDown += TxtMarca_KeyDown;
            txtDescrizione.TextChanged += TxtDescrizione_TextChanged;
            txtPrezzoNetto.TextChanged += txtPrezzoNetto_TextChanged;
            txtPrezzoIvato.TextChanged += txtPrezzoIvato_TextChanged;
            nudAliquota.ValueChanged += NudAliquota_ValueChanged;
            txtNote.GotFocus += TxtNote_GotFocus;
            txtNote.LostFocus += TxtNote_LostFocus;

            this.idProdotto = idProdotto;
            LoadForm();
            txtPrezzoNetto.ForeColor = Color.Black;
            txtPrezzoIvato.ForeColor = Color.Black;
        }

        private void TxtMarca_TextChanged(object? sender, EventArgs e)
        {
            lblMarca.ForeColor = Color.Black;
        }

        private void TxtMarca_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void TxtDescrizione_TextChanged(object? sender, EventArgs e)
        {
            lblDescrizione.ForeColor = Color.Black;
        }

        string? prezzoNetto;
        private void txtPrezzoNetto_TextChanged(object ?sender, EventArgs e)
        {
            lblPrezzoNetto.ForeColor = Color.Black;
            txtPrezzoIvato.ForeColor = Color.Red;
            try
            {
                double value = double.Parse(txtPrezzoNetto.Text);
                prezzoNetto = value.ToString("C", CultureInfo.CurrentCulture);
            }
            catch
            {
                txtPrezzoNetto.Text = String.Empty;
            }
        }

        string ?prezzoIvato;
        private void txtPrezzoIvato_TextChanged(object ?sender, EventArgs e)
        {
            txtPrezzoNetto.ForeColor = Color.Red;
            lblPrezzoIvato.ForeColor = Color.Black;
            try
            {
                double value = double.Parse(txtPrezzoIvato.Text);
                prezzoIvato = value.ToString("C", CultureInfo.CurrentCulture);
            }
            catch
            {
                txtPrezzoIvato.Text = String.Empty;
            }
        }

        private void NudAliquota_ValueChanged(object? sender, EventArgs e)
        {
            if (txtPrezzoNetto.Text != String.Empty && txtPrezzoIvato.Text != String.Empty)
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

        private void LoadForm()
        {
            DataTable dt = ModelProdotti.getProdottoById(idProdotto);
            if (dt.Rows.Count != 0)
            {
                dtpData.Text = dt.Rows[0]["DATA"].ToString();
                txtMarca.Text = dt.Rows[0]["MARCA"].ToString();
                txtDescrizione.Text = dt.Rows[0]["DESCRIZIONE"].ToString();
                string ?sqnt = dt.Rows[0]["QNT"].ToString();
                if (!String.IsNullOrEmpty(sqnt))
                    nudQnt.Value = int.Parse(sqnt);
                string? saliquota = dt.Rows[0]["ALIQUOTA"].ToString();
                if (!String.IsNullOrEmpty(saliquota))
                    nudAliquota.Value = int.Parse(saliquota);
                string ?strPN = dt.Rows[0]["PREZZO_NETTO"].ToString();
                if(!String.IsNullOrEmpty(strPN))
                    txtPrezzoNetto.Text = strPN.Replace("€","");
                string? strPI = dt.Rows[0]["PREZZO_IVATO"].ToString();
                if (!String.IsNullOrEmpty(strPI))
                    txtPrezzoIvato.Text = strPI.Replace("€", "");
                txtNote.Text = dt.Rows[0]["NOTE"].ToString();
            }
        }

        private void btnAddIVA_Click(object sender, EventArgs e)
        {
            if (txtPrezzoNetto.Text != String.Empty)
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
            if (txtPrezzoIvato.Text != String.Empty)
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

            if (String.IsNullOrEmpty(txtMarca.Text))
            {
                lblMarca.ForeColor = Color.Red;
                res1 = false;
            }
            if (String.IsNullOrEmpty(txtDescrizione.Text))
            {
                lblDescrizione.ForeColor = Color.Red;
                res2 = false;
            }
            if (String.IsNullOrEmpty(txtPrezzoNetto.Text))
            {
                lblPrezzoNetto.ForeColor = Color.Red;
                res3 = false;
            }
            if (String.IsNullOrEmpty(txtPrezzoIvato.Text))
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
                txtPrezzoNetto.TextChanged -= txtPrezzoNetto_TextChanged;
                txtPrezzoIvato.TextChanged -= txtPrezzoIvato_TextChanged;
                if (!String.IsNullOrEmpty(prezzoNetto))
                    txtPrezzoNetto.Text = prezzoNetto;
                if (!String.IsNullOrEmpty(prezzoIvato))
                    txtPrezzoIvato.Text = prezzoIvato;
                txtPrezzoNetto.TextChanged += txtPrezzoNetto_TextChanged;
                txtPrezzoIvato.TextChanged += txtPrezzoIvato_TextChanged;
                ModelProdotti.editProdotto(
                    idProdotto,
                    dtpData.Value.ToShortDateString(),
                    txtMarca.Text.ToUpper(),
                    txtDescrizione.Text.ToUpper(),
                    nudAliquota.Value.ToString(),
                    nudQnt.Value.ToString(),
                    txtPrezzoNetto.Text,
                    txtPrezzoIvato.Text,
                    txtNote.Text.ToUpper());
                    
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteForm dltFrm = new DeleteForm(txtMarca.Text + " " + txtDescrizione.Text);
                dltFrm.ShowDialog();
                if (dltFrm.result)
                {
                    ModelProdotti.deleteProdotto(idProdotto);
                    isDelete = true;
                    this.Close();
                }
            }
            catch { }
        }
    }
}
