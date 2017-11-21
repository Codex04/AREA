﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    /// <summary>
    /// Defines an <see cref="IndexViewModel"/>
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// The list of <see cref="Area"/> visible
        /// </summary>
        public List<Area> Areas { get; set; }

        /// <summary>
        /// Serialize the list of <see cref="Area"/>
        /// </summary>
        /// <returns>The stringified list of AREAs</returns>
        public string AreasToJSON()
        {
            return (JsonConvert.SerializeObject(Areas));
        }

        /// <summary>
        /// Constructor of an <see cref="IndexViewModel"/> 
        /// </summary>
        /// <param name="areas">A list of AREAs</param>
        public IndexViewModel(List<Area> areas)
        {
            Areas = areas;
        }

        //TEMP
        public IndexViewModel()
        {
            Areas = new List<Area>
            {
                new Area("Emails"),
                new Area("FB notifications"),
                new Area("Twitter notifications")
            };
        }
    }
}