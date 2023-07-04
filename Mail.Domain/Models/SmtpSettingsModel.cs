namespace Mail.Domain.Models
{
    internal class SmtpSettingsModel
    {
        /// <summary>
        /// Пароль отправителя письма.
        /// </summary>
        public string SenderPassword { get; init; }

        /// <summary>
        /// Хост SMTP-сервера.
        /// </summary>
        public string SmtpHost { get; init; }

        /// <summary>
        /// Порт SMTP-сервера.
        /// </summary>
        public int SmtpPort { get; init; }
    }
}
