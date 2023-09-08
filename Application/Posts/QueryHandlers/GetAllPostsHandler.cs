using Application.Abstractions;
using Domain.Models;
using Application.Posts.Queries;
using MediatR;

namespace Application.Posts.QueryHandlers
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPosts, ICollection<Post>>
    {

        private readonly IPostRepository _postRepository;

        public GetAllPostsHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository ?? throw new System.ArgumentNullException(nameof(postRepository));
        }
        public Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            return _postRepository.GetAllPosts(cancellationToken);
        }
    }
}