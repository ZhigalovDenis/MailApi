using Mail.Domain.Models;
namespace Mail.DAL.Entities;

public class Letter
{
    /// <summary>
    /// Уникальный идентификатор письма.
    /// </summary>
    public int Id { get; private init; }

    /// <summary>
    /// Тема письма.
    /// </summary>
    public string Subject { get; private init; }

    /// <summary>
    /// Текст письма.
    /// </summary>
    public string Body { get; private init; }

    /// <summary>
    /// Получатели письма.
    /// </summary>
    public string[] Recipients { get; private init; }

    /// <summary>
    /// Связанный статус письма.
    /// </summary>
    public LetterStatus LetterStatus { get; private init; }

    /// <summary>
    /// Создает экземпляр класса LetterEnt из модели LetterInfo.
    /// </summary>
    /// <param name="model">Модель LetterInfo.</param>
    /// <returns>Экземпляр класса LetterEnt.</returns>
    public static Letter FromModel(LetterInfoModel model)
    {
        return new Letter
        {
            Subject = model.Letter.Subject,
            Body = model.Letter.Body,
            Recipients = model.Letter.Recipients,
        };
    }
}
