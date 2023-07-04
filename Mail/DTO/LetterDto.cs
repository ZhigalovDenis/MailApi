using Mail.Domain.Models;

namespace Mail.DTO
{
    public class LetterDto
    {
        /// <summary>
        /// Представляет тему письма.
        /// </summary>
        public string Subject { get; init; }

        /// <summary>
        /// Представляет тело письма.
        /// </summary>
        public string Body { get; init; }

        /// <summary>
        /// Представляет массив адресатов письма.
        /// </summary>
        public string[] Recipients { get; init; }

        /// <summary>
        /// Мапинг из модели <see cref="LetterDto"/> в модель <see cref="LetterModel"./>
        /// </summary>
        /// <param name="model">Объект данных <see cref="LetterDto"./></param>
        /// <returns>Взвращает модель <see cref="LetterModel"./></returns>
        public static LetterModel ToModel(LetterDto model)
        {
            return new LetterModel
            {
                Body = model.Body,
                Recipients = model.Recipients.ToArray(),
                Subject = model.Subject,
            };
        }

        /// <summary>
        /// Мапинг из модели <see cref="LetterModel"/> в модель <see cref="LetterDto"/>
        /// </summary>
        /// <param name="model">Объект данных <see cref="LetterModel"./></param>
        /// <returns>Взвращает модель <see cref="LetterDto"./></returns>
        public static LetterDto FromModel(LetterModel model) 
        {
            return new LetterDto
            {
                Body = model.Body,
                Recipients = model.Recipients,
                Subject = model.Subject,
            };
        }
    }
}


