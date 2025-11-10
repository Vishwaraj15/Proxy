using System;
using System.Collections.Generic;

namespace MyOrganizationApp.Domain.Entities;

public partial class TblDepartment
{
    public int PkdeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TblEmployee> TblEmployees { get; set; } = new List<TblEmployee>();
}
