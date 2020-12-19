using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;


//services.AddHttpContextAccessor();  services.AddSession(); app.UseSession();  must be in Startup
//Ref projects https://github.com/uacaps/BootstrapNotifications https://github.com/mouse0270/bootstrap-notify 
// front-end js to sort out https://alertifyjs.com/notifier.html
public class SecondNotification
{
    //message|type format in session
    public List<(string, string)> GetNotification()
    {
        var lst = new List<(string, string)>();
        for (int i = 0; i < 10; i++)
        {
            var message = new HttpContextAccessor().HttpContext.Session.GetString($"SecondNotification{i}");
            if (message == null)
            {
                return lst;
            }
            var tupleMessage = message.Split('|');

            if (string.IsNullOrEmpty(tupleMessage[1])) return lst;
            else SetNotification("", "", i);

            var NotifyValue = typeof(NotificationEnum).GetTypeInfo().DeclaredMembers.SingleOrDefault(x => x.Name == tupleMessage[1].Trim())?.GetCustomAttribute<EnumMemberAttribute>(false)?.Value;

            lst.Add((tupleMessage[0], NotifyValue ?? ""));
        }
        return lst;
    }

    public void SetNotification(string message, string type, int notificationId = 100)
    {
        for (int i = 0; i < 10; i++)
        {
            if (notificationId != 100)
            {
                i = notificationId;
            }
            var existingMessage = new HttpContextAccessor().HttpContext.Session.GetString($"SecondNotification{i}");
            if (string.IsNullOrEmpty(existingMessage) || existingMessage == "|" || (message == "" && type == ""))
            {
                new HttpContextAccessor().HttpContext.Session.SetString($"SecondNotification{i}", $"{message}|{type.ToLower()}");
                break;
            }
        }
    }

    public enum NotificationEnum
    {
        [EnumMember(Value = "alert-secondary")] secondary,
        [EnumMember(Value = "alert-warning")] warning,
        [EnumMember(Value = "alert-success")] success,
        [EnumMember(Value = "alert-danger")] danger,
        [EnumMember(Value = "alert-info")] info,
        [EnumMember(Value = "alert-primary")] primary,
        [EnumMember(Value = "alert-light")] light,
        [EnumMember(Value = "alert-dark")] dark,
    }
}
