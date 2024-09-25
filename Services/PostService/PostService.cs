using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepoPattern.Data;

namespace RepoPattern.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;

        public PostService(DataContext context)
        {
           _context = context;
        }
        public async Task<List<Post>?> AddPost(Post post)
        {
            var posts = await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return await _context.Posts.ToListAsync();
        }

        public async Task<List<Post>?> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post is null) return null;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return await _context.Posts.ToListAsync();
        }

        public async Task<List<Post>> GetAllPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post is null) return null;
            return post;
        }

        public async Task<Post> UpdatePost(int id, Post request)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post is null) return null;

            post.Title = request.Title;
            post.Description = request.Description;

            await _context.SaveChangesAsync();
            return post;
        }
    }
}
