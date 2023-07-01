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
        /// Мапинг из модели <see cref="LetterDto"/> в модель <see cref="Letter"./>
        /// </summary>
        /// <param name="model">Объект данных <see cref="LetterDto"./></param>
        /// <returns>Взвращает модель <see cref="Letter"./></returns>
        public static Letter ToModel(LetterDto model)
        {
            return new Letter
            {
                Body = model.Body,
                Recipients = model.Recipients.ToArray(),
                Subject = model.Subject,
            };
        }

        /// <summary>
        /// Мапинг из модели <see cref="Letter"/> в модель <see cref="LetterDto"/>
        /// </summary>
        /// <param name="model">Объект данных <see cref="Letter"./></param>
        /// <returns>Взвращает модель <see cref="LetterDto"./></returns>
        public static LetterDto FromModel(Letter model) 
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


