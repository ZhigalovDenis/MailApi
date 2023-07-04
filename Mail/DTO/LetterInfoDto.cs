using Mail.Domain.Models;

namespace Mail.DTO
{
    public class LetterInfoDto
    {
        /// <summary>
        /// Представляет объект данных письма.
        /// </summary>
        public LetterDto Letter { get; private init; }

        /// <summary>
        /// Представляет статус отправки письма.
        /// </summary>
        public LetterStatusDto LetterStatus { get; private init; }

        /// <summary>
        /// Мапинг из модели <see cref="LetterInfoModel"/> в модель <see cref="LetterInfoDto"./>
        /// </summary>
        /// <param name="model">Объект данных <see cref="LetterInfoModel"./></param>
        /// <returns>Взвращает модель <see cref="LetterInfoDto"./></returns>
        public static LetterInfoDto fromModel(LetterInfoModel model)
        {
            return new LetterInfoDto
            {
                Letter = LetterDto.FromModel(model.Letter),
                LetterStatus = LetterStatusDto.FromModel(model.LetterStatus),
            };
        }
    }
}
