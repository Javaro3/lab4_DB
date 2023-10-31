using lab4.Data;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class AgentTypeController : Controller {
        private InsuranceCompanyContext db;

        public AgentTypeController(InsuranceCompanyContext context) {
            db = context;
        }

        [ResponseCache(CacheProfileName = "ModelCache")]
        public IActionResult ShowTable() {
            var agentTypes = db.AgentTypes;
            return View(agentTypes);
        }
    }
}
