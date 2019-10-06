using MediaPerf.Infrastructure.Communs;
using MediaPerf.Modules.FactCli.MVVM.ViewModels;
using MediaPerf.Modules.FactCli.MVVM.Views;
using NLog;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPerf.Modules.FactCli
{
    public class FactCliModule : IModule  //
    {
        #region Constantes
        private const string MAIN_REGION_NAME = "MainRegion";
        #endregion

        #region Fields
        private IRegionManager _regionManager;
        public static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructor
        public FactCliModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        } 
        #endregion

        #region Methods

        /// <summary>
        /// -- Nouveau reservé prism 7.0.439  --
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _logger.Debug($"==> Initialisation de la region associée à la vue [EnvoiFichePaieView].");
            // On initialise les region qui s'affichent dès l'ouverture de l'application
            _regionManager.RegisterViewWithRegion(MAIN_REGION_NAME, typeof(FactCliView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        #endregion
    }
}
