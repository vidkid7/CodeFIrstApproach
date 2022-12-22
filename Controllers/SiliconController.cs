using CodeFirstApproach.Data;
using CodeFirstApproach.Models;
using CodeFirstApproach.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApproach.Controllers
{
    public class SiliconController : Controller
    {
        private readonly SiliconDbContext silicondbcontext;
        public SiliconController(SiliconDbContext silicondbcontext)
        {
            this.silicondbcontext = silicondbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add() 
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddSiliconVM addsiliconVM)
        {
            var silicon = new Silicon()
            {
                SiliconId= addsiliconVM.SiliconId,
                Name= addsiliconVM.Name,
                Age = addsiliconVM.Age,
                Salary= addsiliconVM.Salary,
                Address= addsiliconVM.Address,
            };
           await silicondbcontext.Silicons.AddAsync(silicon);
            await silicondbcontext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
        public async Task<IActionResult> Edit(int? Id) 
        {
            var silicon = await silicondbcontext.Silicons.FirstOrDefaultAsync(s => s.SiliconId == Id);
            if (silicon != null)
            {
                var result = new UpdateSiliconVM();
                {
                    result.SiliconId = silicon.SiliconId;
                    result.Name = silicon.Name;
                    result.Age = silicon.Age;
                    result.Salary = silicon.Salary;
                    result.Address = silicon.Address;
                }
                return await Task.Run(() => View("Edit", result));

            }

            return RedirectToAction("List");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateSiliconVM updateSilicon)
        {
            var silicon = await silicondbcontext.Silicons.FindAsync(updateSilicon.SiliconId);
            if (silicon != null ) 
            {
                silicon.SiliconId = updateSilicon.SiliconId;
                silicon.Name = updateSilicon.Name;
                silicon.Age = updateSilicon.Age;
                silicon.Salary = updateSilicon.Salary;
                silicon.Address = updateSilicon.Address;

                await silicondbcontext.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateSiliconVM updateSiliconVM)
        {
            var silicon = await silicondbcontext.Silicons.FindAsync(updateSiliconVM.SiliconId);
            if (silicon != null)
            {
                silicondbcontext.Silicons.Remove(silicon);
                await silicondbcontext.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
        public async Task<IActionResult> List()
        {
            var silicons = await silicondbcontext.Silicons.ToListAsync(); 
            return View(silicons);
        }
    }
}
