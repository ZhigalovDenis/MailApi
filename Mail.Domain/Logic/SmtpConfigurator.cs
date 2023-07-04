using Mail.Domain.Models;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

namespace Mail.Domain.Logic
{
    internal class SmtpConfigurator
    {
        private readonly SmtpSettingsModel _emailSettings;
        private readonly SmtpSettingsModel _emailSettings1;
        private const string ConfigPath = "SMTPConfig.json";

        public SmtpConfigurator()
        {

            try
            {
                string json;
                using (StreamReader reader = new StreamReader(ConfigPath))
                {
                    json = reader.ReadToEnd();
                }

                _emailSettings = JsonConvert.DeserializeObject<SmtpSettingsModel>(json);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Конфигурирует клиент SMTP для отправки писем.
        /// </summary>
        /// <param name="senderEmail">Email отправителя.</param>
        /// <returns>Объект SmtpClient.</returns>
        public async Task<SmtpClient> ConfigureClient(string senderEmail)
        {
            SmtpClient smtpClient = new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort);
            smtpClient.Credentials = new NetworkCredential(senderEmail, _emailSettings.SenderPassword);
            smtpClient.EnableSsl = true;

            return await Task.FromResult(smtpClient);
        }
    }
}
