﻿using MVC_RunGroopWebApp.Data.Enum;
using MVC_RunGroopWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_RunGroopWebApp.ViewModels
{
    public class CreateClubViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public IFormFile Image { get; set; }
        public ClubCategory ClubCategory { get; set; }

        public string  AppUserId  { get; set; }

    }
}
