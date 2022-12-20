using GUI_Final_Project;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
namespace GUI_Final_Project
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
*/
namespace WebBrowserIEVersionTest

{

    static class Program

    {

        static Mutex mutex = new System.Threading.Mutex(false, "jMutex");



        /// <summary>

        /// The main entry point for the application.

        /// </summary>

        [STAThread]

        static void Main()

        {

            if (!mutex.WaitOne(TimeSpan.FromSeconds(2), false))

            {

                //another application instance is running

                return;

            }



            try

            {

                Application.EnableVisualStyles();

                Application.SetCompatibleTextRenderingDefault(false);



                var targetApplication = Process.GetCurrentProcess().ProcessName + ".exe";

                int browserver = 7;

                int ie_emulation = 11999;



                using (WebBrowser wb = new WebBrowser())

                {

                    browserver = wb.Version.Major;





                    if (browserver >= 11)

                        ie_emulation = 11001;

                    else if (browserver == 10)

                        ie_emulation = 10001;

                    else if (browserver == 9)

                        ie_emulation = 9999;

                    else if (browserver == 8)

                        ie_emulation = 8888;

                    else

                        ie_emulation = 7000;

                }



                try

                {

                    //string tmp = Properties.Settings.Default.Properties.

                    SetIEVersioneKeyforWebBrowserControl(targetApplication, ie_emulation);

                    Application.Run(new Form1());



                }

                catch (Exception ex1)

                {



                }



            }

            catch (Exception ex2)

            {





            }
            finally

            {

                mutex.ReleaseMutex();

            }

        }



        private static void SetIEVersioneKeyforWebBrowserControl(string appName, int ieval)

        {

            RegistryKey Regkey = null;

            try

            {

                Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);



                //If the path is not correct or 

                //If user't have priviledges to access registry 

                if (Regkey == null)

                {

                    MessageBox.Show("Application FEATURE_BROWSER_EMULATION Failed - Registry key Not found");

                    return;

                }



                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));



                //Check if key is already present 

                if (FindAppkey == ieval.ToString())

                {

                    MessageBox.Show("Application FEATURE_BROWSER_EMULATION already set to " + ieval);

                    Regkey.Close();

                    return;

                }



                //If key is not present or different from desired, add/modify the key , key value 

                Regkey.SetValue(appName, unchecked((int)ieval), RegistryValueKind.DWord);



                //check for the key after adding 

                FindAppkey = Convert.ToString(Regkey.GetValue(appName));



                if (FindAppkey == ieval.ToString())

                {

                    MessageBox.Show("Application FEATURE_BROWSER_EMULATION changed to " + ieval + "; changes will be visible at application restart");

                }

                else

                {

                    MessageBox.Show("Application FEATURE_BROWSER_EMULATION setting failed; current value is  " + ieval);

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("Application FEATURE_BROWSER_EMULATION setting failed; " + ex.Message);

            }

            finally

            {

                //Close the Registry 

                if (Regkey != null)

                    Regkey.Close();

            }

        }

    }

}
