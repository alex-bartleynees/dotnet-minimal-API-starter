using Domain.Models;

namespace Application.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPosts(CancellationToken cancellationToken);

        Task<Post> GetPostById(int postId, CancellationToken cancellationToken);

        Task<Post> CreatePost(Post toCreate, CancellationToken cancellationToken);

        Task<Post> UpdatePost(string updatedContent, int postId, CancellationToken cancellationToken);

        Task DeletePost(int postId, CancellationToken cancellationToken);
    }
}