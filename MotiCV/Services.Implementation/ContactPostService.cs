
using Domain.Entities;
using Repositories;

namespace Services.Implementation
{
    public class ContactPostService(IContactPostRepository contactPostRepository) : IContactPostService
    {
        public async Task<string> Add(string fullName, string email, string subject, string content)
        {
            var post = new ContactPost
            {
                FullName = fullName,
                Email = email,
                Subject = subject,
                Content = content
            };

            await contactPostRepository.AddAsync(post);
            await contactPostRepository.SaveAsync();

            return "Müraciətiniz qəbul olundu!";
        }
    }
}
