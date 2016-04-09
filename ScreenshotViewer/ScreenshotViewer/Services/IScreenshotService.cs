using ScreenshotViewer.Models;
using ScreenshotViewer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotViewer.Services {
    public interface IScreenshotService {
        Task<List<Screenshot>> GetScreenshotsAsync();
        IEnumerable<object> GetScreenshotViewModelGroups(List<ScreenshotViewModel> screenshotVMs);
        Screenshot GetScreenshot(int id);
        List<Screenshot> JsonToScreenshots(string json);
        string PlanetsToJson(List<Screenshot> screenshots);
    }
}
