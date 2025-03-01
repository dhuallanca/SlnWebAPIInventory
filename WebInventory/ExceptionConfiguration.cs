﻿using WebInventory.Exceptions;

namespace WebInventory
{
    public static class ExceptionConfiguration
    {
        public static void RegisterExceptionConfiguration(this IServiceCollection services) {
            services.AddExceptionHandler<UnauthorizedExceptionHandler>();
            services.AddExceptionHandler<BadRequestExceptionHandler>();
            services.AddExceptionHandler<NotFoundExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
        }
    }
}
