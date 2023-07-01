using Mail.DAL.Entitys;
using Mail.Domain.Interfaces.Repositories;
using Mail.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Mail.DAL.Repositories
{
    public class LetterRepository : ILetterRepository
    {
        private readonly ApplicationDbContext _db;

        public LetterRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Получить все письма с информацией о статусе.
        /// </summary>
        /// <returns>Коллекция писем с информацией о статусе.</returns>
        public async Task<IEnumerable<LetterInfo>> GetAll()
        {
            var query = from letter in _db.Letters
                        join letterStatus in _db.LetterStatuses on letter.Id equals letterStatus.Id
                        select new LetterInfo
                        {
                            Letter = new Letter
                            {
                                Body = letter.Body,
                                Recipients = letter.Recipients,
                                Subject = letter.Subject,
                            },
                            LetterStatus = new LetterStatus
                            {
                                CreateAt = letterStatus.CreateAt,
                                FailedMessage = letterStatus.FailedMessage,
                                Result = letterStatus.Result,
                            }
                        };

            return await query.ToListAsync();
        }

        /// <summary>
        /// Сохранить письмо и его статус.
        /// </summary>
        /// <param name="letterInfo">Информация о письме и его статусе.</param>
        /// <returns>Задача, представляющая асинхронную операцию сохранения.</returns>
        public async Task SaveLatter(LetterInfo letterInfo)
        {
            var letterEnt = LetterEnt.FromModel(letterInfo);
            _db.Letters.Add(letterEnt);
            await _db.SaveChangesAsync();

            var letterStatusEnt = LetterStatusEnt.FromModel(letterInfo, letterEnt);
            _db.LetterStatuses.Add(letterStatusEnt);
            await _db.SaveChangesAsync();
        }

    }
}