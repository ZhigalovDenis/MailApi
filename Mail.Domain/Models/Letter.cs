namespace Mail.Domain.Models
{
    public class Letter
    {
        /// <summary>
        /// Тема письма.
        /// </summary>
        public string Subject { get; init; }

        /// <summary>
        /// Текст письма.
        /// </summary>
        public string Body { get; init; }

        /// <summary>
        /// Получатели письма.
        /// </summary>
        public string[] Recipients { get; init; }
    }

}
