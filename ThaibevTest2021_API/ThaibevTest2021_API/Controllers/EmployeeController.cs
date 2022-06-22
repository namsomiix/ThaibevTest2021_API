using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace ThaibevTest2021_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //public static string BVR_DevConnectionString { get; } = "Data Source=c1000998\\SQL2014;Initial Catalog=Thaibev;User ID=sa;Password=Sommeow1416;Min Pool Size=10;Max Pool Size=200;Application Name=Thaibev;MultipleActiveResultSets=True;Connection Timeout=20000";
        public static string BVR_DevConnectionString { get; } = "Data Source=SLEAPRTRDEVST01.thaibev.com;Initial Catalog=ExamLMS;User ID=rtrdevteam;Password=RtRD3vte@m1;Min Pool Size=10;Max Pool Size=200;Application Name=APP_OMSAP;MultipleActiveResultSets=True;Connection Timeout=20000";

        [HttpGet]
        [Route("GetEmployeeList")]
        public IActionResult GetEmployeeList()
        {
            List<Employee> listUserRole;
            using (var conn = new SqlConnection(BVR_DevConnectionString))
            {
                //var p = new DynamicParameters();
                //p.Add("@ContactId", res.ContactId);
                listUserRole = conn.Query<Employee>("SP_91000104_GET_EMPLOYEE_LIST", commandType: CommandType.StoredProcedure).ToList();
            }
            return Ok(listUserRole);
        }

        [HttpPost]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee([FromBody] Employee data)
        {
            try
            {
                bool result = true;
                List<Employee> list;
                using (var conn = new SqlConnection(BVR_DevConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@ContactId", data.ContactId);
                    p.Add("@UpdatedBy", data.UpdatedBy);
                    list = conn.Query<Employee>("SP_91000104_DELETE_EMPLOYEE", p, commandType: CommandType.StoredProcedure).ToList();
                }
                if (result)
                {
                    return Ok(list);
                }
                else
                {
                    return BadRequest("Object is not null.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("InsertEmployee")]
        public IActionResult InsertEmployee([FromBody] Employee data)
        {
            try
            {
                bool result = true;
                List<Employee> list;
                using (var conn = new SqlConnection(BVR_DevConnectionString))
                {
                    var p = new DynamicParameters();
                    //p.Add("@ContactId", data.ContactId);
                    p.Add("@EmployeeId", data.EmployeeId);
                    p.Add("@FirstName", data.FirstName);
                    p.Add("@LastName", data.LastName);
                    p.Add("@Company", data.Company);
                    p.Add("@Address", data.Address);
                    p.Add("@Mobile", data.Mobile);
                    p.Add("@PathPicture", data.PathPicture);
                    p.Add("@UpdatedBy", data.UpdatedBy);
                    list = conn.Query<Employee>("SP_91000104_INSERT_EMPLOYEE", p, commandType: CommandType.StoredProcedure).ToList();
                }
                if (result)
                {
                    return Ok(list);
                }
                else
                {
                    return BadRequest("Object is not null.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employee data)
        {
            try
            {
                bool result = true;
                List<Employee> list;
                using (var conn = new SqlConnection(BVR_DevConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@ContactId", data.ContactId);
                    p.Add("@EmployeeId", data.EmployeeId);
                    p.Add("@FirstName", data.FirstName);
                    p.Add("@LastName", data.LastName);
                    p.Add("@Company", data.Company);
                    p.Add("@Address", data.Address);
                    p.Add("@Mobile", data.Mobile);
                    p.Add("@PathPicture", data.PathPicture);
                    p.Add("@UpdatedBy", data.UpdatedBy);
                    list = conn.Query<Employee>("SP_91000104_UPDATE_EMPLOYEE", p, commandType: CommandType.StoredProcedure).ToList();
                }
                if (result)
                {
                    return Ok(list);
                }
                else
                {
                    return BadRequest("Object is not null.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpPost]
        //[Route("InsertEmployee")]
        //public IActionResult InsertEmployee([FromBody] Employee data)
        //{
        //    try
        //    {
        //        bool result = true;
        //        List<Employee> list;
        //        using (var conn = new SqlConnection(BVR_DevConnectionString))
        //        {
        //            var p = new DynamicParameters();
        //            p.Add("@EmployeeId", data.EmployeeId);
        //            p.Add("@FirseName", data.FirseName);
        //            p.Add("@LastName", data.LastName);
        //            p.Add("@Address", data.Address);
        //            p.Add("@Mobile", data.Mobile);
        //            p.Add("@UpdatedBy", data.UpdatedBy);
        //            list = conn.Query<Employee>("SP_INSERT_EMPLOYEE", p, commandType: CommandType.StoredProcedure).ToList();
        //        }
        //        if (result)
        //        {
        //            return Ok(list);
        //        }
        //        else
        //        {
        //            return BadRequest("Object is not null.");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        //[HttpPost]
        //[Route("UpdateEmployee")]
        //public IActionResult UpdateEmployee([FromBody] Employee data)
        //{
        //    try
        //    {
        //        bool result = true;
        //        List<Employee> list;
        //        using (var conn = new SqlConnection(BVR_DevConnectionString))
        //        {
        //            var p = new DynamicParameters();
        //            p.Add("@EmployeeId", data.EmployeeId);
        //            p.Add("@FirseName", data.FirseName);
        //            p.Add("@LastName", data.LastName);
        //            p.Add("@Address", data.Address);
        //            p.Add("@Mobile", data.Mobile);
        //            p.Add("@ContactId", data.ContactId);
        //            p.Add("@UserIdUpdate", data.UpdatedBy);
        //            list = conn.Query<Employee>("SP_UPDATE_EMPLOYEE", p, commandType: CommandType.StoredProcedure).ToList();
        //        }
        //        if (result)
        //        {
        //            return Ok(list);
        //        }
        //        else
        //        {
        //            return BadRequest("Object is not null.");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("GetEmployeeATKList")]
        //public IActionResult GetEmployeeATKList()
        //{
        //    List<Employee> listUserRole;
        //    using (var conn = new SqlConnection(BVR_DevConnectionString))
        //    {
        //        listUserRole = conn.Query<Employee>("SP_GET_EMPLOYEE_ATK_LIST", commandType: CommandType.StoredProcedure).ToList();
        //    }
        //    return Ok(listUserRole);
        //}

        //[HttpGet]
        //[Route("GetEmployeeATKWaitingList")]
        //public IActionResult GetEmployeeATKWaitingList()
        //{
        //    List<Employee> listUserRole;
        //    using (var conn = new SqlConnection(BVR_DevConnectionString))
        //    {
        //        listUserRole = conn.Query<Employee>("SP_GET_EMPLOYEE_ATK_WaitingList", commandType: CommandType.StoredProcedure).ToList();
        //    }
        //    return Ok(listUserRole);
        //}

        //[HttpPost]
        //[Route("InsertEmployeeATKWaitingList")]
        //public IActionResult InsertEmployeeATKWaitingList([FromBody] EmployeeATKUpdate data)
        //{
        //    try
        //    {
        //        bool result = true;
        //        List<Employee> list;
        //        using (var conn = new SqlConnection(BVR_DevConnectionString))
        //        {
        //            var p = new DynamicParameters();
        //            p.Add("@ContactId", data.ContactId);
        //            p.Add("@UpdatedBy", data.UpdatedBy);
        //            list = conn.Query<Employee>("SP_INSERT_EMPLOYEE_ATK_WAITINGLIST", p, commandType: CommandType.StoredProcedure).ToList();
        //        }
        //        if (result)
        //        {
        //            return Ok(list);
        //        }
        //        else
        //        {
        //            return BadRequest("Object is not null.");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        //[HttpPost]
        //[Route("UpdateEmployeeATKWaitingList")]
        //public IActionResult UpdateEmployeeATKWaitingList([FromBody] EmployeeATKUpdate data)
        //{
        //    try
        //    {
        //        bool result = true;
        //        List<Employee> list;
        //        using (var conn = new SqlConnection(BVR_DevConnectionString))
        //        {
        //            var p = new DynamicParameters();
        //            p.Add("@ContactId", data.ContactId);
        //            p.Add("@UpdatedBy", data.UpdatedBy);
        //            list = conn.Query<Employee>("SP_UPDATE_EMPLOYEE_ATK_WAITINGLIST", p, commandType: CommandType.StoredProcedure).ToList();
        //        }
        //        if (result)
        //        {
        //            return Ok(list);
        //        }
        //        else
        //        {
        //            return BadRequest("Object is not null.");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
    }
}
