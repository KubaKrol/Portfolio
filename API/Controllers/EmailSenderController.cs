using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmailSenderController : BaseApiController
    {
        private readonly IEmailService _emailService;
        private DataContext _context;

        public EmailSenderController(IEmailService emailService, DataContext context)
        {
            _emailService = emailService;
            _context = context;
        }

        [HttpPost("sendmail")]
        public ActionResult<EmailDto> Send(EmailDto emailDto)
        {
            emailDto.Message += "\n\n From: " + emailDto.Name;
            emailDto.Message += "\n PhoneNumber: " + emailDto.PhoneNumber;
            emailDto.Message += "\n Email: " + emailDto.Email;
            _emailService.Send(emailDto.Subject, emailDto.Message);

            var email = new Email
            {
                Name = emailDto.Name,
                PersonEmail = emailDto.Email,
                PhoneNumber = emailDto.PhoneNumber,
                Subject = emailDto.Subject,
                Message = emailDto.Message
            };

            _context.Emails.Add(email);
            _context.SaveChanges();

            return emailDto;
        }
    }
}