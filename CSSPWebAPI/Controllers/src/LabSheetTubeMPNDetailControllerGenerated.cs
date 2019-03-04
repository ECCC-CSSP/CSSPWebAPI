using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/labSheetTubeMPNDetail")]
    public partial class LabSheetTubeMPNDetailController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailController() : base()
        {
        }
        public LabSheetTubeMPNDetailController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/labSheetTubeMPNDetail
        [Route("")]
        public IHttpActionResult GetLabSheetTubeMPNDetailList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetailExtraA), lang, skip, take, asc, desc, where, extra);

                    if (labSheetTubeMPNDetailService.Query.HasErrors)
                    {
                        return Ok(new List<LabSheetTubeMPNDetailExtraA>()
                        {
                            new LabSheetTubeMPNDetailExtraA()
                            {
                                HasErrors = labSheetTubeMPNDetailService.Query.HasErrors,
                                ValidationResults = labSheetTubeMPNDetailService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetailExtraB), lang, skip, take, asc, desc, where, extra);

                    if (labSheetTubeMPNDetailService.Query.HasErrors)
                    {
                        return Ok(new List<LabSheetTubeMPNDetailExtraB>()
                        {
                            new LabSheetTubeMPNDetailExtraB()
                            {
                                HasErrors = labSheetTubeMPNDetailService.Query.HasErrors,
                                ValidationResults = labSheetTubeMPNDetailService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), lang, skip, take, asc, desc, where, extra);

                    if (labSheetTubeMPNDetailService.Query.HasErrors)
                    {
                        return Ok(new List<LabSheetTubeMPNDetail>()
                        {
                            new LabSheetTubeMPNDetail()
                            {
                                HasErrors = labSheetTubeMPNDetailService.Query.HasErrors,
                                ValidationResults = labSheetTubeMPNDetailService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList());
                    }
                }
            }
        }
        // GET api/labSheetTubeMPNDetail/1
        [Route("{LabSheetTubeMPNDetailID:int}")]
        public IHttpActionResult GetLabSheetTubeMPNDetailWithID([FromUri]int LabSheetTubeMPNDetailID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), lang, 0, 1, "", "", extra);

                if (labSheetTubeMPNDetailService.Query.Extra == "A")
                {
                    LabSheetTubeMPNDetailExtraA labSheetTubeMPNDetailExtraA = new LabSheetTubeMPNDetailExtraA();
                    labSheetTubeMPNDetailExtraA = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailExtraAWithLabSheetTubeMPNDetailID(LabSheetTubeMPNDetailID);

                    if (labSheetTubeMPNDetailExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(labSheetTubeMPNDetailExtraA);
                }
                else if (labSheetTubeMPNDetailService.Query.Extra == "B")
                {
                    LabSheetTubeMPNDetailExtraB labSheetTubeMPNDetailExtraB = new LabSheetTubeMPNDetailExtraB();
                    labSheetTubeMPNDetailExtraB = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailExtraBWithLabSheetTubeMPNDetailID(LabSheetTubeMPNDetailID);

                    if (labSheetTubeMPNDetailExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(labSheetTubeMPNDetailExtraB);
                }
                else
                {
                    LabSheetTubeMPNDetail labSheetTubeMPNDetail = new LabSheetTubeMPNDetail();
                    labSheetTubeMPNDetail = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(LabSheetTubeMPNDetailID);

                    if (labSheetTubeMPNDetail == null)
                    {
                        return NotFound();
                    }

                    return Ok(labSheetTubeMPNDetail);
                }
            }
        }
        // POST api/labSheetTubeMPNDetail
        [Route("")]
        public IHttpActionResult Post([FromBody]LabSheetTubeMPNDetail labSheetTubeMPNDetail, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail))
                {
                    return BadRequest(String.Join("|||", labSheetTubeMPNDetail.ValidationResults));
                }
                else
                {
                    labSheetTubeMPNDetail.ValidationResults = null;
                    return Created<LabSheetTubeMPNDetail>(new Uri(Request.RequestUri, labSheetTubeMPNDetail.LabSheetTubeMPNDetailID.ToString()), labSheetTubeMPNDetail);
                }
            }
        }
        // PUT api/labSheetTubeMPNDetail
        [Route("")]
        public IHttpActionResult Put([FromBody]LabSheetTubeMPNDetail labSheetTubeMPNDetail, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail))
                {
                    return BadRequest(String.Join("|||", labSheetTubeMPNDetail.ValidationResults));
                }
                else
                {
                    labSheetTubeMPNDetail.ValidationResults = null;
                    return Ok(labSheetTubeMPNDetail);
                }
            }
        }
        // DELETE api/labSheetTubeMPNDetail
        [Route("")]
        public IHttpActionResult Delete([FromBody]LabSheetTubeMPNDetail labSheetTubeMPNDetail, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail))
                {
                    return BadRequest(String.Join("|||", labSheetTubeMPNDetail.ValidationResults));
                }
                else
                {
                    labSheetTubeMPNDetail.ValidationResults = null;
                    return Ok(labSheetTubeMPNDetail);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
