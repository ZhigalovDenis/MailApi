using Mail.Domain.Models;

namespace Mail.Domain.Interfaces.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILetterRepository
    {
        /// <summary>
        /// Сохраняет информацию о письме.
        /// </summary>
        /// <param name="letterInfo">Информация о письме.</param>
        /// <returns>Асинхронная задача.</returns>
        Task SaveLatter(LetterInfo letterInfo);

        /// <summary>
        /// Возвращает список всех писем.
        /// </summary>
        /// <returns>Асинхронная задача, возвращающая список информации о письмах.</returns>
        Task<IEnumerable<LetterInfo>> GetAll();
    }
}
