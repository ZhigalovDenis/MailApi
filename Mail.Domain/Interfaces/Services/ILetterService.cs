using Mail.Domain.Models;

namespace Mail.Domain.Interfaces.Services
{
    /// <summary>
    /// Сервис для работы с письмами.
    /// </summary>
    public interface ILetterService
    {
        /// <summary>
        /// Отправляет письмо.
        /// </summary>
        /// <param name="letter">Объект письма.</param>
        /// <returns>Асинхронная задача.</returns>
        Task Send(LetterModel letter);

        /// <summary>
        /// Сохраняет информацию о письме.
        /// </summary>
        /// <param name="letterInfo">Информация о письме.</param>
        /// <returns>Асинхронная задача.</returns>
        Task SaveLetter(LetterInfoModel letterInfo);

        /// <summary>
        /// Возвращает список всех писем.
        /// </summary>
        /// <returns>Асинхронная задача, возвращающая список информации о письмах.</returns>
        Task<IEnumerable<LetterInfoModel>> GetAll();
    }

}
