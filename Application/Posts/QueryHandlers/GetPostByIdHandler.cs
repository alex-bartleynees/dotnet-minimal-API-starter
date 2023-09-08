using MediatR;
using Domain.Models;
using Application.Abstractions;
using Application.Posts.Queries;

namespace Application.Posts.QueryHandlers
{
    public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
    {

        private readonly IPostRepository _postRepository;

        public GetPostByIdHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository ?? throw new System.ArgumentNullException(nameof(postRepository));
        }
        public Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            return _postRepository.GetPostById(request.PostId, cancellationToken);
        }
    }
}