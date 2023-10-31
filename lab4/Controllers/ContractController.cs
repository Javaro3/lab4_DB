using lab4.Data;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers {
    public class ContractController : Controller {
        private InsuranceCompanyContext db;

        public ContractController(InsuranceCompanyContext context) {
            db = context;
        }

        [ResponseCache(CacheProfileName = "ModelCache")]
        public IActionResult ShowTable() {
            var contracts = db.Contracts;
            return View(contracts);
        }
    }
}
