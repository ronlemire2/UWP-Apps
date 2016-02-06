using PrismBasicsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismBasicsDemo.Services {
    public interface IPlanetRepository {
        List<Planet> ReLoadPlanets();
        List<Planet> GetPlanets();
        Planet GetPlanet(int id);
        int CreatePlanet(Planet planet);
        int UpdatePlanet(Planet planet);
        bool DeletePlanet(int id);
    }
}
