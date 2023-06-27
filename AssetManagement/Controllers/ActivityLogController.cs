using AssetManagement.DBContext;
using AssetManagement.Dto;
using AssetManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ActivityLogController : ControllerBase
    {
        private readonly AMDbcontext _amdDbContext;
        public ActivityLogController(AMDbcontext dbcontext)
        {
            _amdDbContext = dbcontext;
        }


        [HttpPost]
        public ActivityLog CreateActivityLog(ActivityLog activityLog)
        {
            try
            {
                var activity = _amdDbContext.ActivityLogs.FirstOrDefault(x => x.Data == activityLog.Data);
                if (activity == null)
                {
                    activityLog.DateTime = DateTime.Now;
                    _amdDbContext.ActivityLogs.Add(activityLog);
                    _amdDbContext.SaveChanges();
                    return activity;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
