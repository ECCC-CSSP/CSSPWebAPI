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
    public partial class MWQMSubsectorControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void MWQMSubsector_Controller_GetMWQMSubsectorList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorController mwqmSubsectorController = new MWQMSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSubsectorController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorController.DatabaseType);

                    MWQMSubsector mwqmSubsectorFirst = new MWQMSubsector();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorFirst = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                        count = (from c in db.MWQMSubsectors select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSubsector info
                    IHttpActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMSubsector>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMSubsector>>;
                    Assert.AreEqual(mwqmSubsectorFirst.MWQMSubsectorID, ret.Content[0].MWQMSubsectorID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorList = (from c in db.MWQMSubsectors select c).OrderBy(c => c.MWQMSubsectorID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSubsectors select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSubsector info
                        jsonRet = mwqmSubsectorController.GetMWQMSubsectorList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMSubsector>>;
                        Assert.AreEqual(mwqmSubsectorList[0].MWQMSubsectorID, ret.Content[0].MWQMSubsectorID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSubsector info
                           IHttpActionResult jsonRet2 = mwqmSubsectorController.GetMWQMSubsectorList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMSubsector>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMSubsector>>;
                           Assert.AreEqual(mwqmSubsectorList[1].MWQMSubsectorID, ret2.Content[0].MWQMSubsectorID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MWQMSubsector_Controller_GetMWQMSubsectorWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorController mwqmSubsectorController = new MWQMSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSubsectorController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorController.DatabaseType);

                    MWQMSubsector mwqmSubsectorFirst = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query(), db, ContactID);
                        mwqmSubsectorFirst = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IHttpActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorFirst.MWQMSubsectorID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsector> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsector>;
                    MWQMSubsector mwqmSubsectorRet = Ret.Content;
                    Assert.AreEqual(mwqmSubsectorFirst.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mwqmSubsectorController.GetMWQMSubsectorWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.IsNull(mwqmSubsectorRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MWQMSubsector_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorController mwqmSubsectorController = new MWQMSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSubsectorController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorController.DatabaseType);

                    MWQMSubsector mwqmSubsectorLast = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorLast = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IHttpActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorLast.MWQMSubsectorID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsector> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsector>;
                    MWQMSubsector mwqmSubsectorRet = Ret.Content;
                    Assert.AreEqual(mwqmSubsectorLast.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MWQMSubsectorID exist
                    IHttpActionResult jsonRet2 = mwqmSubsectorController.Post(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.IsNull(mwqmSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MWQMSubsector
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    mwqmSubsectorController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSubsectorController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSubsector");
                    IHttpActionResult jsonRet3 = mwqmSubsectorController.Post(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSubsector>;
                    Assert.IsNotNull(mwqmSubsectorRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mwqmSubsectorController.Delete(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.IsNotNull(mwqmSubsectorRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MWQMSubsector_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorController mwqmSubsectorController = new MWQMSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSubsectorController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorController.DatabaseType);

                    MWQMSubsector mwqmSubsectorLast = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorLast = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IHttpActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorLast.MWQMSubsectorID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsector> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsector>;
                    MWQMSubsector mwqmSubsectorRet = Ret.Content;
                    Assert.AreEqual(mwqmSubsectorLast.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mwqmSubsectorController.Put(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.IsNotNull(mwqmSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MWQMSubsectorID of 0 does not exist
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    IHttpActionResult jsonRet3 = mwqmSubsectorController.Put(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.IsNull(mwqmSubsectorRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MWQMSubsector_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorController mwqmSubsectorController = new MWQMSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSubsectorController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorController.DatabaseType);

                    MWQMSubsector mwqmSubsectorLast = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorLast = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IHttpActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorLast.MWQMSubsectorID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsector> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsector>;
                    MWQMSubsector mwqmSubsectorRet = Ret.Content;
                    Assert.AreEqual(mwqmSubsectorLast.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MWQMSubsector
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    mwqmSubsectorController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSubsectorController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSubsector");
                    IHttpActionResult jsonRet3 = mwqmSubsectorController.Post(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSubsector>;
                    Assert.IsNotNull(mwqmSubsectorRet3);
                    MWQMSubsector mwqmSubsector = mwqmSubsectorRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mwqmSubsectorController.Delete(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.IsNotNull(mwqmSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MWQMSubsectorID of 0 does not exist
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    IHttpActionResult jsonRet4 = mwqmSubsectorController.Delete(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.IsNull(mwqmSubsectorRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
