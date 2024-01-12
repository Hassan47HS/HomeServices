using Home_Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace Home_Service.ServiceLayer
{
    public class AdminService : IAdminService
    {
        private readonly HomeServiceDB _context;

        public AdminService(HomeServiceDB context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.categories.ToList();
        }

        public void AddCategory(Category category)
        {
                _context.categories.Add(category);
                _context.SaveChanges();
        }

        // Other methods for managing services...

        // Example methods for managing new services
        public List<Services> GetNewServices()
        {
            return _context.services.Where(s => s.Status == Status.Pending).ToList();
        }

        public void ApproveService(int id)
        {
            var service = _context.services.Find(id);
            if (service != null)
            {
                service.Status = Status.Approve;
                _context.SaveChanges();
            }
        }

        public void RejectService(int id, string rejectionReason)
        {
            var service = _context.services.Find(id);
            if (service != null)
            {
                service.Status = Status.Reject;
                service.RejectionReason = rejectionReason;
                _context.SaveChanges();
            }
        }

        // Example methods for managing approved services
        public List<Services> GetApprovedServices()
        {
            return _context.services.Where(s => s.Status == Status.Approve).ToList();
        }

        // Example methods for managing rejected services
        public List<Services> GetRejectedServices()
        {
            return _context.services.Where(s => s.Status == Status.Reject).ToList();
        }

        public Services GetRejectedService(int id)
        {
            return _context.services.Find(id);
        }

        public void ApproveRejectedService(int id)
        {
            var rejectedService = _context.services.Find(id);
            if (rejectedService != null)
            {
                rejectedService.Status = Status.Approve;
                _context.SaveChanges();
            }
        }
    }

}
