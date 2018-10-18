// FILENAME    : Peoples.cs
// ==========================================================
//  
// AUTHOR      : FADHLY PERMATA
// CREATED AT  : 2018-10-18
// 
// ==========================================================

#region REFFERENCES

using Data.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

#endregion

namespace Business
{
    public class Peoples
    {
        /// <summary>
        ///     Sort people data by their first name.
        /// </summary>
        /// <param name="peoples">List of people data.</param>
        /// <param name="direction">Sort direction</param>
        /// <returns>
        ///     List of sorted people data.
        /// </returns>
        public static List<PeopleModel> SortByFirstName(List<PeopleModel> peoples,
            ListSortDirection direction = ListSortDirection.Ascending)
        {
            var result = peoples.OrderBy(x => x.FirstName).ToList();
            if (direction == ListSortDirection.Descending) result.Reverse();

            return result;
        }

        /// <summary>
        ///     Sort people data by their last name.
        /// </summary>
        /// <param name="peoples">List of people data.</param>
        /// <param name="direction">Sort direction</param>
        /// <returns>
        ///     List of sorted people data.
        /// </returns>
        public static List<PeopleModel> SortByLastName(List<PeopleModel> peoples,
            ListSortDirection direction = ListSortDirection.Ascending)
        {
            var result = peoples.OrderBy(x => x.LastName).ToList();
            if (direction == ListSortDirection.Descending) result.Reverse();

            return result;
        }

        /// <summary>
        ///     Sort people data by their last name and then by their first name.
        /// </summary>
        /// <param name="peoples">List of people data.</param>
        /// <param name="direction">Sort direction</param>
        /// <returns>
        ///     List of sorted people data.
        /// </returns>
        public static List<PeopleModel> SortByLastNameThenFirstName(List<PeopleModel> peoples,
            ListSortDirection direction = ListSortDirection.Ascending)
        {
            var result = peoples.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            if (direction == ListSortDirection.Descending) result.Reverse();

            return result;
        }
    }
}