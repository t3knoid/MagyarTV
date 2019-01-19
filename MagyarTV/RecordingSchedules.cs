using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagyarTV
{
    class RecordingSchedules
    {

        public void Save()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MagyarTV\RecordingSchedules");

            key.SetValue("Setting1", "This is our setting 1");
            key.SetValue("Setting2", "This is our setting 2");
            key.Close();
        }

    }
}
