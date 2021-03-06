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
    public partial class MWQMSitePolSourceSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSitePolSourceSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void MWQMSitePolSourceSite_Controller_GetMWQMSitePolSourceSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSitePolSourceSiteController mwqmSitePolSourceSiteController = new MWQMSitePolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSitePolSourceSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSitePolSourceSiteController.DatabaseType);

                    MWQMSitePolSourceSite mwqmSitePolSourceSiteFirst = new MWQMSitePolSourceSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(query, db, ContactID);
                        mwqmSitePolSourceSiteFirst = (from c in db.MWQMSitePolSourceSites select c).FirstOrDefault();
                        count = (from c in db.MWQMSitePolSourceSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSitePolSourceSite info
                    IHttpActionResult jsonRet = mwqmSitePolSourceSiteController.GetMWQMSitePolSourceSiteList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMSitePolSourceSite>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMSitePolSourceSite>>;
                    Assert.AreEqual(mwqmSitePolSourceSiteFirst.MWQMSitePolSourceSiteID, ret.Content[0].MWQMSitePolSourceSiteID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteList = new List<MWQMSitePolSourceSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(query, db, ContactID);
                        mwqmSitePolSourceSiteList = (from c in db.MWQMSitePolSourceSites select c).OrderBy(c => c.MWQMSitePolSourceSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSitePolSourceSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSitePolSourceSite info
                        jsonRet = mwqmSitePolSourceSiteController.GetMWQMSitePolSourceSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMSitePolSourceSite>>;
                        Assert.AreEqual(mwqmSitePolSourceSiteList[0].MWQMSitePolSourceSiteID, ret.Content[0].MWQMSitePolSourceSiteID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSitePolSourceSite info
                           IHttpActionResult jsonRet2 = mwqmSitePolSourceSiteController.GetMWQMSitePolSourceSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMSitePolSourceSite>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMSitePolSourceSite>>;
                           Assert.AreEqual(mwqmSitePolSourceSiteList[1].MWQMSitePolSourceSiteID, ret2.Content[0].MWQMSitePolSourceSiteID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MWQMSitePolSourceSite_Controller_GetMWQMSitePolSourceSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSitePolSourceSiteController mwqmSitePolSourceSiteController = new MWQMSitePolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSitePolSourceSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSitePolSourceSiteController.DatabaseType);

                    MWQMSitePolSourceSite mwqmSitePolSourceSiteFirst = new MWQMSitePolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query(), db, ContactID);
                        mwqmSitePolSourceSiteFirst = (from c in db.MWQMSitePolSourceSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSitePolSourceSite info
                    IHttpActionResult jsonRet = mwqmSitePolSourceSiteController.GetMWQMSitePolSourceSiteWithID(mwqmSitePolSourceSiteFirst.MWQMSitePolSourceSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> Ret = jsonRet as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    MWQMSitePolSourceSite mwqmSitePolSourceSiteRet = Ret.Content;
                    Assert.AreEqual(mwqmSitePolSourceSiteFirst.MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteRet.MWQMSitePolSourceSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mwqmSitePolSourceSiteController.GetMWQMSitePolSourceSiteWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> mwqmSitePolSourceSiteRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    Assert.IsNull(mwqmSitePolSourceSiteRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MWQMSitePolSourceSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSitePolSourceSiteController mwqmSitePolSourceSiteController = new MWQMSitePolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSitePolSourceSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSitePolSourceSiteController.DatabaseType);

                    MWQMSitePolSourceSite mwqmSitePolSourceSiteLast = new MWQMSitePolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(query, db, ContactID);
                        mwqmSitePolSourceSiteLast = (from c in db.MWQMSitePolSourceSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSitePolSourceSite info
                    IHttpActionResult jsonRet = mwqmSitePolSourceSiteController.GetMWQMSitePolSourceSiteWithID(mwqmSitePolSourceSiteLast.MWQMSitePolSourceSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> Ret = jsonRet as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    MWQMSitePolSourceSite mwqmSitePolSourceSiteRet = Ret.Content;
                    Assert.AreEqual(mwqmSitePolSourceSiteLast.MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteRet.MWQMSitePolSourceSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MWQMSitePolSourceSiteID exist
                    IHttpActionResult jsonRet2 = mwqmSitePolSourceSiteController.Post(mwqmSitePolSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> mwqmSitePolSourceSiteRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    Assert.IsNull(mwqmSitePolSourceSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MWQMSitePolSourceSite
                    mwqmSitePolSourceSiteRet.MWQMSitePolSourceSiteID = 0;
                    mwqmSitePolSourceSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSitePolSourceSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSitePolSourceSite");
                    IHttpActionResult jsonRet3 = mwqmSitePolSourceSiteController.Post(mwqmSitePolSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSitePolSourceSite> mwqmSitePolSourceSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSitePolSourceSite>;
                    Assert.IsNotNull(mwqmSitePolSourceSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mwqmSitePolSourceSiteController.Delete(mwqmSitePolSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> mwqmSitePolSourceSiteRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    Assert.IsNotNull(mwqmSitePolSourceSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MWQMSitePolSourceSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSitePolSourceSiteController mwqmSitePolSourceSiteController = new MWQMSitePolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSitePolSourceSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSitePolSourceSiteController.DatabaseType);

                    MWQMSitePolSourceSite mwqmSitePolSourceSiteLast = new MWQMSitePolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(query, db, ContactID);
                        mwqmSitePolSourceSiteLast = (from c in db.MWQMSitePolSourceSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSitePolSourceSite info
                    IHttpActionResult jsonRet = mwqmSitePolSourceSiteController.GetMWQMSitePolSourceSiteWithID(mwqmSitePolSourceSiteLast.MWQMSitePolSourceSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> Ret = jsonRet as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    MWQMSitePolSourceSite mwqmSitePolSourceSiteRet = Ret.Content;
                    Assert.AreEqual(mwqmSitePolSourceSiteLast.MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteRet.MWQMSitePolSourceSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mwqmSitePolSourceSiteController.Put(mwqmSitePolSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> mwqmSitePolSourceSiteRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    Assert.IsNotNull(mwqmSitePolSourceSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MWQMSitePolSourceSiteID of 0 does not exist
                    mwqmSitePolSourceSiteRet.MWQMSitePolSourceSiteID = 0;
                    IHttpActionResult jsonRet3 = mwqmSitePolSourceSiteController.Put(mwqmSitePolSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> mwqmSitePolSourceSiteRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    Assert.IsNull(mwqmSitePolSourceSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MWQMSitePolSourceSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSitePolSourceSiteController mwqmSitePolSourceSiteController = new MWQMSitePolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSitePolSourceSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSitePolSourceSiteController.DatabaseType);

                    MWQMSitePolSourceSite mwqmSitePolSourceSiteLast = new MWQMSitePolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(query, db, ContactID);
                        mwqmSitePolSourceSiteLast = (from c in db.MWQMSitePolSourceSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSitePolSourceSite info
                    IHttpActionResult jsonRet = mwqmSitePolSourceSiteController.GetMWQMSitePolSourceSiteWithID(mwqmSitePolSourceSiteLast.MWQMSitePolSourceSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> Ret = jsonRet as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    MWQMSitePolSourceSite mwqmSitePolSourceSiteRet = Ret.Content;
                    Assert.AreEqual(mwqmSitePolSourceSiteLast.MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteRet.MWQMSitePolSourceSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MWQMSitePolSourceSite
                    mwqmSitePolSourceSiteRet.MWQMSitePolSourceSiteID = 0;
                    mwqmSitePolSourceSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSitePolSourceSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSitePolSourceSite");
                    IHttpActionResult jsonRet3 = mwqmSitePolSourceSiteController.Post(mwqmSitePolSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSitePolSourceSite> mwqmSitePolSourceSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSitePolSourceSite>;
                    Assert.IsNotNull(mwqmSitePolSourceSiteRet3);
                    MWQMSitePolSourceSite mwqmSitePolSourceSite = mwqmSitePolSourceSiteRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mwqmSitePolSourceSiteController.Delete(mwqmSitePolSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> mwqmSitePolSourceSiteRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    Assert.IsNotNull(mwqmSitePolSourceSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MWQMSitePolSourceSiteID of 0 does not exist
                    mwqmSitePolSourceSiteRet.MWQMSitePolSourceSiteID = 0;
                    IHttpActionResult jsonRet4 = mwqmSitePolSourceSiteController.Delete(mwqmSitePolSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSitePolSourceSite> mwqmSitePolSourceSiteRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSitePolSourceSite>;
                    Assert.IsNull(mwqmSitePolSourceSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
