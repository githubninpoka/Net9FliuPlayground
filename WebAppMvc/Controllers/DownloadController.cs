using Microsoft.AspNetCore.Mvc;

namespace WebAppMvc.Controllers;

public class DownloadController : Controller
{
    public VirtualFileResult Vf()
    {
        return new VirtualFileResult("JustADownloadableFile.txt", "text/plain");
    }
    public PhysicalFileResult Pf()
    {
        return new PhysicalFileResult($"{Environment.CurrentDirectory}\\PhysicalFiles\\JustADownloadableFileToo.txt", "text/plain");
    }
    public FileContentResult Fc()
    {
        byte[] file = System.IO.File.ReadAllBytes($"{Environment.CurrentDirectory}\\PhysicalFiles\\broeikas.jpg");
        return new FileContentResult(file,"application/jpg");
    }
}
