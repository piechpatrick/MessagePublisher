using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.Client.Helpers
{
    /// <summary>
    /// Simple WaitForm manager
    /// </summary>
    public interface ISplashScreenManager
    {
        /// <summary>
        /// Indicate if WaitForm is already shown
        /// </summary>
        bool IsSplashScreenShown { get; }
        /// <summary>
        /// Show and close WaitForm
        /// </summary>
        /// <returns></returns>
        IDisposable LoadingOn();
        /// <summary>
        /// Show WaitForm
        /// </summary>
        void StartBusy();
        /// <summary>
        /// Close WaitForm
        /// </summary>
        void StopBusy();
    }
}
