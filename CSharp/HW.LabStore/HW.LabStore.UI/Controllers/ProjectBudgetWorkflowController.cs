using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C1.Web.Mvc;
using C1.Web.Mvc.Serialization;
using HW.LabStore.Entity;

namespace HW.LabStore.UI.Controllers
{
    public class ProjectBudgetWorkflowController : Controller
    {
        // GET: ProjectBudgetWorkflow
        public ActionResult Index()
        {
            return View("SubmitForRequired");
        }

        public ActionResult SubmitForRequired()
        {
            ApprovalWorkflowModel mode = new ApprovalWorkflowModel();
            mode.IntermediateResult.PTDHeader = "PTD Active at "+DateTime.Now.ToString("dd MM yyyy");
            mode.IntermediateResult.FirstHeader = "First BL V1";
            mode.IntermediateResult.RevisedHeader = "Latest BL V2";
            mode.IntermediateResult.CostSheetHeader = "Cost Sheet";
            mode.IntermediateResult.ProposedHeader = "Proposed";
            mode.IntermediateResult.VarianceHeader = "Variance (Proposed - 1st BL)";
            mode.IntermediateResult.NetHeader = "Variance (Proposed - latest BL)";
            return View(mode);
        }

        private IEnumerable<UserModel> UserInfos
        {
            get
            {
                if (Session[CommonConstants.SessionConst.UserNameInfo] == null)
                {
                    return new List<UserModel>();
                }
                else
                {
                    return Session[CommonConstants.SessionConst.UserNameInfo] as IEnumerable<UserModel>;
                }
            }
            set { Session[CommonConstants.SessionConst.UserNameInfo] = value; }
        }

        public ActionResult FlexGrid()
        {
            if (this.UserInfos == null || !this.UserInfos.Any())
            {
                var model = GetData(20);
                UserInfos = model;
            }
            
            return View(UserInfos);
        }

        private IEnumerable<UserModel> GetData(int count)
        {
            var random = new Random();
            var data = Enumerable.Range(0, count).Select(p =>
            {
                return new UserModel()
                {
                    Age = p,
                    Birthday = DateTime.Now.ToString("dd-MMM-yyy"),
                    Email = "xxx.gmail.com",
                    Gender = p%2 == 0,
                    ID = p,
                    InTime = DateTime.Now.AddYears(-1).ToString("dd-MMM-yyy"),
                    QQ = ((int)(random.NextDouble() * 1000)).ToString(),
                    Tel = "12345678",
                    UserName = "XXOO"
                };

            });
            return data;
        }

        public ActionResult UpdateUserInfo([C1JsonRequest]CollectionViewEditRequest<UserModel> requestData)
        {
            var allData = this.UserInfos.ToList();
            return this.C1Json(CollectionViewHelper.Edit<UserModel>(requestData, item =>
            {
                string error = string.Empty;
                bool success = true;
                try
                {
                    var currentItem = allData.FirstOrDefault(p => p.ID == item.ID);
                    allData.Remove(currentItem);
                    if (currentItem != null)
                    {
                        currentItem.Age = item.Age;
                        currentItem.Birthday = item.Birthday;
                        currentItem.Email = item.Email;
                        currentItem.Gender = item.Gender;
                        currentItem.InTime = item.InTime;
                        currentItem.QQ = item.QQ;
                        currentItem.Tel = item.Tel;
                        currentItem.UserName = item.UserName;
                        allData.Add(currentItem);
                    }
                    this.UserInfos = allData;
                }
                catch (Exception e)
                {
                    error = e.Message;
                    success = false;
                }
                return new CollectionViewItemResult<UserModel>
                {
                    Error = error,
                    Success = success,
                    Data = item
                };

            },() => this.UserInfos));
        }

        public ActionResult CreateUserInfo([C1JsonRequest] CollectionViewEditRequest<UserModel> requestData)
        {
            return this.C1Json(CollectionViewHelper.Edit<UserModel>(requestData, item =>
            {
                string error = string.Empty;
                bool success = true;
                try
                {
                    item.ID = this.UserInfos.Max(p => p.ID) + 1;
                    this.UserInfos.ToList().Add(item);
                }
                catch (Exception e)
                {
                    error = e.Message;
                    success = false;
                }
                return new CollectionViewItemResult<UserModel>
                {
                    Error = error,
                    Success = success,
                    Data = item
                };
            }, () => this.UserInfos));
        }

        public ActionResult DeleteUserInfo([C1JsonRequest] CollectionViewEditRequest<UserModel> requestData)
        {
            return this.C1Json(CollectionViewHelper.Edit<UserModel>(requestData, item =>
            {
                string error = string.Empty;
                bool success = true;
                try
                {
                    var resultItem = this.UserInfos.ToList().Find(u => u.ID == item.ID);
                    this.UserInfos.ToList().Remove(resultItem);
                }
                catch (Exception e)
                {
                    error = e.Message;
                    success = false;
                }
                return new CollectionViewItemResult<UserModel>
                {
                    Error = error,
                    Success = success,
                    Data = item
                };
            }, () => this.UserInfos));
        }
    }
}