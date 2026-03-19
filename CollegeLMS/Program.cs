// ============================================================
// COPYRIGHT NOTICE
// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba
// Student No:  20232990
// © 2026 Nicolette Mashaba. All rights reserved.
// ============================================================

using System;
using System.Windows.Forms;

namespace CollegeLMS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
        }
    }
}