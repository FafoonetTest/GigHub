using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;
using GigHub.Repositories;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly NotificationRepository _notificationRepository;

        public NotificationsController()
        {
            _notificationRepository = new NotificationRepository();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var notifications = _notificationRepository.GetAllNotificationsByUser(User.Identity.GetUserId());
            
            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userNotifications = _notificationRepository.GetAllUserNotificationsByUser(User.Identity.GetUserId());

            foreach (var un in userNotifications)
            {
                un.Read();
            }

            _notificationRepository.Complete();

            return Ok();
        }
    }
}
