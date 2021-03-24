using System;

namespace API.Errors
{
    public class ApiResponses
    {


        public ApiResponses(int statusCode, string message = null)
        {
            StatusCode = statusCode;

            // ?? => NULL coalescing operator. It means that if the default value is not null execute the thing after "??".
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);

        }



        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made.",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Internal Serevr Error",
                _ => null
            };
        }
    }
}