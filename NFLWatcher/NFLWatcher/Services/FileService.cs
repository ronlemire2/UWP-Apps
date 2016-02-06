using NFLWatcher.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace NFLWatcher.Services {
    public class FileService {
        const string folderName = "Data";
        const string fileName = "teams.json";
        private ObservableCollection<Team> teams = new ObservableCollection<Team>();

        public async Task WriteYearCalendarAsync(string fileName, string json) {
            try {
                var _Folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var _Option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
                var _File = await _Folder.CreateFileAsync(fileName, _Option);
                await Windows.Storage.FileIO.WriteTextAsync(_File, json);
            }
            catch (Exception x) {
                string msg = x.Message;
            }
        }

        public async Task<string> ReadYearCalendarAsync(string fileName) {
            string json = string.Empty;
            try {
                var _Folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var _File = await _Folder.GetFileAsync(fileName);
                json = await Windows.Storage.FileIO.ReadTextAsync(_File);
            }
            catch (Exception x) {
                string msg = x.Message;
            }
            return json;
        }

        public async Task<ObservableCollection<Team>> GetTeamsAsync() {
            await ensureDataLoaded();
            return teams;
        }

        private async Task ensureDataLoaded() {
            if (teams.Count == 0) {
                await getTeamsDataAsync();
            }
            return;
        }

        private async Task getTeamsDataAsync() {
            if (this.teams.Count != 0)
                return;

            try {
                // http://stackoverflow.com/questions/21500336/how-to-get-file-in-winrt-from-project-path
                var uri = new System.Uri("ms-appx:///Assets/Data/Teams.json");
                var teamsJsonFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
                var teamsJsonData = await Windows.Storage.FileIO.ReadTextAsync(teamsJsonFile);

                JsonObject jsonObject = JsonObject.Parse(teamsJsonData);
                JsonArray jsonArray = jsonObject["Teams"].GetArray();

                Team team;
                foreach (JsonValue teamValue in jsonArray) {
                    JsonObject teamObject = teamValue.GetObject();
                    team = new Team(teamObject["Id"].GetString(),
                                        teamObject["Abbr"].GetString(),
                                        teamObject["City"].GetString(),
                                        teamObject["NickName"].GetString(),
                                        teamObject["FullName"].GetString(),
                                        teamObject["ImagePath"].GetString());
                    this.teams.Add(team);
                }
            }
            catch (Exception x) {
                string msg = x.Message;
            }
        }
    }
}
