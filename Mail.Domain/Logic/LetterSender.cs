using Mail.Domain.Interfaces.Logic;
using System.Net.Mail;
using Mail.Domain.Models;

namespace Mail.Domain.Logic
{
    public class LetterSender : ILetterSender
    {
        private const string SenderEmail = "1@mail.ru";
        private const string SendError = "Ошибка при отправке письма.";

        /// <summary>
        /// Отправляет письмо.
        /// </summary>
        /// <param name="letter">Объект письма.</param>
        /// <returns>Асинхронная задача.</returns>
        /// <exception cref="SmtpException">Ошибка при отправке письма.</exception>
        public async Task Send(LetterModel letter)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(SenderEmail);

            foreach (var recipient in letter.Recipients)
            {
                mailMessage.To.Add(recipient);
            }         

            mailMessage.Subject = letter.Subject;
            mailMessage.Body = letter.Body;
            mailMessage.IsBodyHtml = true;

            var smtpClient = await new SmtpConfigurator().ConfigureClient(SenderEmail);

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (SmtpException)
            {
                throw new SmtpException(SendError);
            }

        }
    }
}
