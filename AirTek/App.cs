using AirTek.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AirTek
{
    class App
    {
        IFlight _flightService;
        IOrder _orderService;
        ISchedule _schedulerService;
        IFileRead<JSONFileReader> _jsonReader;
        IFileRead<TextFileReader> _textReader;
        IWriter<FlightWriter> _flightWriter;
        IWriter<OrderWriter> _orderWriter;
        public App(IFlight flightService, IOrder orderService, ISchedule schedulerService, IFileRead<JSONFileReader> jsonReader, IFileRead<TextFileReader> textReader, IWriter<FlightWriter> flightWriter, IWriter<OrderWriter> orderWriter)
        {
            _flightService = flightService;
            _orderService = orderService;
            _schedulerService = schedulerService;
            _jsonReader = jsonReader;
            _textReader = textReader;
            _flightWriter = flightWriter;
            _orderWriter = orderWriter;
        }
        public async Task Run()
        {
            try
            {
                _textReader.Read();
                _jsonReader.Read();
                _flightWriter.Write();

                _schedulerService.ScheduleFlight();
                _orderWriter.Write();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
