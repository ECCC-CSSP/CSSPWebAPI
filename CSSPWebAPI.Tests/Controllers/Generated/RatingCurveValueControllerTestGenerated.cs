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
    public partial class RatingCurveValueControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RatingCurveValueControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void RatingCurveValue_Controller_GetRatingCurveValueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveValueController ratingCurveValueController = new RatingCurveValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(ratingCurveValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, ratingCurveValueController.DatabaseType);

                    RatingCurveValue ratingCurveValueFirst = new RatingCurveValue();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(query, db, ContactID);
                        ratingCurveValueFirst = (from c in db.RatingCurveValues select c).FirstOrDefault();
                        count = (from c in db.RatingCurveValues select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with RatingCurveValue info
                    IHttpActionResult jsonRet = ratingCurveValueController.GetRatingCurveValueList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<RatingCurveValue>> ret = jsonRet as OkNegotiatedContentResult<List<RatingCurveValue>>;
                    Assert.AreEqual(ratingCurveValueFirst.RatingCurveValueID, ret.Content[0].RatingCurveValueID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(query, db, ContactID);
                        ratingCurveValueList = (from c in db.RatingCurveValues select c).OrderBy(c => c.RatingCurveValueID).Skip(0).Take(2).ToList();
                        count = (from c in db.RatingCurveValues select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with RatingCurveValue info
                        jsonRet = ratingCurveValueController.GetRatingCurveValueList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<RatingCurveValue>>;
                        Assert.AreEqual(ratingCurveValueList[0].RatingCurveValueID, ret.Content[0].RatingCurveValueID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with RatingCurveValue info
                           IHttpActionResult jsonRet2 = ratingCurveValueController.GetRatingCurveValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<RatingCurveValue>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<RatingCurveValue>>;
                           Assert.AreEqual(ratingCurveValueList[1].RatingCurveValueID, ret2.Content[0].RatingCurveValueID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void RatingCurveValue_Controller_GetRatingCurveValueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveValueController ratingCurveValueController = new RatingCurveValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(ratingCurveValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, ratingCurveValueController.DatabaseType);

                    RatingCurveValue ratingCurveValueFirst = new RatingCurveValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query(), db, ContactID);
                        ratingCurveValueFirst = (from c in db.RatingCurveValues select c).FirstOrDefault();
                    }

                    // ok with RatingCurveValue info
                    IHttpActionResult jsonRet = ratingCurveValueController.GetRatingCurveValueWithID(ratingCurveValueFirst.RatingCurveValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurveValue> Ret = jsonRet as OkNegotiatedContentResult<RatingCurveValue>;
                    RatingCurveValue ratingCurveValueRet = Ret.Content;
                    Assert.AreEqual(ratingCurveValueFirst.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = ratingCurveValueController.GetRatingCurveValueWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.IsNull(ratingCurveValueRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void RatingCurveValue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveValueController ratingCurveValueController = new RatingCurveValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(ratingCurveValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, ratingCurveValueController.DatabaseType);

                    RatingCurveValue ratingCurveValueLast = new RatingCurveValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(query, db, ContactID);
                        ratingCurveValueLast = (from c in db.RatingCurveValues select c).FirstOrDefault();
                    }

                    // ok with RatingCurveValue info
                    IHttpActionResult jsonRet = ratingCurveValueController.GetRatingCurveValueWithID(ratingCurveValueLast.RatingCurveValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurveValue> Ret = jsonRet as OkNegotiatedContentResult<RatingCurveValue>;
                    RatingCurveValue ratingCurveValueRet = Ret.Content;
                    Assert.AreEqual(ratingCurveValueLast.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because RatingCurveValueID exist
                    IHttpActionResult jsonRet2 = ratingCurveValueController.Post(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.IsNull(ratingCurveValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added RatingCurveValue
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    ratingCurveValueController.Request = new System.Net.Http.HttpRequestMessage();
                    ratingCurveValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/ratingCurveValue");
                    IHttpActionResult jsonRet3 = ratingCurveValueController.Post(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<RatingCurveValue>;
                    Assert.IsNotNull(ratingCurveValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = ratingCurveValueController.Delete(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet4 = jsonRet4 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.IsNotNull(ratingCurveValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void RatingCurveValue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveValueController ratingCurveValueController = new RatingCurveValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(ratingCurveValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, ratingCurveValueController.DatabaseType);

                    RatingCurveValue ratingCurveValueLast = new RatingCurveValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(query, db, ContactID);
                        ratingCurveValueLast = (from c in db.RatingCurveValues select c).FirstOrDefault();
                    }

                    // ok with RatingCurveValue info
                    IHttpActionResult jsonRet = ratingCurveValueController.GetRatingCurveValueWithID(ratingCurveValueLast.RatingCurveValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurveValue> Ret = jsonRet as OkNegotiatedContentResult<RatingCurveValue>;
                    RatingCurveValue ratingCurveValueRet = Ret.Content;
                    Assert.AreEqual(ratingCurveValueLast.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = ratingCurveValueController.Put(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.IsNotNull(ratingCurveValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because RatingCurveValueID of 0 does not exist
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    IHttpActionResult jsonRet3 = ratingCurveValueController.Put(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet3 = jsonRet3 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.IsNull(ratingCurveValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void RatingCurveValue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveValueController ratingCurveValueController = new RatingCurveValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(ratingCurveValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, ratingCurveValueController.DatabaseType);

                    RatingCurveValue ratingCurveValueLast = new RatingCurveValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(query, db, ContactID);
                        ratingCurveValueLast = (from c in db.RatingCurveValues select c).FirstOrDefault();
                    }

                    // ok with RatingCurveValue info
                    IHttpActionResult jsonRet = ratingCurveValueController.GetRatingCurveValueWithID(ratingCurveValueLast.RatingCurveValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurveValue> Ret = jsonRet as OkNegotiatedContentResult<RatingCurveValue>;
                    RatingCurveValue ratingCurveValueRet = Ret.Content;
                    Assert.AreEqual(ratingCurveValueLast.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added RatingCurveValue
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    ratingCurveValueController.Request = new System.Net.Http.HttpRequestMessage();
                    ratingCurveValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/ratingCurveValue");
                    IHttpActionResult jsonRet3 = ratingCurveValueController.Post(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<RatingCurveValue>;
                    Assert.IsNotNull(ratingCurveValueRet3);
                    RatingCurveValue ratingCurveValue = ratingCurveValueRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = ratingCurveValueController.Delete(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.IsNotNull(ratingCurveValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because RatingCurveValueID of 0 does not exist
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    IHttpActionResult jsonRet4 = ratingCurveValueController.Delete(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet4 = jsonRet4 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.IsNull(ratingCurveValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
