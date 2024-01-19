using Home_Service;
using System.Collections.Generic;
using System.Linq;
using Home_Service.Models;
using Microsoft.EntityFrameworkCore;
using Home_Service.ViewModel;

public class ServicesLayer
{
   private readonly HomeServiceDB _context;
        public ServicesLayer(HomeServiceDB context)
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
        return _context.services.Include(s=>s.Category)
            .Include(s=>s.Reviews).ToList()
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
    public void ReapproveService(EditViewModel viewModel)
    {
        var service = _context.services.FirstOrDefault(s => s.Id == viewModel.Id);

        if (service != null && service.Status == Status.Reject)
        {
            service.Title = viewModel.Title;
            service.Description = viewModel.Description;
            service.Price = viewModel.Price;
            var selectedCategory = _context.categories.FirstOrDefault(c => c.Id == viewModel.SelectedCategoryId);
            service.Category = selectedCategory;
            service.AverageRating = viewModel.AverageRating;
            service.Location = viewModel.Location;
            service.Justification = viewModel.ReapprovalRequestMessage;
            service.Status = Status.ReapprovalRequest;
            service.IsReApprovalRequested = true;
            service.AdminComment = viewModel.AdminComment;
            _context.SaveChanges();
        }
    }

}
