﻿using DataAccessLayer;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists(Repository.SETTINGS_PATH))
            {
                File.WriteAllText(Repository.SETTINGS_PATH, Repository.DEFAULT_SETTINGS);
                Application.Run(new Settings());
            }
            else
            {
                Application.Run(new MainForm());
            }
            
        }
    }
}
