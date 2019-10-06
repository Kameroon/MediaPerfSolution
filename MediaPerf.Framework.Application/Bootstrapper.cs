using MediaPerf.Framework.App.MVVM.Views;
using MediaPerf.Infrastructure.Services.Contracts;
using MediaPerf.Infrastructure.Services.Implementations;
using MediaPerf.Module.Message;
using MediaPerf.Modules.FactCli;
using NLog;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace MediaPerf.Framework.App
{
    public class Bootstrapper : UnityBootstrapper
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public override void Run(bool runWithDefaultConfiguration)
        {
            _logger.Debug($"****** Démarrage de l'application. [Nom de la machine :] {Environment.MachineName} ********");
            base.Run(runWithDefaultConfiguration);
        }

        protected override DependencyObject CreateShell()
        {
            _logger.Debug($"==> Création du Shell.");
            return Container.TryResolve<Shell>();
        }

        protected override void InitializeShell()
        {
            _logger.Debug($"==> Initialisation du Shell.");
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            try
            {
                _logger.Debug($"==> Début configuration des differents modules.");
                // -- Apres avoir créer un module FichesPaieModule --
                Type factureClientModuleType = typeof(FactCliModule);
                ModuleCatalog.AddModule(new ModuleInfo
                {
                    ModuleName = factureClientModuleType.Name,
                    ModuleType = factureClientModuleType.AssemblyQualifiedName
                });

                Type messageModuleType = typeof(MessageModule);
                ModuleCatalog.AddModule(new ModuleInfo
                {
                    ModuleName = messageModuleType.Name,
                    ModuleType = messageModuleType.AssemblyQualifiedName
                });

                foreach (var module in ModuleCatalog.Modules)
                {
                    _logger.Debug($"==> Configuration du module [{module.ModuleName}].");
                }

                _logger.Debug($"==> Fin configuration des differents modules.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                throw;
            }
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            _logger.Debug($"==> Début configuration des differents containers.");
            Container.RegisterType<IDialogService, DialogService>();
            //Container.RegisterType<IEmailMessage, EmailMessage>();
            //Container.RegisterType<IMessageBoxConsolidateHelper, MessageBoxConsolidateHelper>();
            //Container.RegisterType<IDataTableFormExcelFileDataService, DataTableFormExcelFileDataService>();

            //Container.RegisterTypeForNavigation<UserDetail>("UserDetail");

            _logger.Debug($"==> Fin configuration des differents containers.");
        }
    }

    #region Methode d'extension 
    public static class UnityExtensions
    {
        public static void ResgisterTypeForNavigation<T>(this IUnityContainer container, string name)
        {
            container.RegisterType(typeof(object), typeof(T), name);
        }
    }
    #endregion
}
