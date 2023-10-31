using lab4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab4.Controllers {
    public class InsuranceAgentController : Controller {
        private InsuranceCompanyContext db;

        public InsuranceAgentController(InsuranceCompanyContext context) {
            db = context;
        }

        [ResponseCache(CacheProfileName = "ModelCache")]
        public IActionResult ShowTable() {
            var insuranceAgents = db.InsuranceAgents
                .Include(ia => ia.AgentTypeNavigation)
                .Include(ia => ia.ContractNavigation);
            return View(insuranceAgents);
        }
    }
}
