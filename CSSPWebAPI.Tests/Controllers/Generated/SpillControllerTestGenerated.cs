using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    [TestClass]
    public partial class SpillControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SpillControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void Spill_Controller_GetSpillList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillController spillController = new SpillController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(spillController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, spillController.DatabaseType);

                    Spill spillFirst = new Spill();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SpillService spillService = new SpillService(query, db, ContactID);
                        spillFirst = (from c in db.Spills select c).FirstOrDefault();
                        count = (from c in db.Spills select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Spill info
                    IHttpActionResult jsonRet = spillController.GetSpillList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<Spill>> ret = jsonRet as OkNegotiatedContentResult<List<Spill>>;
                    Assert.AreEqual(spillFirst.SpillID, ret.Content[0].SpillID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<Spill> spillList = new List<Spill>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SpillService spillService = new SpillService(query, db, ContactID);
                        spillList = (from c in db.Spills select c).OrderBy(c => c.SpillID).Skip(0).Take(2).ToList();
                        count = (from c in db.Spills select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Spill info
                        jsonRet = spillController.GetSpillList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<Spill>>;
                        Assert.AreEqual(spillList[0].SpillID, ret.Content[0].SpillID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Spill info
                           IHttpActionResult jsonRet2 = spillController.GetSpillList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<Spill>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<Spill>>;
                           Assert.AreEqual(spillList[1].SpillID, ret2.Content[0].SpillID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void Spill_Controller_GetSpillWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillController spillController = new SpillController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(spillController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, spillController.DatabaseType);

                    Spill spillFirst = new Spill();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SpillService spillService = new SpillService(new Query(), db, ContactID);
                        spillFirst = (from c in db.Spills select c).FirstOrDefault();
                    }

                    // ok with Spill info
                    IHttpActionResult jsonRet = spillController.GetSpillWithID(spillFirst.SpillID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Spill> Ret = jsonRet as OkNegotiatedContentResult<Spill>;
                    Spill spillRet = Ret.Content;
                    Assert.AreEqual(spillFirst.SpillID, spillRet.SpillID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = spillController.GetSpillWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Spill> spillRet2 = jsonRet2 as OkNegotiatedContentResult<Spill>;
                    Assert.IsNull(spillRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void Spill_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillController spillController = new SpillController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(spillController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, spillController.DatabaseType);

                    Spill spillLast = new Spill();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SpillService spillService = new SpillService(query, db, ContactID);
                        spillLast = (from c in db.Spills select c).FirstOrDefault();
                    }

                    // ok with Spill info
                    IHttpActionResult jsonRet = spillController.GetSpillWithID(spillLast.SpillID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Spill> Ret = jsonRet as OkNegotiatedContentResult<Spill>;
                    Spill spillRet = Ret.Content;
                    Assert.AreEqual(spillLast.SpillID, spillRet.SpillID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because SpillID exist
                    IHttpActionResult jsonRet2 = spillController.Post(spillRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Spill> spillRet2 = jsonRet2 as OkNegotiatedContentResult<Spill>;
                    Assert.IsNull(spillRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added Spill
                    spillRet.SpillID = 0;
                    spillController.Request = new System.Net.Http.HttpRequestMessage();
                    spillController.Request.RequestUri = new System.Uri("http://localhost:5000/api/spill");
                    IHttpActionResult jsonRet3 = spillController.Post(spillRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Spill> spillRet3 = jsonRet3 as CreatedNegotiatedContentResult<Spill>;
                    Assert.IsNotNull(spillRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = spillController.Delete(spillRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<Spill> spillRet4 = jsonRet4 as OkNegotiatedContentResult<Spill>;
                    Assert.IsNotNull(spillRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void Spill_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillController spillController = new SpillController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(spillController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, spillController.DatabaseType);

                    Spill spillLast = new Spill();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SpillService spillService = new SpillService(query, db, ContactID);
                        spillLast = (from c in db.Spills select c).FirstOrDefault();
                    }

                    // ok with Spill info
                    IHttpActionResult jsonRet = spillController.GetSpillWithID(spillLast.SpillID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Spill> Ret = jsonRet as OkNegotiatedContentResult<Spill>;
                    Spill spillRet = Ret.Content;
                    Assert.AreEqual(spillLast.SpillID, spillRet.SpillID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = spillController.Put(spillRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Spill> spillRet2 = jsonRet2 as OkNegotiatedContentResult<Spill>;
                    Assert.IsNotNull(spillRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because SpillID of 0 does not exist
                    spillRet.SpillID = 0;
                    IHttpActionResult jsonRet3 = spillController.Put(spillRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<Spill> spillRet3 = jsonRet3 as OkNegotiatedContentResult<Spill>;
                    Assert.IsNull(spillRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void Spill_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillController spillController = new SpillController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(spillController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, spillController.DatabaseType);

                    Spill spillLast = new Spill();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SpillService spillService = new SpillService(query, db, ContactID);
                        spillLast = (from c in db.Spills select c).FirstOrDefault();
                    }

                    // ok with Spill info
                    IHttpActionResult jsonRet = spillController.GetSpillWithID(spillLast.SpillID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Spill> Ret = jsonRet as OkNegotiatedContentResult<Spill>;
                    Spill spillRet = Ret.Content;
                    Assert.AreEqual(spillLast.SpillID, spillRet.SpillID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added Spill
                    spillRet.SpillID = 0;
                    spillController.Request = new System.Net.Http.HttpRequestMessage();
                    spillController.Request.RequestUri = new System.Uri("http://localhost:5000/api/spill");
                    IHttpActionResult jsonRet3 = spillController.Post(spillRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Spill> spillRet3 = jsonRet3 as CreatedNegotiatedContentResult<Spill>;
                    Assert.IsNotNull(spillRet3);
                    Spill spill = spillRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = spillController.Delete(spillRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Spill> spillRet2 = jsonRet2 as OkNegotiatedContentResult<Spill>;
                    Assert.IsNotNull(spillRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because SpillID of 0 does not exist
                    spillRet.SpillID = 0;
                    IHttpActionResult jsonRet4 = spillController.Delete(spillRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<Spill> spillRet4 = jsonRet4 as OkNegotiatedContentResult<Spill>;
                    Assert.IsNull(spillRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
