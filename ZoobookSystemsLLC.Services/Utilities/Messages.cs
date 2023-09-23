using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoobookSystemsLLC.Services.Utilities
{
    public static class Messages
    {
        public static class EmployeeStatusMsg
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Employees not found";
                return "Employee not found";
            }
            public static string Add(string employeeName)
            {
                return $"{employeeName} employee has been added successfully";
            }
            public static string Update(string employeeName)
            {
                return $"{employeeName} employee has been updated successfully";
            }
            public static string Delete(string employeeName)
            {
                return $"{employeeName} employee has been deleted successfully";
            }
        }
    }
}
