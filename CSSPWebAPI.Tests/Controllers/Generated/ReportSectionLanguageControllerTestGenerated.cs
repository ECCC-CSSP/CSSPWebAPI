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
    public partial class ReportSectionLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportSectionLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void ReportSectionLanguage_Controller_GetReportSectionLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionLanguageController reportSectionLanguageController = new ReportSectionLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportSectionLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportSectionLanguageController.DatabaseType);

                    ReportSectionLanguage reportSectionLanguageFirst = new ReportSectionLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(query, db, ContactID);
                        reportSectionLanguageFirst = (from c in db.ReportSectionLanguages select c).FirstOrDefault();
                        count = (from c in db.ReportSectionLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ReportSectionLanguage info
                    IHttpActionResult jsonRet = reportSectionLanguageController.GetReportSectionLanguageList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<ReportSectionLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<ReportSectionLanguage>>;
                    Assert.AreEqual(reportSectionLanguageFirst.ReportSectionLanguageID, ret.Content[0].ReportSectionLanguageID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(query, db, ContactID);
                        reportSectionLanguageList = (from c in db.ReportSectionLanguages select c).OrderBy(c => c.ReportSectionLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.ReportSectionLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ReportSectionLanguage info
                        jsonRet = reportSectionLanguageController.GetReportSectionLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ReportSectionLanguage>>;
                        Assert.AreEqual(reportSectionLanguageList[0].ReportSectionLanguageID, ret.Content[0].ReportSectionLanguageID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ReportSectionLanguage info
                           IHttpActionResult jsonRet2 = reportSectionLanguageController.GetReportSectionLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ReportSectionLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ReportSectionLanguage>>;
                           Assert.AreEqual(reportSectionLanguageList[1].ReportSectionLanguageID, ret2.Content[0].ReportSectionLanguageID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void ReportSectionLanguage_Controller_GetReportSectionLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionLanguageController reportSectionLanguageController = new ReportSectionLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportSectionLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportSectionLanguageController.DatabaseType);

                    ReportSectionLanguage reportSectionLanguageFirst = new ReportSectionLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query(), db, ContactID);
                        reportSectionLanguageFirst = (from c in db.ReportSectionLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportSectionLanguage info
                    IHttpActionResult jsonRet = reportSectionLanguageController.GetReportSectionLanguageWithID(reportSectionLanguageFirst.ReportSectionLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportSectionLanguage> Ret = jsonRet as OkNegotiatedContentResult<ReportSectionLanguage>;
                    ReportSectionLanguage reportSectionLanguageRet = Ret.Content;
                    Assert.AreEqual(reportSectionLanguageFirst.ReportSectionLanguageID, reportSectionLanguageRet.ReportSectionLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = reportSectionLanguageController.GetReportSectionLanguageWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportSectionLanguage> reportSectionLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<ReportSectionLanguage>;
                    Assert.IsNull(reportSectionLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void ReportSectionLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionLanguageController reportSectionLanguageController = new ReportSectionLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportSectionLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportSectionLanguageController.DatabaseType);

                    ReportSectionLanguage reportSectionLanguageLast = new ReportSectionLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(query, db, ContactID);
                        reportSectionLanguageLast = (from c in db.ReportSectionLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportSectionLanguage info
                    IHttpActionResult jsonRet = reportSectionLanguageController.GetReportSectionLanguageWithID(reportSectionLanguageLast.ReportSectionLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportSectionLanguage> Ret = jsonRet as OkNegotiatedContentResult<ReportSectionLanguage>;
                    ReportSectionLanguage reportSectionLanguageRet = Ret.Content;
                    Assert.AreEqual(reportSectionLanguageLast.ReportSectionLanguageID, reportSectionLanguageRet.ReportSectionLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ReportSectionLanguageID exist
                    IHttpActionResult jsonRet2 = reportSectionLanguageController.Post(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportSectionLanguage> reportSectionLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<ReportSectionLanguage>;
                    Assert.IsNull(reportSectionLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added ReportSectionLanguage
                    reportSectionLanguageRet.ReportSectionLanguageID = 0;
                    reportSectionLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    reportSectionLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/reportSectionLanguage");
                    IHttpActionResult jsonRet3 = reportSectionLanguageController.Post(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ReportSectionLanguage> reportSectionLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<ReportSectionLanguage>;
                    Assert.IsNotNull(reportSectionLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = reportSectionLanguageController.Delete(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ReportSectionLanguage> reportSectionLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<ReportSectionLanguage>;
                    Assert.IsNotNull(reportSectionLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void ReportSectionLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionLanguageController reportSectionLanguageController = new ReportSectionLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportSectionLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportSectionLanguageController.DatabaseType);

                    ReportSectionLanguage reportSectionLanguageLast = new ReportSectionLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(query, db, ContactID);
                        reportSectionLanguageLast = (from c in db.ReportSectionLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportSectionLanguage info
                    IHttpActionResult jsonRet = reportSectionLanguageController.GetReportSectionLanguageWithID(reportSectionLanguageLast.ReportSectionLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportSectionLanguage> Ret = jsonRet as OkNegotiatedContentResult<ReportSectionLanguage>;
                    ReportSectionLanguage reportSectionLanguageRet = Ret.Content;
                    Assert.AreEqual(reportSectionLanguageLast.ReportSectionLanguageID, reportSectionLanguageRet.ReportSectionLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = reportSectionLanguageController.Put(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportSectionLanguage> reportSectionLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<ReportSectionLanguage>;
                    Assert.IsNotNull(reportSectionLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ReportSectionLanguageID of 0 does not exist
                    reportSectionLanguageRet.ReportSectionLanguageID = 0;
                    IHttpActionResult jsonRet3 = reportSectionLanguageController.Put(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<ReportSectionLanguage> reportSectionLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<ReportSectionLanguage>;
                    Assert.IsNull(reportSectionLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void ReportSectionLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionLanguageController reportSectionLanguageController = new ReportSectionLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportSectionLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportSectionLanguageController.DatabaseType);

                    ReportSectionLanguage reportSectionLanguageLast = new ReportSectionLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(query, db, ContactID);
                        reportSectionLanguageLast = (from c in db.ReportSectionLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportSectionLanguage info
                    IHttpActionResult jsonRet = reportSectionLanguageController.GetReportSectionLanguageWithID(reportSectionLanguageLast.ReportSectionLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportSectionLanguage> Ret = jsonRet as OkNegotiatedContentResult<ReportSectionLanguage>;
                    ReportSectionLanguage reportSectionLanguageRet = Ret.Content;
                    Assert.AreEqual(reportSectionLanguageLast.ReportSectionLanguageID, reportSectionLanguageRet.ReportSectionLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added ReportSectionLanguage
                    reportSectionLanguageRet.ReportSectionLanguageID = 0;
                    reportSectionLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    reportSectionLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/reportSectionLanguage");
                    IHttpActionResult jsonRet3 = reportSectionLanguageController.Post(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ReportSectionLanguage> reportSectionLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<ReportSectionLanguage>;
                    Assert.IsNotNull(reportSectionLanguageRet3);
                    ReportSectionLanguage reportSectionLanguage = reportSectionLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = reportSectionLanguageController.Delete(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportSectionLanguage> reportSectionLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<ReportSectionLanguage>;
                    Assert.IsNotNull(reportSectionLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ReportSectionLanguageID of 0 does not exist
                    reportSectionLanguageRet.ReportSectionLanguageID = 0;
                    IHttpActionResult jsonRet4 = reportSectionLanguageController.Delete(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ReportSectionLanguage> reportSectionLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<ReportSectionLanguage>;
                    Assert.IsNull(reportSectionLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
