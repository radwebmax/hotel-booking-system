using HotelReservationSystem.Models;
using HotelReservationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace HotelReservationSystem.Controllers
{
	public class ReservationController : Controller
	{

		private readonly ApplicationDbContext _context;

		public ReservationController(ApplicationDbContext context)
		{

			_context = context;

		}
		public ActionResult Index()
		{
			return View(_context.Reservation.ToList());
		}

		public ActionResult Create()
		{
            List<SelectListItem> rooms = new List<SelectListItem>
            {
                new SelectListItem() { Text = "room", Value = "room" },
                new SelectListItem() { Text = "single", Value = "single" },
                new SelectListItem() { Text = "double", Value = "double" },
                new SelectListItem() { Text = "suite", Value = "suite" }
            };
            ViewBag.Room = rooms;

            List<SelectListItem> roomPreference = new List<SelectListItem>
            {
                new SelectListItem() { Text = "TV", Value = "TV" },
                new SelectListItem() { Text = "Wi-Fi", Value = "Wi - Fi" },
                new SelectListItem() { Text = "A/C", Value = "A/C" },
                new SelectListItem() { Text = "Pets", Value = "Pets" }
            };
            ViewBag.RoomPreference = roomPreference;

            List<SelectListItem> childrenNumber = new List<SelectListItem>
            {
                new SelectListItem() { Text = "0", Value = "0" },
                new SelectListItem() { Text = "1 Child", Value = "1" },
                new SelectListItem() { Text = "2 Children", Value = "2" },
                new SelectListItem() { Text = "3 Children", Value = "3" }
            };
            ViewBag.ChildrenNumber = childrenNumber;

            List<SelectListItem> guestsNumber = new List<SelectListItem>
            {
                new SelectListItem() { Text = "1 Person", Value = "1" },
                new SelectListItem() { Text = "2 Persons", Value = "2" },
                new SelectListItem() { Text = "3 Persons", Value = "3" },
                new SelectListItem() { Text = "4 Persons", Value = "4" },
                new SelectListItem() { Text = "5 Persons", Value = "5" }
            };
            ViewBag.GuestsNumber = guestsNumber;
			return View(new ReservationViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(ReservationViewModel model)
		{

				Reservation obj = new Reservation() { 
                    Name = model.Name, 
                    Email = model.Email, 
                    ArrivalDateTime = model.ArrivalDateTime,
                    DepartureDateTime = model.DepartureDateTime, 
                    Room = model.Room, 
                    GuestsNumber = model.GuestsNumber, 
                    RoomPreference = model.RoomPreference, 
                    ChildrenNumber = model.ChildrenNumber };
				_context.Reservation.Add(obj);
				await _context.SaveChangesAsync();

                return RedirectToAction("Index");
          
            //Init
            List<SelectListItem> rooms = new List<SelectListItem>
            {
                new SelectListItem() { Text = "room", Value = "room" },
                new SelectListItem() { Text = "single", Value = "single" },
                new SelectListItem() { Text = "double", Value = "double" },
                new SelectListItem() { Text = "suite", Value = "suite" }
            };
            ViewBag.Room = rooms;

            List<SelectListItem> roomPreference = new List<SelectListItem>
            {
                new SelectListItem() { Text = "TV", Value = "TV" },
                new SelectListItem() { Text = "Wi-Fi", Value = "Wi - Fi" },
                new SelectListItem() { Text = "A/C", Value = "A/C" },
                new SelectListItem() { Text = "Pets", Value = "Pets" }
            };
            ViewBag.RoomPreference = roomPreference;

            List<SelectListItem> childrenNumber = new List<SelectListItem>
            {
                new SelectListItem() { Text = "0", Value = "0" },
                new SelectListItem() { Text = "1 Child", Value = "1" },
                new SelectListItem() { Text = "2 Children", Value = "2" },
                new SelectListItem() { Text = "3 Children", Value = "3" }
            };
            ViewBag.ChildrenNumber = childrenNumber;

            List<SelectListItem> guestsNumber = new List<SelectListItem>
            {
                new SelectListItem() { Text = "1 Person", Value = "1" },
                new SelectListItem() { Text = "2 Persons", Value = "2" },
                new SelectListItem() { Text = "3 Persons", Value = "3" },
                new SelectListItem() { Text = "4 Persons", Value = "4" },
                new SelectListItem() { Text = "5 Persons", Value = "5" }
            };
            ViewBag.GuestsNumber = guestsNumber;


			//Console.WriteLine("finally");
			//return View(model);
		}
        
    }
}
