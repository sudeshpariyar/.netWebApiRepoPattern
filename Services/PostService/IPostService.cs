using Microsoft.AspNetCore.Mvc;

namespace RepoPattern.Services.PostService
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPost(int id);
        Task<List<Post>?> AddPost([FromBody] Post post);
        Task<Post> UpdatePost(int id, Post request);
        Task<List<Post>?> DeletePost(int id);
    }
}
