using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace AromaCafeService.Models
{
    [DataContract]
    public class Employee
    {
        private int employeeId;
        private string name;
        private string username;
        private string password;
        private string employeeType;

        [DataMember]
        public int EmployeeId { get {  return employeeId; } set { employeeId = value; } }
        [DataMember]
        public string Name { get { return name; } set { name = value; } }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember] 
        public string EmployeeAddress { get; set; }
        [DataMember]
        public string Username { get { return username; } set { username = value; } }
        [DataMember]
        public string Password { get { return password; } set { password = value; } }
        [DataMember]
        public string EmployeeType { get { return employeeType; } set { employeeType = value; } }
    }
}
