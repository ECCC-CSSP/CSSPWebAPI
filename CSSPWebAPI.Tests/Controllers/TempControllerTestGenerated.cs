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
    public partial class TempControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TempControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Functions public

        [TestMethod]
        public void Address_Controller_GetAddressList()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })
                {
                    List<Address> addressList = null;

                    AddressController addressController = new AddressController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(addressController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, addressController.DatabaseType);

                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AddressService addressService = new AddressService(new Query(), db, ContactID);
                        addressList = (from c in db.Addresses select c).ToList();
                        count = addressList.Count;
                    }

                    // GetAddressList()
                    IHttpActionResult jsonRet = addressController.GetAddressList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<Address>> ret = jsonRet as OkNegotiatedContentResult<List<Address>>;
                    Assert.AreEqual(addressList[0].AddressID, ret.Content[0].AddressID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    // GetAddressList(lang)
                    string lang = query.Language.ToString();
                    jsonRet = addressController.GetAddressList(lang);
                    Assert.IsNotNull(jsonRet);

                    ret = jsonRet as OkNegotiatedContentResult<List<Address>>;
                    Assert.AreEqual(addressList[0].AddressID, ret.Content[0].AddressID);
                    Assert.AreEqual(addressList.Count, ret.Content.Count);

                    // GetAddressList(lang, skip)
                    int skip = 1;
                    jsonRet = addressController.GetAddressList(lang, skip);
                    Assert.IsNotNull(jsonRet);

                    ret = jsonRet as OkNegotiatedContentResult<List<Address>>;
                    Assert.AreEqual(addressList[1].AddressID, ret.Content[0].AddressID);
                    Assert.AreEqual(addressList.Count - 1, ret.Content.Count);

                    // GetAddressList(lang, skip, take)
                    int take = 1;
                    jsonRet = addressController.GetAddressList(lang, skip, take);
                    Assert.IsNotNull(jsonRet);

                    ret = jsonRet as OkNegotiatedContentResult<List<Address>>;
                    Assert.AreEqual(addressList[1].AddressID, ret.Content[0].AddressID);
                    Assert.AreEqual(take, ret.Content.Count);

                    // GetAddressList(lang, skip, take, order)
                    string order = "LastUpdateDate_UTC";
                    jsonRet = addressController.GetAddressList(lang, skip, take, order);
                    Assert.IsNotNull(jsonRet);

                    ret = jsonRet as OkNegotiatedContentResult<List<Address>>;
                    Assert.AreEqual(addressList.OrderBy(c => c.LastUpdateDate_UTC).Skip(1).Take(1).FirstOrDefault().AddressID, ret.Content[0].AddressID);
                    Assert.AreEqual(take, ret.Content.Count);

                    // GetAddressList(lang, skip, take, order, where)
                    string where = "AddressID,EQ,3";
                    jsonRet = addressController.GetAddressList(lang: lang, where: where);
                    Assert.IsNotNull(jsonRet);

                    ret = jsonRet as OkNegotiatedContentResult<List<Address>>;
                    Assert.AreEqual(addressList.Where(c => c.AddressID == 3).FirstOrDefault().AddressID, ret.Content[0].AddressID);
                    Assert.AreEqual(1, ret.Content.Count);

                    // GetAddressList(lang, skip, take, order, where)
                    where = "AddressID,GT,2|AddressID,LT,5";
                    jsonRet = addressController.GetAddressList(lang: lang, where: where);
                    Assert.IsNotNull(jsonRet);

                    ret = jsonRet as OkNegotiatedContentResult<List<Address>>;
                    Assert.AreEqual(addressList.Where(c => c.AddressID > 2 && c.AddressID < 5).FirstOrDefault().AddressID, ret.Content[0].AddressID);
                    Assert.AreEqual(2, ret.Content.Count);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
