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
    public partial class LabSheetDetailControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetDetailControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void LabSheetDetail_Controller_GetLabSheetDetailList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetDetailController labSheetDetailController = new LabSheetDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(labSheetDetailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, labSheetDetailController.DatabaseType);

                    LabSheetDetail labSheetDetailFirst = new LabSheetDetail();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(query, db, ContactID);
                        labSheetDetailFirst = (from c in db.LabSheetDetails select c).FirstOrDefault();
                        count = (from c in db.LabSheetDetails select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with LabSheetDetail info
                    IHttpActionResult jsonRet = labSheetDetailController.GetLabSheetDetailList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<LabSheetDetail>> ret = jsonRet as OkNegotiatedContentResult<List<LabSheetDetail>>;
                    Assert.AreEqual(labSheetDetailFirst.LabSheetDetailID, ret.Content[0].LabSheetDetailID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<LabSheetDetail> labSheetDetailList = new List<LabSheetDetail>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(query, db, ContactID);
                        labSheetDetailList = (from c in db.LabSheetDetails select c).OrderBy(c => c.LabSheetDetailID).Skip(0).Take(2).ToList();
                        count = (from c in db.LabSheetDetails select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with LabSheetDetail info
                        jsonRet = labSheetDetailController.GetLabSheetDetailList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<LabSheetDetail>>;
                        Assert.AreEqual(labSheetDetailList[0].LabSheetDetailID, ret.Content[0].LabSheetDetailID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with LabSheetDetail info
                           IHttpActionResult jsonRet2 = labSheetDetailController.GetLabSheetDetailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<LabSheetDetail>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<LabSheetDetail>>;
                           Assert.AreEqual(labSheetDetailList[1].LabSheetDetailID, ret2.Content[0].LabSheetDetailID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void LabSheetDetail_Controller_GetLabSheetDetailWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetDetailController labSheetDetailController = new LabSheetDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(labSheetDetailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, labSheetDetailController.DatabaseType);

                    LabSheetDetail labSheetDetailFirst = new LabSheetDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query(), db, ContactID);
                        labSheetDetailFirst = (from c in db.LabSheetDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetDetail info
                    IHttpActionResult jsonRet = labSheetDetailController.GetLabSheetDetailWithID(labSheetDetailFirst.LabSheetDetailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetDetail>;
                    LabSheetDetail labSheetDetailRet = Ret.Content;
                    Assert.AreEqual(labSheetDetailFirst.LabSheetDetailID, labSheetDetailRet.LabSheetDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = labSheetDetailController.GetLabSheetDetailWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetDetail> labSheetDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetDetail>;
                    Assert.IsNull(labSheetDetailRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void LabSheetDetail_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetDetailController labSheetDetailController = new LabSheetDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(labSheetDetailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, labSheetDetailController.DatabaseType);

                    LabSheetDetail labSheetDetailLast = new LabSheetDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(query, db, ContactID);
                        labSheetDetailLast = (from c in db.LabSheetDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetDetail info
                    IHttpActionResult jsonRet = labSheetDetailController.GetLabSheetDetailWithID(labSheetDetailLast.LabSheetDetailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetDetail>;
                    LabSheetDetail labSheetDetailRet = Ret.Content;
                    Assert.AreEqual(labSheetDetailLast.LabSheetDetailID, labSheetDetailRet.LabSheetDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because LabSheetDetailID exist
                    IHttpActionResult jsonRet2 = labSheetDetailController.Post(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetDetail> labSheetDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetDetail>;
                    Assert.IsNull(labSheetDetailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added LabSheetDetail
                    labSheetDetailRet.LabSheetDetailID = 0;
                    labSheetDetailController.Request = new System.Net.Http.HttpRequestMessage();
                    labSheetDetailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/labSheetDetail");
                    IHttpActionResult jsonRet3 = labSheetDetailController.Post(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<LabSheetDetail> labSheetDetailRet3 = jsonRet3 as CreatedNegotiatedContentResult<LabSheetDetail>;
                    Assert.IsNotNull(labSheetDetailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = labSheetDetailController.Delete(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<LabSheetDetail> labSheetDetailRet4 = jsonRet4 as OkNegotiatedContentResult<LabSheetDetail>;
                    Assert.IsNotNull(labSheetDetailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void LabSheetDetail_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetDetailController labSheetDetailController = new LabSheetDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(labSheetDetailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, labSheetDetailController.DatabaseType);

                    LabSheetDetail labSheetDetailLast = new LabSheetDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(query, db, ContactID);
                        labSheetDetailLast = (from c in db.LabSheetDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetDetail info
                    IHttpActionResult jsonRet = labSheetDetailController.GetLabSheetDetailWithID(labSheetDetailLast.LabSheetDetailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetDetail>;
                    LabSheetDetail labSheetDetailRet = Ret.Content;
                    Assert.AreEqual(labSheetDetailLast.LabSheetDetailID, labSheetDetailRet.LabSheetDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = labSheetDetailController.Put(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetDetail> labSheetDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetDetail>;
                    Assert.IsNotNull(labSheetDetailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because LabSheetDetailID of 0 does not exist
                    labSheetDetailRet.LabSheetDetailID = 0;
                    IHttpActionResult jsonRet3 = labSheetDetailController.Put(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<LabSheetDetail> labSheetDetailRet3 = jsonRet3 as OkNegotiatedContentResult<LabSheetDetail>;
                    Assert.IsNull(labSheetDetailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void LabSheetDetail_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetDetailController labSheetDetailController = new LabSheetDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(labSheetDetailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, labSheetDetailController.DatabaseType);

                    LabSheetDetail labSheetDetailLast = new LabSheetDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(query, db, ContactID);
                        labSheetDetailLast = (from c in db.LabSheetDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetDetail info
                    IHttpActionResult jsonRet = labSheetDetailController.GetLabSheetDetailWithID(labSheetDetailLast.LabSheetDetailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetDetail>;
                    LabSheetDetail labSheetDetailRet = Ret.Content;
                    Assert.AreEqual(labSheetDetailLast.LabSheetDetailID, labSheetDetailRet.LabSheetDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added LabSheetDetail
                    labSheetDetailRet.LabSheetDetailID = 0;
                    labSheetDetailController.Request = new System.Net.Http.HttpRequestMessage();
                    labSheetDetailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/labSheetDetail");
                    IHttpActionResult jsonRet3 = labSheetDetailController.Post(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<LabSheetDetail> labSheetDetailRet3 = jsonRet3 as CreatedNegotiatedContentResult<LabSheetDetail>;
                    Assert.IsNotNull(labSheetDetailRet3);
                    LabSheetDetail labSheetDetail = labSheetDetailRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = labSheetDetailController.Delete(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetDetail> labSheetDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetDetail>;
                    Assert.IsNotNull(labSheetDetailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because LabSheetDetailID of 0 does not exist
                    labSheetDetailRet.LabSheetDetailID = 0;
                    IHttpActionResult jsonRet4 = labSheetDetailController.Delete(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<LabSheetDetail> labSheetDetailRet4 = jsonRet4 as OkNegotiatedContentResult<LabSheetDetail>;
                    Assert.IsNull(labSheetDetailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
