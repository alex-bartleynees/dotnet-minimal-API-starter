using Application.Abstractions;
using Application.Posts.Commands;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    public class DeletePostHandler : IRequestHandler<DeletePost>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository ?? throw new System.ArgumentNullException(nameof(postRepository));
        }

        public async Task<Unit> Handle(DeletePost request, CancellationToken cancellationToken)
        {
            await _postRepository.DeletePost(request.PostId, cancellationToken);
            return Unit.Value;
        }

    }
}