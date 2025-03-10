﻿using System.ComponentModel;
using System.ServiceProcess;

namespace chz.WindowsServices.Host
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        ServiceProcessInstaller processInstaller;

        ServiceInstaller unloadServiceInstaller;
        ServiceInstaller loadServiceInstaller;
        ServiceInstaller directoryServiceInstaller;

        public Installer()
        {
            InitializeComponent();

            processInstaller = new ServiceProcessInstaller();

            unloadServiceInstaller = new ServiceInstaller();
            loadServiceInstaller = new ServiceInstaller();
            directoryServiceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;

            unloadServiceInstaller.StartType = ServiceStartMode.Automatic;
            unloadServiceInstaller.ServiceName = "Служба отправки документов в МДЛП.";

            loadServiceInstaller.StartType = ServiceStartMode.Automatic;
            loadServiceInstaller.ServiceName = "Служба получения документов из МДЛП.";

            directoryServiceInstaller.StartType = ServiceStartMode.Automatic;
            directoryServiceInstaller.ServiceName = "Служба загрузки справочников из МДЛП.";

            Installers.Add(loadServiceInstaller);
            Installers.Add(unloadServiceInstaller);
            Installers.Add(directoryServiceInstaller);

            Installers.Add(processInstaller);
        }
    }
}
