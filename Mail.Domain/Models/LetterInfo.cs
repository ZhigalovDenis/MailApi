namespace Mail.Domain.Models
{
    public class LetterInfo
    {
        /// <summary>
        /// Информация о письме.
        /// </summary>
        public Letter Letter { get; init; }

        /// <summary>
        /// Статус отправки письма.
        /// </summary>
        public LetterStatus LetterStatus { get; init; }
    }
}