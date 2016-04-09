using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenshotViewer.Models;
using Windows.Data.Json;
using ScreenshotViewer.ViewModels;
using Newtonsoft.Json;

namespace ScreenshotViewer.Services {
    public class ScreenshotService : IScreenshotService {
        const string FILENAME = "screenshots.json";

        #region Get Methods

        public async Task<List<Screenshot>> GetScreenshotsAsync() {
            List<Screenshot> screenshots = new List<Screenshot>();

            try {
                var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await folder.GetFileAsync(FILENAME);
                var data = await Windows.Storage.FileIO.ReadTextAsync(file);
                screenshots = JsonToScreenshots(data);
            }
            catch (Exception x) {
                string msg = x.Message;
            }

            return screenshots;
        }

        public IEnumerable<object> GetScreenshotViewModelGroups(List<ScreenshotViewModel> screenshotVMs) {
            IEnumerable<object> screenshotVMsByApp;

            screenshotVMsByApp = screenshotVMs
                .GroupBy(s => s.App)
                .Select(g => g);

            return screenshotVMsByApp;
        }

        public Screenshot GetScreenshot(int id) {
            throw new NotImplementedException();
        }

        #endregion

        #region Json Methods

        // Serialize C# Objects to Json
        public string PlanetsToJson(List<Screenshot> screenshots) {
            string json = JsonConvert.SerializeObject(screenshots, Formatting.Indented);
            return json;
        }

        // Deserialize Json to C# Objects
        public List<Screenshot> JsonToScreenshots(string json) {
            List<Screenshot> screenshots = new List<Screenshot>();
            screenshots = JsonConvert.DeserializeObject<List<Screenshot>>(json);
            return screenshots;
        }

        #endregion

    }
}
