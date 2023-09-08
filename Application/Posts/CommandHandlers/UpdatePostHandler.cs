using Application.Abstractions;
using Domain.Models;
using Application.Posts.Commands;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
    {
        private readonly IPostRepository _postRepository;

        public UpdatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository ?? throw new System.ArgumentNullException(nameof(postRepository));
        }

        public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            return await _postRepository.UpdatePost(request.PostContent, request.PostId, cancellationToken);
        }
    }
}