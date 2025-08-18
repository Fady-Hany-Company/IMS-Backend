using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entities
{
    public class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; } = string.Empty;
        public T? Data { get; private set; }

        private BaseResponse(bool success, string message, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        // Factory methods
        public static BaseResponse<T> SuccessResponse(string message, T data) =>
            new BaseResponse<T>(true, message, data);

        public static BaseResponse<T> SuccessResponse(string message) =>
            new BaseResponse<T>(true, message);

        public static BaseResponse<T> FailureResponse(string message) =>
            new BaseResponse<T>(false, message);


    }
}
