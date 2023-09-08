using Application.Abstractions;
using Application.Common.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbContext _context;

        public PostRepository(SocialDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Post> CreatePost(Post toCreate, CancellationToken cancellationToken)
        {
            toCreate.DateCreated = DateTime.UtcNow;
            toCreate.LastModified = DateTime.UtcNow;
            _context.Posts.Add(toCreate);
            await _context.SaveChangesAsync(cancellationToken);
            return toCreate;
        }

        public async Task DeletePost(int postId, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId, cancellationToken);
            if (post == null) return;

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<Post>> GetAllPosts(CancellationToken cancellationToken)
        {
            return await _context.Posts.ToListAsync(cancellationToken);
        }

        public async Task<Post> GetPostById(int postId, CancellationToken cancellationToken)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId, cancellationToken) ?? throw new NotFoundException($"Post with id {postId} not found");
        }

        public async Task<Post> UpdatePost(string updatedContent, int postId, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId, cancellationToken) ?? throw new NotFoundException($"Post with id {postId} not found");
            post.LastModified = DateTime.Now;
            post.Content = updatedContent;
            await _context.SaveChangesAsync(cancellationToken);
            return post;
        }
    }
}