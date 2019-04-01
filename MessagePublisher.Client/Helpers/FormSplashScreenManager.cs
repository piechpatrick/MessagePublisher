using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using MessagePublisher.Client.BaseViews;

namespace MessagePublisher.Client.Helpers
{
    public class FormSplashScreenManager : ISplashScreenManager
    {
        private readonly Form form;
        private BusyStateHandler busyHandler;

        internal FormSplashScreenManager(Form form)
        {
            this.form = form;
            busyHandler = new BusyStateHandler();
        }

        public bool IsSplashScreenShown { get; private set; }

        public IDisposable LoadingOn()
        {
            return busyHandler.StartBusy(this);
        }

        public void StartBusy()
        {
            SplashScreenManager.ShowForm(form, typeof(TrWaitForm), true, true);
            IsSplashScreenShown = true;
        }

        public void StopBusy()
        {
            SplashScreenManager.CloseForm(false, 2, form);
            IsSplashScreenShown = false;
        }

    }

    internal sealed class BusyStateHandler
    {
        internal ISplashScreenManager SplashManager { get; private set; }
        internal IDisposable StartBusy(ISplashScreenManager splashManager)
        {
            SplashManager = splashManager;
            SplashManager.StartBusy();
            return new DisposableLoadingHandler(this);
        }
    }

    internal sealed class DisposableLoadingHandler : IDisposable
    {
        internal BusyStateHandler busyHandler { get; private set; }
        public DisposableLoadingHandler(BusyStateHandler busyStateHandler)
        {
            busyHandler = busyStateHandler;
        }
        public void Dispose()
        {
            busyHandler.SplashManager.StopBusy();
        }
    }
}
