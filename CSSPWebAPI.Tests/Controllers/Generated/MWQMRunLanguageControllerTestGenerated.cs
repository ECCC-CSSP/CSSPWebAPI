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
    public partial class MWQMRunLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void MWQMRunLanguage_Controller_GetMWQMRunLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunLanguageController mwqmRunLanguageController = new MWQMRunLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmRunLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmRunLanguageController.DatabaseType);

                    MWQMRunLanguage mwqmRunLanguageFirst = new MWQMRunLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(query, db, ContactID);
                        mwqmRunLanguageFirst = (from c in db.MWQMRunLanguages select c).FirstOrDefault();
                        count = (from c in db.MWQMRunLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMRunLanguage info
                    IHttpActionResult jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMRunLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMRunLanguage>>;
                    Assert.AreEqual(mwqmRunLanguageFirst.MWQMRunLanguageID, ret.Content[0].MWQMRunLanguageID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(query, db, ContactID);
                        mwqmRunLanguageList = (from c in db.MWQMRunLanguages select c).OrderBy(c => c.MWQMRunLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMRunLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMRunLanguage info
                        jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMRunLanguage>>;
                        Assert.AreEqual(mwqmRunLanguageList[0].MWQMRunLanguageID, ret.Content[0].MWQMRunLanguageID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMRunLanguage info
                           IHttpActionResult jsonRet2 = mwqmRunLanguageController.GetMWQMRunLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMRunLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMRunLanguage>>;
                           Assert.AreEqual(mwqmRunLanguageList[1].MWQMRunLanguageID, ret2.Content[0].MWQMRunLanguageID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MWQMRunLanguage_Controller_GetMWQMRunLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunLanguageController mwqmRunLanguageController = new MWQMRunLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmRunLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmRunLanguageController.DatabaseType);

                    MWQMRunLanguage mwqmRunLanguageFirst = new MWQMRunLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query(), db, ContactID);
                        mwqmRunLanguageFirst = (from c in db.MWQMRunLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMRunLanguage info
                    IHttpActionResult jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageWithID(mwqmRunLanguageFirst.MWQMRunLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRunLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMRunLanguage>;
                    MWQMRunLanguage mwqmRunLanguageRet = Ret.Content;
                    Assert.AreEqual(mwqmRunLanguageFirst.MWQMRunLanguageID, mwqmRunLanguageRet.MWQMRunLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mwqmRunLanguageController.GetMWQMRunLanguageWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRunLanguage> mwqmRunLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRunLanguage>;
                    Assert.IsNull(mwqmRunLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MWQMRunLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunLanguageController mwqmRunLanguageController = new MWQMRunLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmRunLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmRunLanguageController.DatabaseType);

                    MWQMRunLanguage mwqmRunLanguageLast = new MWQMRunLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(query, db, ContactID);
                        mwqmRunLanguageLast = (from c in db.MWQMRunLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMRunLanguage info
                    IHttpActionResult jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageWithID(mwqmRunLanguageLast.MWQMRunLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRunLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMRunLanguage>;
                    MWQMRunLanguage mwqmRunLanguageRet = Ret.Content;
                    Assert.AreEqual(mwqmRunLanguageLast.MWQMRunLanguageID, mwqmRunLanguageRet.MWQMRunLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MWQMRunLanguageID exist
                    IHttpActionResult jsonRet2 = mwqmRunLanguageController.Post(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRunLanguage> mwqmRunLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRunLanguage>;
                    Assert.IsNull(mwqmRunLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MWQMRunLanguage
                    mwqmRunLanguageRet.MWQMRunLanguageID = 0;
                    mwqmRunLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmRunLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmRunLanguage");
                    IHttpActionResult jsonRet3 = mwqmRunLanguageController.Post(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMRunLanguage> mwqmRunLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMRunLanguage>;
                    Assert.IsNotNull(mwqmRunLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mwqmRunLanguageController.Delete(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMRunLanguage> mwqmRunLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMRunLanguage>;
                    Assert.IsNotNull(mwqmRunLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MWQMRunLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunLanguageController mwqmRunLanguageController = new MWQMRunLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmRunLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmRunLanguageController.DatabaseType);

                    MWQMRunLanguage mwqmRunLanguageLast = new MWQMRunLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(query, db, ContactID);
                        mwqmRunLanguageLast = (from c in db.MWQMRunLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMRunLanguage info
                    IHttpActionResult jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageWithID(mwqmRunLanguageLast.MWQMRunLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRunLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMRunLanguage>;
                    MWQMRunLanguage mwqmRunLanguageRet = Ret.Content;
                    Assert.AreEqual(mwqmRunLanguageLast.MWQMRunLanguageID, mwqmRunLanguageRet.MWQMRunLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mwqmRunLanguageController.Put(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRunLanguage> mwqmRunLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRunLanguage>;
                    Assert.IsNotNull(mwqmRunLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MWQMRunLanguageID of 0 does not exist
                    mwqmRunLanguageRet.MWQMRunLanguageID = 0;
                    IHttpActionResult jsonRet3 = mwqmRunLanguageController.Put(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMRunLanguage> mwqmRunLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMRunLanguage>;
                    Assert.IsNull(mwqmRunLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MWQMRunLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunLanguageController mwqmRunLanguageController = new MWQMRunLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmRunLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmRunLanguageController.DatabaseType);

                    MWQMRunLanguage mwqmRunLanguageLast = new MWQMRunLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(query, db, ContactID);
                        mwqmRunLanguageLast = (from c in db.MWQMRunLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMRunLanguage info
                    IHttpActionResult jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageWithID(mwqmRunLanguageLast.MWQMRunLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRunLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMRunLanguage>;
                    MWQMRunLanguage mwqmRunLanguageRet = Ret.Content;
                    Assert.AreEqual(mwqmRunLanguageLast.MWQMRunLanguageID, mwqmRunLanguageRet.MWQMRunLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MWQMRunLanguage
                    mwqmRunLanguageRet.MWQMRunLanguageID = 0;
                    mwqmRunLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmRunLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmRunLanguage");
                    IHttpActionResult jsonRet3 = mwqmRunLanguageController.Post(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMRunLanguage> mwqmRunLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMRunLanguage>;
                    Assert.IsNotNull(mwqmRunLanguageRet3);
                    MWQMRunLanguage mwqmRunLanguage = mwqmRunLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mwqmRunLanguageController.Delete(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRunLanguage> mwqmRunLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRunLanguage>;
                    Assert.IsNotNull(mwqmRunLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MWQMRunLanguageID of 0 does not exist
                    mwqmRunLanguageRet.MWQMRunLanguageID = 0;
                    IHttpActionResult jsonRet4 = mwqmRunLanguageController.Delete(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMRunLanguage> mwqmRunLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMRunLanguage>;
                    Assert.IsNull(mwqmRunLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
