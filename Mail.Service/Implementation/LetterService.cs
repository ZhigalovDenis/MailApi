
using Mail.Domain.Interfaces.Logic;
using Mail.Domain.Interfaces.Repositories;
using Mail.Domain.Interfaces.Services;
using Mail.Domain.Models;

namespace Mail.Service.Implementation
{
    public class LetterService : ILetterService
    {
        private readonly ILetterRepository _letterRepository;
        private readonly ILetterSender _letterSender;

        public LetterService(ILetterRepository letterRepository, ILetterSender letterSender)
        {
            _letterRepository = letterRepository;
            _letterSender = letterSender;
        }

        /// <summary>
        /// Получить все письма.
        /// </summary>
        /// <returns>Список информации о письмах</returns>
        public async Task<IEnumerable<LetterInfoModel>> GetAll()
        {
            return await _letterRepository.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="letterInfo"></param>
        /// <returns></returns>
        public async Task SaveLetter(LetterInfoModel letterInfo)
        {
            await _letterRepository.SaveLetter(letterInfo);
        }

        /// <summary>
        /// Отправить письмо.
        /// </summary>
        /// <param name="letter">Письмо</param>
        /// <returns></returns>
        public async Task Send(LetterModel letter)
        {
            await _letterSender.Send(letter);
        }
    }
}
