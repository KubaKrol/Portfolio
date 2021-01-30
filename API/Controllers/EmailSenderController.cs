using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmailSenderController : BaseApiController
    {
        private readonly IEmailService _emailService;

        public EmailSenderController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("sendmail")]
        public ActionResult<EmailDto> Send(EmailDto emailDto)
        {
            emailDto.Message += "\n\n From: " + emailDto.Name;
            emailDto.Message += "\n PhoneNumber: " + emailDto.PhoneNumber;
            emailDto.Message += "\n Email: " + emailDto.Email;
            _emailService.Send(emailDto.Subject, emailDto.Message);
            return emailDto;
        }
    }
}