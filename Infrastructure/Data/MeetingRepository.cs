using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MeetingRepository : IMeetingRepository
{
    private readonly ServiTurnosDbContext _context;

    public MeetingRepository(ServiTurnosDbContext context)
    {
        _context = context;
    }

    public List<Meeting> GetMeetings()
    {
        return _context.Meetings
            .Include(meeting => meeting.Customer)
            .Include(meeting => meeting.Professional)
            .ToList();
    }


    public Meeting? GetMeetingById(int id)
    {
        return _context.Meetings
            .Include(x => x.Customer)
            .Include(x => x.Professional)
            .FirstOrDefault(x => x.Id == id);
    }

    public List<Meeting> GetMeetingsByProfessional(int professionalId)
    {
        return _context.Meetings
            .Include(meeting => meeting.Customer)
            .Include(meeting => meeting.Professional)
            .Where(meeting => meeting.Professional.Id == professionalId)
            .ToList();
    }

    public List<Meeting> GetMeetingsByCustomer(int customerId)
    {
        return _context.Meetings
            .Include(meeting => meeting.Customer)
            .Include(meeting => meeting.Professional)
            .Where(meeting => meeting.Customer.Id == customerId)
            .ToList();
    }

    public void AddMeeting(Meeting entity)
    {
        _context.Meetings.Add(entity);
        _context.SaveChanges();
    }

    public void UpdateMeeting(Meeting entity)
    {
        _context.Meetings.Update(entity);
        _context.SaveChanges();
    }

    public void DeleteMeeting(Meeting meeting)
    {
        _context.Meetings.Remove(meeting);
        _context.SaveChanges();
    }
}

