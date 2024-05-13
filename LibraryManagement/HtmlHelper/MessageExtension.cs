using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement
{
    public static class MessageExtension
    {
        public enum MessageType
        {
            Success = 0,
            Info = 1,
            Warning = 2,
            Error = 3
        }

        /// <summary>
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        /// <param name="showAfterRedirect"></param>
        public static void ShowMessage(this Controller controller, MessageType messageType, string message,
            bool showAfterRedirect = false)
        {
            string messageTypeKey = messageType.ToString();
            if (showAfterRedirect)
            {
                controller.TempData[messageTypeKey] = message;
                controller.TempData["MessageTypeKey"] = messageTypeKey.ToString();
            }
            else
            {
                controller.ViewData[messageTypeKey] = message;
                controller.ViewData["MessageTypeKey"] = messageTypeKey.ToString();
            }
        }

        /// <summary>
        ///     Render all messages that have been set during execution of the controller action.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="clearMessage"></param>
        /// <returns></returns>
        public static HtmlString RenderMessages(this HtmlHelper htmlHelper, bool clearMessage = true)
        {
            string messages = String.Empty;

            string messageType = htmlHelper.ViewContext.ViewData.ContainsKey("MessageTypeKey")
                ? Convert.ToString(htmlHelper.ViewContext.ViewData["MessageTypeKey"])
                : htmlHelper.ViewContext.TempData.ContainsKey("MessageTypeKey")
                    ? Convert.ToString(htmlHelper.ViewContext.TempData["MessageTypeKey"])
                    : null;
            if (messageType != null)
            {
                object message = htmlHelper.ViewContext.ViewData.ContainsKey(messageType)
                    ? htmlHelper.ViewContext.ViewData[messageType]
                    : htmlHelper.ViewContext.TempData.ContainsKey(messageType)
                        ? htmlHelper.ViewContext.TempData[messageType]
                        : null;
                if (message != null)
                {
                    string _class = string.Empty;
                    string _strHtml = "";
                    string _messageTypeUpperCase = messageType.ToUpper();
                    switch (_messageTypeUpperCase)
                    {
                        case "SUCCESS":
                            _class = "alert-success";
                            _strHtml += "<i class='fa fa-check-circle'></i><strong> Success!</strong> ";
                            break;
                        case "ERROR":
                            _class = "alert-danger";
                            _strHtml += "<i class='fa fa-times-circle'></i><strong> Error!</strong> ";
                            break;
                        case "INFO":
                            _class = "alert-info";
                            _strHtml += "<i class='fa fa-info-circle'></i><strong> Information!</strong> ";
                            break;
                        case "WARNING":
                            _class = "alert-warning";
                            _strHtml += "<i class='fa fa-exclamation-triangle'></i><strong> Warning!</strong> ";
                            break;
                    }
                    var messageBoxBuilder = new TagBuilder("div");
                    messageBoxBuilder.Attributes["onclick"] = "$(this).fadeOut(3000)";
                    messageBoxBuilder.AddCssClass(string.Format("alert {0} alert-dismissable", _class));


                    messageBoxBuilder.InnerHtml = "<button class='close' data-dismiss='alert'>×</button>"
                                            + _strHtml + message.ToString();
                    messages += messageBoxBuilder.ToString();
                    ClearMessages(htmlHelper, messageType);
                }
            }
            return MvcHtmlString.Create(messages);
        }

        /// <summary>
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="messageType"></param>
        private static void ClearMessages(HtmlHelper htmlHelper, string messageType)
        {
            htmlHelper.ViewContext.ViewData[messageType] = htmlHelper.ViewContext.TempData[messageType] = null;
            htmlHelper.ViewContext.ViewData["MessageTypeKey"] = htmlHelper.ViewContext.TempData["MessageTypeKey"] = null;
        }
    }
}
