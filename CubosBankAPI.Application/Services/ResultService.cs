using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.Services
{
    public class ResultService
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }



        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                Success = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                Success = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService Fail (string message)
        {
            return new ResultService
            {
                Success = false,
                Message = message
            };
        }

        public static ResultService<T> Fail<T>(string message)
        {
            return new ResultService<T>
            {
                Success = false,
                Message = message
            };
        }

        public static ResultService Ok(string message)
        {
            return new ResultService
            {
                Message = message,
                Success = true
            };
        }
    }



    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
