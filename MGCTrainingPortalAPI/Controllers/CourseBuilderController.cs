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
    [RoutePrefix("api/CourseBuilder")]
    public class CourseBuilderController : ApiController
    {
       private CourseMaterialBuilder oCourseBuilder = new CourseMaterialBuilder(); 

       [Route("FullCourseMaterial/{TrainingCourseId}")] 
       public async Task<IHttpActionResult> GetFullCourseMaterial(int iTrainingCourseId)
       {
            try
            {
               FullTrainingCourse oFullTrainingCourse = await oCourseBuilder.GetFullTrainingCourse(iTrainingCourseId);
               return Json(oFullTrainingCourse);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
       }
    }
}
