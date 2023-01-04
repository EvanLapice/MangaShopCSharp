namespace MSSA_Assignment_12._2.Services
{
    public interface IFileUpload
    {
        Task<bool> UploadFile(IFormFile file);
        string? FileName { get; set; }
    }
}
