
using Mail.Domain.Interfaces.Repositories;
using Mail.Domain.Interfaces.Services;
using Mail.Domain.Logic;
using Mail.Domain.Models;

namespace Mail.Service.Implementation
{
    public class LetterService : ILetterService
    {
        private readonly ILetterRepository _letterRepository;

        public LetterService(ILetterRepository letterRepository)
        {
            _letterRepository = letterRepository;
        }

        /// <summary>
        /// Получить все письма.
        /// </summary>
        /// <returns>Список информации о письмах</returns>
        public async Task<IEnumerable<LetterInfo>> GetAll()
        {
            return await _letterRepository.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="letterInfo"></param>
        /// <returns></returns>
        public async Task SaveLatter(LetterInfo letterInfo)
        {
            await _letterRepository.SaveLatter(letterInfo);
        }

        /// <summary>
        /// Отправить письмо.
        /// </summary>
        /// <param name="letter">Письмо</param>
        /// <returns></returns>
        public async Task Send(Letter letter)
        {
            await new LetterSender().Send(letter);
        }
    }
}
