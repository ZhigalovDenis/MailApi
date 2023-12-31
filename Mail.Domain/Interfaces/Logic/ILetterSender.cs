﻿
using Mail.Domain.Models;

namespace Mail.Domain.Interfaces.Logic
{
    public interface ILetterSender
    {
        /// <summary>
        /// Отправляет письмо.
        /// </summary>
        /// <param name="letter">Письмо для отправки.</param>
        /// <returns>Асинхронная задача.</returns>
        Task Send(LetterModel letter);
    }
}
