using AutoMapper;
using CustMgmt.Entities;
using CustMgmt.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustMgmt.Services
{
    public class NoteService : IService
    {

        public CustMgmtDbContext _dbContext { get; set; }
        private IMapper _mapper { get; }
        public NoteService(CustMgmtDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NoteDto> GetNoteAsync(Guid customerId, Guid noteId)
        {
            var note = await _dbContext.Set<Note>().SingleOrDefaultAsync(note => note.CustomerId == customerId && note.Id == noteId);
            return _mapper.Map<NoteDto>(note);
        }

        public Task<IEnumerable<NoteDto>> GetNotesAsync(Guid customerId)
        {
             
            var notes =  _dbContext.Set<Note>().Where(Note => Note.CustomerId == customerId).OrderByDescending(note=>note.CreatedAt).AsEnumerable();
            return Task.FromResult(_mapper.Map<IEnumerable<NoteDto>>(notes));
        }

        public async Task<NoteDto> CreateAsync(Guid customerId, NoteForCreationDto entityDto)
        {

            var Note = _mapper.Map<Note>(entityDto);
            Note.CustomerId = customerId;
            Note.CreatedAt = DateTime.UtcNow;
            _dbContext.Set<Note>().Add(Note);
            var result = await _dbContext.SaveChangesAsync();

            var NoteCreated = _mapper.Map<NoteDto>(Note);
            return NoteCreated;

        }

        public async Task<NoteDto> UpdateAsync(Guid customerId, NoteForUpdateDto entityDto)
        {
            var note = await _dbContext.Set<Note>().SingleOrDefaultAsync(note => note.CustomerId == customerId && note.Id == entityDto.Id);
            note.Content = entityDto.Content;
            note.ModifiedAt = DateTime.UtcNow;
            _dbContext.Set<Note>().Update(note);
            await _dbContext.SaveChangesAsync();

            var noteUpdated = _mapper.Map<NoteDto>(note);
            return noteUpdated;
        }

        public async Task<bool> DeleteAsync(Guid customerId,  Guid id)
        {
            var note = _dbContext.Set<Note>().Where(note=>note.CustomerId== customerId && note.Id == id).FirstOrDefault();
            note.IsDeleted = true;
            note.DeletedAt = DateTime.UtcNow;
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> IsExistAsync(Guid customerId, Guid noteId)
        {
            return await _dbContext.Set<Note>().AnyAsync(note => note.Id == noteId && note.CustomerId == customerId);
        }
    }
}