using MediatR;
using Domain.Models;

namespace Application.Posts.Queries
{
    public record GetPostById(int PostId) : IRequest<Post>;
}