using Mail.Domain.Interfaces.Services;
using Mail.DTO;
using Mail.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Mail.Controllers
{
    [ApiController]
    [Route("/api/mails")]
    public class LetterController : ControllerBase
    {
        private const string EmptyMessage ="";
        private readonly ILetterService _letterService;

        public LetterController(ILetterService mailService)
        {
            _letterService = mailService;
        }

        /// <summary>
        /// Отправка письма.
        /// </summary>
        /// <param name="letterDto">Объект данных <see cref="LetterDto"./></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendMail([FromBody] LetterDto letterDto)
        {
            if (!LetterHelper.IsDataValid(letterDto))
            {
                return BadRequest();
            }

            if (!LetterHelper.IsValidEmail(letterDto.Recipients))
            {
                return BadRequest();
            }

            try
            {
                await _letterService.Send(LetterDto.ToModel(letterDto));

                await _letterService.SaveLetter(LetterHelper.CreateInfo(letterDto, ResultStatus.Ok, EmptyMessage));
            }
            catch (SmtpException ex)
            {
                await _letterService.SaveLetter(LetterHelper.CreateInfo(letterDto, ResultStatus.Failed, ex.Message));

                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Получение данных
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _letterService.GetAll();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

    }
}