using System;
using System.Collections.Generic;

namespace MyOrganizationApp.Domain.Entities;

public partial class TblEmployee
{
    public int PkempId { get; set; }

    public string EmpName { get; set; } = null!;

    public double Salary { get; set; }

    public bool IsActive { get; set; }

    public int FkdeptId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TblDepartment Fkdept { get; set; } = null!;
}
