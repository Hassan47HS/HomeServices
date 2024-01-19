using Home_Service;
using Home_Service.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Home_Service.Servicelayer
{
    public class AdminService : IAdminService
    {
        private readonly HomeServiceDB _context;

        public AdminService(HomeServiceDB context)
        {
            _context = context;
        }
        public void DeleteCategory(int categoryId)
        {
            var category = _context.categories.Find(categoryId);
            if (category != null)
            {
                _context.categories.Remove(category);
                _context.SaveChanges();
            }
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

        public List<Services> GetNewServices()
        {
            return _context.services
                .Include(s => s.User)
                .Where(s => s.Status == Status.Pending)
                .ToList();
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

        public void RejectService(int id, string adminComment)
        {
            var service = _context.services
                .Include(s => s.User)
                .FirstOrDefault(s => s.Id == id);

            if (service != null)
            {
                service.Status = Status.Reject;
                service.AdminComment = adminComment ?? string.Empty;
                _context.SaveChanges();
            }
        }

        public List<Services> GetApprovedServices()
        {
            return _context.services
                .Include(s => s.User)
                .Where(s => s.Status == Status.Approve)
                .ToList();
        }

        public List<Services> GetRejectedServices()
        {
            return _context.services
                .Include(s => s.User)
                .Where(s => s.Status == Status.Reject)
                .ToList();
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

        public List<Services> GetReapprovalRequests()
        {
            return _context.services
                .Include(s => s.User)
                .Where(s => s.Status == Status.ReapprovalRequest)
                .ToList();
        }
        public Services GetReapprovedServices(int id)
        {
            // Find the reapproved service based on the provided ID
            var reapprovedService = _context.services
                .Include(s => s.User)
                .FirstOrDefault(s => s.Id == id && s.Status == Status.Approve);

            return reapprovedService;
        }
        public int GetReapprovalRequestsCount()
        {
            return _context.services.Count(s => s.IsReApprovalRequested);
        }
    }
}

