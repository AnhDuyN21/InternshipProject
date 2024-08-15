﻿namespace Application.Interfaces.IServices
{
    public interface IClaimsService
    {
        public int? GetCurrentUserRole { get; }
        public string? GetCurrentUserName { get; }
        public int GetCurrentUserId { get; }
    }
}
