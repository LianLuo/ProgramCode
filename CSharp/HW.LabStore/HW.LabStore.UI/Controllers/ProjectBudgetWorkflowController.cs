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
    }
}