using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFriends22.Data;
using MyFriends22.Models;

namespace MyFriends22.Controllers
{
    public class FriendModelsController : Controller
    {
        private readonly MyFriends22Context _context;

        public FriendModelsController(MyFriends22Context context)
        {
            _context = context;
        }

        // GET: FriendModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.FriendModel.ToListAsync());
        }

        // GET: FriendModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendModel = await _context.FriendModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friendModel == null)
            {
                return NotFound();
            }

            return View(friendModel);
        }

        // GET: FriendModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FriendModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone")] FriendModel friendModel,
            IFormFile SetImage)
        {
            friendModel.SetImage = SetImage;
            //ModelState.Clear();
            //TryValidateModel(friendModel);
            ModelState.Remove("SetImage");

            if (ModelState.IsValid && friendModel.Images.Any())
            {
                _context.Add(friendModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(friendModel);
        }

        // GET: FriendModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendModel = await _context.FriendModel.FindAsync(id);
            if (friendModel == null)
            {
                return NotFound();
            }
            return View(friendModel);
        }

        // POST: FriendModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone")] FriendModel friendModel)
        {
            if (id != friendModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendModelExists(friendModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(friendModel);
        }

        // GET: FriendModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendModel = await _context.FriendModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friendModel == null)
            {
                return NotFound();
            }

            return View(friendModel);
        }

        // POST: FriendModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var friendModel = await _context.FriendModel.FindAsync(id);
            if (friendModel != null)
            {
                _context.FriendModel.Remove(friendModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendModelExists(int id)
        {
            return _context.FriendModel.Any(e => e.Id == id);
        }
    }
}
