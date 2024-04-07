﻿using System;

namespace UserService.Api.Model.DTO
{
    public class ApiResponse<T>
    { 
            public bool Success { get; set; }
            public  T? Data { get; set; }
            public string ErrorMessage { get; set; }
    }
}
