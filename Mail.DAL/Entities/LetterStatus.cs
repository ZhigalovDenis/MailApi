﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mail.Domain.Models;

namespace Mail.DAL.Entities
{
    public class LetterStatus
    {
        /// <summary>
        /// Уникальный идентификатор статуса письма.
        /// </summary>
        [Key]
        [ForeignKey("Letter")]
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
        public Letter Letter { get; private init; }

        /// <summary>
        /// Создает экземпляр класса LetterStatusEnt из модели LetterInfo и сущности Letter.
        /// </summary>
        /// <param name="model">Модель LetterInfo.</param>
        /// <param name="entity">Сущность Letter.</param>
        /// <returns>Экземпляр класса LetterStatus.</returns>
        public static LetterStatus FromModel(LetterInfoModel model, Letter entity)
        {
            return new LetterStatus
            {
                Id = entity.Id,
                CreateAt = model.LetterStatus.CreateAt.UtcDateTime,
                Result = model.LetterStatus.Result,
                FailedMessage = model.LetterStatus.FailedMessage,
            };
        }

    }
}
