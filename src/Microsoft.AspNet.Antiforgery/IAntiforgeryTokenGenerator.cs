// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Http;

namespace Microsoft.AspNet.Antiforgery
{
    /// <summary>
    /// Generates and validates antiforgery tokens.
    /// </summary>
    public interface IAntiforgeryTokenGenerator
    {
        // Generates a new random cookie token.
        AntiforgeryToken GenerateCookieToken();

        // Given a cookie token, generates a corresponding request token.
        // The incoming cookie token must be valid.
        AntiforgeryToken GenerateRequestToken(
            HttpContext httpContext,
            AntiforgeryToken cookieToken);

        // Determines whether an existing cookie token is valid (well-formed).
        // If it is not, the caller must call GenerateCookieToken() before calling GenerateFormToken().
        bool IsCookieTokenValid(AntiforgeryToken cookieToken);

        // Validates a (cookie, request) token pair.
        void ValidateTokens(
            HttpContext httpContext,
            AntiforgeryToken cookieToken,
            AntiforgeryToken requestToken);
    }
}