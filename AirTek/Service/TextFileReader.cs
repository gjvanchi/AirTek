using AirTek.Model;
using AirTek.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek.Service
{
    internal class TextFileReader : IFileRead<TextFileReader>
    {

        List<Flight> _flights = null;
        List<Schedule> _schedule = null;
        ISchedule _schedulerService = null;
        IFlightRepository _flightRepository = null;
        public TextFileReader(ISchedule schedulerService, IFlightRepository flightRepository)
        {
            _flights = new List<Flight>();
            _schedule = new List<Schedule>();
            _schedulerService = schedulerService;
            _flightRepository = flightRepository;   
        }
        public void Read()
        {
            if (!File.Exists(ConfigurationManager.AppSettings["flightschedule"]))
            {
                Console.WriteLine($"File {ConfigurationManager.AppSettings["flightschedule"]} not available");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(ConfigurationManager.AppSettings["flightschedule"]);
                int day = 0;
                int flightId = 0;
                string source = null, destination = null, sourceIATA = null, destinationIATA = null;
                char[] delimiterChars = { ' ', ',', '.', '\t' };
                for (var i = 0; i < lines.Length; i += 1)
                {
                    var line = lines[i].TrimEnd();
                    List<string> words = line.Split(delimiterChars).ToList();

                    words.Remove("airport");
                    if (words.Contains("to"))
                        words.Remove("to");
                    words.Remove("");
                    words.Remove(":");
                    if (words[0].ToLower() == "day")
                    {

                        day = int.Parse(words[1].Split(":")[0]);
                        _schedulerService.AddSchedule(new Schedule
                        {
                            Day = day,
                            Flights = new List<Flight>()
                        }); ;
                        continue;
                    }

                    if (words[0].ToLower() == "flight")
                    {
                        flightId = int.Parse(words[1].Split(":")[0]);
                        source = words[2];
                        sourceIATA = words[3];
                        destination = words[4];
                        destinationIATA = words[5];
                        var flight = new Flight
                        {
                            Id = flightId,
                            Source = source,
                            Destination = destination,
                            IATASource = sourceIATA.Trim('(', ')'),
                            IATADestination = destinationIATA.Trim('(', ')'),
                            Day = day,
                        };
                        _flights.Add(flight);
                        _schedulerService.AddFlight(day, flight);
                    }


                }
                _flightRepository.UpdateFlight(_flights);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
