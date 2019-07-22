﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reloaded.Mod.Launcher.Models.ViewModel;
using Reloaded.Mod.Shared;

namespace Reloaded.Mod.Launcher.Utility
{
    /// <summary>
    /// Class that provides automatic injection to applications with the feature enabled.
    /// </summary>
    public class AutoInjector
    {
        private MainPageViewModel _mainPageViewModel;
        private ProcessWatcher _processWatcher;

        /* Construction */
        public AutoInjector(MainPageViewModel mainPageViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
            _processWatcher = new ProcessWatcher();
            _processWatcher.OnNewProcess += ProcessWatcherOnOnNewProcess;
        }

        /* Implementation */
        private void ProcessWatcherOnOnNewProcess(Process newProcess)
        {
            try
            {
                string fullPath = newProcess.GetExecutablePath();
                var config = _mainPageViewModel.Applications.FirstOrDefault(x => string.Equals(x.ApplicationConfig.AppLocation, fullPath, StringComparison.OrdinalIgnoreCase));
                if (config != null)
                {
                    var appInjector = new ApplicationInjector(newProcess);
                    appInjector.Inject();
                }
            }
            catch (Exception ex) { }
        }
    }
}
