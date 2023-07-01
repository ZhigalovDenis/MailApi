using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mail.Domain.Models;

namespace Mail.DAL.Entitys
{
    public class LetterStatusEnt
    {
        /// <summary>
        /// Уникальный идентификатор статуса письма.
        /// </summary>
        [Key]
        [ForeignKey("LetterEnt")]
        public int Id { get; private init; }

        /// <summary>
        /// Дата и время создания статуса.
        /// </summary>
        public DateTimeOffset CreateAt { get; private init; }

        /// <summary>
        /// Результат отправки письма.
        /// </summary>
        public string Result { get; private init; }

        /// <summary>
        /// Сообщение об ошибке отправки письма.
        /// </summary>
        public string FailedMessage { get; private init; }

        /// <summary>
        /// Связанное письмо.
        /// </summary>
        public LetterEnt LetterEnt { get; private init; }

        /// <summary>
        /// Создает экземпляр класса LetterStatusEnt из модели LetterInfo и сущности LetterEnt.
        /// </summary>
        /// <param name="model">Модель LetterInfo.</param>
        /// <param name="entity">Сущность LetterEnt.</param>
        /// <returns>Экземпляр класса LetterStatusEnt.</returns>
        public static LetterStatusEnt FromModel(LetterInfo model, LetterEnt entity)
        {
            return new LetterStatusEnt
            {
                Id = entity.Id,
                CreateAt = model.LetterStatus.CreateAt.UtcDateTime,
                Result = model.LetterStatus.Result,
                FailedMessage = model.LetterStatus.FailedMessage,
            };
        }

    }
}
