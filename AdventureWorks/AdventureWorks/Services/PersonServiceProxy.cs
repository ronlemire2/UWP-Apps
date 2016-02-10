using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Models;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using AdventureWorks.ViewModels;

namespace AdventureWorks.Services {
    public class PersonServiceProxy : IPersonServiceProxy {
        private string _personBaseUri = string.Format(CultureInfo.InvariantCulture, "{0}/api/Person/", Constants.ServerAddress);

        public async Task<List<PersonVM>> GetPeopleAsync() {
            using (var httpClient = new HttpClient()) {
                var response = await httpClient.GetAsync(new Uri(string.Format("{0}", _personBaseUri)));
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<PersonVM>>(responseContent);
                return result;
            }
        }

        public Task<int> AddPersonAsync(PersonVM personVM) {
            throw new NotImplementedException();
        }

        public Task<int> DeletePersonAsync(PersonVM personVM) {
            throw new NotImplementedException();
        }

        public Task<int> EditPersonAsync(PersonVM personVM) {
            throw new NotImplementedException();
        }

    }
}
