using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/vpScenario")]
    public partial class VPScenarioController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioController() : base()
        {
        }
        public VPScenarioController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/vpScenario
        [Route("")]
        public IHttpActionResult GetVPScenarioList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenarioExtraA), lang, skip, take, asc, desc, where, extra);

                    if (vpScenarioService.Query.HasErrors)
                    {
                        return Ok(new List<VPScenarioExtraA>()
                        {
                            new VPScenarioExtraA()
                            {
                                HasErrors = vpScenarioService.Query.HasErrors,
                                ValidationResults = vpScenarioService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(vpScenarioService.GetVPScenarioExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenarioExtraB), lang, skip, take, asc, desc, where, extra);

                    if (vpScenarioService.Query.HasErrors)
                    {
                        return Ok(new List<VPScenarioExtraB>()
                        {
                            new VPScenarioExtraB()
                            {
                                HasErrors = vpScenarioService.Query.HasErrors,
                                ValidationResults = vpScenarioService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(vpScenarioService.GetVPScenarioExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), lang, skip, take, asc, desc, where, extra);

                    if (vpScenarioService.Query.HasErrors)
                    {
                        return Ok(new List<VPScenario>()
                        {
                            new VPScenario()
                            {
                                HasErrors = vpScenarioService.Query.HasErrors,
                                ValidationResults = vpScenarioService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(vpScenarioService.GetVPScenarioList().ToList());
                    }
                }
            }
        }
        // GET api/vpScenario/1
        [Route("{VPScenarioID:int}")]
        public IHttpActionResult GetVPScenarioWithID([FromUri]int VPScenarioID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), lang, 0, 1, "", "", extra);

                if (vpScenarioService.Query.Extra == "A")
                {
                    VPScenarioExtraA vpScenarioExtraA = new VPScenarioExtraA();
                    vpScenarioExtraA = vpScenarioService.GetVPScenarioExtraAWithVPScenarioID(VPScenarioID);

                    if (vpScenarioExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(vpScenarioExtraA);
                }
                else if (vpScenarioService.Query.Extra == "B")
                {
                    VPScenarioExtraB vpScenarioExtraB = new VPScenarioExtraB();
                    vpScenarioExtraB = vpScenarioService.GetVPScenarioExtraBWithVPScenarioID(VPScenarioID);

                    if (vpScenarioExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(vpScenarioExtraB);
                }
                else
                {
                    VPScenario vpScenario = new VPScenario();
                    vpScenario = vpScenarioService.GetVPScenarioWithVPScenarioID(VPScenarioID);

                    if (vpScenario == null)
                    {
                        return NotFound();
                    }

                    return Ok(vpScenario);
                }
            }
        }
        // POST api/vpScenario
        [Route("")]
        public IHttpActionResult Post([FromBody]VPScenario vpScenario, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioService.Add(vpScenario))
                {
                    return BadRequest(String.Join("|||", vpScenario.ValidationResults));
                }
                else
                {
                    vpScenario.ValidationResults = null;
                    return Created<VPScenario>(new Uri(Request.RequestUri, vpScenario.VPScenarioID.ToString()), vpScenario);
                }
            }
        }
        // PUT api/vpScenario
        [Route("")]
        public IHttpActionResult Put([FromBody]VPScenario vpScenario, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioService.Update(vpScenario))
                {
                    return BadRequest(String.Join("|||", vpScenario.ValidationResults));
                }
                else
                {
                    vpScenario.ValidationResults = null;
                    return Ok(vpScenario);
                }
            }
        }
        // DELETE api/vpScenario
        [Route("")]
        public IHttpActionResult Delete([FromBody]VPScenario vpScenario, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioService.Delete(vpScenario))
                {
                    return BadRequest(String.Join("|||", vpScenario.ValidationResults));
                }
                else
                {
                    vpScenario.ValidationResults = null;
                    return Ok(vpScenario);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
