using System;
using System.Collections.Generic;

namespace ComputerBuildService.BL.Models
{
    public class ResultObject<T>
        where T : class
    {
        private ResultObject()
        {
        }

        public T Value { get; private set; }

        public List<Exception> Errors { get; private set; }

        public bool IsSuccess => Errors.Count == 0;

        public static ResultObject<T> Create()
        {
            return Create(null);
        }

        public static ResultObject<T> Create(T responseObj)
        {
            return new ResultObject<T>
            {
                Value = responseObj,
                Errors = new List<Exception>()
            };
        }

        public ResultObject<T> AddError(Exception exception)
        {
            Errors.Add(exception);
            return this;
        }

        public ResultObject<T> SetValue(T responseObj)
        {
            Value = responseObj;
            return this;
        }
    }
}
