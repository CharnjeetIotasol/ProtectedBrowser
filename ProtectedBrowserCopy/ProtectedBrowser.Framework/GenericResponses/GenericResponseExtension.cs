using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.GenericResponse
{
    public static class GenericResponseExtension
    {
        /// <summary>
        /// It create success response
        /// </summary>
        /// <typeparam name="T">Type of data for response</typeparam>
        /// <param name="obj">Object for create response</param>
        /// <param name="message">Additional string message for response</param>
        /// <returns><see cref="ApiRespone{T}"/></returns>
        public static ApiRespone<T> SuccessResponse<T>(this T obj, string message = null)
        {
            //if obj is string message then send it as message
            if (typeof(T) == typeof(string))
            {
                return new ApiRespone<T>
                {
                    Status = true,
                    Message = obj as string
                };
            }
            return new ApiRespone<T>
            {
                Data = obj,
                Status = true,
                Message = message
            };
        }

        /// <summary>
        /// It Create error resposne
        /// </summary>
        /// <typeparam name="T">Type of data for response</typeparam>
        /// <param name="obj">Object for create response</param>
        /// <param name="message">Additional string message for response</param>
        /// <returns><see cref="ApiRespone{T}"/></returns>
        public static ApiRespone<T> ErrorResponse<T>(this T obj, string message = null)
        {
            if (typeof(T) == typeof(string))
            {
                return new ApiRespone<T>
                {
                    Status = false,
                    Message = obj as string
                };
            }
            return new ApiRespone<T>
            {
                Data = obj,
                Status = false,
                Message = message
            };
        }
    }
}
