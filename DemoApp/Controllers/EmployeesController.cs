using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Domain.Entities;
using DemoApp.Dtos;
using DemoApp.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Controllers
{
    public class EmployeesController : DemoAppBaseController
    {
        public EmployeesController(DemoAppDbContext dbContext) : base(dbContext)
        {
        }


        [HttpGet, Route("{lang}")]
        public async Task<IActionResult> GetEmployees(string lang)
        {
            try
            {
                var query = dbContext.Employees.AsQueryable();

                var projection = query
                    .Include(x => x.Department)
                    .Select(s => new EmployeeDto()
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Designation = s.Designation,
                        Department = s.Department == null ? null : new IdNameDto()
                        {
                            Id = s.Department.Id,
                            Name = s.Department.Name
                        }
                    });

                var result = await projection.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("{lang}/{id}")]
        public async Task<IActionResult> GetEmployeeById(string lang, long id)
        {
            try
            {
                var query = dbContext.Employees.Where(x => x.Id == id);
                var projection = query
                    .Include(x => x.Department)
                    .Select(s => new EmployeeDto()
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Designation = s.Designation,
                        Department = s.Department == null ? null : new IdNameDto()
                        {
                            Id = s.Department.Id,
                            Name = s.Department.Name
                        }
                    });

                var result = await projection.FirstOrDefaultAsync();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete, Route("{lang}/{id}")]
        public async Task<IActionResult> DeleteEmployeeById(string lang, long id)
        {
            try
            {
                var query = dbContext.Employees.Where(x => x.Id == id);
                var employee = await query.FirstOrDefaultAsync();
                dbContext.Remove(employee);
                await dbContext.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost, Route("{lang}")]
        public async Task<IActionResult> SaveEmployee(string lang, EmployeeDto dto)
        {
            try
            {
                if (dto == null)
                    throw new ArgumentNullException(nameof(dto));

                Employee employee;
                if (dto.Id > 0)
                {
                    employee = await dbContext.Employees
                        .Include(d => d.Department)
                        .FirstOrDefaultAsync(x => x.Id == dto.Id);

                    dbContext.Employees.Update(employee);
                }
                else
                {
                    employee = new Employee();
                    dbContext.Employees.Add(employee);
                }

                employee.FirstName = dto.FirstName;
                employee.LastName = dto.LastName;
                employee.Designation = dto.Designation;

                if (dto.Department != null)
                {
                    var department = await dbContext.TypeOf<Department>().FirstOrDefaultAsync(x => x.Id == dto.Department.Id);
                    employee.Department = department;
                    employee.DepartmentId = department.Id;
                }
                else
                {
                    employee.Department = null;
                    employee.DepartmentId = null;
                }

                await dbContext.SaveChangesAsync();
                return Ok(employee.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
