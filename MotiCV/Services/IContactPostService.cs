﻿namespace Services
{
    public interface IContactPostService
    {
        Task<string> Add(string fullName, string email, string subject, string content);
    }
}
