using Domain.Models;
using MediatR;

namespace Application.Posts.Commands
{
    public record CreatePost(string PostContent) : IRequest<Post>;
}