﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models.Response
{
    public class BaseResponse<T>
    {
        public T response { get; set; }

        public BaseResponse(T response)
        {
            this.response = response;
        }


    }

}

