using MessagePublisher.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessagePublisher.Client.Controls
{
    /// <summary>
    /// The BaseUserControl
    /// </summary>
    public abstract class BaseForm : Form
    {
        private ISplashScreenManager BusyManager { get; set; }

        /// <summary>
        /// Default ctr, this.BusyManager = new TrControlSplashScreenManager(this);
        /// </summary>
        public BaseForm()
        {
            this.BusyManager = new FormSplashScreenManager(this);
        }

        /// <summary>
        /// Use this to invoke TrWaitForm
        /// </summary>
        /// <returns>DisposableLoadingHandler</returns>
        protected IDisposable LoadingOn()
        {
            return this.BusyManager.LoadingOn();
        }
    }
}
