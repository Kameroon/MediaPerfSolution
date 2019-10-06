using MediaPerf.Module.Message.MVVM.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPerf.Module.Message
{
    public class MessageModule : IModule  //
    {
        #region Constantes
        private const string MESSAGE_REGION_NAME = "MessageRegion";
        #endregion

        #region Fields
        private IRegionManager _regionManager;
        //public static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructor
        public MessageModule(IRegionManager regionManager)
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
            //_logger.Debug($"==> Initialisation de la region associée à la vue [EnvoiFichePaieView].");
            // On initialise les region qui s'affichent dès l'ouverture de l'application
            _regionManager.RegisterViewWithRegion(MESSAGE_REGION_NAME, typeof(MessageView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        #endregion
    }
}
