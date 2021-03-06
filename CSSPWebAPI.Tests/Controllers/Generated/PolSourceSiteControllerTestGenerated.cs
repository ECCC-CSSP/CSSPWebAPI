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
    public partial class PolSourceSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void PolSourceSite_Controller_GetPolSourceSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteController polSourceSiteController = new PolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteController.DatabaseType);

                    PolSourceSite polSourceSiteFirst = new PolSourceSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(query, db, ContactID);
                        polSourceSiteFirst = (from c in db.PolSourceSites select c).FirstOrDefault();
                        count = (from c in db.PolSourceSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceSite info
                    IHttpActionResult jsonRet = polSourceSiteController.GetPolSourceSiteList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<PolSourceSite>> ret = jsonRet as OkNegotiatedContentResult<List<PolSourceSite>>;
                    Assert.AreEqual(polSourceSiteFirst.PolSourceSiteID, ret.Content[0].PolSourceSiteID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(query, db, ContactID);
                        polSourceSiteList = (from c in db.PolSourceSites select c).OrderBy(c => c.PolSourceSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceSite info
                        jsonRet = polSourceSiteController.GetPolSourceSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<PolSourceSite>>;
                        Assert.AreEqual(polSourceSiteList[0].PolSourceSiteID, ret.Content[0].PolSourceSiteID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceSite info
                           IHttpActionResult jsonRet2 = polSourceSiteController.GetPolSourceSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<PolSourceSite>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<PolSourceSite>>;
                           Assert.AreEqual(polSourceSiteList[1].PolSourceSiteID, ret2.Content[0].PolSourceSiteID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void PolSourceSite_Controller_GetPolSourceSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteController polSourceSiteController = new PolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteController.DatabaseType);

                    PolSourceSite polSourceSiteFirst = new PolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query(), db, ContactID);
                        polSourceSiteFirst = (from c in db.PolSourceSites select c).FirstOrDefault();
                    }

                    // ok with PolSourceSite info
                    IHttpActionResult jsonRet = polSourceSiteController.GetPolSourceSiteWithID(polSourceSiteFirst.PolSourceSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSite> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSite>;
                    PolSourceSite polSourceSiteRet = Ret.Content;
                    Assert.AreEqual(polSourceSiteFirst.PolSourceSiteID, polSourceSiteRet.PolSourceSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = polSourceSiteController.GetPolSourceSiteWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSite> polSourceSiteRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSite>;
                    Assert.IsNull(polSourceSiteRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void PolSourceSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteController polSourceSiteController = new PolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteController.DatabaseType);

                    PolSourceSite polSourceSiteLast = new PolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(query, db, ContactID);
                        polSourceSiteLast = (from c in db.PolSourceSites select c).FirstOrDefault();
                    }

                    // ok with PolSourceSite info
                    IHttpActionResult jsonRet = polSourceSiteController.GetPolSourceSiteWithID(polSourceSiteLast.PolSourceSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSite> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSite>;
                    PolSourceSite polSourceSiteRet = Ret.Content;
                    Assert.AreEqual(polSourceSiteLast.PolSourceSiteID, polSourceSiteRet.PolSourceSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because PolSourceSiteID exist
                    IHttpActionResult jsonRet2 = polSourceSiteController.Post(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSite> polSourceSiteRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSite>;
                    Assert.IsNull(polSourceSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added PolSourceSite
                    polSourceSiteRet.PolSourceSiteID = 0;
                    polSourceSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceSite");
                    IHttpActionResult jsonRet3 = polSourceSiteController.Post(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceSite> polSourceSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceSite>;
                    Assert.IsNotNull(polSourceSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = polSourceSiteController.Delete(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceSite> polSourceSiteRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceSite>;
                    Assert.IsNotNull(polSourceSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void PolSourceSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteController polSourceSiteController = new PolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteController.DatabaseType);

                    PolSourceSite polSourceSiteLast = new PolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(query, db, ContactID);
                        polSourceSiteLast = (from c in db.PolSourceSites select c).FirstOrDefault();
                    }

                    // ok with PolSourceSite info
                    IHttpActionResult jsonRet = polSourceSiteController.GetPolSourceSiteWithID(polSourceSiteLast.PolSourceSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSite> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSite>;
                    PolSourceSite polSourceSiteRet = Ret.Content;
                    Assert.AreEqual(polSourceSiteLast.PolSourceSiteID, polSourceSiteRet.PolSourceSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = polSourceSiteController.Put(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSite> polSourceSiteRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSite>;
                    Assert.IsNotNull(polSourceSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because PolSourceSiteID of 0 does not exist
                    polSourceSiteRet.PolSourceSiteID = 0;
                    IHttpActionResult jsonRet3 = polSourceSiteController.Put(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<PolSourceSite> polSourceSiteRet3 = jsonRet3 as OkNegotiatedContentResult<PolSourceSite>;
                    Assert.IsNull(polSourceSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void PolSourceSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteController polSourceSiteController = new PolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteController.DatabaseType);

                    PolSourceSite polSourceSiteLast = new PolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(query, db, ContactID);
                        polSourceSiteLast = (from c in db.PolSourceSites select c).FirstOrDefault();
                    }

                    // ok with PolSourceSite info
                    IHttpActionResult jsonRet = polSourceSiteController.GetPolSourceSiteWithID(polSourceSiteLast.PolSourceSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSite> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSite>;
                    PolSourceSite polSourceSiteRet = Ret.Content;
                    Assert.AreEqual(polSourceSiteLast.PolSourceSiteID, polSourceSiteRet.PolSourceSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added PolSourceSite
                    polSourceSiteRet.PolSourceSiteID = 0;
                    polSourceSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceSite");
                    IHttpActionResult jsonRet3 = polSourceSiteController.Post(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceSite> polSourceSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceSite>;
                    Assert.IsNotNull(polSourceSiteRet3);
                    PolSourceSite polSourceSite = polSourceSiteRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = polSourceSiteController.Delete(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSite> polSourceSiteRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSite>;
                    Assert.IsNotNull(polSourceSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because PolSourceSiteID of 0 does not exist
                    polSourceSiteRet.PolSourceSiteID = 0;
                    IHttpActionResult jsonRet4 = polSourceSiteController.Delete(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceSite> polSourceSiteRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceSite>;
                    Assert.IsNull(polSourceSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
