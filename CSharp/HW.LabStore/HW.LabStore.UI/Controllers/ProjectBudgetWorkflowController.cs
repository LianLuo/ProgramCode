using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult FlexGrid()
        {
            var model = GetData(20);
            return View(model);
        }

        private IEnumerable<UserModel> GetData(int count)
        {
            var random = new Random();
            var data = Enumerable.Range(0, count).Select(p =>
            {
                return new UserModel()
                {
                    Age = p,
                    Birthday = DateTime.Now,
                    Email = "xxx.gmail.com",
                    Gender = p%2 == 0,
                    ID = p,
                    InTime = DateTime.Now.AddYears(-1),
                    QQ = ((int)(random.NextDouble() * 1000)).ToString(),
                    Tel = "12345678",
                    UserName = "XXOO"
                };

            });
            return data;
        }
    }
}