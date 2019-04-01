using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.Models
{
    public class NotificationTemplate : EntityBase
    {
        private string message;
        private string name;
        private bool isFavorite;
        private int closeAfter;
        private bool hasToConfirm;
        private int imageIndex;
        public NotificationTemplate()
        {
            this.Message = "Enter notification message";
            this.Name = "Example notification";
        }

        public NotificationTemplate(NotificationTemplate notificationTemplate)
        {
            this.Message = notificationTemplate.Message;
            this.Name = notificationTemplate.Name;
        }

        public bool IsFavorite
        {
            get { return this.isFavorite; }
            set { this.SetProperty(ref this.isFavorite, value, "IsFavorite"); }
        }

        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value, "Name"); }
        }
        public string Message
        {
            get { return this.message; }
            set { this.SetProperty(ref this.message, value, "Message"); }
        }

        public int CloseAfter
        {
            get { return this.closeAfter; }
            set { this.SetProperty(ref this.closeAfter, value, "CloseAfter"); }
        }

        public bool HasToConfirm
        {
            get { return this.hasToConfirm; }
            set { this.SetProperty(ref this.hasToConfirm, value, "HasToConfirm"); }
        }

        public int ImageIndex
        {
            get { return this.imageIndex; }
            set { this.SetProperty(ref this.imageIndex, value, "ImageIndex"); }
        }



        public override string ToString()
        {
            return this.Name;
        }
    }
}
