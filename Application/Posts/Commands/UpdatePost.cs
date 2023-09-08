using MediatR;
using Domain.Models;

namespace Application.Posts.Commands
{
    public record UpdatePost(int PostId, string PostContent) : IRequest<Post>;
}