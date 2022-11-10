using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Contracts
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data)
        {
            Data = data;
            Successed = true;
            Errors = null;
            Message = string.Empty;
        }
        public T Data { get; set;}
        public bool Successed { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
        
    }
}