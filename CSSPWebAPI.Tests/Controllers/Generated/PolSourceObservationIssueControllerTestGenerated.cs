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
    public partial class PolSourceObservationIssueControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void PolSourceObservationIssue_Controller_GetPolSourceObservationIssueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationIssueController polSourceObservationIssueController = new PolSourceObservationIssueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceObservationIssueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationIssueController.DatabaseType);

                    PolSourceObservationIssue polSourceObservationIssueFirst = new PolSourceObservationIssue();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(query, db, ContactID);
                        polSourceObservationIssueFirst = (from c in db.PolSourceObservationIssues select c).FirstOrDefault();
                        count = (from c in db.PolSourceObservationIssues select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceObservationIssue info
                    IHttpActionResult jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<PolSourceObservationIssue>> ret = jsonRet as OkNegotiatedContentResult<List<PolSourceObservationIssue>>;
                    Assert.AreEqual(polSourceObservationIssueFirst.PolSourceObservationIssueID, ret.Content[0].PolSourceObservationIssueID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(query, db, ContactID);
                        polSourceObservationIssueList = (from c in db.PolSourceObservationIssues select c).OrderBy(c => c.PolSourceObservationIssueID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceObservationIssues select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceObservationIssue info
                        jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<PolSourceObservationIssue>>;
                        Assert.AreEqual(polSourceObservationIssueList[0].PolSourceObservationIssueID, ret.Content[0].PolSourceObservationIssueID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceObservationIssue info
                           IHttpActionResult jsonRet2 = polSourceObservationIssueController.GetPolSourceObservationIssueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<PolSourceObservationIssue>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<PolSourceObservationIssue>>;
                           Assert.AreEqual(polSourceObservationIssueList[1].PolSourceObservationIssueID, ret2.Content[0].PolSourceObservationIssueID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void PolSourceObservationIssue_Controller_GetPolSourceObservationIssueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationIssueController polSourceObservationIssueController = new PolSourceObservationIssueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceObservationIssueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationIssueController.DatabaseType);

                    PolSourceObservationIssue polSourceObservationIssueFirst = new PolSourceObservationIssue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query(), db, ContactID);
                        polSourceObservationIssueFirst = (from c in db.PolSourceObservationIssues select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservationIssue info
                    IHttpActionResult jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueWithID(polSourceObservationIssueFirst.PolSourceObservationIssueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceObservationIssue> Ret = jsonRet as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    PolSourceObservationIssue polSourceObservationIssueRet = Ret.Content;
                    Assert.AreEqual(polSourceObservationIssueFirst.PolSourceObservationIssueID, polSourceObservationIssueRet.PolSourceObservationIssueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = polSourceObservationIssueController.GetPolSourceObservationIssueWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceObservationIssue> polSourceObservationIssueRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    Assert.IsNull(polSourceObservationIssueRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void PolSourceObservationIssue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationIssueController polSourceObservationIssueController = new PolSourceObservationIssueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceObservationIssueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationIssueController.DatabaseType);

                    PolSourceObservationIssue polSourceObservationIssueLast = new PolSourceObservationIssue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(query, db, ContactID);
                        polSourceObservationIssueLast = (from c in db.PolSourceObservationIssues select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservationIssue info
                    IHttpActionResult jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueWithID(polSourceObservationIssueLast.PolSourceObservationIssueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceObservationIssue> Ret = jsonRet as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    PolSourceObservationIssue polSourceObservationIssueRet = Ret.Content;
                    Assert.AreEqual(polSourceObservationIssueLast.PolSourceObservationIssueID, polSourceObservationIssueRet.PolSourceObservationIssueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because PolSourceObservationIssueID exist
                    IHttpActionResult jsonRet2 = polSourceObservationIssueController.Post(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceObservationIssue> polSourceObservationIssueRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    Assert.IsNull(polSourceObservationIssueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added PolSourceObservationIssue
                    polSourceObservationIssueRet.PolSourceObservationIssueID = 0;
                    polSourceObservationIssueController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceObservationIssueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceObservationIssue");
                    IHttpActionResult jsonRet3 = polSourceObservationIssueController.Post(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceObservationIssue> polSourceObservationIssueRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceObservationIssue>;
                    Assert.IsNotNull(polSourceObservationIssueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = polSourceObservationIssueController.Delete(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceObservationIssue> polSourceObservationIssueRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    Assert.IsNotNull(polSourceObservationIssueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void PolSourceObservationIssue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationIssueController polSourceObservationIssueController = new PolSourceObservationIssueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceObservationIssueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationIssueController.DatabaseType);

                    PolSourceObservationIssue polSourceObservationIssueLast = new PolSourceObservationIssue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(query, db, ContactID);
                        polSourceObservationIssueLast = (from c in db.PolSourceObservationIssues select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservationIssue info
                    IHttpActionResult jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueWithID(polSourceObservationIssueLast.PolSourceObservationIssueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceObservationIssue> Ret = jsonRet as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    PolSourceObservationIssue polSourceObservationIssueRet = Ret.Content;
                    Assert.AreEqual(polSourceObservationIssueLast.PolSourceObservationIssueID, polSourceObservationIssueRet.PolSourceObservationIssueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = polSourceObservationIssueController.Put(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceObservationIssue> polSourceObservationIssueRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    Assert.IsNotNull(polSourceObservationIssueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because PolSourceObservationIssueID of 0 does not exist
                    polSourceObservationIssueRet.PolSourceObservationIssueID = 0;
                    IHttpActionResult jsonRet3 = polSourceObservationIssueController.Put(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<PolSourceObservationIssue> polSourceObservationIssueRet3 = jsonRet3 as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    Assert.IsNull(polSourceObservationIssueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void PolSourceObservationIssue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationIssueController polSourceObservationIssueController = new PolSourceObservationIssueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceObservationIssueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationIssueController.DatabaseType);

                    PolSourceObservationIssue polSourceObservationIssueLast = new PolSourceObservationIssue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(query, db, ContactID);
                        polSourceObservationIssueLast = (from c in db.PolSourceObservationIssues select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservationIssue info
                    IHttpActionResult jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueWithID(polSourceObservationIssueLast.PolSourceObservationIssueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceObservationIssue> Ret = jsonRet as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    PolSourceObservationIssue polSourceObservationIssueRet = Ret.Content;
                    Assert.AreEqual(polSourceObservationIssueLast.PolSourceObservationIssueID, polSourceObservationIssueRet.PolSourceObservationIssueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added PolSourceObservationIssue
                    polSourceObservationIssueRet.PolSourceObservationIssueID = 0;
                    polSourceObservationIssueController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceObservationIssueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceObservationIssue");
                    IHttpActionResult jsonRet3 = polSourceObservationIssueController.Post(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceObservationIssue> polSourceObservationIssueRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceObservationIssue>;
                    Assert.IsNotNull(polSourceObservationIssueRet3);
                    PolSourceObservationIssue polSourceObservationIssue = polSourceObservationIssueRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = polSourceObservationIssueController.Delete(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceObservationIssue> polSourceObservationIssueRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    Assert.IsNotNull(polSourceObservationIssueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because PolSourceObservationIssueID of 0 does not exist
                    polSourceObservationIssueRet.PolSourceObservationIssueID = 0;
                    IHttpActionResult jsonRet4 = polSourceObservationIssueController.Delete(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceObservationIssue> polSourceObservationIssueRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceObservationIssue>;
                    Assert.IsNull(polSourceObservationIssueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
