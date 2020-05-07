using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using OdeToFood.Data.Models;
using OdeToFood.Web.Controllers;

namespace OdeToFood.Web.Models.ViewModels
{
    public class RestaurantFormViewModel
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required]
        [Display(Name = "Type of food")]
        public CuisineType Cuisine { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<RestaurantsController, Task<ActionResult>>> create = (c => c.Create(this));
                Expression<Func<RestaurantsController, Task<ActionResult>>> update = (c => c.Update(this));
                var method = Id != 0 ? update : create;
                return (method.Body as MethodCallExpression)?.Method.Name;
            }
        }
    }
}