﻿using System;

namespace Network.Events
{
    /// <summary>
    /// Defines the basic object used for handling answer from the server
    /// </summary>
    public class HttpEventAnswer
    {
        /// <summary>
        /// Creates a specific <see cref="HttpEventAnswer"/> with a predefined pattern used for errors.
        /// </summary>
        /// <param name="e">The source event used for generating the answer</param>
        /// <param name="code">The error code</param>
        /// <param name="message">The error message</param>
        /// <returns></returns>
        public static HttpEventAnswer Error(Event e, int code, string message)
        {
            HttpEventStatus status = new HttpEventStatus { Code = code, Message = message };
            return new HttpEventAnswer { Parent = e, Data = null, Status = status };
        }

        /// <summary>
        /// Creates a specific <see cref="HttpEventAnswer"/> with a predefined pattern used for success status.
        /// </summary>
        /// <param name="e">The source event used for generating the answer</param>
        /// <param name="message">The error message</param>
        /// <returns></returns>
        public static HttpEventAnswer Success(Event e, string message)
        {
            HttpEventStatus status = new HttpEventStatus { Code = 200, Message = message };
            return new HttpEventAnswer { Parent = e, Data = null, Status = status };
        }

        /// <summary>
        /// Defines the source event used for generating the answer
        /// </summary>
        public Event Parent { get; set; }
        /// <summary>
        /// Represent the answer as a data
        /// </summary>
        public  Object Data{ get; set; }
        /// <summary>
        ///Http status with a code and a message
        /// </summary>
        public HttpEventStatus Status { get; set; }
    }
}
