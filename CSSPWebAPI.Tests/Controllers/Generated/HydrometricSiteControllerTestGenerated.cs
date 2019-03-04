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
    public partial class HydrometricSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void HydrometricSite_Controller_GetHydrometricSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricSiteController hydrometricSiteController = new HydrometricSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(hydrometricSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, hydrometricSiteController.DatabaseType);

                    HydrometricSite hydrometricSiteFirst = new HydrometricSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(query, db, ContactID);
                        hydrometricSiteFirst = (from c in db.HydrometricSites select c).FirstOrDefault();
                        count = (from c in db.HydrometricSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with HydrometricSite info
                    IHttpActionResult jsonRet = hydrometricSiteController.GetHydrometricSiteList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<HydrometricSite>> ret = jsonRet as OkNegotiatedContentResult<List<HydrometricSite>>;
                    Assert.AreEqual(hydrometricSiteFirst.HydrometricSiteID, ret.Content[0].HydrometricSiteID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(query, db, ContactID);
                        hydrometricSiteList = (from c in db.HydrometricSites select c).OrderBy(c => c.HydrometricSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.HydrometricSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with HydrometricSite info
                        jsonRet = hydrometricSiteController.GetHydrometricSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<HydrometricSite>>;
                        Assert.AreEqual(hydrometricSiteList[0].HydrometricSiteID, ret.Content[0].HydrometricSiteID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with HydrometricSite info
                           IHttpActionResult jsonRet2 = hydrometricSiteController.GetHydrometricSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<HydrometricSite>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<HydrometricSite>>;
                           Assert.AreEqual(hydrometricSiteList[1].HydrometricSiteID, ret2.Content[0].HydrometricSiteID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void HydrometricSite_Controller_GetHydrometricSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricSiteController hydrometricSiteController = new HydrometricSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(hydrometricSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, hydrometricSiteController.DatabaseType);

                    HydrometricSite hydrometricSiteFirst = new HydrometricSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query(), db, ContactID);
                        hydrometricSiteFirst = (from c in db.HydrometricSites select c).FirstOrDefault();
                    }

                    // ok with HydrometricSite info
                    IHttpActionResult jsonRet = hydrometricSiteController.GetHydrometricSiteWithID(hydrometricSiteFirst.HydrometricSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<HydrometricSite> Ret = jsonRet as OkNegotiatedContentResult<HydrometricSite>;
                    HydrometricSite hydrometricSiteRet = Ret.Content;
                    Assert.AreEqual(hydrometricSiteFirst.HydrometricSiteID, hydrometricSiteRet.HydrometricSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = hydrometricSiteController.GetHydrometricSiteWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<HydrometricSite> hydrometricSiteRet2 = jsonRet2 as OkNegotiatedContentResult<HydrometricSite>;
                    Assert.IsNull(hydrometricSiteRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void HydrometricSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricSiteController hydrometricSiteController = new HydrometricSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(hydrometricSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, hydrometricSiteController.DatabaseType);

                    HydrometricSite hydrometricSiteLast = new HydrometricSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(query, db, ContactID);
                        hydrometricSiteLast = (from c in db.HydrometricSites select c).FirstOrDefault();
                    }

                    // ok with HydrometricSite info
                    IHttpActionResult jsonRet = hydrometricSiteController.GetHydrometricSiteWithID(hydrometricSiteLast.HydrometricSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<HydrometricSite> Ret = jsonRet as OkNegotiatedContentResult<HydrometricSite>;
                    HydrometricSite hydrometricSiteRet = Ret.Content;
                    Assert.AreEqual(hydrometricSiteLast.HydrometricSiteID, hydrometricSiteRet.HydrometricSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because HydrometricSiteID exist
                    IHttpActionResult jsonRet2 = hydrometricSiteController.Post(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<HydrometricSite> hydrometricSiteRet2 = jsonRet2 as OkNegotiatedContentResult<HydrometricSite>;
                    Assert.IsNull(hydrometricSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added HydrometricSite
                    hydrometricSiteRet.HydrometricSiteID = 0;
                    hydrometricSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    hydrometricSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/hydrometricSite");
                    IHttpActionResult jsonRet3 = hydrometricSiteController.Post(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<HydrometricSite> hydrometricSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<HydrometricSite>;
                    Assert.IsNotNull(hydrometricSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = hydrometricSiteController.Delete(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<HydrometricSite> hydrometricSiteRet4 = jsonRet4 as OkNegotiatedContentResult<HydrometricSite>;
                    Assert.IsNotNull(hydrometricSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void HydrometricSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricSiteController hydrometricSiteController = new HydrometricSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(hydrometricSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, hydrometricSiteController.DatabaseType);

                    HydrometricSite hydrometricSiteLast = new HydrometricSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(query, db, ContactID);
                        hydrometricSiteLast = (from c in db.HydrometricSites select c).FirstOrDefault();
                    }

                    // ok with HydrometricSite info
                    IHttpActionResult jsonRet = hydrometricSiteController.GetHydrometricSiteWithID(hydrometricSiteLast.HydrometricSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<HydrometricSite> Ret = jsonRet as OkNegotiatedContentResult<HydrometricSite>;
                    HydrometricSite hydrometricSiteRet = Ret.Content;
                    Assert.AreEqual(hydrometricSiteLast.HydrometricSiteID, hydrometricSiteRet.HydrometricSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = hydrometricSiteController.Put(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<HydrometricSite> hydrometricSiteRet2 = jsonRet2 as OkNegotiatedContentResult<HydrometricSite>;
                    Assert.IsNotNull(hydrometricSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because HydrometricSiteID of 0 does not exist
                    hydrometricSiteRet.HydrometricSiteID = 0;
                    IHttpActionResult jsonRet3 = hydrometricSiteController.Put(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<HydrometricSite> hydrometricSiteRet3 = jsonRet3 as OkNegotiatedContentResult<HydrometricSite>;
                    Assert.IsNull(hydrometricSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void HydrometricSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricSiteController hydrometricSiteController = new HydrometricSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(hydrometricSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, hydrometricSiteController.DatabaseType);

                    HydrometricSite hydrometricSiteLast = new HydrometricSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(query, db, ContactID);
                        hydrometricSiteLast = (from c in db.HydrometricSites select c).FirstOrDefault();
                    }

                    // ok with HydrometricSite info
                    IHttpActionResult jsonRet = hydrometricSiteController.GetHydrometricSiteWithID(hydrometricSiteLast.HydrometricSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<HydrometricSite> Ret = jsonRet as OkNegotiatedContentResult<HydrometricSite>;
                    HydrometricSite hydrometricSiteRet = Ret.Content;
                    Assert.AreEqual(hydrometricSiteLast.HydrometricSiteID, hydrometricSiteRet.HydrometricSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added HydrometricSite
                    hydrometricSiteRet.HydrometricSiteID = 0;
                    hydrometricSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    hydrometricSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/hydrometricSite");
                    IHttpActionResult jsonRet3 = hydrometricSiteController.Post(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<HydrometricSite> hydrometricSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<HydrometricSite>;
                    Assert.IsNotNull(hydrometricSiteRet3);
                    HydrometricSite hydrometricSite = hydrometricSiteRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = hydrometricSiteController.Delete(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<HydrometricSite> hydrometricSiteRet2 = jsonRet2 as OkNegotiatedContentResult<HydrometricSite>;
                    Assert.IsNotNull(hydrometricSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because HydrometricSiteID of 0 does not exist
                    hydrometricSiteRet.HydrometricSiteID = 0;
                    IHttpActionResult jsonRet4 = hydrometricSiteController.Delete(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<HydrometricSite> hydrometricSiteRet4 = jsonRet4 as OkNegotiatedContentResult<HydrometricSite>;
                    Assert.IsNull(hydrometricSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
