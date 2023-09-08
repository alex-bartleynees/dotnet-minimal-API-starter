using Domain.Models;
using MediatR;

namespace Application.Posts.Queries
{
    public record GetAllPosts : IRequest<ICollection<Post>>;
}