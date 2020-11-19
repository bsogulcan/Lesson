using Abp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain
{
    [Serializable]
    class SentHomeworkInfoNotificationData: NotificationData
    {
        public string Summary { get; set; }

        public SentHomeworkInfoNotificationData(string summary)
        {
            Summary = summary;
        }

    }
}
