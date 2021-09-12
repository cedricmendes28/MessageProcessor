using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using MessageProcessor.Application.Utility;
using MessageProcessor.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using MessageProcessor.Domain.DomainModels;
using Newtonsoft.Json;
using MessageProcessor.Domain.Interfaces;

namespace MessageProcessor.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ILogger<MessagingController> _logger;

        public MessagingController(
            IMessageRepository messageRepository,
            ILogger<MessagingController> logger)
        {
            _messageRepository = messageRepository;
            _logger = logger;
        }

        /// <summary>
        /// Verifies if the inputObject is valid and has correct json message schema
        /// Saves the message to database
        /// </summary>
        /// <param name="inputObject"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] dynamic inputObject)
        {
            try
            {
                var obj = MessageParser.TryParse(inputObject);

                var message = new Message(obj.ToString());

                await _messageRepository.CreateAsync(message);

                return Ok();
            }
            catch (MessageParsingException msgEx)
            {
                _logger.LogError(msgEx.ToString());

                return StatusCode(
                    StatusCodes.Status422UnprocessableEntity,
                    msgEx.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e.Message);
            }
        }

        /// <summary>
        /// Retrieves all the messages from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Message), StatusCodes.Status200OK)]
        public async Task<ActionResult<Message>> GetAll()
        {
            try
            {
                return Ok(await _messageRepository.GetAllAsync());
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(
                    StatusCodes.Status500InternalServerError, 
                    e.Message);
            }
        }
    }
}
