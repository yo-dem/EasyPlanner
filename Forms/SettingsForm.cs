using EasyPlanner.Data;
using System.Reflection;

namespace EasyPlanner.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            chkAccessMode.Checked = ModelPwd.IsEnabled();
            txtHeader.Text = ModelInfo.GetHeaderText();
        }

        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtOldPassword.Text) || string.IsNullOrEmpty(txtNewPassword.Text)))
            {
                if (ModelPwd.GetAccess(txtOldPassword.Text))
                {
                    ModelPwd.ChangePwd(txtNewPassword.Text);
                    lblPasswordResult.Text = "Password cambiata";
                    txtOldPassword.Text = String.Empty;
                    txtNewPassword.Text = String.Empty;
                }
                else
                    lblPasswordResult.Text = "Password errata";
            }
        }

        private void btnPasswordReset_Click(object sender, EventArgs e)
        {
            ModelPwd.ChangePwd("1234");
            lblPasswordResult.Text = "Password resettata";
        }

        private void chkAccessMode_CheckedChanged(object sender, EventArgs e)
        {
            ModelPwd.SetEnabled(chkAccessMode.Checked);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnHeaderSave_Click(sender, e);
            this.Close();
        }

        private void btnHeaderSave_Click(object sender, EventArgs e)
        {
            ModelInfo.SetHeaderText(txtHeader.Text);
            lblHeaderResult.Text = "Intestazione cambiata";
        }

        private void btnHeaderReset_Click(object sender, EventArgs e)
        {
            string header = "INVENTARIO  - " + DateTime.Now.ToShortDateString();
            ModelInfo.SetHeaderText(header);
            txtHeader.Text = header;
            lblHeaderResult.Text = "Intestazione resettata";
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                var location = Assembly.GetEntryAssembly();
                if (location != null)
                {
                    string sourceFile = Path.GetDirectoryName(location.Location) + @"\Data\PSDB.db";
                    string targetPath = Path.GetDirectoryName(location.Location) + @"\Data\Archivio\";

                    string timestamp = DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_').Replace(':', '_');

                    string destFile = Path.Combine(targetPath, "PSDB_" + timestamp + ".db");

                    Directory.CreateDirectory(targetPath);

                    System.IO.File.Copy(sourceFile, destFile, true);
                    MessageBox.Show("Backup eseguito correttamente");
                }
            }
            catch
            {
                MessageBox.Show("Errore nel salvataggio del backup. Procedere a un salvataggio manuale");
            }
        }
    }
}
