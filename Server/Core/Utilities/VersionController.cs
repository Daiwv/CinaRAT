using System;
using System.Windows.Forms;

namespace xServer.Core.Utilities
{
    public static class VersionController
    {
        private static Version actualVersion;
        private static Version myVersion;

        private static bool existsNewVersion()
        {
            var dif = actualVersion.CompareTo(myVersion);
            if (dif > 0)
                return true;
            else
                return false;
        }

        private static Version getActualVersion()
        {
            return new Version(new System.IO.StreamReader
                (
                    System.Net.WebRequest.Create(
                        @"https://raw.githubusercontent.com/wearelegal/CinaRAT/master/Version"
                    ).
                    GetResponse().
                    GetResponseStream()
                ).ReadToEnd()
            );
        }

        private static Version getMyVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            return new Version(fileVersionInfo.ProductVersion);
        }

        public static void init(bool force = false)
        {
            if (force)
            {
                myVersion = getMyVersion();
                actualVersion = getActualVersion();
                if (actualVersion.CompareTo(myVersion) > 0)
                {
                    DialogResult adr = MessageBox.Show("There is a new version of CinaRAT is available. Do you want download it?", "CinaRAT Version", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (adr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://github.com/wearelegal/CinaRAT/releases/tag/" + actualVersion);
                    }
                }
                else
                    MessageBox.Show("There is not a new version of CinaRAT is available.", "CinaRAT Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                myVersion = getMyVersion();
                actualVersion = getActualVersion();
                if (actualVersion.CompareTo(myVersion) > 0)
                {
                    DialogResult adr = MessageBox.Show("There is a new version of CinaRAT is available. Do you want download it?", "CinaRAT Version", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (adr == DialogResult.Yes){
                        System.Diagnostics.Process.Start("https://github.com/wearelegal/CinaRAT/releases/tag/" + actualVersion);
                    }
                }
            }
        }

    }
}
