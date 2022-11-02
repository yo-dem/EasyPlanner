using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.Globalization;

namespace EasyPlanner.Forms
{
    public partial class CalculateForm : Form
    {
        public CalculateForm(DataGridView dgvData)
        {
            InitializeComponent();
            timerStop.Enabled = true;
            Calculate(dgvData);
        }

        private void Calculate(DataGridView dgvData)
        {
            DataTable dt = (DataTable)dgvData.DataSource;
            float netto = 0;
            int q = 1;
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    if (row.Table.Columns[i].ColumnName == "QNT")
                    {
                        string? data = row[i].ToString();
                        if (data != null)
                            q = int.Parse(data);
                    }
                    if (row.Table.Columns[i].ColumnName == "PREZZO_NETTO")
                    {
                        string? data = row[i].ToString();
                        if (!String.IsNullOrEmpty(data) && data.Contains("€"))
                        {
                            data = data.Replace("€", "");
                            netto += float.Parse(data) * q;

                            string sData = netto.ToString("C", CultureInfo.CurrentCulture);

                            lblCalc.Text = sData;
                            Clipboard.SetText(sData);
                        }
                    }
                }
            }


        }

        private void timerStop_Tick(object sender, EventArgs e)
        {
            timerStop.Enabled = false;
            this.Close();
        }
    }
}
