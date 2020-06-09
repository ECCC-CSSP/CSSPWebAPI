using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/reportType")]
    public partial class ReportTypeController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportTypeController() : base()
        {
        }
        public ReportTypeController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/reportType
        [Route("")]
        public IHttpActionResult GetReportTypeList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), lang, skip, take, asc, desc, where, extra);

                    if (reportTypeService.Query.HasErrors)
                    {
                        return Ok(new List<ReportType>()
                        {
                            new ReportType()
                            {
                                HasErrors = reportTypeService.Query.HasErrors,
                                ValidationResults = reportTypeService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(reportTypeService.GetReportTypeList().ToList());
                    }
                }
            }
        }
        // GET api/reportType/1
        [Route("{ReportTypeID:int}")]
        public IHttpActionResult GetReportTypeWithID([FromUri]int ReportTypeID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeService reportTypeService = new ReportTypeService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), lang, 0, 1, "", "", extra);

                else
                {
                    ReportType reportType = new ReportType();
                    reportType = reportTypeService.GetReportTypeWithReportTypeID(ReportTypeID);

                    if (reportType == null)
                    {
                        return NotFound();
                    }

                    return Ok(reportType);
                }
            }
        }
        // POST api/reportType
        [Route("")]
        public IHttpActionResult Post([FromBody]ReportType reportType, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeService reportTypeService = new ReportTypeService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportTypeService.Add(reportType))
                {
                    return BadRequest(String.Join("|||", reportType.ValidationResults));
                }
                else
                {
                    reportType.ValidationResults = null;
                    return Created<ReportType>(new Uri(Request.RequestUri, reportType.ReportTypeID.ToString()), reportType);
                }
            }
        }
        // PUT api/reportType
        [Route("")]
        public IHttpActionResult Put([FromBody]ReportType reportType, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeService reportTypeService = new ReportTypeService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportTypeService.Update(reportType))
                {
                    return BadRequest(String.Join("|||", reportType.ValidationResults));
                }
                else
                {
                    reportType.ValidationResults = null;
                    return Ok(reportType);
                }
            }
        }
        // DELETE api/reportType
        [Route("")]
        public IHttpActionResult Delete([FromBody]ReportType reportType, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeService reportTypeService = new ReportTypeService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportTypeService.Delete(reportType))
                {
                    return BadRequest(String.Join("|||", reportType.ValidationResults));
                }
                else
                {
                    reportType.ValidationResults = null;
                    return Ok(reportType);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
