﻿using System.ComponentModel.DataAnnotations;

namespace BadgemaniaAPI.Models.DTO.AuthDTOs
{
    public class RegisterStudentRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
