using Home_Service;
using System.Collections.Generic;
using System.Linq;
using Home_Service.Models;
using Microsoft.EntityFrameworkCore;

public class ServiceLayer
{
   private readonly HomeServiceDB _context;
        public ServiceLayer(HomeServiceDB context)
        {
           _context = context;
        }
        public List<Services> GetAllServices()
        {
            return _context.services.Include(s=>s.Category).ToList();
        }
    public List<Services> GetAllServiceForUser(string UserId)
    {
        return _context.services.Include(s=>s.Category).Where(s=>s.UserId == UserId).ToList();
    }
    public Services GetServiceById(int id)
    {   
        return _context.services.Include(s=>s.Category).ToList()
            .FirstOrDefault(s => s.Id == id);
    }
    public void ResolveComments(int id, string adminComments)
    {
        var service = _context.services.FirstOrDefault(s => s.Id == id);
        if (service != null)
        {
            service.AdminComment = adminComments;
            service.Status = Status.Reject;
            _context.SaveChanges();
        }
    }
    public void CreateService(Services service,string UserId)
    {
        service.UserId=UserId;
        _context.services.Add(service);
        _context.SaveChanges();
    }
    public List<Category> GetAllCategories()
    {
        return _context.categories.ToList();
    }
}
