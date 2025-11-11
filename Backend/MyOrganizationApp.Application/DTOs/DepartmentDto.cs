using MyOrganizationApp.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MyOrganizationApp.Application.DTOs;

public record DepartmentDto
{
    public int ID { get; init; }

    public string Name { get; init; } = null!;

    public bool IsActive { get; init; }

    public DateTime CreatedDate { get; init; }

    public DateTime? UpdatedDate { get; init; }

    public virtual ICollection<TblEmployee> Employees { get; init; } = new List<TblEmployee>();
}

[Mapper]
public partial class DepartmentMapper
{
    [MapProperty(nameof(DepartmentDto.ID), nameof(TblDepartment.PkdeptId))]
    [MapProperty(nameof(DepartmentDto.Name), nameof(TblDepartment.DeptName))]
    [MapperIgnoreSource(nameof(DepartmentDto.Employees))]
    [MapperIgnoreTarget(nameof(TblDepartment.TblEmployees))]
    public partial TblDepartment ToTblDepartment(DepartmentDto dto);

    [MapProperty(nameof(TblDepartment.PkdeptId), nameof(DepartmentDto.ID))]
    [MapProperty(nameof(TblDepartment.DeptName), nameof(DepartmentDto.Name))]
    [MapProperty(nameof(TblDepartment.TblEmployees), nameof(DepartmentDto.Employees))]
    public partial DepartmentDto ToDepartmentDto(TblDepartment tbl);

    public partial IEnumerable<DepartmentDto> ToDepartmentsDto(IEnumerable<TblDepartment> tblDepartments);
}

