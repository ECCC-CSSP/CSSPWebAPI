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
    public partial class TestDBContextControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TestDBContextControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void TestDBContext_Controller_GetTestDBContextList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TestDBContextController testDBContextController = new TestDBContextController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(testDBContextController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, testDBContextController.DatabaseType);

                    TestDBContext testDBContextFirst = new TestDBContext();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TestDBContextService testDBContextService = new TestDBContextService(query, db, ContactID);
                        testDBContextFirst = (from c in db.TestDBContexts select c).FirstOrDefault();
                        count = (from c in db.TestDBContexts select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TestDBContext info
                    IHttpActionResult jsonRet = testDBContextController.GetTestDBContextList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<TestDBContext>> ret = jsonRet as OkNegotiatedContentResult<List<TestDBContext>>;
                    Assert.AreEqual(testDBContextFirst.TestDBContextID, ret.Content[0].TestDBContextID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TestDBContext> testDBContextList = new List<TestDBContext>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TestDBContextService testDBContextService = new TestDBContextService(query, db, ContactID);
                        testDBContextList = (from c in db.TestDBContexts select c).OrderBy(c => c.TestDBContextID).Skip(0).Take(2).ToList();
                        count = (from c in db.TestDBContexts select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TestDBContext info
                        jsonRet = testDBContextController.GetTestDBContextList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TestDBContext>>;
                        Assert.AreEqual(testDBContextList[0].TestDBContextID, ret.Content[0].TestDBContextID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TestDBContext info
                           IHttpActionResult jsonRet2 = testDBContextController.GetTestDBContextList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TestDBContext>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TestDBContext>>;
                           Assert.AreEqual(testDBContextList[1].TestDBContextID, ret2.Content[0].TestDBContextID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void TestDBContext_Controller_GetTestDBContextWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TestDBContextController testDBContextController = new TestDBContextController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(testDBContextController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, testDBContextController.DatabaseType);

                    TestDBContext testDBContextFirst = new TestDBContext();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TestDBContextService testDBContextService = new TestDBContextService(new Query(), db, ContactID);
                        testDBContextFirst = (from c in db.TestDBContexts select c).FirstOrDefault();
                    }

                    // ok with TestDBContext info
                    IHttpActionResult jsonRet = testDBContextController.GetTestDBContextWithID(testDBContextFirst.TestDBContextID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TestDBContext> Ret = jsonRet as OkNegotiatedContentResult<TestDBContext>;
                    TestDBContext testDBContextRet = Ret.Content;
                    Assert.AreEqual(testDBContextFirst.TestDBContextID, testDBContextRet.TestDBContextID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = testDBContextController.GetTestDBContextWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TestDBContext> testDBContextRet2 = jsonRet2 as OkNegotiatedContentResult<TestDBContext>;
                    Assert.IsNull(testDBContextRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void TestDBContext_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TestDBContextController testDBContextController = new TestDBContextController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(testDBContextController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, testDBContextController.DatabaseType);

                    TestDBContext testDBContextLast = new TestDBContext();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TestDBContextService testDBContextService = new TestDBContextService(query, db, ContactID);
                        testDBContextLast = (from c in db.TestDBContexts select c).FirstOrDefault();
                    }

                    // ok with TestDBContext info
                    IHttpActionResult jsonRet = testDBContextController.GetTestDBContextWithID(testDBContextLast.TestDBContextID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TestDBContext> Ret = jsonRet as OkNegotiatedContentResult<TestDBContext>;
                    TestDBContext testDBContextRet = Ret.Content;
                    Assert.AreEqual(testDBContextLast.TestDBContextID, testDBContextRet.TestDBContextID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TestDBContextID exist
                    IHttpActionResult jsonRet2 = testDBContextController.Post(testDBContextRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TestDBContext> testDBContextRet2 = jsonRet2 as OkNegotiatedContentResult<TestDBContext>;
                    Assert.IsNull(testDBContextRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added TestDBContext
                    testDBContextRet.TestDBContextID = 0;
                    testDBContextController.Request = new System.Net.Http.HttpRequestMessage();
                    testDBContextController.Request.RequestUri = new System.Uri("http://localhost:5000/api/testDBContext");
                    IHttpActionResult jsonRet3 = testDBContextController.Post(testDBContextRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TestDBContext> testDBContextRet3 = jsonRet3 as CreatedNegotiatedContentResult<TestDBContext>;
                    Assert.IsNotNull(testDBContextRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = testDBContextController.Delete(testDBContextRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TestDBContext> testDBContextRet4 = jsonRet4 as OkNegotiatedContentResult<TestDBContext>;
                    Assert.IsNotNull(testDBContextRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void TestDBContext_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TestDBContextController testDBContextController = new TestDBContextController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(testDBContextController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, testDBContextController.DatabaseType);

                    TestDBContext testDBContextLast = new TestDBContext();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TestDBContextService testDBContextService = new TestDBContextService(query, db, ContactID);
                        testDBContextLast = (from c in db.TestDBContexts select c).FirstOrDefault();
                    }

                    // ok with TestDBContext info
                    IHttpActionResult jsonRet = testDBContextController.GetTestDBContextWithID(testDBContextLast.TestDBContextID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TestDBContext> Ret = jsonRet as OkNegotiatedContentResult<TestDBContext>;
                    TestDBContext testDBContextRet = Ret.Content;
                    Assert.AreEqual(testDBContextLast.TestDBContextID, testDBContextRet.TestDBContextID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = testDBContextController.Put(testDBContextRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TestDBContext> testDBContextRet2 = jsonRet2 as OkNegotiatedContentResult<TestDBContext>;
                    Assert.IsNotNull(testDBContextRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TestDBContextID of 0 does not exist
                    testDBContextRet.TestDBContextID = 0;
                    IHttpActionResult jsonRet3 = testDBContextController.Put(testDBContextRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<TestDBContext> testDBContextRet3 = jsonRet3 as OkNegotiatedContentResult<TestDBContext>;
                    Assert.IsNull(testDBContextRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void TestDBContext_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TestDBContextController testDBContextController = new TestDBContextController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(testDBContextController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, testDBContextController.DatabaseType);

                    TestDBContext testDBContextLast = new TestDBContext();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TestDBContextService testDBContextService = new TestDBContextService(query, db, ContactID);
                        testDBContextLast = (from c in db.TestDBContexts select c).FirstOrDefault();
                    }

                    // ok with TestDBContext info
                    IHttpActionResult jsonRet = testDBContextController.GetTestDBContextWithID(testDBContextLast.TestDBContextID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TestDBContext> Ret = jsonRet as OkNegotiatedContentResult<TestDBContext>;
                    TestDBContext testDBContextRet = Ret.Content;
                    Assert.AreEqual(testDBContextLast.TestDBContextID, testDBContextRet.TestDBContextID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TestDBContext
                    testDBContextRet.TestDBContextID = 0;
                    testDBContextController.Request = new System.Net.Http.HttpRequestMessage();
                    testDBContextController.Request.RequestUri = new System.Uri("http://localhost:5000/api/testDBContext");
                    IHttpActionResult jsonRet3 = testDBContextController.Post(testDBContextRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TestDBContext> testDBContextRet3 = jsonRet3 as CreatedNegotiatedContentResult<TestDBContext>;
                    Assert.IsNotNull(testDBContextRet3);
                    TestDBContext testDBContext = testDBContextRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = testDBContextController.Delete(testDBContextRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TestDBContext> testDBContextRet2 = jsonRet2 as OkNegotiatedContentResult<TestDBContext>;
                    Assert.IsNotNull(testDBContextRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TestDBContextID of 0 does not exist
                    testDBContextRet.TestDBContextID = 0;
                    IHttpActionResult jsonRet4 = testDBContextController.Delete(testDBContextRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TestDBContext> testDBContextRet4 = jsonRet4 as OkNegotiatedContentResult<TestDBContext>;
                    Assert.IsNull(testDBContextRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
