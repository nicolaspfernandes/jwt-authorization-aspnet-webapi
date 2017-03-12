namespace JwtWebApiAuthorization.Models {

    using System.Net;

    /// <summary>
    /// Custom response with general information to be sent as Response for requests.
    /// </summary>
    public class CustomResponse {

        /// <summary>
        /// Default constructor. It assumes that the response is a success by default and have HTTP code as 200.
        /// </summary>
        public CustomResponse() {
            Success = true;
            ErrorMessage = string.Empty;
            StatusCode = (int) HttpStatusCode.OK;
        }

        /// <summary>
        /// Overloading constructor. Sending information and status code to be set in the object instance.
        /// </summary>
        /// <param name="data">Data information to be set to the object.</param>
        /// <param name="statusCode">Integer value with status code of the operation.</param>
        public CustomResponse(object data, int statusCode) : this() {
            Data = data;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Overloading constructor. Sending information and status code to be set in the object instance.
        /// </summary>
        /// <param name="data">Data information to be set to the object.</param>
        /// <param name="statusCode">HttpStatusCode enum value with status code of the operation.</param>
        public CustomResponse(object data, HttpStatusCode statusCode = HttpStatusCode.OK) : this(data, (int) statusCode) { }

        public object Data { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}