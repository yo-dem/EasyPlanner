using EasyPlanner.Data;
using EasyPlanner.Forms;
using EasyPlanner.Printing;
using System.Data;
using System.Reflection;
using Font = System.Drawing.Font;

namespace EasyPlanner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            LoadProdotti(0);

            SetProductDataGridValues();
            SetDataGridStyles();

            dgvData.MouseDoubleClick += dgvData_MouseDoubleClick;
            dgvData.KeyDown += dgvData_KeyDown;
            dgvData.SelectionChanged += dgvData_SelectionChanged;

            if (ModelPwd.IsEnabled())
                btnLogout.Visible = true;
            else
                btnLogout.Visible = false;
        }

        void LoadProdotti(int selectedIndex)
        {
            ModelProdotti.getProdotti(dgvData);
            if (selectedIndex < dgvData.Rows.Count)
            {
                dgvData.Rows[selectedIndex].Selected = true;
                dgvData.FirstDisplayedScrollingRowIndex = selectedIndex;
            }
            else
                dgvData.Rows[--selectedIndex].Selected = true;
        }

        void SetProductDataGridValues()
        {
            dgvData.Columns["IDPRODOTTO"].DisplayIndex = 0;
            dgvData.Columns["IDPRODOTTO"].Visible = false;
            dgvData.Columns["IDPRODOTTO"].HeaderText = "IDPRODOTTO";
            dgvData.Columns["IDPRODOTTO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvData.Columns["IDPRODOTTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvData.Columns["DATA"].DisplayIndex = 1;
            dgvData.Columns["DATA"].Visible = true;
            dgvData.Columns["DATA"].HeaderText = "DATA";
            dgvData.Columns["DATA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvData.Columns["DATA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvData.Columns["MARCA"].DisplayIndex = 2;
            dgvData.Columns["MARCA"].Visible = true;
            dgvData.Columns["MARCA"].HeaderText = "MARCA";
            dgvData.Columns["MARCA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvData.Columns["MARCA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvData.Columns["DESCRIZIONE"].DisplayIndex = 3;
            dgvData.Columns["DESCRIZIONE"].Visible = true;
            dgvData.Columns["DESCRIZIONE"].HeaderText = "DESCRIZIONE";
            dgvData.Columns["DESCRIZIONE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvData.Columns["DESCRIZIONE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvData.Columns["DESCRIZIONE"].DefaultCellStyle.Font = new Font("Corbel", 13, System.Drawing.FontStyle.Bold);
            dgvData.Columns["DESCRIZIONE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgvData.Columns["ALIQUOTA"].DisplayIndex = 4;
            dgvData.Columns["ALIQUOTA"].Visible = true;
            dgvData.Columns["ALIQUOTA"].HeaderText = "IVA";
            dgvData.Columns["ALIQUOTA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvData.Columns["ALIQUOTA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvData.Columns["ALIQUOTA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvData.Columns["QNT"].DisplayIndex = 5;
            dgvData.Columns["QNT"].Visible = false;
            dgvData.Columns["QNT"].HeaderText = "QNT";
            dgvData.Columns["QNT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvData.Columns["QNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvData.Columns["PREZZO_NETTO"].DisplayIndex = 6;
            dgvData.Columns["PREZZO_NETTO"].Visible = true;
            dgvData.Columns["PREZZO_NETTO"].HeaderText = "NETTO";
            dgvData.Columns["PREZZO_NETTO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvData.Columns["PREZZO_NETTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvData.Columns["PREZZO_NETTO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvData.Columns["PREZZO_IVATO"].DisplayIndex = 7;
            dgvData.Columns["PREZZO_IVATO"].Visible = true;
            dgvData.Columns["PREZZO_IVATO"].HeaderText = "IVATO";
            dgvData.Columns["PREZZO_IVATO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvData.Columns["PREZZO_IVATO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvData.Columns["PREZZO_IVATO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvData.Columns["NOTE"].DisplayIndex = 8;
            dgvData.Columns["NOTE"].Visible = true;
            dgvData.Columns["NOTE"].HeaderText = "NOTE";
            dgvData.Columns["NOTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns["NOTE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns["NOTE"].DefaultCellStyle.Font = new Font("Corbel", 8, FontStyle.Bold);
        }

        void SetDataGridStyles()
        {
            dgvData.ShowCellToolTips = false;
            // Impedisce al controllo di scegliere autonomamente l'altezza dell'header delle colonne
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            // Imposta l'altezza dell'header delle colonne
            dgvData.ColumnHeadersHeight = 50;
            // Imposta l'altezza delle singole righe
            dgvData.RowTemplate.Height = 40;
            // Imposta il font per l'header delle colonne
            dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Corbel", 10, System.Drawing.FontStyle.Bold);
            // Imposta il font per ogni cella del datagridview
            dgvData.Font = new Font("Corbel", 10, FontStyle.Regular);
            // Impedisce all'utente di modificare la dimensione delle righe
            dgvData.AllowUserToResizeRows = false;
            // Impedisce all'utente di modificare la dimensione delle colonne
            dgvData.AllowUserToResizeColumns = false;
            // Impedisce all'utente di aggiungere una nuova riga
            dgvData.AllowUserToAddRows = false;
            // Impone la dimensione massima possibile per ciascuna colonna
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Disabilita l'ordinamento automatico di ogni colonna, escluse le prime 4
            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                if (column.Index > 3)
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            // Nasconde il selettore di riga
            dgvData.RowHeadersVisible = true;
            // Impedisce la modifica del valore delle celle
            dgvData.ReadOnly = true;
            // Impone la selezione dell'intera riga e non della singola cella
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Impedisce la selezione di più righe contemporaneamente
            dgvData.MultiSelect = false;
            // Aggiunge un offset per distanziare i contenuti delle celle dai bordi
            dgvData.DefaultCellStyle.Padding = new Padding(5);

            // Opzioni di stile grafico

            // Abilita la personalizzazione degli stili
            dgvData.EnableHeadersVisualStyles = false;
            // Imposta il colore di sfondo del datagridview
            dgvData.BackgroundColor = Color.FromArgb(230, 230, 230);
            // Elimina il bordo del datagridview
            dgvData.BorderStyle = BorderStyle.None;
            // Elimina il bordo dell'header delle colonne
            dgvData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            // Imposta solo una bordo orizzontale per ogni riga
            dgvData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            // Imposta il colore di sfondo dell'header delle colonne a un grigio chiaro
            dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            // Imposta il colore di sfondo delle righe selezionate
            dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 210, 210);
            // Imposta il colore del testo delle righe selezionate
            dgvData.DefaultCellStyle.SelectionForeColor = Color.Black;
            // Imposta il colore di sfondo dell'header selezionato uguale a quello del proprio sfondo
            dgvData.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvData.ColumnHeadersDefaultCellStyle.BackColor;
            // Imposta il colore del selettore di riga
            dgvData.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            // Imposta la larghezza dell'header delle righe
            dgvData.RowHeadersWidth = 30;
            // Disabilita la possibilità di ridimensionare la larghezza dell'header delle righe
            dgvData.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ProductInsertForm productInsertForm = new ProductInsertForm();
            productInsertForm.ShowDialog();
            ModelProdotti.getProdotti(dgvData);
            dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 230);
            timerView.Interval = 3000;
            timerView.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selected = 0;
            int displayPos = 0;
            
            try
            {
                string? idProdotto = dgvData.SelectedRows[0].Cells["IDPRODOTTO"].Value.ToString();
                selected = dgvData.SelectedRows[0].Index;
                displayPos = dgvData.FirstDisplayedScrollingRowIndex;

                if (!String.IsNullOrEmpty(idProdotto))
                {
                    ProductEditForm productEditForm = new ProductEditForm(idProdotto);
                    productEditForm.ShowDialog();

                    LoadProdotti(0);
                    if (productEditForm.isDelete)
                    {
                        dgvData.Rows[selected].Selected = true;
                        dgvData.FirstDisplayedScrollingRowIndex = displayPos;
                    }
                    else
                    {
                        dgvData.Rows[selected].Selected = true;
                        dgvData.FirstDisplayedScrollingRowIndex = displayPos;
                        dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 230);
                        timerView.Interval = 3000;
                        timerView.Enabled = true;
                    }
                }
            }
            catch
            {
                dgvData.Rows[--selected].Selected = true;
                dgvData.FirstDisplayedScrollingRowIndex = displayPos;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selected = 0;
            int displayPos = 0;
            try
            {
                string? idProdotto = dgvData.SelectedRows[0].Cells["IDPRODOTTO"].Value.ToString();
                selected = dgvData.SelectedRows[0].Index;
                displayPos = dgvData.FirstDisplayedScrollingRowIndex;

                if (dgvData.Rows.Count != 0)
                {
                    DeleteForm dltFrm = new DeleteForm(dgvData.SelectedRows[0].Cells["MARCA"].Value.ToString() + " " + dgvData.SelectedRows[0].Cells["DESCRIZIONE"].Value.ToString());
                    dltFrm.ShowDialog();
                    if (dltFrm.result)
                    {
                        ModelProdotti.deleteProdotto(idProdotto);
                        LoadProdotti(0);
                        dgvData.Rows[selected].Selected = true;
                        dgvData.FirstDisplayedScrollingRowIndex = displayPos;
                    }
                }
            }
            catch
            {
                dgvData.Rows[--selected].Selected = true;
                dgvData.FirstDisplayedScrollingRowIndex = displayPos;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lgn = new LoginForm();
            lgn.ShowDialog();
            if (lgn.logged)
                this.Show();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            SettingsForm frm = new SettingsForm();
            frm.ShowDialog();
            if (frm.chkAccessMode.Checked)
                btnLogout.Visible = true;
            else
                btnLogout.Visible = false;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
                new CalculateForm(dgvData).ShowDialog();
        }

        private void btnPrintTest_Click(object sender, EventArgs e)
        {
            Assembly? location = Assembly.GetEntryAssembly();
            if (location != null)
            {
                string timestamp = DateTime.Now.ToShortDateString().Replace("/", "_");
                string fileName = "\\Inventario_" + timestamp + ".pdf"; ;
                string? path = String.Empty;


                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderBrowserDialog.SelectedPath + fileName;
                    DataTable dtOrdered = new DataTable();
                    dtOrdered.Columns.Add("IDPRODOTTO");
                    dtOrdered.Columns.Add("DATA");
                    dtOrdered.Columns.Add("MARCA");
                    dtOrdered.Columns.Add("DESCRIZIONE");
                    dtOrdered.Columns.Add("ALIQUOTA");
                    dtOrdered.Columns.Add("QNT");
                    dtOrdered.Columns.Add("PREZZO_NETTO");
                    dtOrdered.Columns.Add("PREZZO_IVATO");
                    dtOrdered.Columns.Add("NOTE");

                    for (int row = 0; row < dgvData.Rows.Count; row++)
                    {
                        dtOrdered.Rows.Add(dtOrdered.NewRow());
                        for (int col = 0; col < dgvData.Rows[row].Cells.Count; col++)
                        {
                            dtOrdered.Rows[row][col] = (dgvData.Rows[row].Cells[col].Value.ToString());
                        }

                    }

                    PrintingUtility.CreatePDF(dtOrdered, path);
                }
            }
        }

        private void dgvData_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (sender != null)
                btnEdit_Click(sender, e);
        }

        private void dgvData_KeyDown(object? sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (sender != null && e.KeyCode == Keys.Return)
            {
                btnEdit_Click(sender, e);
            }
            if (sender != null && e.KeyCode == Keys.Back)
            {
                btnDelete_Click(sender, e);
            }
            if (sender != null && e.KeyCode == Keys.Delete)
            {
                btnDelete_Click(sender, e);
            }
            if (sender != null && e.KeyCode == Keys.Up)
            {
                try
                {
                    int selected = dgvData.SelectedRows[0].Index;
                    int displayPos = dgvData.FirstDisplayedScrollingRowIndex;
                    dgvData.Rows[selected - 1].Selected = true;
                }
                catch { }
            }
            if (sender != null && e.KeyCode == Keys.Down)
            {
                try
                {
                    int selected = dgvData.SelectedRows[0].Index;
                    int displayPos = dgvData.FirstDisplayedScrollingRowIndex;
                    dgvData.Rows[selected + 1].Selected = true;
                }
                catch { }
            }
        }

        private void dgvData_SelectionChanged(object? sender, EventArgs e)
        {
            dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 210, 210);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != String.Empty && dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgvData.Rows)
                {
                    try
                    {
                        if (dgvr.Cells["DATA"].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower())
                            || dgvr.Cells["MARCA"].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower())
                            || dgvr.Cells["DESCRIZIONE"].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            dgvData.Rows[dgvr.Index].Selected = true;
                            dgvData.FirstDisplayedScrollingRowIndex = dgvData.SelectedRows[0].Index;
                            dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 230);
                            timerView.Interval = 3000;
                            timerView.Enabled = true;
                            return;
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (txtSearch.Text != String.Empty)
                    btnEdit_Click(sender, e);
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = String.Empty;
        }

        private void timerView_Tick(object sender, EventArgs e)
        {
            dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 210, 210);
            timerView.Enabled = false;
        }

    }
}