using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// -------------------------------- Start 174. Add Person - Model - 1 -----------------------------------
    ///
    /// We made a class Public.
    /// 
    /// <summary>
    /// Person domain model.
    /// </summary>
    public class Person
    {
        // I have not added the Person Keyword before properties name like PersonName, PersonID, etc.,
        // Because as per the c# teacher Krystina, the class names tells us that to whom these properties belong.
        // Also the when we will create the object of this class, the  object name will also tell us the same.
        public Guid ID {  get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }
    }
    /// -------------------------------- End 174. Add Person - Model - 1 -----------------------------------
    ///
}
