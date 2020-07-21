using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.Shared
{
    public class ResponseObject<T>
        where T: class
    {
        private ResponseObject()
        {
        }

        public T Value { get; private set; }

        public Exception Error { get; private set; }

        public bool IsSuccess => Error == null;

        public static ResponseObject<T> Create(T responseObj, Exception exception = null)
        {
            return new ResponseObject<T>
            {
                Value = responseObj,
                Error = exception
            };
        }
    }
}
