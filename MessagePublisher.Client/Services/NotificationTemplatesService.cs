using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePublisher.Models;
using RestSharp;

namespace MessagePublisher.Client.Services
{
    public class NotificationTemplatesService : INotificationTemplatesService
    {
        RestClient client = new RestClient("http://localhost:58995/api/");
        public NotificationTemplatesService()
        {

        }
        public IEnumerable<NotificationTemplate> GetAll()
        {
            RestRequest request = new RestRequest("NotificationTemlates", Method.GET);
            IRestResponse<List<NotificationTemplate>> response = client.Execute<List<NotificationTemplate>>(request);
            return response.Data;
        }

        public void Add(NotificationTemplate notificationTemplate)
        {
            var request = new RestRequest("NotificationTemlates", Method.POST);
            request.AddJsonBody(notificationTemplate);
            client.Execute(request);
        }

        public void Update(NotificationTemplate notificationTemplate)
        {
            var request = new RestRequest("NotificationTemlates", Method.PUT);
            request.AddJsonBody(notificationTemplate);
            client.Execute(request);
        }

        public void Remove(NotificationTemplate notificationTemplate)
        {
            var request = new RestRequest("NotificationTemlates", Method.DELETE);
            request.AddJsonBody(notificationTemplate);
            client.Execute(request);
        }
    }
}
