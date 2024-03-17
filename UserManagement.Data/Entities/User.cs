using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }


    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$",
        ErrorMessage = "Please enter a valid name that is at least 3 characters. Must start with a capital letter."),
        Required, StringLength(20, MinimumLength = 3)]
    public string Forename { get; set; } = default!;

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$",
        ErrorMessage = "Please enter a valid name that is at least 3 characters. Must start with a capital letter."),
        Required, StringLength(20, MinimumLength = 3)]
    public string Surname { get; set; } = default!;

    [Required, Display(Name = "Date of birth"), DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = default!;

    [Required]
    [Display(Name = "Is the user active?")]
    public bool IsActive { get; set; }
}
