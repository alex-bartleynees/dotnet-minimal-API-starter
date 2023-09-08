using MediatR;

namespace Application.Posts.Commands
{
    public record DeletePost(int PostId) : IRequest;
}