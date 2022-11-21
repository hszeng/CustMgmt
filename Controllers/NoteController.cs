using AutoMapper;
using CustMgmt.Entities;
using CustMgmt.Filters;
using CustMgmt.Models;
using CustMgmt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustMgmt.Controllers
{
    [Route("api/Customers/{customerId}/Notes")]
    [ApiController]
    [ServiceFilter(typeof(CheckCustomerExistFilterAttribute))]
    public class NoteController : ControllerBase
    {

        private ILogger<CustomerController> _logger { get; }
        private NoteService _noteService { get; }
        public NoteController(NoteService noteService, IMapper mapper, ILogger<CustomerController> logger)
        {
            _noteService = noteService;
        }

        [HttpPost()]
        public async Task<IActionResult> AddNoteAsync(Guid customerId, NoteForCreationDto noteForCreationDto)
        {
            var noteDto = await _noteService.CreateAsync(customerId, noteForCreationDto);
            if (noteDto == null)
            {
                throw new Exception("Create Note failed");
            }
            return CreatedAtRoute(nameof(GetNoteAsync), new {CustomerId = customerId, NoteId = noteDto.Id }, noteDto);
        }


        [HttpDelete("{noteId}")]
        public async Task<IActionResult> DeleteNoteAsync(Guid customerId, Guid noteId)
        {
            var note = await _noteService.GetNoteAsync(customerId, noteId);
            if (note == null)
            {
                return NotFound();
            }

            var result = await _noteService.DeleteAsync(customerId, noteId);
            if (!result)
            {
                throw new Exception("Delete Note failes");
            }
            return NoContent();
        }

        [HttpGet("{noteId}", Name = nameof(GetNoteAsync))]
        public async Task<ActionResult<NoteDto>> GetNoteAsync(Guid customerId, Guid noteId)
        {
            var noteDto = await _noteService.GetNoteAsync(customerId, noteId);
            if (noteDto == null)
            {
                return NotFound();
            }
            return noteDto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotesAsync(Guid customerId)
        {
            var noteDtos = await _noteService.GetNotesAsync(customerId);
            return Ok(noteDtos);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateNoteAsync(Guid customerId, NoteForUpdateDto updatedNote)
        { 
            if (!await _noteService.IsExistAsync(customerId, updatedNote.Id))
            {
                return NotFound();
            }
            var newNoteDto = await _noteService.UpdateAsync(customerId, updatedNote);
            if (newNoteDto == null)
            {
                throw new Exception("Update Note Failed");
            }
            return NoContent();
        }
    }
}