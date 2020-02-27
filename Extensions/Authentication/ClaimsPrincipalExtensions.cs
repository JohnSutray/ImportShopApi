﻿using System.Linq;
using System.Security.Claims;

namespace ImportShopApi.Extensions.Authentication {
  public static class ClaimsPrincipalExtensions {
    public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
      => int.Parse(claimsPrincipal.Claims.First().Value);
  }
}