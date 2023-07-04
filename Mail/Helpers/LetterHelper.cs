using Mail.Domain.Models;
using Mail.DTO;
using System.Text.RegularExpressions;

namespace Mail.Helpers
{
    public  static class LetterHelper
    {
        private const string EmailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        /// <summary>
        /// Проверка входных данных на валидность.
        /// </summary>
        /// <param name="letter">Объект данных <see cref="LetterDto"./></param>
        /// <returns>Возвращает значение <see cref="true"/>, если входные данные являются валидными, в противном случае - <see cref="false"./></returns>
        public static bool IsDataValid(LetterDto letter) 
        {
            if (string.IsNullOrWhiteSpace(letter.Subject) || !letter.Recipients.All(x => !string.IsNullOrWhiteSpace(x)))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Провека соответствия для Email формата.
        /// </summary>
        /// <param name="recipients">Список Email адресов <see cref="string[]"./></param>
        /// <returns>Возвращает значение <see cref="true"/>, если входные данные являются валидными, в противном случае - <see cref="false"./></returns>
        public static bool IsValidEmail(string[] recipients)
        {
            foreach (var emailAddress in recipients)
            {
                if(!Regex.IsMatch(emailAddress, EmailPattern))
                {
                    return false;
                }                 
            }

            return true;
        }

        /// <summary>
        /// Мапинг из модели <see cref="LetterDto"/> в модель <see cref="LetterInfoModel"./>
        /// </summary>
        /// <param name="letterDto">Объект данных <see cref="LetterDto"./></param>
        /// <param name="result">Статус отправки <see cref="ResultStatus"./></param>
        /// <param name="failedMessage">Сообщение об ошибке <see cref="string"./></param>
        /// <returns>Возвращает объект <see cref="LetterInfoModel"./></returns>
        public static LetterInfoModel CreateInfo(LetterDto letterDto, ResultStatus result, string failedMessage)
        {
            return new LetterInfoModel
            {
                Letter = LetterDto.ToModel(letterDto),
                LetterStatus = new LetterStatusModel
                {
                    CreateAt = DateTime.Now,
                    Result = result.ToString(),
                    FailedMessage = failedMessage,
                },
            };
        }
    }
}
