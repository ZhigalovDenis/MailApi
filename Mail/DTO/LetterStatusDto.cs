using Mail.Domain.Models;

namespace Mail.DTO
{
    public class LetterStatusDto
    {
        /// <summary>
        /// Представляет дату и время создания статуса отправки письма.
        /// </summary>
        public DateTimeOffset CreateAt { get; private init; }

        /// <summary>
        /// Представляет результат отправки письма.
        /// </summary>
        public string Result { get; private init; }

        /// <summary>
        /// Представляет сообщение об ошибке отправки письма (если есть).
        /// </summary>
        public string FailedMessage { get; private init; }

        /// <summary>
        /// Мапинг из модели <see cref="LetterStatus"/> в модель <see cref="LetterStatusDto"./>
        /// </summary>
        /// <param name="model">Объект данных <see cref="LetterStatus"./></param>
        /// <returns>Взвращает модель <see cref="LetterStatusDto"./></returns>
        public static LetterStatusDto FromModel(LetterStatus model)
        {
            return new LetterStatusDto
            {
                CreateAt = model.CreateAt,
                Result = model.Result,
                FailedMessage = model.FailedMessage,
            };
        }
    }
}
