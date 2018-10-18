// FILENAME    : Peoples.cs
// ==========================================================
//  
// AUTHOR      : FADHLY PERMATA
// CREATED AT  : 2018-10-18
// 
// ==========================================================

#region REFFERENCES

using Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utilities.Extensions;

#endregion

namespace Data.Context
{
    public class Peoples
    {
        /// <summary>
        ///     Get data from text and bind it into model.
        /// </summary>
        /// <param name="path">Path of file to be readed.</param>
        /// <returns>
        ///     List of PeopleModel
        /// </returns>
        public static List<PeopleModel> Get(string path)
        {
            // validate the parameters
            if (string.IsNullOrEmpty(path))
                throw new Exception("Invalid file path");

            var listPeoples = new List<PeopleModel>();
            var names = File.ReadLines(path).ToList();

            // bind each line into model;
            foreach (var name in names)
            {
                var arrName = name.Trim().Split(' ');

                // create people data and attach it into list
                var peopleData = new PeopleModel
                {
                    FirstName = arrName[0]
                };

                if (arrName.Length > 2)
                {
                    peopleData.MiddleName = arrName[1];
                    peopleData.LastName = string.Join(" ", arrName.Slice(2, arrName.Length));
                }
                else if (arrName.Length == 2)
                {
                    peopleData.LastName = arrName[1];
                }

                listPeoples.Add(peopleData);
            }

            return listPeoples;
        }

        /// <summary>
        ///     Write data list into text file.
        /// </summary>
        /// <param name="data">List of people.</param>
        /// <param name="path">Path of file to be writed.</param>
        public static void Set(List<PeopleModel> data, string path)
        {
            // validate the parameters
            if (string.IsNullOrEmpty(path))
                throw new Exception("Invalid file path");

            File.WriteAllLines(
                path,
                data.Select(x => x.FullName).ToList()
            );
        }
    }
}