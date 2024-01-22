﻿using System.Security.Claims;

namespace MVC_RunGroopWebApp
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {

            return user.FindFirst(ClaimTypes.NameIdentifier).Value;

        }
    }
}
