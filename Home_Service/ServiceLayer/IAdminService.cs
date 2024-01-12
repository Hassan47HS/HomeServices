using Home_Service.Models;

public interface IAdminService
{
    List<Category> GetCategories();
    void AddCategory(Category category);

    List<Services> GetNewServices();
    void ApproveService(int id);
    void RejectService(int id, string rejectionReason);

    List<Services> GetApprovedServices();
    List<Services> GetRejectedServices();
    Services GetRejectedService(int id);
    void ApproveRejectedService(int id);
}