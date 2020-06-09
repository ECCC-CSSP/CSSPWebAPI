using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/testDBContext")]
    public partial class TestDBContextController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TestDBContextController() : base()
        {
        }
        public TestDBContextController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/testDBContext
        [Route("")]
        public IHttpActionResult GetTestDBContextList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TestDBContextService testDBContextService = new TestDBContextService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   testDBContextService.Query = testDBContextService.FillQuery(typeof(TestDBContext), lang, skip, take, asc, desc, where, extra);

                    if (testDBContextService.Query.HasErrors)
                    {
                        return Ok(new List<TestDBContext>()
                        {
                            new TestDBContext()
                            {
                                HasErrors = testDBContextService.Query.HasErrors,
                                ValidationResults = testDBContextService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(testDBContextService.GetTestDBContextList().ToList());
                    }
                }
            }
        }
        // GET api/testDBContext/1
        [Route("{TestDBContextID:int}")]
        public IHttpActionResult GetTestDBContextWithID([FromUri]int TestDBContextID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TestDBContextService testDBContextService = new TestDBContextService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                testDBContextService.Query = testDBContextService.FillQuery(typeof(TestDBContext), lang, 0, 1, "", "", extra);

                else
                {
                    TestDBContext testDBContext = new TestDBContext();
                    testDBContext = testDBContextService.GetTestDBContextWithTestDBContextID(TestDBContextID);

                    if (testDBContext == null)
                    {
                        return NotFound();
                    }

                    return Ok(testDBContext);
                }
            }
        }
        // POST api/testDBContext
        [Route("")]
        public IHttpActionResult Post([FromBody]TestDBContext testDBContext, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TestDBContextService testDBContextService = new TestDBContextService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!testDBContextService.Add(testDBContext))
                {
                    return BadRequest(String.Join("|||", testDBContext.ValidationResults));
                }
                else
                {
                    testDBContext.ValidationResults = null;
                    return Created<TestDBContext>(new Uri(Request.RequestUri, testDBContext.TestDBContextID.ToString()), testDBContext);
                }
            }
        }
        // PUT api/testDBContext
        [Route("")]
        public IHttpActionResult Put([FromBody]TestDBContext testDBContext, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TestDBContextService testDBContextService = new TestDBContextService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!testDBContextService.Update(testDBContext))
                {
                    return BadRequest(String.Join("|||", testDBContext.ValidationResults));
                }
                else
                {
                    testDBContext.ValidationResults = null;
                    return Ok(testDBContext);
                }
            }
        }
        // DELETE api/testDBContext
        [Route("")]
        public IHttpActionResult Delete([FromBody]TestDBContext testDBContext, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TestDBContextService testDBContextService = new TestDBContextService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!testDBContextService.Delete(testDBContext))
                {
                    return BadRequest(String.Join("|||", testDBContext.ValidationResults));
                }
                else
                {
                    testDBContext.ValidationResults = null;
                    return Ok(testDBContext);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
