using MessagePublisher.Client.Forms;
using MessagePublisher.Packets;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessagePublisher.Client.Extensions
{
    public static class ShowDialogExtensions
    {
        public static Task<bool> ShowDialogAsync(this Form self, NotificationPacket notificationPacket, Image image)
        {
            if (self == null) throw new ArgumentNullException("self");

            TaskCompletionSource<bool> completion = new TaskCompletionSource<bool>();
            var result = false;
            //begin invoke on main thread
            self.BeginInvoke((MethodInvoker)delegate {
                var form = new NotificationForm(notificationPacket, image);
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (form.ShowDialog(self) == DialogResult.OK)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                completion.SetResult(result);
            });
            return completion.Task;
        }
    }
}
