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
    public partial class BoxModelResultControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelResultControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void BoxModelResult_Controller_GetBoxModelResultList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelResultController boxModelResultController = new BoxModelResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(boxModelResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, boxModelResultController.DatabaseType);

                    BoxModelResult boxModelResultFirst = new BoxModelResult();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(query, db, ContactID);
                        boxModelResultFirst = (from c in db.BoxModelResults select c).FirstOrDefault();
                        count = (from c in db.BoxModelResults select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with BoxModelResult info
                    IHttpActionResult jsonRet = boxModelResultController.GetBoxModelResultList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<BoxModelResult>> ret = jsonRet as OkNegotiatedContentResult<List<BoxModelResult>>;
                    Assert.AreEqual(boxModelResultFirst.BoxModelResultID, ret.Content[0].BoxModelResultID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<BoxModelResult> boxModelResultList = new List<BoxModelResult>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(query, db, ContactID);
                        boxModelResultList = (from c in db.BoxModelResults select c).OrderBy(c => c.BoxModelResultID).Skip(0).Take(2).ToList();
                        count = (from c in db.BoxModelResults select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with BoxModelResult info
                        jsonRet = boxModelResultController.GetBoxModelResultList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<BoxModelResult>>;
                        Assert.AreEqual(boxModelResultList[0].BoxModelResultID, ret.Content[0].BoxModelResultID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with BoxModelResult info
                           IHttpActionResult jsonRet2 = boxModelResultController.GetBoxModelResultList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<BoxModelResult>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<BoxModelResult>>;
                           Assert.AreEqual(boxModelResultList[1].BoxModelResultID, ret2.Content[0].BoxModelResultID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void BoxModelResult_Controller_GetBoxModelResultWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelResultController boxModelResultController = new BoxModelResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(boxModelResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, boxModelResultController.DatabaseType);

                    BoxModelResult boxModelResultFirst = new BoxModelResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(new Query(), db, ContactID);
                        boxModelResultFirst = (from c in db.BoxModelResults select c).FirstOrDefault();
                    }

                    // ok with BoxModelResult info
                    IHttpActionResult jsonRet = boxModelResultController.GetBoxModelResultWithID(boxModelResultFirst.BoxModelResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModelResult> Ret = jsonRet as OkNegotiatedContentResult<BoxModelResult>;
                    BoxModelResult boxModelResultRet = Ret.Content;
                    Assert.AreEqual(boxModelResultFirst.BoxModelResultID, boxModelResultRet.BoxModelResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = boxModelResultController.GetBoxModelResultWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModelResult> boxModelResultRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModelResult>;
                    Assert.IsNull(boxModelResultRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void BoxModelResult_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelResultController boxModelResultController = new BoxModelResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(boxModelResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, boxModelResultController.DatabaseType);

                    BoxModelResult boxModelResultLast = new BoxModelResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelResultService boxModelResultService = new BoxModelResultService(query, db, ContactID);
                        boxModelResultLast = (from c in db.BoxModelResults select c).FirstOrDefault();
                    }

                    // ok with BoxModelResult info
                    IHttpActionResult jsonRet = boxModelResultController.GetBoxModelResultWithID(boxModelResultLast.BoxModelResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModelResult> Ret = jsonRet as OkNegotiatedContentResult<BoxModelResult>;
                    BoxModelResult boxModelResultRet = Ret.Content;
                    Assert.AreEqual(boxModelResultLast.BoxModelResultID, boxModelResultRet.BoxModelResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because BoxModelResultID exist
                    IHttpActionResult jsonRet2 = boxModelResultController.Post(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModelResult> boxModelResultRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModelResult>;
                    Assert.IsNull(boxModelResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added BoxModelResult
                    boxModelResultRet.BoxModelResultID = 0;
                    boxModelResultController.Request = new System.Net.Http.HttpRequestMessage();
                    boxModelResultController.Request.RequestUri = new System.Uri("http://localhost:5000/api/boxModelResult");
                    IHttpActionResult jsonRet3 = boxModelResultController.Post(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<BoxModelResult> boxModelResultRet3 = jsonRet3 as CreatedNegotiatedContentResult<BoxModelResult>;
                    Assert.IsNotNull(boxModelResultRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = boxModelResultController.Delete(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<BoxModelResult> boxModelResultRet4 = jsonRet4 as OkNegotiatedContentResult<BoxModelResult>;
                    Assert.IsNotNull(boxModelResultRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void BoxModelResult_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelResultController boxModelResultController = new BoxModelResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(boxModelResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, boxModelResultController.DatabaseType);

                    BoxModelResult boxModelResultLast = new BoxModelResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        BoxModelResultService boxModelResultService = new BoxModelResultService(query, db, ContactID);
                        boxModelResultLast = (from c in db.BoxModelResults select c).FirstOrDefault();
                    }

                    // ok with BoxModelResult info
                    IHttpActionResult jsonRet = boxModelResultController.GetBoxModelResultWithID(boxModelResultLast.BoxModelResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModelResult> Ret = jsonRet as OkNegotiatedContentResult<BoxModelResult>;
                    BoxModelResult boxModelResultRet = Ret.Content;
                    Assert.AreEqual(boxModelResultLast.BoxModelResultID, boxModelResultRet.BoxModelResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = boxModelResultController.Put(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModelResult> boxModelResultRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModelResult>;
                    Assert.IsNotNull(boxModelResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because BoxModelResultID of 0 does not exist
                    boxModelResultRet.BoxModelResultID = 0;
                    IHttpActionResult jsonRet3 = boxModelResultController.Put(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<BoxModelResult> boxModelResultRet3 = jsonRet3 as OkNegotiatedContentResult<BoxModelResult>;
                    Assert.IsNull(boxModelResultRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void BoxModelResult_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelResultController boxModelResultController = new BoxModelResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(boxModelResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, boxModelResultController.DatabaseType);

                    BoxModelResult boxModelResultLast = new BoxModelResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelResultService boxModelResultService = new BoxModelResultService(query, db, ContactID);
                        boxModelResultLast = (from c in db.BoxModelResults select c).FirstOrDefault();
                    }

                    // ok with BoxModelResult info
                    IHttpActionResult jsonRet = boxModelResultController.GetBoxModelResultWithID(boxModelResultLast.BoxModelResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModelResult> Ret = jsonRet as OkNegotiatedContentResult<BoxModelResult>;
                    BoxModelResult boxModelResultRet = Ret.Content;
                    Assert.AreEqual(boxModelResultLast.BoxModelResultID, boxModelResultRet.BoxModelResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added BoxModelResult
                    boxModelResultRet.BoxModelResultID = 0;
                    boxModelResultController.Request = new System.Net.Http.HttpRequestMessage();
                    boxModelResultController.Request.RequestUri = new System.Uri("http://localhost:5000/api/boxModelResult");
                    IHttpActionResult jsonRet3 = boxModelResultController.Post(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<BoxModelResult> boxModelResultRet3 = jsonRet3 as CreatedNegotiatedContentResult<BoxModelResult>;
                    Assert.IsNotNull(boxModelResultRet3);
                    BoxModelResult boxModelResult = boxModelResultRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = boxModelResultController.Delete(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModelResult> boxModelResultRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModelResult>;
                    Assert.IsNotNull(boxModelResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because BoxModelResultID of 0 does not exist
                    boxModelResultRet.BoxModelResultID = 0;
                    IHttpActionResult jsonRet4 = boxModelResultController.Delete(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<BoxModelResult> boxModelResultRet4 = jsonRet4 as OkNegotiatedContentResult<BoxModelResult>;
                    Assert.IsNull(boxModelResultRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
