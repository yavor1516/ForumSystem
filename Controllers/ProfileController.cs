using ForumSystem.Models;
using ForumSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq; // Import System.Linq for ToList()

public class ProfileController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;

    public ProfileController(IUserRepository userRepository, IPostRepository postRepository)
    {
        _userRepository = userRepository;
        _postRepository = postRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        // If you intend to display user profiles, you should pass a ProfileViewModel here
        // Example: return View(new ProfileViewModel());
        return View("Index");
    }

    public IActionResult Profile(int userId)
    {
        // Fetch the user and their posts from the database
        var user = _userRepository.GetUserById(userId); // Replace with your data fetching logic

        // Check if the user is found
        if (user == null)
        {
            return NotFound(); // Handle the case where the user is not found
        }

        // Fetch posts for the user
        var posts = _postRepository.GetPostsByUserId(userId); // Replace with your data fetching logic

        var viewModel = new ProfileViewModel
        {
            User = user,
            Posts = posts.ToList() // Convert to a list if necessary
        };

        return View(viewModel);
    }
}
