using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository ?? throw new System.ArgumentNullException(nameof(postRepository));
        }
        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Content = request.PostContent,
            };

            return await _postRepository.CreatePost(post, cancellationToken);
        }
    }
}