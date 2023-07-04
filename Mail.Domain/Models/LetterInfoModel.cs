namespace Mail.Domain.Models
{
    public class LetterInfoModel
    {
        /// <summary>
        /// Информация о письме.
        /// </summary>
        public LetterModel Letter { get; init; }

        /// <summary>
        /// Статус отправки письма.
        /// </summary>
        public LetterStatusModel LetterStatus { get; init; }
    }
}