﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Area.Events;

namespace Area
{
    /// <summary>
    /// Handle new events and route them to 
    /// </summary>
    public class Dispatcher
    {
        private Dictionary<HttpEventType, Func<Event, HttpEventAnswer>> routes = new Dictionary<HttpEventType, Func<Event, HttpEventAnswer>> { };

        /// <summary>
        /// Getter and Setter for the <see cref="Dispatcher"/> routes
        /// </summary>
        public Dictionary<HttpEventType, Func<Event, HttpEventAnswer>> Routes { get => routes; set => routes = value; }

        /// <summary>
        /// EntryPoint of the Dispatcher which handle and route events
        /// </summary>
        /// <param name="e"><see cref="Event"/> to be routed</param>
        /// <returns>A <see cref="HttpEventAnswer"/> object which define the answer of the server for the event</returns>
        public HttpEventAnswer Trigger(Event e)
        {
            Console.WriteLine("Server application dispatcher triggered for event of type " + e.GetType());
            // TODO: Send information about the triggered event to the monitors
            return (this.Routes.TryGetValue(e.Type, out Func<Event, HttpEventAnswer> route))
                ? this.Routes[e.Type](e)
                : HttpEventAnswer.Error(e, 400, "Unknown type '" + e.Type + "'");
        }
    }
}