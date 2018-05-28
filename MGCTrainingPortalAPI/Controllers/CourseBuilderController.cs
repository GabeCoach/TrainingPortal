using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MGCTrainingPortalAPI.CourseBuilder;

namespace MGCTrainingPortalAPI.Controllers
{
    [Authorize]
    public class CourseBuilderController : ApiController
    {

        private CourseMaterialBuilder oCourseMaterialBuilder = new CourseMaterialBuilder();

        // GET: api/CourseBuilder
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CourseBuilder/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CourseBuilder
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CourseBuilder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CourseBuilder/5
        public void Delete(int id)
        {
        }


        //[Route("api/CourseBuilder/FullCourseMaterial/{iTrainingCourseId}")]
        //public async Task<IHttpActionResult> GetFullCourseMaterial(int iTrainingCourseId)
        //{
        //    try
        //    {
        //        FullTrainingCourse fullTrainingCourse = await oCourseMaterialBuilder.GetFullTrainingCourse(iTrainingCourseId);
        //        return Json(fullTrainingCourse);
        //    }
        //    catch(Exception ex)
        //    {
        //        return Json(ex);
        //    }
        //}
    }
}
