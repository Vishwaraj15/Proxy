using System;
using System.Collections.Generic;

namespace MyOrganizationApp.Domain.Entities;

public partial class VwEmployeeDepartmentDetail
{
    public int Id { get; set; }

    public string EmployeeName { get; set; } = null!;

    public double Salary { get; set; }

    public string DepartmentName { get; set; } = null!;
}
