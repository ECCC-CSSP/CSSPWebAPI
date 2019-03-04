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
    public partial class MWQMSampleControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void MWQMSample_Controller_GetMWQMSampleList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleController mwqmSampleController = new MWQMSampleController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSampleController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleController.DatabaseType);

                    MWQMSample mwqmSampleFirst = new MWQMSample();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(query, db, ContactID);
                        mwqmSampleFirst = (from c in db.MWQMSamples select c).FirstOrDefault();
                        count = (from c in db.MWQMSamples select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSample info
                    IHttpActionResult jsonRet = mwqmSampleController.GetMWQMSampleList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMSample>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMSample>>;
                    Assert.AreEqual(mwqmSampleFirst.MWQMSampleID, ret.Content[0].MWQMSampleID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(query, db, ContactID);
                        mwqmSampleList = (from c in db.MWQMSamples select c).OrderBy(c => c.MWQMSampleID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSamples select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSample info
                        jsonRet = mwqmSampleController.GetMWQMSampleList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMSample>>;
                        Assert.AreEqual(mwqmSampleList[0].MWQMSampleID, ret.Content[0].MWQMSampleID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSample info
                           IHttpActionResult jsonRet2 = mwqmSampleController.GetMWQMSampleList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMSample>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMSample>>;
                           Assert.AreEqual(mwqmSampleList[1].MWQMSampleID, ret2.Content[0].MWQMSampleID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MWQMSample_Controller_GetMWQMSampleWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleController mwqmSampleController = new MWQMSampleController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSampleController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleController.DatabaseType);

                    MWQMSample mwqmSampleFirst = new MWQMSample();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query(), db, ContactID);
                        mwqmSampleFirst = (from c in db.MWQMSamples select c).FirstOrDefault();
                    }

                    // ok with MWQMSample info
                    IHttpActionResult jsonRet = mwqmSampleController.GetMWQMSampleWithID(mwqmSampleFirst.MWQMSampleID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSample> Ret = jsonRet as OkNegotiatedContentResult<MWQMSample>;
                    MWQMSample mwqmSampleRet = Ret.Content;
                    Assert.AreEqual(mwqmSampleFirst.MWQMSampleID, mwqmSampleRet.MWQMSampleID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mwqmSampleController.GetMWQMSampleWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSample> mwqmSampleRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSample>;
                    Assert.IsNull(mwqmSampleRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MWQMSample_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleController mwqmSampleController = new MWQMSampleController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSampleController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleController.DatabaseType);

                    MWQMSample mwqmSampleLast = new MWQMSample();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSampleService mwqmSampleService = new MWQMSampleService(query, db, ContactID);
                        mwqmSampleLast = (from c in db.MWQMSamples select c).FirstOrDefault();
                    }

                    // ok with MWQMSample info
                    IHttpActionResult jsonRet = mwqmSampleController.GetMWQMSampleWithID(mwqmSampleLast.MWQMSampleID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSample> Ret = jsonRet as OkNegotiatedContentResult<MWQMSample>;
                    MWQMSample mwqmSampleRet = Ret.Content;
                    Assert.AreEqual(mwqmSampleLast.MWQMSampleID, mwqmSampleRet.MWQMSampleID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MWQMSampleID exist
                    IHttpActionResult jsonRet2 = mwqmSampleController.Post(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSample> mwqmSampleRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSample>;
                    Assert.IsNull(mwqmSampleRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MWQMSample
                    mwqmSampleRet.MWQMSampleID = 0;
                    mwqmSampleController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSampleController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSample");
                    IHttpActionResult jsonRet3 = mwqmSampleController.Post(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSample> mwqmSampleRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSample>;
                    Assert.IsNotNull(mwqmSampleRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mwqmSampleController.Delete(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSample> mwqmSampleRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSample>;
                    Assert.IsNotNull(mwqmSampleRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MWQMSample_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleController mwqmSampleController = new MWQMSampleController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSampleController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleController.DatabaseType);

                    MWQMSample mwqmSampleLast = new MWQMSample();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSampleService mwqmSampleService = new MWQMSampleService(query, db, ContactID);
                        mwqmSampleLast = (from c in db.MWQMSamples select c).FirstOrDefault();
                    }

                    // ok with MWQMSample info
                    IHttpActionResult jsonRet = mwqmSampleController.GetMWQMSampleWithID(mwqmSampleLast.MWQMSampleID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSample> Ret = jsonRet as OkNegotiatedContentResult<MWQMSample>;
                    MWQMSample mwqmSampleRet = Ret.Content;
                    Assert.AreEqual(mwqmSampleLast.MWQMSampleID, mwqmSampleRet.MWQMSampleID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mwqmSampleController.Put(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSample> mwqmSampleRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSample>;
                    Assert.IsNotNull(mwqmSampleRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MWQMSampleID of 0 does not exist
                    mwqmSampleRet.MWQMSampleID = 0;
                    IHttpActionResult jsonRet3 = mwqmSampleController.Put(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMSample> mwqmSampleRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMSample>;
                    Assert.IsNull(mwqmSampleRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MWQMSample_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleController mwqmSampleController = new MWQMSampleController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSampleController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleController.DatabaseType);

                    MWQMSample mwqmSampleLast = new MWQMSample();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSampleService mwqmSampleService = new MWQMSampleService(query, db, ContactID);
                        mwqmSampleLast = (from c in db.MWQMSamples select c).FirstOrDefault();
                    }

                    // ok with MWQMSample info
                    IHttpActionResult jsonRet = mwqmSampleController.GetMWQMSampleWithID(mwqmSampleLast.MWQMSampleID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSample> Ret = jsonRet as OkNegotiatedContentResult<MWQMSample>;
                    MWQMSample mwqmSampleRet = Ret.Content;
                    Assert.AreEqual(mwqmSampleLast.MWQMSampleID, mwqmSampleRet.MWQMSampleID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MWQMSample
                    mwqmSampleRet.MWQMSampleID = 0;
                    mwqmSampleController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSampleController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSample");
                    IHttpActionResult jsonRet3 = mwqmSampleController.Post(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSample> mwqmSampleRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSample>;
                    Assert.IsNotNull(mwqmSampleRet3);
                    MWQMSample mwqmSample = mwqmSampleRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mwqmSampleController.Delete(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSample> mwqmSampleRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSample>;
                    Assert.IsNotNull(mwqmSampleRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MWQMSampleID of 0 does not exist
                    mwqmSampleRet.MWQMSampleID = 0;
                    IHttpActionResult jsonRet4 = mwqmSampleController.Delete(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSample> mwqmSampleRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSample>;
                    Assert.IsNull(mwqmSampleRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
