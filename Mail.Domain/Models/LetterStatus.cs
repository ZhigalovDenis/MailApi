namespace Mail.Domain.Models
{
    public class LetterStatus
    {
        /// <summary>
        /// Дата и время создания письма.
        /// </summary>
        public DateTimeOffset CreateAt { get; init; }

        /// <summary>
        /// Результат отправки письма.
        /// </summary>
        public string Result { get; init; }

        /// <summary>
        /// Сообщение об ошибке при отправке письма (если есть).
        /// </summary>
        public string FailedMessage { get; init; }
    }
}
