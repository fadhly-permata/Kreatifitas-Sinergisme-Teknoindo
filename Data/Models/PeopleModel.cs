// FILENAME    : PeopleModel.cs
// ==========================================================
//  
// AUTHOR      : FADHLY PERMATA
// CREATED AT  : 2018-10-18
// 
// ==========================================================

namespace Data.Models
{
    public class PeopleModel
    {
        #region PROPS
        // First (1st) word of name part
        public string FirstName { get; set; }

        // Second (2nd) word of name part
        public string MiddleName { get; set; }

        // Another (3rd, 4th, 5th, ...) words of name part 
        public string LastName { get; set; }

        // Compiled name
        public string FullName => $"{FirstName} {MiddleName} {LastName}"
                .Trim()
                .Replace("  ", " "); // make sure there are no double space
        #endregion PROPS
    }
}