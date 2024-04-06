namespace LiftLog.WebApi.Utils.Models.Emailing
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public MailRequest(string SendTo, string EmailSubject, string EmailBody)
        {
            ToEmail = SendTo;
            Subject = EmailSubject;
            Body = EmailBody;
        }
    }
}
