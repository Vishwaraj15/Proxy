using MyOrganizationApp.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MyOrganizationApp.Application.DTOs;

    public record EmployeeDto
    {
        public int ID { get; set; }

        public string Name { get; set; } = null!;

        public double Salary { get; set; }

        public bool IsActive { get; set; }

        public int DeptID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual TblDepartment Department { get; set; } = null!;
    }

[Mapper]
public partial class EmployeeMapper
{
    [MapProperty(nameof(EmployeeDto.ID), nameof(TblEmployee.PkempId))]
    [MapProperty(nameof(EmployeeDto.Name), nameof(TblEmployee.EmpName))]
    [MapProperty(nameof(EmployeeDto.DeptID), nameof(TblEmployee.FkdeptId))]
    [MapperIgnoreSource(nameof(EmployeeDto.Department))]
    [MapperIgnoreTarget(nameof(TblEmployee.Fkdept))]
    public partial TblEmployee ToTblEmployee(EmployeeDto dto);


    [MapProperty(nameof(TblEmployee.PkempId), nameof(EmployeeDto.ID))]
    [MapProperty(nameof(TblEmployee.EmpName), nameof(EmployeeDto.Name))]
    [MapProperty(nameof(TblEmployee.FkdeptId), nameof(EmployeeDto.DeptID))]
    [MapProperty(nameof(TblEmployee.Fkdept), nameof(EmployeeDto.Department))]
    public partial EmployeeDto ToEmployeeDto(TblEmployee tbl);
}

