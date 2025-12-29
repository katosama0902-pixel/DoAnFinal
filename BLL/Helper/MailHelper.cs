using System;
using System.Net;
using System.Net.Mail;

namespace DoAnFinal.Helper
{
    public class MailHelper
    {
        // ⚠️ QUAN TRỌNG: Hãy thay email_cua_ban@gmail.com bằng Email thật của bạn
        private static string _fromEmail = "katosama0902@gmail.com";

        // Mật khẩu ứng dụng 16 ký tự bạn đã lấy được
        private static string _password = "phaw edcg ptls lszz";

        public static bool SendMail(string toEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(_fromEmail, _password);

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                // Nếu lỗi thì in ra cửa sổ Output để debug
                System.Diagnostics.Debug.WriteLine("Lỗi gửi mail: " + ex.Message);
                return false;
            }
        }
    }
}